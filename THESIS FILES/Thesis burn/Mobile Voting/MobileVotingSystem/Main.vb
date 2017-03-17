Imports System
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports

Public Class Main
    Dim constr As String = ("Database=thesis; server=localhost; user=root")


    Dim DBConn As New MySqlConnection(constr)
    Dim DBCmd As New MySqlCommand

    Dim DBConn2 As New MySqlConnection(constr)
    Dim DBCmd2 As New MySqlCommand

    Dim DBConn3 As New MySqlConnection(constr)
    Dim DBCmd3 As New MySqlCommand

    Dim DR As MySqlDataReader


    Dim DBConn4 As New MySqlConnection(constr)
    Dim DBCmd4 As New MySqlCommand

    Dim DR2 As MySqlDataReader


    Dim WithEvents SerialPort1 As New System.IO.Ports.SerialPort
    Dim ReceivedSMSData As String = ""
    Public Event DataReceived As IO.Ports.SerialDataReceivedEventHandler

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenSerialPort1()
    End Sub

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SerialPort1.Close()
    End Sub

    'Open Serial Port 
    Sub OpenSerialPort1()
        With SerialPort1
            .PortName = "COM8"
            '.PortName = "COM17"
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

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, _
                 ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Receiving()
        ReceivedSMSData = SerialPort1.ReadExisting 'or SerialPort1.ReadLine

        Me.Invoke(New EventHandler(AddressOf ReceivingData))
    End Sub

    ''Test 
    'Sub ReceivingData()
    '    Dim SourceString As String = ""

    '    TextBox1.Text = ""

    '    SourceString = ReceivedSMSData

    '    TextBox1.Text = TextBox1.Text & SourceString

    '    If SourceString.Length() >= 104 And SourceString.Length() <= 120 Then


    '    ElseIf SourceString.Length() >= 120 And SourceString.Length() <= 155 Then

    '        Dim splitstring() As String = SourceString.Split(",")

    '        Dim splitstring1() As String = splitstring(2).Split(" ")
    '        Dim splitstring2() As String = splitstring(5).Split(" ")

    '        'Variable Declaration for Candidates
    '        Dim strCandidates As String = ""
    '        Dim InitialCandidates As String = ""
    '        Dim Candidates As String = ""

    '        'retrieve candidates 
    '        strCandidates = splitstring2(2)
    '        InitialCandidates = strCandidates.Trim
    '        Candidates = (InitialCandidates).Trim


    '        Dim splitCandidates() As String = (Candidates).Split("_")


    '        'Variable Declaration for Candidates
    '        Dim strPresident As String = ""
    '        Dim strVicePresident As String = ""
    '        Dim strSec As String = ""
    '        Dim strTre As String = ""
    '        Dim strAud As String = ""
    '        Dim strBus As String = ""
    '        Dim strPro As String = ""


    '        For i As Integer = 0 To UBound(splitCandidates)

    '            If Not i = UBound(splitCandidates) Then

    '                If splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "p" Then
    '                    strPresident = splitCandidates(i).Trim
    '                ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "vp" Then
    '                    strVicePresident = splitCandidates(i).Trim
    '                ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "sec" Then
    '                    strSec = splitCandidates(i).Trim
    '                ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "tre" Then
    '                    strTre = splitCandidates(i).Trim
    '                ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "aud" Then
    '                    strAud = splitCandidates(i).Trim
    '                ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "bus" Then
    '                    strBus = splitCandidates(i).Trim
    '                ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "pro" Then
    '                    strPro = splitCandidates(i).Trim
    '                End If
    '            Else
    '                Dim LastDataString() As String = splitCandidates(i).Split(" ")
    '                Dim LastCandidates As String = LastDataString(0).Trim

    '                'MsgBox(LastCandidates.Length)

    '                If Not LastCandidates.Length < 14 Then
    '                    LastCandidates = LastCandidates.Substring(0, (LastCandidates.Length - 12)).Trim
    '                End If

    '                If Not LastCandidates.Length < 2 Then
    '                    If LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "p" Then
    '                        strPresident = LastCandidates
    '                    ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "vp" Then
    '                        strVicePresident = LastCandidates
    '                    ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "sec" Then
    '                        strSec = LastCandidates
    '                    ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "tre" Then
    '                        strTre = LastCandidates
    '                    ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "aud" Then
    '                        strAud = LastCandidates
    '                    ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "bus" Then
    '                        strBus = LastCandidates
    '                    ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "pro" Then
    '                        strPro = LastCandidates
    '                    End If
    '                End If
    '            End If

    '            'MsgBox(splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)))
    '        Next i

    '        If strPresident.Length = 2 Or _
    '           strVicePresident.Length = 3 Or _
    '           strSec.Length = 4 Or _
    '           strAud.Length = 4 Or _
    '           strBus.Length = 4 Or _
    '           strBus.Length = 4 Or _
    '           strPro.Length = 4 Then

    '            MsgBox("President = " & strPresident & " Vice President = " & strVicePresident & _
    '               " Sec = " & strSec & " Tre = " & strTre & " Aud = " & strAud & " Bus = " & strBus & _
    '               " Pro = " & strPro)
    '        Else
    '            MsgBox("Invalid keyword")
    '        End If

    '    End If

    'End Sub


    Sub ReceivingData()
        Dim SourceString As String = ""

        'Variable Declaration for Mobile Number
        Dim strMobileNumb As String = ""
        Dim InitialMobileNumb As String = ""
        Dim MobileNumber As String = ""

        'Variable Declaration for Student Number
        Dim strStudentNumb As String = ""
        Dim InitialStudentNumb As String = ""
        Dim StudentNumber As String = ""

        'Variable Declaration for Candidates
        Dim strCandidates As String = ""
        Dim InitialCandidates As String = ""
        Dim Candidates As String = ""

        'Variable Declaration for Candidates
        Dim strPresident As String = ""
        Dim strVicePresident As String = ""
        Dim strSec As String = ""
        Dim strTre As String = ""
        Dim strAud As String = ""
        Dim strBus As String = ""
        Dim strPro As String = ""

        'Variable for SMS
        Dim strSMS As String = ""


        TextBox1.Text = ""

        SourceString = ReceivedSMSData

        'TextBox1.Text = TextBox1.Text & SourceString

        If SourceString.Length() >= 104 And SourceString.Length() <= 120 Then

            Dim splitstring() As String = SourceString.Split(",")

            Dim splitstring1() As String = splitstring(2).Split(" ")
            Dim splitstring2() As String = splitstring(5).Split(" ")

            strMobileNumb = splitstring1(0)

            'Retrive Mobile Number
            InitialMobileNumb = strMobileNumb.Substring(2, 12)
            MobileNumber = InitialMobileNumb.Trim

            If MobileNumber.Length = 12 Then


                strSMS = "Invalid Keyword!" & vbCrLf & ""
                Sending(MobileNumber, strSMS)

                MobileNumber = ""

            End If

            'MsgBox(MobileNumber)

        ElseIf SourceString.Length() >= 120 And SourceString.Length() <= 155 Then

            Dim splitstring() As String = SourceString.Split(",")

            Dim splitstring1() As String = splitstring(2).Split(" ")
            Dim splitstring2() As String = splitstring(5).Split(" ")

            'retrieve mobile number
            strMobileNumb = splitstring1(0)
            InitialMobileNumb = strMobileNumb.Substring(2, 12)
            MobileNumber = InitialMobileNumb.Trim

            'retrieve student number 
            strStudentNumb = splitstring2(1)
            InitialStudentNumb = strStudentNumb.Trim
            StudentNumber = InitialStudentNumb.Trim

            'retrieve candidates 
            strCandidates = splitstring2(2)
            InitialCandidates = strCandidates.Trim
            Candidates = InitialCandidates.Trim

            Dim splitCandidates() As String = Candidates.Split("_")

            For i As Integer = 0 To UBound(splitCandidates)

                If Not i = UBound(splitCandidates) Then

                    If splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "p" Then
                        strPresident = splitCandidates(i).Trim
                    ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "vp" Then
                        strVicePresident = splitCandidates(i).Trim
                    ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "sec" Then
                        strSec = splitCandidates(i).Trim
                    ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "tre" Then
                        strTre = splitCandidates(i).Trim
                    ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "aud" Then
                        strAud = splitCandidates(i).Trim
                    ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "bus" Then
                        strBus = splitCandidates(i).Trim
                    ElseIf splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)) = "pro" Then
                        strPro = splitCandidates(i).Trim
                    End If
                Else
                    Dim LastDataString() As String = splitCandidates(i).Split(" ")
                    Dim LastCandidates As String = LastDataString(0).Trim

                    'MsgBox(LastCandidates.Length)

                    If Not LastCandidates.Length < 14 Then
                        LastCandidates = LastCandidates.Substring(0, (LastCandidates.Length - 12)).Trim
                    End If

                    If Not LastCandidates.Length < 2 Then
                        If LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "p" Then
                            strPresident = LastCandidates
                        ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "vp" Then
                            strVicePresident = LastCandidates
                        ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "sec" Then
                            strSec = LastCandidates
                        ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "tre" Then
                            strTre = LastCandidates
                        ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "aud" Then
                            strAud = LastCandidates
                        ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "bus" Then
                            strBus = LastCandidates
                        ElseIf LastCandidates.Substring(0, (LastCandidates.Length - 1)) = "pro" Then
                            strPro = LastCandidates
                        End If
                    End If
                End If

                'MsgBox(splitCandidates(i).Substring(0, (splitCandidates(i).Length - 1)))
            Next i

            'Condition for MobileNumber
            If MobileNumber.Length = 12 Then

                'Condition for StudentNumber
                If StudentNumber.Length = 10 Then
                    'Comdition for Candidates

                    'Debuging mode
                    'MsgBox(strPresident & ", " & strVicePresident & ", " & _
                    '       strSec & ", " & strTre & ", " & strAud & ", " & _
                    '       strBus & ", " & strPro)

                    'Debuging mode
                    'MsgBox(strPro)


                    DBConn4 = New MySqlConnection(constr)
                    DBConn4.Open()

                    DBCmd4 = New MySqlCommand("SELECT * FROM user WHERE stud_no = " & StudentNumber, DBConn4)

                    DR2 = DBCmd4.ExecuteReader

                    Dim strStud_No As String = ""


                    If DR2.Read Then
                        strStud_No = DR2("stud_no")
                    End If


                    If strStud_No = "" Then
                        strSMS = "You're not yet registered"

                        Sending(MobileNumber, strSMS)
                        MobileNumber = ""

                    Else
                        DR2.Close()
                        DBConn4.Close()

                        'Condition for Candidates
                        If strPresident.Length = 2 Or _
                           strVicePresident.Length = 3 Or _
                           strSec.Length = 4 Or _
                           strAud.Length = 4 Or _
                           strBus.Length = 4 Or _
                           strBus.Length = 4 Or _
                           strPro.Length = 4 Then

                            'Checking if the voters already voted
                            DBConn2 = New MySqlConnection(constr)
                            DBConn2.Open()

                            DBCmd2 = New MySqlCommand("SELECT * FROM user WHERE stud_no = " & StudentNumber, DBConn2)

                            DR = DBCmd2.ExecuteReader

                            Dim strStatus As String = ""

                            If DR.Read Then
                                strStatus = DR("status")
                            End If


                            If strStatus = "VOTED" Then
                                strSMS = "Sorry your request is failed because you have already voted."

                                Sending(MobileNumber, strSMS)
                                MobileNumber = ""

                                DBConn2.Close()
                                DR.Close()

                            Else

                                DR.Close()
                                DBConn2.Close()
                                DBConn = New MySqlConnection(constr)
                                DBConn.Open()





                                'DBCmd = New MySqlCommand("INSERT INTO votetable(username,votetime,Pres,VP,SEC,TREAS,AUD,BUSman,PRO) VALUES (" & _
                                '                         "(SELECT CONCAT(fname, ' ' , lname) FROM user WHERE stud_no = @StudentNumb), " & _
                                '                         "NOW(), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @Pres), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @VP), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @SEC), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @TRES), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @AUD), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @BUSman), " & _
                                '                         "(SELECT CONCAT(party) FROM candidates WHERE keyword = @PRO) " & ") ", DBConn)


                                DBCmd = New MySqlCommand("INSERT INTO votetable(username,votetime,Pres,VP,SEC,TREAS,AUD,BUSman,PRO) VALUES (" & _
                                                         "(SELECT CONCAT(fname, ' ' , lname) FROM user WHERE stud_no = @StudentNumb), " & _
                                                         "NOW(), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @Pres),'Abstain'), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @VP),'Abstain'), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @SEC),'Abstain'), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @TRES),'Abstain'), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @AUD),'Abstain'), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @BUSman),'Abstain'), " & _
                                                         "IFNULL((SELECT CONCAT(party) FROM candidates WHERE keyword = @PRO),'Abstain') " & ") ", DBConn)


                                DBCmd.Parameters.Add("@StudentNumb", MySqlDbType.VarChar).Value = StudentNumber
                                DBCmd.Parameters.Add("@Pres", MySqlDbType.VarChar).Value = strPresident
                                DBCmd.Parameters.Add("@VP", MySqlDbType.VarChar).Value = strVicePresident
                                DBCmd.Parameters.Add("@SEC", MySqlDbType.VarChar).Value = strSec
                                DBCmd.Parameters.Add("@TRES", MySqlDbType.VarChar).Value = strTre
                                DBCmd.Parameters.Add("@AUD", MySqlDbType.VarChar).Value = strAud
                                DBCmd.Parameters.Add("@BUSman", MySqlDbType.VarChar).Value = strBus
                                DBCmd.Parameters.Add("@PRO", MySqlDbType.VarChar).Value = strPro



                                DBCmd.ExecuteNonQuery()
                                DBConn.Close()


                                DBConn3 = New MySqlConnection(constr)
                                DBConn3.Open()

                                DBCmd3 = New MySqlCommand("UPDATE user SET status = 'VOTED' where stud_no = @StudentNumb", DBConn3)

                                DBCmd3.Parameters.Add("@StudentNumb", MySqlDbType.VarChar).Value = StudentNumber

                                DBCmd3.ExecuteNonQuery()
                                DBConn3.Close()


                                strSMS = "Your vote for " & strPresident & ", " & strVicePresident & ", " & _
                                                          strSec & ", " & strTre & ", " & strAud & ", " & _
                                                          strBus & "and " & strPro & " was successful. Thank you for voting"

                                Sending(MobileNumber, strSMS)
                                MobileNumber = ""
                            End If 'Check if voter already voted


                        Else

                            strSMS = "Invalid Keyword for Candidates"

                            Sending(MobileNumber, strSMS)
                            MobileNumber = ""

                            'MsgBox("Invalid Keyword for Candidates")
                        End If
                        'End IF Condition for Candidates

                    End If 'End IF not Registered

                    DR2.Close()
                    DBConn4.Close()

                Else

                    strSMS = "Invalid Student Number"

                    Sending(MobileNumber, strSMS)
                    MobileNumber = ""

                    'MsgBox("Invalid Student Number")
                End If 'End If Comdition for StudentNumber


            End If 'End If Comdition for MobileNumber


        End If

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

    Private Sub Sending(ByVal strMobileNumber As String, ByVal strSMS As String)
        With SerialPort1

            If SerialPort1.IsOpen = False Then
                MsgBox("Error on Comport!!")
                Exit Sub
            End If
            .Write("AT" & vbCrLf)
            Sleep(500)
            .Write("AT+CMGF=1" & vbCrLf)
            Sleep(500)
            .Write("AT+CMGS=" & Chr(34) & strMobileNumber & Chr(34) & vbCrLf)
            Sleep(1000)
            .Write(strSMS & Chr(26))
            Sleep(2000)
            'MsgBox("Message Send")
        End With

    End Sub


    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim str As String = ""
    '    str = TextBox1.Text

    '    MsgBox(str.Length())
    'End Sub
End Class

