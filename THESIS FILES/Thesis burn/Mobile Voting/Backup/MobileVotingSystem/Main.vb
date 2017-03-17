Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports

Public Class Main
    'Dim connection As String = Dim rngConnString As String = ("Initial Catalog=StudentRecord;" + "Data Source=RINGO-PC\SQLEXPRESS;Initial Catalog=CNSSampleDatabase;Integrated Security=True")
    Dim connection As String = ("Password=Password101;Persist Security Info=True;User ID=sa;Initial Catalog=MobileVotingDatabase;Data Source=(local)\SQL2008R2")
    Dim DBConn As New SqlConnection
    Dim DBCmd As New SqlCommand

    Dim DBConn2 As New SqlConnection
    Dim DBCmd2 As New SqlCommand
    Dim DR As SqlDataReader


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

    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, _
                 ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Receiving()
        ReceivedSMSData = SerialPort1.ReadExisting 'or SerialPort1.ReadLine

        Me.Invoke(New EventHandler(AddressOf ReceivingData))
    End Sub

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

        If SourceString.Length() >= 104 And SourceString.Length() <= 123 Then

            Dim splitstring() As String = SourceString.Split(",")

            Dim splitstring1() As String = splitstring(2).Split(" ")
            Dim splitstring2() As String = splitstring(5).Split(" ")

            strMobileNumb = splitstring1(0)

            'Retrive Mobile Number
            InitialMobileNumb = strMobileNumb.Substring(2, 12)
            MobileNumber = InitialMobileNumb.Trim

            If MobileNumber.Length = 12 Then


                strSMS = "Use the ff. Keyword" & vbCrLf & ""
                Sending(MobileNumber, strSMS)

                MobileNumber = ""

            End If

            'MsgBox(MobileNumber)

        ElseIf SourceString.Length() >= 124 And SourceString.Length() <= 155 Then

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

            strPresident = splitCandidates(0).Trim
            strVicePresident = splitCandidates(1).Trim
            strSec = splitCandidates(2).Trim
            strTre = splitCandidates(3).Trim
            strAud = splitCandidates(4).Trim
            strBus = splitCandidates(5).Trim
            strPro = splitCandidates(6).Substring(0, 4).Trim

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

                    'Condition for Candidates
                    If strPresident.Length = 2 And _
                       strVicePresident.Length = 3 And _
                       strSec.Length = 4 And _
                       strAud.Length = 4 And _
                       strBus.Length = 4 And _
                       strBus.Length = 4 And _
                       strPro.Length = 4 Then

                        'Checking if the voters already voted
                        DBConn2 = New SqlConnection(connection)
                        DBConn2.Open()

                        DBCmd2 = New SqlCommand("SELECT * FROM VoteVaultTable WHERE StudentNumb = '" & StudentNumber & "' AND VoteNo = 7", DBConn2)

                        DR = DBCmd2.ExecuteReader

                        Dim strVoteNo As String = ""

                        If DR.Read Then
                            strVoteNo = DR("VoteNo")
                        End If


                        If Not strVoteNo = "" Then
                            strSMS = "Sorry your request is failed because you already voted."

                            Sending(MobileNumber, strSMS)
                            MobileNumber = ""

                            DBConn2.Close()
                            DR.Close()

                        Else
                            Dim intIDArray(6) As Integer

                            intIDArray(0) = 0
                            intIDArray(1) = 1
                            intIDArray(2) = 2
                            intIDArray(3) = 3
                            intIDArray(4) = 4
                            intIDArray(5) = 5
                            intIDArray(6) = 6

                            For Each i As Integer In intIDArray
                                DR.Close()
                                DBConn2.Close()
                                DBConn = New SqlConnection(connection)
                                DBConn.Open()

                                DBCmd = New SqlCommand("DECLARE @varStudNumb VARCHAR(50) = '' DECLARE @varVoteNo INT = 0 " & _
                                                       " SELECT @varStudNumb = ISNULL(StudentNumb,''), @varVoteNo = ISNULL(VoteNo,0) FROM VoteVaultTable WHERE StudentNumb = " & StudentNumber & _
                                                       " AND VoteNo = " & (i + 1).ToString & _
                                                       " IF @varStudNumb = '' AND @varVoteNo = 0 " & _
                                                       "BEGIN " & _
                                                       "INSERT INTO VoteVaultTable(StudentNumb,CandidatesKeyWord,VoteNo,[Date])VALUES(@StudentNumb,@CandidatesKeyWord,@VoteNo,GETDATE())" & _
                                                       "END", DBConn)


                                DBCmd.Parameters.Add("@StudentNumb", SqlDbType.VarChar, 50)
                                DBCmd.Parameters.Add("@CandidatesKeyWord", SqlDbType.VarChar, 50)
                                DBCmd.Parameters.Add("@VoteNo", SqlDbType.Int)

                                DBCmd.Parameters("@StudentNumb").Value = StudentNumber

                                If Not i = 6 Then
                                    DBCmd.Parameters("@CandidatesKeyWord").Value = splitCandidates(i)
                                Else
                                    DBCmd.Parameters("@CandidatesKeyWord").Value = splitCandidates(i).Substring(0, 4).Trim
                                End If

                                DBCmd.Parameters("@VoteNo").Value = i + 1

                                DBCmd.ExecuteNonQuery()
                                DBConn.Close()
                            Next i


                            strSMS = "Your vote for " & strPresident & ", " & strVicePresident & ", " & _
                                                      strSec & ", " & strTre & ", " & strAud & ", " & _
                                                      strBus & "and " & strPro & "was successful. Thank you for voting"

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
                MsgBox("Error on COmport!!")
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

    'Test Button Data Recieve Length
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim str As String = ""
    '    str = TextBox1.Text

    '    MsgBox(str.Length())
    'End Sub

End Class
