Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Dns
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic

' State object for reading client data asynchronously

Public Class StateObject
    ' Client  socket.
    Public workSocket As Socket = Nothing
    ' Size of receive buffer.
    Public Const BufferSize As Integer = 1024
    ' Receive buffer.
    Public buffer(BufferSize) As Byte
    ' Received data string.
    Public sb As New StringBuilder

End Class 'StateObject


Public NotInheritable Class AsynchronousSocketListener

    Public Shared bShutdown As Boolean

    ' Thread signal.
    Public Shared allDone As New ManualResetEvent(False)
    'Mutex
    Private Shared mut As New Mutex
    'Clients
    Public Shared clients As New List(Of StateObject)
    'Log
    Public mainThread As Thread

    Delegate Sub WriteToLogDelegate(ByVal entry As String)

    Public Sub New(ByVal strSocket As String)
        Try
            ' WriteLog("Asynchronous server socket initialized")
            mainThread = New Thread(AddressOf AsynchronousSocketListener.Main)
            mainThread.Start(strSocket)
        Catch
            WriteLog(gcstrError, "modSocketInterface.New " & Err.Description)
        End Try
    End Sub

   
    Public Shared Sub Main(ByVal socket As Object)

        ' This server waits for a connection and then uses  asychronous operations to
        ' accept the connection, get data from the connected client

        Try

            ' Data buffer for incoming data.
            Dim bytes() As Byte = New [Byte](1023) {}    '$ PROBHIDE ALL

            ' Establish the local endpoint for the socket.
            Dim ipaddress As IPAddress = Net.IPAddress.Parse(GetIPAddress)

            ' Dim ipAddress2 As IPAddress = Dns.GetHostEntry("localhost").AddressList(0)


            Dim localEndPoint As New IPEndPoint(ipaddress, CInt(socket))

            ' Create a TCP/IP socket.
            Dim listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)


            ' Bind the socket to the local endpoint and listen for incoming connections.
            listener.Bind(localEndPoint)
            listener.Listen(100)


            While True

                If bShutdown = True Then
                    'listener.LingerState = New LingerOption(False, 0)

                    listener.Close()
                    Exit While
                End If

                ' Set the event to nonsignaled state.
                allDone.Reset()

                ' Start an asynchronous socket to listen for connections.
                listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)

                ' Wait until a connection is made and processed before continuing.
                allDone.WaitOne()

            End While

            If bShutdown = True Then

                listener.Close(100)
                listener.Close()
                listener = Nothing

            End If

        Catch
            WriteLog(gcstrError, "modSocketInterface.Main " & Err.Description)
        End Try

    End Sub 'Main

    Public Shared Sub AcceptCallback(ByVal ar As IAsyncResult)
        ' Get the socket that handles the client request.
        Try
            Dim listener As Socket = DirectCast(ar.AsyncState, Socket)
            ' End the operation.
            Dim handler As Socket = listener.EndAccept(ar)

            ' Create the state object for the async receive.
            Dim state As New StateObject
            state.workSocket = handler
            state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)

            'Add the client socket to a list for easy reference: Note: Not sure if the mutex is necessary
            mut.WaitOne()
            clients.Add(state)
            mut.ReleaseMutex()

            'Signal the main thread to continue.
            allDone.Set()
        Catch
            'just abort
            WriteLog(gcstrError, "AcceptCallback " & Err.Description)
        End Try
    End Sub 'AcceptCallback
    Public Shared Sub ReceiveCallback(ByVal ar As IAsyncResult)
        Dim content As String = String.Empty
        Dim strMsgToSend As String
        Dim strMsgTextOnly As String
        Dim strMessage As String = vbNullString



        ' Retrieve the state object and the handler socket
        ' from the asynchronous state object.
        Dim state As StateObject = DirectCast(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket
        ' Read data from the client socket. 
        Dim posTerm As Integer
        On Error Resume Next

        Dim bytesRead As Integer = handler.EndReceive(ar)

        strMessage = "check bytes read "
        If bytesRead > 0 Then
            ' There  might be more data, so store the data received so far.
            strMessage = "set content "
            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))

            If gbLogRawInboundData = True Then
                'dump the buffer out
                Dim strRawData As String = String.Empty
                Dim x As Integer
                Dim y As Integer = 0
                Dim bytesperline As Integer = 16


                For x = 0 To bytesRead - 1

                    strRawData &= state.buffer(x).ToString("X2") & Space(1)

                    y += 1
                    If y = bytesperline Then
                        WriteLog(((x + 1) / bytesperline).ToString.PadLeft(5, gcCharZero), strRawData)

                        strRawData = String.Empty
                        y = 0
                    End If
                Next

                If y <> bytesperline And y <> 0 Then
                    'need to write last line

                    WriteLog(Math.Ceiling(((x + 1) / bytesperline)).ToString.PadLeft(5, gcCharZero), strRawData)
                End If
            End If

            content = state.sb.ToString()

            strMessage = "check vbcr vblf vblf  "
            posTerm = InStrRev(content, vbCr & vbLf & vbLf)
            If posTerm > 0 Then

                strMessage = "ACK "
                'RTCIS wants an "A" for ACK
                strMsgTextOnly = Trim(Left(content, posTerm))    'strip off CR,LF,LF
                WriteLog("Received", strMsgTextOnly)
                strMsgToSend = "A"

                strMessage = "send ack "
                Send(handler, strMsgToSend)             'send Ack or Nak back to client
                WriteLog("Sent WMS", strMsgToSend)

                strMessage = "processmsg "
                If Len(strMsgTextOnly) > 0 Then         'have message to decode
                    'MsgInboundDecode(strMsgTextOnly)
                    Dim instXMLReadit As New XMLReadIt
                    instXMLReadit.ParseXML(strMsgTextOnly)
                End If

                strMessage = "clear state.sb "          'clear the buffer 
                state.sb.Remove(0, state.sb.Length)

            Else
                'NAK logic goes here if implemented

            End If
            'resume receiving again
            strMessage = "handler begin receive "
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)

        End If

        Exit Sub

errorhandler:

        clients.Clear()
        WriteLog(gcstrError, "modSocketInterface.ReceiveCallback " & Err.Description & Space(1) & strMessage & bytesRead)



    End Sub 'ReceiveCallback
    Public Shared Sub ReceiveCallback_bad(ByVal ar As IAsyncResult)
        Dim content As String = String.Empty
        Dim strMsgToSend As String
        Dim strMsgTextOnly As String
        Dim strMessage As String = vbNullString



        ' Retrieve the state object and the handler socket
        ' from the asynchronous state object.
        Dim state As StateObject = DirectCast(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket
        Dim dataToRead As Integer = handler.Available
        ' Read data from the client socket. 
        'On Error Resume Next
        Try
            Dim bytesRead As Integer = handler.EndReceive(ar)


            strMessage = "check bytes read "
            If bytesRead > 0 Then
                ' There  might be more data, so store the data received so far.
                strMessage = "set content "
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))

                If gbLogRawInboundData = True Then
                    'dump the buffer out
                    Dim strRawData As String = String.Empty
                    Dim x As Integer
                    Dim y As Integer = 0
                    Dim bytesperline As Integer = 16

                    For x = 0 To bytesRead - 1

                        strRawData &= state.buffer(x).ToString("X2") & Space(1)

                        y += 1
                        If y = bytesperline Then
                            WriteLog(((x + 1) / bytesperline).ToString.PadLeft(5, gcCharZero), strRawData)

                            strRawData = String.Empty
                            y = 0
                        End If
                    Next

                    If y <> bytesperline And y <> 0 Then
                        'need to write last line

                        WriteLog(Math.Ceiling(((x + 1) / bytesperline)).ToString.PadLeft(5, gcCharZero), strRawData)
                    End If
                End If

                content = state.sb.ToString()

                strMessage = "check vbcr vblf vblf  "
                If Right(content, 3) = vbCr & vbLf & vbLf Then

                    strMessage = "ACK "
                    'RTCIS wants an "A" for ACK
                    strMsgTextOnly = Trim(Left(content, Len(content) - 3))    'strip off CR,LF,LF
                    WriteLog("Received", strMsgTextOnly)
                    strMsgToSend = "A"

                    strMessage = "send ack "
                    Send(handler, strMsgToSend)             'send Ack or Nak back to client
                    WriteLog("Sent WMS", strMsgToSend)

                    strMessage = "processmsg "
                    If Len(strMsgTextOnly) > 0 Then         'have message to decode
                        'MsgInboundDecode(strMsgTextOnly)
                        Dim instXMLReadit As New XMLReadIt
                        instXMLReadit.ParseXML(strMsgTextOnly)
                    End If

                    strMessage = "clear state.sb "          'clear the buffer 
                    state.sb.Remove(0, state.sb.Length)

                Else
                    'NAK logic goes here if implemented

                End If
                If dataToRead <> 0 Then
                    'resume receiving again
                    strMessage = "handler begin receive "
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
                End If
            End If

            'Exit Sub

        Catch
            WriteLog(gcstrError, "modSocketInterface.ReceiveCallback " & Err.Description & Space(1) & strMessage)
        End Try


    End Sub 'ReceiveCallback


    Public Shared Sub ReadCallback(ByVal ar As IAsyncResult)
        Dim content As String = String.Empty

        ' Retrieve the state object and the handler socket
        ' from the asynchronous state object.
        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket

        ' Read data from the client socket. 
        Dim bytesRead As Integer = handler.EndReceive(ar)

        If bytesRead > 0 Then
            ' There  might be more data, so store the data received so far.
            state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead))

            ' Check for end-of-file tag. If it is not there, read 
            ' more data.
            content = state.sb.ToString()
            If content.IndexOf("<EOF>") > -1 Then
                ' All the data has been read from the 
                ' client. Display it on the console.
                Console.WriteLine("Read {0} bytes from socket. " + vbLf + " Data : {1}", content.Length, content)
                ' Echo the data back to the client.
                Send(handler, content)
            Else
                ' Not all data received. Get more.
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReadCallback), state)
            End If
        End If
    End Sub 'ReadCallback

    Public Shared Sub Send(ByVal handler As Socket, ByVal data As String)
        ' Convert the string data to byte data using ASCII encoding.

        Dim byteData As Byte() = Encoding.ASCII.GetBytes(data)
        Try
            ' Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0, New AsyncCallback(AddressOf SendCallback), handler)

        Catch
            WriteLog(gcstrError, "modSocketInterface.Send " & Err.Description)
            For i As Integer = 0 To clients.Count - 1
                clients(i).workSocket.Close()
            Next
            clients.Clear()
            allDone.Set()
        End Try
    End Sub 'Send

    Private Shared Sub SendCallback(ByVal ar As IAsyncResult)
        Try
            ' Retrieve the socket from the state object.
            Dim handler As Socket = DirectCast(ar.AsyncState, Socket)

            ' Complete sending the data to the remote device.
            Dim bytesSent As Integer = handler.EndSend(ar)  '$ PROBHIDE ALL


        Catch
            WriteLog(gcstrError, "SendCallback " & Err.Description)
        End Try
    End Sub 'SendCallback


    Public Sub CloseSockets()
        Try
            For i As Integer = 0 To clients.Count - 1
                'don't do anything, left in place - just in case
            Next
            AsynchronousSocketListener.allDone.Close()

        Catch
            WriteLog(gcstrError, "CloseSockets " & Err.Description)
        End Try


    End Sub

    Public Shared Sub WriteLog(ByVal strAction As String, ByVal strText As String)
        Dim FilePath As String
        Try

            If giMessageLogLevel = -1 Then Exit Sub
            FilePath = LogFileName()

            My.Computer.FileSystem.WriteAllText(FilePath, Now & " | " & strAction.PadRight(15, Convert.ToChar(" ")) & strText & vbCrLf, True)
        Catch

        End Try
    End Sub


End Class 'AsynchronousSocketListener






