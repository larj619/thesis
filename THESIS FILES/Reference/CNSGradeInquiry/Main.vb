Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports

Public Class Main
    Dim rngConnString As String = ("Initial Catalog=StudentRecord;" + "Data Source=RINGO-PC\SQLEXPRESS;Initial Catalog=CNSSampleDatabase;Integrated Security=True")
    Dim DBConn As New SqlConnection
    Dim DBCmd As New SqlCommand
    Dim DR As SqlDataReader
    Dim DBCmd2 As New SqlCommand
    Dim DR2 As SqlDataReader
    Dim DBCmd3 As New SqlCommand
    Dim CurrentTime As System.DateTime = System.DateTime.Now

    Dim WithEvents SerialPort1 As New System.IO.Ports.SerialPort
    Dim inputData As String = ""
    Public Event DataReceived As IO.Ports.SerialDataReceivedEventHandler

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With SerialPort1
            .PortName = "COM17"
            .BaudRate = "9600"
            .Parity = IO.Ports.Parity.None
            .DataBits = 8
            .StopBits = IO.Ports.StopBits.One
            .RtsEnable = True
            .DtrEnable = True
            SerialPort1.Encoding.GetEncoder()
            .ReceivedBytesThreshold = 1
            .Handshake = IO.Ports.Handshake.None
            .NewLine = vbCrLf
            .Open()
        End With
    End Sub

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SerialPort1.Close()
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, _
                     ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Call Receiving()
        inputData = SerialPort1.ReadExisting 'or SerialPort1.ReadLine

        Me.Invoke(New EventHandler(AddressOf DoUpdate))
    End Sub

    Public Sub DoUpdate()
        TextBox1.Text = TextBox1.Text & inputData

        'Dim SourceString As String
        ''DBConn = New SqlConnection(rngConnString)
        ''DBConn.Open()

        'SourceString = inputData



        'If SourceString.Length() >= 104 And SourceString.Length() <= 123 Then
        '    Dim splitstring() As String = SourceString.Split(",")

        '    Dim splitstring1() As String = splitstring(2).Split(" ")
        '    Dim splitstring2() As String = splitstring(5).Split(" ")
        '    TextBox1.Text = (splitstring(2) & " " & splitstring(4) & " " & splitstring(5))

        '    Dim str4 As String
        '    Dim MobNumb As String

        '    str4 = splitstring1(0)

        '    Dim a As String = str4.Substring(2, 12)

        '    MobNumb = a.Trim

        '    With SerialPort1

        '        If SerialPort1.IsOpen = False Then
        '            MsgBox("Error on COmport!!")
        '            Exit Sub
        '        End If
        '        .Write("AT" & vbCrLf)
        '        Sleep(500)
        '        .Write("AT+CMGF=1" & vbCrLf)
        '        Sleep(500)
        '        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '        Sleep(1000)
        '        .Write("Use the ff. Keyword:" & vbCrLf & "GRADE<space>YourStudentNumber<space>CourseCode..Thank You" & Chr(26))
        '        Sleep(2000)
        '        MsgBox("Message Send")
        '    End With

        '    Call SMSDB()

        '    DBCmd3.Parameters("@Sender").Value = MobNumb
        '    DBCmd3.Parameters("@Message").Value = "Invalid Transaction"
        '    DBCmd3.Parameters("@Recipient").Value = MobNumb
        '    DBCmd3.Parameters("@SentMessage").Value = "Help Message"
        '    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '    DBCmd3.ExecuteNonQuery()
        '    DBConn.Close()


        'ElseIf SourceString.Length() >= 124 And SourceString.Length() <= 129 Then

        '    Dim splitstring() As String = SourceString.Split(",")

        '    Dim splitstring1() As String = splitstring(2).Split(" ")
        '    Dim splitstring2() As String = splitstring(5).Split(" ")
        '    TextBox1.Text = (splitstring(2) & " " & splitstring(4) & " " & splitstring(5))

        '    Dim str1 As String
        '    Dim Keyword As String

        '    str1 = splitstring2(0)

        '    Dim x As String = str1.Substring(12, 7).Trim

        '    Keyword = x.Trim


        '    Dim str2 As String
        '    Dim StudNumb As String

        '    str2 = splitstring2(1)

        '    Dim y As String = str2.Substring(0, 10).Trim

        '    StudNumb = y.Trim

        '    Dim str3 As String
        '    Dim CourseCode As String

        '    str3 = splitstring2(2)

        '    Dim z As String = str3.Substring(0, 9).Trim

        '    CourseCode = z.Trim


        '    Dim str4 As String
        '    Dim MobNumb As String

        '    str4 = splitstring1(0)

        '    Dim a As String = str4.Substring(2, 12)

        '    MobNumb = a.Trim


        '    If Keyword = "GRADE" Then


        '        If CourseCode = "ALL1G1" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH101" & "=" & DR("MATH101") & vbCrLf & "FIL101" & "=" & DR("FIL101") & _
        '                               vbCrLf & "ENG101" & "=" & DR("ENG101") & vbCrLf & "SOCIO101" & " = " & DR("SOCIO101") & _
        '                               vbCrLf & "CS101" & " = " & DR("CS101") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH101" & "=" & DR("MATH101") & vbCrLf & "FIL101" & "=" & DR("FIL101") & _
        '                               vbCrLf & "ENG101" & "=" & DR("ENG101") & vbCrLf & "SOCIO101" & " = " & DR("SOCIO101") & _
        '                               vbCrLf & "NU101" & " = " & DR("NU101") & Chr(26))
        '                        Sleep(2000)
        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH101" & "=" & DR("MATH101") & vbCrLf & "FIL101" & "=" & DR("FIL101") & _
        '                               vbCrLf & "ENG101" & "=" & DR("ENG101") & vbCrLf & "SOCIO101" & " = " & DR("SOCIO101") & _
        '                               vbCrLf & "BA101" & " = " & DR("BA101") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH101" & "=" & DR("MATH101") & vbCrLf & "FIL101" & "=" & DR("FIL101") & _
        '                               vbCrLf & "ENG101" & "=" & DR("ENG101") & vbCrLf & "SOCIO101" & " = " & DR("SOCIO101") & _
        '                               vbCrLf & "EDU101" & " = " & DR("EDU101") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                End If 'College Selection
        '            End If 'StudNo



        '        ElseIf CourseCode = "ALL1G2" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH123" & "=" & DR("MATH123") & vbCrLf & "FIL102" & "=" & DR("FIL102") & _
        '                               vbCrLf & "ENG102" & "=" & DR("ENG102") & vbCrLf & "PSYC101" & " = " & DR("PSYC101") & _
        '                               vbCrLf & "CS102" & " = " & DR("CS102") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "FIL102" & "=" & DR("FIL102") & _
        '                               vbCrLf & "ENG102" & "=" & DR("ENG102") & vbCrLf & "PSYC101" & " = " & DR("PSYC101") & _
        '                               vbCrLf & "NU102" & " = " & DR("NU102") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH123" & "=" & DR("MATH123") & vbCrLf & "FIL102" & "=" & DR("FIL102") & _
        '                               vbCrLf & "ENG102" & "=" & DR("ENG102") & vbCrLf & "PSYC101" & " = " & DR("PSYC101") & _
        '                               vbCrLf & "BA102" & " = " & DR("BA102") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH123" & "=" & DR("MATH123") & vbCrLf & "FIL102" & "=" & DR("FIL102") & _
        '                               vbCrLf & "ENG102" & "=" & DR("ENG102") & vbCrLf & "PSYC101" & " = " & DR("PSYC101") & _
        '                               vbCrLf & "EDU102" & " = " & DR("EDU102") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                End If '2nd College Selection
        '            End If '2nd StudNo


        '        ElseIf CourseCode = "ALL2G1" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH102" & "=" & DR("MATH102") & vbCrLf & "PHIL101" & "=" & DR("PHIL101") & _
        '                               vbCrLf & "HIST101" & "=" & DR("HIST101") & vbCrLf & "MNGT111" & " = " & DR("MNGT111") & _
        '                               vbCrLf & "CS103" & " = " & DR("CS103") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH102" & "=" & DR("MATH102") & vbCrLf & "PHIL101" & "=" & DR("PHIL101") & _
        '                               vbCrLf & "HIST101" & "=" & DR("HIST101") & vbCrLf & "MNGT111" & " = " & DR("MNGT111") & _
        '                               vbCrLf & "NU103" & " = " & DR("NU103") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH102" & "=" & DR("MATH102") & vbCrLf & "PHIL101" & "=" & DR("PHIL101") & _
        '                               vbCrLf & "HIST101" & "=" & DR("HIST101") & vbCrLf & "MNGT111" & " = " & DR("MNGT111") & _
        '                               vbCrLf & "BA103" & " = " & DR("BA103") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH102" & "=" & DR("MATH102") & vbCrLf & "PHIL101" & "=" & DR("PHIL101") & _
        '                               vbCrLf & "HIST101" & "=" & DR("HIST101") & vbCrLf & "MNGT111" & " = " & DR("MNGT111") & _
        '                               vbCrLf & "EDU103" & " = " & DR("EDU103") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                End If '3RD College Selection
        '            End If '3RD StudNo


        '        ElseIf CourseCode = "ALL2G2" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH171" & "=" & DR("MATH171") & vbCrLf & "HIST102" & "=" & DR("HIST102") & _
        '                               vbCrLf & "LIT101" & "=" & DR("LIT101") & vbCrLf & "PS101" & " = " & DR("PS101") & _
        '                               vbCrLf & "CS104" & " = " & DR("CS104") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "HIST102" & "=" & DR("HIST102") & _
        '                               vbCrLf & "LIT101" & "=" & DR("LIT101") & vbCrLf & "PS101" & " = " & DR("PS101") & _
        '                               vbCrLf & "NU104" & " = " & DR("NU104") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "HIST102" & "=" & DR("HIST102") & _
        '                               vbCrLf & "LIT101" & "=" & DR("LIT101") & vbCrLf & "PS101" & " = " & DR("PS101") & _
        '                               vbCrLf & "BA104" & " = " & DR("BA104") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "HIST102" & "=" & DR("HIST102") & _
        '                               vbCrLf & "LIT101" & "=" & DR("LIT101") & vbCrLf & "PS101" & " = " & DR("PS101") & _
        '                               vbCrLf & "EDU104" & " = " & DR("EDU104") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                End If '4TH College Selection
        '            End If '4TH StudNo


        '        ElseIf CourseCode = "ALL3G1" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "NASC101" & "=" & DR("NASC101") & vbCrLf & "PHYS121" & "=" & DR("PHYS121") & _
        '                               vbCrLf & "MATH172" & "=" & DR("MATH172") & _
        '                               vbCrLf & "CS110" & " = " & DR("CS110") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "NASC101" & "=" & DR("NASC101") & vbCrLf & "PHYS121" & "=" & DR("PHYS121") & _
        '                               vbCrLf & "CHEM102" & "=" & DR("CHEM102") & _
        '                               vbCrLf & "NU105" & " = " & DR("NU105") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "NASC101" & "=" & DR("NASC101") & vbCrLf & "PHYS121" & "=" & DR("PHYS121") & _
        '                               vbCrLf & "MATH172" & "=" & DR("MATH172") & _
        '                               vbCrLf & "BA105" & " = " & DR("BA105") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()



        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "NASC101" & "=" & DR("NASC101") & vbCrLf & "PHYS121" & "=" & DR("PHYS121") & _
        '                               vbCrLf & "MATH172" & "=" & DR("MATH172") & _
        '                               vbCrLf & "EDU105" & " = " & DR("EDU105") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                End If '5TH College Selection
        '            End If '5TH StudNo


        '        ElseIf CourseCode = "ALL3G2" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "PHYS122" & "=" & DR("PHYS122") & vbCrLf & "ACCT111" & "=" & DR("ACCT111") & _
        '                               vbCrLf & "FL102" & "=" & DR("FL102") & _
        '                               vbCrLf & "CS116" & " = " & DR("CS116") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "PHYS122" & "=" & DR("PHYS122") & vbCrLf & "ACCT111" & "=" & DR("ACCT111") & _
        '                               vbCrLf & "CHEM103" & "=" & DR("CHEM103") & _
        '                               vbCrLf & "NU106" & " = " & DR("NU1056") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "PHYS122" & "=" & DR("PHYS122") & vbCrLf & "ACCT111" & "=" & DR("ACCT111") & _
        '                               vbCrLf & "FL102" & "=" & DR("FL102") & _
        '                               vbCrLf & "BA106" & " = " & DR("BA106") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                              "PHYS122" & "=" & DR("PHYS122") & vbCrLf & "ACCT111" & "=" & DR("ACCT111") & _
        '                               vbCrLf & "FL102" & "=" & DR("FL102") & _
        '                               vbCrLf & "EDU106" & " = " & DR("EDU106") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                End If '6TH College Selection
        '            End If '6TH StudNo

        '        ElseIf CourseCode = "ALL4G1" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "MATH139" & "=" & DR("MATH139") & vbCrLf & "CS121" & "=" & DR("CS121") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()



        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "NU107" & "=" & DR("NU107") & vbCrLf & "NU108" & "=" & DR("NU108") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()



        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "BA107" & "=" & DR("BA107") & vbCrLf & "BA108" & "=" & DR("BA108") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                              "EDU107" & "=" & DR("EDU107") & vbCrLf & "EDU108" & "=" & DR("EDU108") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                End If '7TH College Selection
        '            End If '7TH StudNo


        '        ElseIf CourseCode = "ALL4G2" Then
        '            DBCmd = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '            DR = DBCmd.ExecuteReader

        '            If DR.Read Then
        '                Dim SName As String
        '                Dim SNo As String
        '                Dim College As String

        '                SName = DR("StudName")
        '                SNo = DR("StudNo")
        '                College = DR("College")

        '                If College = "CCIS" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "CS124" & "=" & DR("CS124") & vbCrLf & "CS126" & "=" & DR("CS126") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                ElseIf College = "SLCN" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "NU109" & "=" & DR("NU109") & vbCrLf & "NU110" & "=" & DR("NU110") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                ElseIf College = "CBA" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                               "BA109" & "=" & DR("BA109") & vbCrLf & "BA110" & "=" & DR("BA110") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()


        '                ElseIf College = "COE" Then

        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write(SName & vbCrLf & SNo & vbCrLf & _
        '                              "EDU109" & "=" & DR("EDU109") & vbCrLf & "EDU110" & "=" & DR("EDU110") & Chr(26))
        '                        Sleep(2000)

        '                    End With
        '                    DR.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()

        '                End If '8TH College Selection
        '            End If '8TH StudNo





        '        Else
        '            DBCmd = New SqlCommand("Select * from SubjectCodes where SCODE = '" & CourseCode & "'", DBConn)
        '            DR = DBCmd.ExecuteReader
        '            If DR.Read Then
        '                DR.Close()

        '                DBCmd2 = New SqlCommand("Select * from StudDatabase where  StudNo = '" & StudNumb & "'", DBConn)
        '                DR2 = DBCmd2.ExecuteReader
        '                If DR2.Read Then
        '                    Dim SName As String
        '                    Dim SNo As String
        '                    Dim College As String
        '                    Dim CCOde As String
        '                    Dim RGrade As String


        '                    SName = DR2("StudName")
        '                    SNo = DR2("StudNo")
        '                    College = DR2("College")
        '                    CCOde = CourseCode.Trim
        '                    RGrade = DR2(CCOde)


        '                    With SerialPort1

        '                        If SerialPort1.IsOpen = False Then
        '                            MsgBox("Error on COmport!!")
        '                            Exit Sub
        '                        End If
        '                        .Write("AT" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGF=1" & vbCrLf)
        '                        Sleep(500)
        '                        .Write("AT+CMGS=" & Chr(34) & MobNumb & Chr(34) & vbCrLf)
        '                        Sleep(1000)
        '                        .Write((SName & vbCrLf & SNo & vbCrLf & CCOde & " = " & RGrade) & Chr(26))
        '                        Sleep(2000)
        '                        MsgBox("Message Send")
        '                    End With
        '                    DR2.Close()
        '                    Call SMSDB()
        '                    DBCmd3.Parameters("@Sender").Value = SName
        '                    DBCmd3.Parameters("@Message").Value = (Keyword & " " & StudNumb & " " & CourseCode).Trim
        '                    DBCmd3.Parameters("@Recipient").Value = SName
        '                    DBCmd3.Parameters("@SentMessage").Value = "Grade of" & " " & SName & " " & CourseCode
        '                    DBCmd3.Parameters("@Date").Value = ((CurrentTime.Month) & "/" & (CurrentTime.Day) & "/" & (CurrentTime.Year))
        '                    DBCmd3.Parameters("@Time").Value = ((CurrentTime.Hour) & ":" & (CurrentTime.Minute) & ":" & (CurrentTime.Second))

        '                    DBCmd3.ExecuteNonQuery()
        '                    DBConn.Close()
        '                End If '
        '            End If




        '        End If 'CourseCode

        '    End If 'Keyword


        'End If  'Valid Request

    






    End Sub

    Private Sub Receiving()
        With SerialPort1
            .Write("AT" & vbCrLf)
            Sleep(500)
            .Write("AT+CMGF=1" & vbCrLf)
            Sleep(500)
            .Write("AT+CMGR=0" & vbCrLf)
            Sleep(500)
            .Write("AT+CMGD=0" & vbCrLf)
            Sleep(500)
        End With
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        DBConn = New SqlConnection(rngConnString)
        DBConn.Open()




        DBCmd = New SqlCommand("Select * from StudDatabase where StudNo = '" & txtStudNo.Text & "'", DBConn)
        DR = DBCmd.ExecuteReader

        If DR.Read Then
            cmdShowGrade.Enabled = "True"
            ComboBox1.Enabled = "True"
            Label1.Enabled = "True"

            txtStudName.Text = DR("StudName")
            txtMobNo.Text = DR("MobileNumber")
            txtCollege.Text = DR("College")
            txtSection.Text = DR("Section")
        Else

            txtStudName.Text = ""
            txtMobNo.Text = ""
            txtCollege.Text = ""
            txtSection.Text = ""
            MsgBox("Cannot Find Data")

        End If

    End Sub


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cmdShowGrade.Enabled = "False"
        ComboBox1.Enabled = "False"
        Label1.Enabled = "False"
        txtStudNo.Text = ""
        txtStudName.Text = ""
        txtMobNo.Text = ""
        txtCollege.Text = ""
        txtSection.Text = ""
        ComboBox1.Text = ""

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        DBConn = New SqlConnection(rngConnString)
        DBConn.Open()

        DBCmd = New SqlCommand("UPDATE StudDatabase Set StudName = @StudName, MobileNumber = @MobileNumber, College = @College, Section = @Section WHERE StudNo = '" & txtStudNo.Text & "'", DBConn)


        DBCmd.Parameters.Add("@StudName", SqlDbType.NVarChar, 50)
        DBCmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar, 15)
        DBCmd.Parameters.Add("@College", SqlDbType.NVarChar, 10)
        DBCmd.Parameters.Add("@Section", SqlDbType.NVarChar, 15)

        DBCmd.Parameters("@StudName").Value = txtStudName.Text
        DBCmd.Parameters("@MobileNumber").Value = txtMobNo.Text
        DBCmd.Parameters("@College").Value = txtCollege.Text
        DBCmd.Parameters("@Section").Value = txtSection.Text

        DBCmd.ExecuteNonQuery()
        DBConn.Close()

        MsgBox("Data Save")
    End Sub

    Private Sub cmdShowGrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowGrade.Click
        Dim GradeDB As New Grade
        DBConn = New SqlConnection(rngConnString)
        DBConn.Open()

        DBCmd = New SqlCommand("Select * from StudDatabase where StudNo = '" & txtStudNo.Text & "'", DBConn)
        DR = DBCmd.ExecuteReader

        If ComboBox1.Text = "1st" Then
            If DR.Read Then
                GradeDB.Show()

                GradeDB.lbl1.Text = "MATH101"
                GradeDB.lbl2.Text = "FIL101"
                GradeDB.lbl3.Text = "ENG101"
                GradeDB.lbl4.Text = "SOCIO101"
                GradeDB.lbl5.Text = "CS101"
                GradeDB.lbl6.Text = "NU101"
                GradeDB.lbl7.Text = "BA101"
                GradeDB.lbl8.Text = "EDU101"

                GradeDB.lbl9.Text = "MATH123"
                GradeDB.lbl10.Text = "FIL102"
                GradeDB.lbl11.Text = "ENG102"
                GradeDB.lbl12.Text = "PSYC101"
                GradeDB.lbl13.Text = "CS102"
                GradeDB.lbl14.Text = "NU102"
                GradeDB.lbl15.Text = "BA102"
                GradeDB.lbl16.Text = "EDU102"


                GradeDB.txtSNo2.Text = DR("StudNo")
                GradeDB.txtSName2.Text = DR("StudName")
                GradeDB.txtYearLevel.Text = ("1")
                '1st Semester 
                GradeDB.txtMATH101.Text = DR("MATH101")
                GradeDB.txtFIL101.Text = DR("FIL101")
                GradeDB.txtENG101.Text = DR("ENG101")
                GradeDB.txtSOCIO101.Text = DR("SOCIO101")
                GradeDB.txtCS101.Text = DR("CS101")
                GradeDB.txtNU101.Text = DR("NU101")
                GradeDB.txtBA101.Text = DR("BA101")
                GradeDB.txtEDU101.Text = DR("EDU101")

                '2nd Semester
                GradeDB.txtMATH123.Text = DR("MATH123")
                GradeDB.txtFIL102.Text = DR("FIL102")
                GradeDB.txtENG102.Text = DR("ENG102")
                GradeDB.txtPSYC101.Text = DR("PSYC101")
                GradeDB.txtCS102.Text = DR("CS102")
                GradeDB.txtNU102.Text = DR("NU102")
                GradeDB.txtBA102.Text = DR("BA102")
                GradeDB.txtEDU102.Text = DR("EDU102")
            End If

        ElseIf ComboBox1.Text = "2nd" Then
            If DR.Read Then
                GradeDB.Show()

                GradeDB.lbl1.Text = "MATH102"
                GradeDB.lbl2.Text = "MNGT111"
                GradeDB.lbl3.Text = "PHIL101"
                GradeDB.lbl4.Text = "HIST101"
                GradeDB.lbl5.Text = "CS103"
                GradeDB.lbl6.Text = "NU103"
                GradeDB.lbl7.Text = "BA103"
                GradeDB.lbl8.Text = "EDU103"

                GradeDB.lbl9.Text = "MATH171"
                GradeDB.lbl10.Text = "HIST102"
                GradeDB.lbl11.Text = "LIT101"
                GradeDB.lbl12.Text = "PS101"
                GradeDB.lbl13.Text = "CS104"
                GradeDB.lbl14.Text = "NU104"
                GradeDB.lbl15.Text = "BA104"
                GradeDB.lbl16.Text = "EDU104"


                GradeDB.txtSNo2.Text = DR("StudNo")
                GradeDB.txtSName2.Text = DR("StudName")
                GradeDB.txtYearLevel.Text = ("2")
                '1st Semester 
                GradeDB.txtMATH101.Text = DR("MATH102")
                GradeDB.txtFIL101.Text = DR("MNGT111")
                GradeDB.txtENG101.Text = DR("PHIL101")
                GradeDB.txtSOCIO101.Text = DR("HIST101")
                GradeDB.txtCS101.Text = DR("CS103")
                GradeDB.txtNU101.Text = DR("NU103")
                GradeDB.txtBA101.Text = DR("BA103")
                GradeDB.txtEDU101.Text = DR("EDU103")

                '2nd Semester
                GradeDB.txtMATH123.Text = DR("MATH171")
                GradeDB.txtFIL102.Text = DR("HIST102")
                GradeDB.txtENG102.Text = DR("LIT101")
                GradeDB.txtPSYC101.Text = DR("PS101")
                GradeDB.txtCS102.Text = DR("CS104")
                GradeDB.txtNU102.Text = DR("NU104")
                GradeDB.txtBA102.Text = DR("BA104")
                GradeDB.txtEDU102.Text = DR("EDU104")
            End If

        ElseIf ComboBox1.Text = "3rd" Then

            If DR.Read Then
                GradeDB.Show()

                GradeDB.lbl1.Text = "NASC101"
                GradeDB.lbl2.Text = "PHYS121"
                GradeDB.lbl3.Text = "MATH172"
                GradeDB.lbl4.Text = "CHEM102"
                GradeDB.lbl5.Text = "CS110"
                GradeDB.lbl6.Text = "NU105"
                GradeDB.lbl7.Text = "BA105"
                GradeDB.lbl8.Text = "EDU105"

                GradeDB.lbl9.Text = "PHYS122"
                GradeDB.lbl10.Text = "ACCT111"
                GradeDB.lbl11.Text = "CHEM103"
                GradeDB.lbl12.Text = "FL102"
                GradeDB.lbl13.Text = "CS116"
                GradeDB.lbl14.Text = "NU106"
                GradeDB.lbl15.Text = "BA106"
                GradeDB.lbl16.Text = "EDU106"


                GradeDB.txtSNo2.Text = DR("StudNo")
                GradeDB.txtSName2.Text = DR("StudName")
                GradeDB.txtYearLevel.Text = ("3")
                '1st Semester 
                GradeDB.txtMATH101.Text = DR("NASC101")
                GradeDB.txtFIL101.Text = DR("PHYS121")
                GradeDB.txtENG101.Text = DR("MATH172")
                GradeDB.txtSOCIO101.Text = DR("CHEM102")
                GradeDB.txtCS101.Text = DR("CS110")
                GradeDB.txtNU101.Text = DR("NU105")
                GradeDB.txtBA101.Text = DR("BA105")
                GradeDB.txtEDU101.Text = DR("EDU105")

                '2nd Semester
                GradeDB.txtMATH123.Text = DR("PHYS122")
                GradeDB.txtFIL102.Text = DR("ACCT111")
                GradeDB.txtENG102.Text = DR("CHEM103")
                GradeDB.txtPSYC101.Text = DR("FL102")
                GradeDB.txtCS102.Text = DR("CS116")
                GradeDB.txtNU102.Text = DR("NU106")
                GradeDB.txtBA102.Text = DR("BA106")
                GradeDB.txtEDU102.Text = DR("EDU106")
            End If

        ElseIf ComboBox1.Text = "4th" Then
            If DR.Read Then
                GradeDB.Show()

                GradeDB.lbl1.Text = "MATH139"
                GradeDB.lbl2.Text = "NU107"
                GradeDB.lbl3.Text = "BA107"
                GradeDB.lbl4.Text = "EDU107"
                GradeDB.lbl5.Text = "CS121"
                GradeDB.lbl6.Text = "NU108"
                GradeDB.lbl7.Text = "BA108"
                GradeDB.lbl8.Text = "EDU108"

                GradeDB.lbl9.Text = "CS124"
                GradeDB.lbl10.Text = "NU109"
                GradeDB.lbl11.Text = "BA109"
                GradeDB.lbl12.Text = "EDU109"
                GradeDB.lbl13.Text = "C126"
                GradeDB.lbl14.Text = "NU110"
                GradeDB.lbl15.Text = "BA110"
                GradeDB.lbl16.Text = "EDU110"


                GradeDB.txtSNo2.Text = DR("StudNo")
                GradeDB.txtSName2.Text = DR("StudName")
                GradeDB.txtYearLevel.Text = ("4")
                '1st Semester 
                GradeDB.txtMATH101.Text = DR("MATH139")
                GradeDB.txtFIL101.Text = DR("NU107")
                GradeDB.txtENG101.Text = DR("BA107")
                GradeDB.txtSOCIO101.Text = DR("EDU107")
                GradeDB.txtCS101.Text = DR("CS121")
                GradeDB.txtNU101.Text = DR("NU108")
                GradeDB.txtBA101.Text = DR("BA108")
                GradeDB.txtEDU101.Text = DR("EDU108")

                '2nd Semester
                GradeDB.txtMATH123.Text = DR("CS124")
                GradeDB.txtFIL102.Text = DR("NU109")
                GradeDB.txtENG102.Text = DR("BA109")
                GradeDB.txtPSYC101.Text = DR("EDU109")
                GradeDB.txtCS102.Text = DR("CS126")
                GradeDB.txtNU102.Text = DR("NU110")
                GradeDB.txtBA102.Text = DR("BA110")
                GradeDB.txtEDU102.Text = DR("EDU110")
            End If
        Else
            MsgBox("Select Year Level")
        End If
       

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        DBConn = New SqlConnection(rngConnString)
        DBConn.Open()

        DBCmd = New SqlCommand("INSERT INTO StudDatabase (StudNo,StudName,MobileNumber,College,Section,MATH101,FIL101,ENG101,SOCIO101,CS101,NU101,BA101,EDU101,MATH123,ENG102,PSYC101,CS102,NU102,BA102,EDU102,FIL102,MATH102,MNGT111,PHIL101,HIST101,CS103,NU103,BA103,EDU103,MATH171,HIST102,LIT101,PS101,CS104,NU104,BA104,EDU104,NASC101,PHYS121,MATH172,CHEM102,CS110,NU105,BA105,EDU105,PHYS122,ACCT111,CHEM103,FL102,CS116,NU106,BA106,EDU106,MATH139,NU107,BA107,EDU107,CS121,NU108,BA108,EDU108,CS124,NU109,BA109,EDU109,CS126,NU110,BA110,EDU110) VALUES(@StudNo,@StudName,@MobileNumber,@College,@Section,@MATH101,@FIL101,@ENG101,@SOCIO101,@CS101,@NU101,@BA101,@EDU101,@MATH123,@ENG102,@PSYC101,@CS102,@NU102,@BA102,@EDU102,@FIL102,@MATH102,@MNGT111,@PHIL101,@HIST101,@CS103,@NU103,@BA103,@EDU103,@MATH171,@HIST102,@LIT101,@PS101,@CS104,@NU104,@BA104,@EDU104,@NASC101,@PHYS121,@MATH172,@CHEM102,@CS110,@NU105,@BA105,@EDU105,@PHYS122,@ACCT111,@CHEM103,@FL102,@CS116,@NU106,@BA106,@EDU106,@MATH139,@NU107,@BA107,@EDU107,@CS121,@NU108,@BA108,@EDU108,@CS124,@NU109,@BA109,@EDU109,@CS126,@NU110,@BA110,@EDU110)", DBConn)

        DBCmd.Parameters.Add("@StudNo", SqlDbType.NVarChar, 15)
        DBCmd.Parameters.Add("@StudName", SqlDbType.NVarChar, 50)
        DBCmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar, 15)
        DBCmd.Parameters.Add("@College", SqlDbType.NVarChar, 10)
        DBCmd.Parameters.Add("@Section", SqlDbType.NVarChar, 15)

        DBCmd.Parameters("@StudNo").Value = txtStudNo.Text
        DBCmd.Parameters("@StudName").Value = txtStudName.Text
        DBCmd.Parameters("@MobileNumber").Value = txtMobNo.Text
        DBCmd.Parameters("@College").Value = txtCollege.Text
        DBCmd.Parameters("@Section").Value = txtSection.Text



        'Default Grading N/A for 1st Sem
        DBCmd.Parameters.Add("@MATH101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@FIL101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@ENG101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@SOCIO101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU101", SqlDbType.Char, 5)

        DBCmd.Parameters("@MATH101").Value = "N/A"
        DBCmd.Parameters("@FIL101").Value = "N/A"
        DBCmd.Parameters("@ENG101").Value = "N/A"
        DBCmd.Parameters("@SOCIO101").Value = "N/A"
        DBCmd.Parameters("@CS101").Value = "N/A"
        DBCmd.Parameters("@NU101").Value = "N/A"
        DBCmd.Parameters("@BA101").Value = "N/A"
        DBCmd.Parameters("@EDU101").Value = "N/A"

        'End of Statement

        'Default Grading N/A for 2nd Sem
        DBCmd.Parameters.Add("@MATH123", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@FIL102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@ENG102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@PSYC101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU102", SqlDbType.Char, 5)

        DBCmd.Parameters("@MATH123").Value = "N/A"
        DBCmd.Parameters("@FIL102").Value = "N/A"
        DBCmd.Parameters("@ENG102").Value = "N/A"
        DBCmd.Parameters("@PSYC101").Value = "N/A"
        DBCmd.Parameters("@CS102").Value = "N/A"
        DBCmd.Parameters("@NU102").Value = "N/A"
        DBCmd.Parameters("@BA102").Value = "N/A"
        DBCmd.Parameters("@EDU102").Value = "N/A"
        'End of Statement

        DBCmd.Parameters.Add("@MATH102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@MNGT111", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@PHIL101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@HIST101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS103", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU103", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA103", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU103", SqlDbType.Char, 5)

        DBCmd.Parameters("@MATH102").Value = "N/A"
        DBCmd.Parameters("@MNGT111").Value = "N/A"
        DBCmd.Parameters("@PHIL101").Value = "N/A"
        DBCmd.Parameters("@HIST101").Value = "N/A"
        DBCmd.Parameters("@CS103").Value = "N/A"
        DBCmd.Parameters("@NU103").Value = "N/A"
        DBCmd.Parameters("@BA103").Value = "N/A"
        DBCmd.Parameters("@EDU103").Value = "N/A"


        DBCmd.Parameters.Add("@MATH171", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@HIST102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@LIT101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@PS101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS104", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU104", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA104", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU104", SqlDbType.Char, 5)

        DBCmd.Parameters("@MATH171").Value = "N/A"
        DBCmd.Parameters("@HIST102").Value = "N/A"
        DBCmd.Parameters("@LIT101").Value = "N/A"
        DBCmd.Parameters("@PS101").Value = "N/A"
        DBCmd.Parameters("@CS104").Value = "N/A"
        DBCmd.Parameters("@NU104").Value = "N/A"
        DBCmd.Parameters("@BA104").Value = "N/A"
        DBCmd.Parameters("@EDU104").Value = "N/A"


        DBCmd.Parameters.Add("@NASC101", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@PHYS121", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@MATH172", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CHEM102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS110", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU105", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA105", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU105", SqlDbType.Char, 5)

        DBCmd.Parameters("@NASC101").Value = "N/A"
        DBCmd.Parameters("@PHYS121").Value = "N/A"
        DBCmd.Parameters("@MATH172").Value = "N/A"
        DBCmd.Parameters("@CHEM102").Value = "N/A"
        DBCmd.Parameters("@CS110").Value = "N/A"
        DBCmd.Parameters("@NU105").Value = "N/A"
        DBCmd.Parameters("@BA105").Value = "N/A"
        DBCmd.Parameters("@EDU105").Value = "N/A"


        DBCmd.Parameters.Add("@PHYS122", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@ACCT111", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CHEM103", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@FL102", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS116", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU106", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA106", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU106", SqlDbType.Char, 5)

        DBCmd.Parameters("@PHYS122").Value = "N/A"
        DBCmd.Parameters("@ACCT111").Value = "N/A"
        DBCmd.Parameters("@CHEM103").Value = "N/A"
        DBCmd.Parameters("@FL102").Value = "N/A"
        DBCmd.Parameters("@CS116").Value = "N/A"
        DBCmd.Parameters("@NU106").Value = "N/A"
        DBCmd.Parameters("@BA106").Value = "N/A"
        DBCmd.Parameters("@EDU106").Value = "N/A"


        DBCmd.Parameters.Add("@MATH139", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU107", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA107", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU107", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS121", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU108", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA108", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU108", SqlDbType.Char, 5)

        DBCmd.Parameters("@MATH139").Value = "N/A"
        DBCmd.Parameters("@NU107").Value = "N/A"
        DBCmd.Parameters("@BA107").Value = "N/A"
        DBCmd.Parameters("@EDU107").Value = "N/A"
        DBCmd.Parameters("@CS121").Value = "N/A"
        DBCmd.Parameters("@NU108").Value = "N/A"
        DBCmd.Parameters("@BA108").Value = "N/A"
        DBCmd.Parameters("@EDU108").Value = "N/A"


        DBCmd.Parameters.Add("@CS124", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU109", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA109", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU109", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@CS126", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@NU110", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@BA110", SqlDbType.Char, 5)
        DBCmd.Parameters.Add("@EDU110", SqlDbType.Char, 5)

        DBCmd.Parameters("@CS124").Value = "N/A"
        DBCmd.Parameters("@NU109").Value = "N/A"
        DBCmd.Parameters("@BA109").Value = "N/A"
        DBCmd.Parameters("@EDU109").Value = "N/A"
        DBCmd.Parameters("@CS126").Value = "N/A"
        DBCmd.Parameters("@NU110").Value = "N/A"
        DBCmd.Parameters("@BA110").Value = "N/A"
        DBCmd.Parameters("@EDU110").Value = "N/A"






        DBCmd.ExecuteNonQuery()
        DBConn.Close()

        MsgBox("Data Save")


    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        DBConn = New SqlConnection(rngConnString)
        DBConn.Open()

        DBCmd = New SqlCommand("Delete from StudDatabase where StudNo = '" + txtStudNo.Text + "'", DBConn)

        MsgBox("DATA Deleted")

        txtStudNo.Text = ""
        txtStudName.Text = ""
        txtMobNo.Text = ""
        txtCollege.Text = ""
        txtSection.Text = ""

        DBCmd.ExecuteNonQuery()
        DBConn.Close()
    End Sub
    Private Sub SMSDB()
        DBCmd3 = New SqlCommand("INSERT INTO Messages (Sender,Message,Recipient,SentMessage,Date,Time) VALUES (@Sender,@Message,@Recipient,@SentMessage,@Date,@Time)", DBConn)

        DBCmd3.Parameters.Add("@Sender", SqlDbType.NVarChar, 50)
        DBCmd3.Parameters.Add("@Message", SqlDbType.NVarChar, 160)
        DBCmd3.Parameters.Add("@Recipient", SqlDbType.NVarChar, 50)
        DBCmd3.Parameters.Add("@SentMessage", SqlDbType.NVarChar, 160)
        DBCmd3.Parameters.Add("@Date", SqlDbType.NVarChar, 15)
        DBCmd3.Parameters.Add("@Time", SqlDbType.NVarChar, 15)

    End Sub


    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String
        str = TextBox1.Text

        MsgBox(str.Length())

    End Sub

   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class