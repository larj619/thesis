Imports System.Data
Imports System.Data.SqlClient
Public Class Grade
    Dim rngConnString As String = ("Initial Catalog=StudentRecord;" + "Data Source=RINGO-PC\SQLEXPRESS;Initial Catalog=CNSSampleDatabase;Integrated Security=True")
    Dim DBConn As New SqlConnection
    Dim DBCmd As New SqlCommand
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit2.Click
        Close()
    End Sub

    Private Sub cmdSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave2.Click
        DBConn = New SqlConnection(rngConnString)
        DBConn.Open()

        If txtYearLevel.Text = "1" Then
            DBCmd = New SqlCommand("UPDATE StudDatabase Set MATH101 = @MATH101, FIL101 = @FIL101, ENG101 = @ENG101, SOCIO101 = @SOCIO101, CS101 = @CS101, NU101 = @NU101, BA101 = @BA101, EDU101 = @EDU101, MATH123 = @MATH123, FIL102 = @FIL102, ENG102 = @ENG102, PSYC101 = @PSYC101, CS102 = @CS102, NU102 = @NU102, BA102 = @BA102, EDU102 = @EDU102 WHERE StudNo = '" & txtSNo2.Text & "'", DBConn)

            DBCmd.Parameters.Add("@MATH101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@FIL101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@ENG101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@SOCIO101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU101", SqlDbType.Char, 5)

            DBCmd.Parameters("@MATH101").Value = txtMATH101.Text
            DBCmd.Parameters("@FIL101").Value = txtFIL101.Text
            DBCmd.Parameters("@ENG101").Value = txtENG101.Text
            DBCmd.Parameters("@SOCIO101").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS101").Value = txtCS101.Text
            DBCmd.Parameters("@NU101").Value = txtNU101.Text
            DBCmd.Parameters("@BA101").Value = txtBA101.Text
            DBCmd.Parameters("@EDU101").Value = txtEDU101.Text


            DBCmd.Parameters.Add("@MATH123", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@FIL102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@ENG102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@PSYC101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU102", SqlDbType.Char, 5)

            DBCmd.Parameters("@MATH123").Value = txtMATH101.Text
            DBCmd.Parameters("@FIL102").Value = txtFIL101.Text
            DBCmd.Parameters("@ENG102").Value = txtENG101.Text
            DBCmd.Parameters("@PSYC101").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS102").Value = txtCS101.Text
            DBCmd.Parameters("@NU102").Value = txtNU101.Text
            DBCmd.Parameters("@BA102").Value = txtBA101.Text
            DBCmd.Parameters("@EDU102").Value = txtEDU101.Text

            DBCmd.ExecuteNonQuery()
            DBConn.Close()

            MsgBox("Data Save")
        ElseIf txtYearLevel.Text = "2" Then
            DBCmd = New SqlCommand("UPDATE StudDatabase Set MATH102 = @MATH102, MNGT111 = @MNGT111, PHIL101 = @PHIL101, HIST101 = @HIST101, CS103 = @CS103, NU103 = @NU103, BA103 = @BA103, EDU103 = @EDU103, MATH171 = @MATH171, HIST102 = @HIST102, LIT101 = @LIT101, PS101 = @PS101, CS104 = @CS104, NU104 = @NU104, BA104 = @BA104, EDU104 = @EDU104 WHERE StudNo = '" & txtSNo2.Text & "'", DBConn)

            DBCmd.Parameters.Add("@MATH102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@MNGT111", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@PHIL101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@HIST101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS103", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU103", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA103", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU103", SqlDbType.Char, 5)

            DBCmd.Parameters("@MATH102").Value = txtMATH101.Text
            DBCmd.Parameters("@MNGT111").Value = txtFIL101.Text
            DBCmd.Parameters("@PHIL101").Value = txtENG101.Text
            DBCmd.Parameters("@HIST101").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS103").Value = txtCS101.Text
            DBCmd.Parameters("@NU103").Value = txtNU101.Text
            DBCmd.Parameters("@BA103").Value = txtBA101.Text
            DBCmd.Parameters("@EDU103").Value = txtEDU101.Text


            DBCmd.Parameters.Add("@MATH171", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@HIST102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@LIT101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@PS101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS104", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU104", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA104", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU104", SqlDbType.Char, 5)

            DBCmd.Parameters("@MATH171").Value = txtMATH101.Text
            DBCmd.Parameters("@HIST102").Value = txtFIL101.Text
            DBCmd.Parameters("@LIT101").Value = txtENG101.Text
            DBCmd.Parameters("@PS101").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS104").Value = txtCS101.Text
            DBCmd.Parameters("@NU104").Value = txtNU101.Text
            DBCmd.Parameters("@BA104").Value = txtBA101.Text
            DBCmd.Parameters("@EDU104").Value = txtEDU101.Text

            DBCmd.ExecuteNonQuery()
            DBConn.Close()

            MsgBox("Data Save")

        ElseIf txtYearLevel.Text = "3" Then
            DBCmd = New SqlCommand("UPDATE StudDatabase Set NASC101 = @NASC101, PHYS121 = @PHYS121, MATH172 = @MATH172, CHEM102 = @CHEM102, CS110 = @CS110, NU105 = @NU105, BA105 = @BA105, EDU105 = @EDU105, PHYS122 = @PHYS122, ACCT111 = @ACCT111, CHEM103 = @CHEM103, FL102 = @FL102, CS116 = @CS116, NU106 = @NU106, BA106 = @BA106, EDU106 = @EDU106 WHERE StudNo = '" & txtSNo2.Text & "'", DBConn)

            DBCmd.Parameters.Add("@NASC101", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@PHYS121", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@MATH172", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CHEM102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS110", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU105", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA105", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU105", SqlDbType.Char, 5)

            DBCmd.Parameters("@NASC101").Value = txtMATH101.Text
            DBCmd.Parameters("@PHYS121").Value = txtFIL101.Text
            DBCmd.Parameters("@MATH172").Value = txtENG101.Text
            DBCmd.Parameters("@CHEM102").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS110").Value = txtCS101.Text
            DBCmd.Parameters("@NU105").Value = txtNU101.Text
            DBCmd.Parameters("@BA105").Value = txtBA101.Text
            DBCmd.Parameters("@EDU105").Value = txtEDU101.Text


            DBCmd.Parameters.Add("@PHYS122", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@ACCT111", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CHEM103", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@FL102", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS116", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU106", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA106", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU106", SqlDbType.Char, 5)

            DBCmd.Parameters("@PHYS122").Value = txtMATH101.Text
            DBCmd.Parameters("@ACCT111").Value = txtFIL101.Text
            DBCmd.Parameters("@CHEM103").Value = txtENG101.Text
            DBCmd.Parameters("@FL102").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS116").Value = txtCS101.Text
            DBCmd.Parameters("@NU106").Value = txtNU101.Text
            DBCmd.Parameters("@BA106").Value = txtBA101.Text
            DBCmd.Parameters("@EDU106").Value = txtEDU101.Text

            DBCmd.ExecuteNonQuery()
            DBConn.Close()

            MsgBox("Data Save")

        ElseIf txtYearLevel.Text = "4" Then
            DBCmd = New SqlCommand("UPDATE StudDatabase Set MATH139 = @MATH139, NU107 = @NU107, BA107 = @BA107, EDU107 = @EDU107, CS121 = @CS121, NU108 = @NU108, BA108 = @BA108, EDU108 = @EDU108, CS124 = @CS124, NU109 = @NU109, BA109 = @BA109, EDU109 = @EDU109, CS126 = @CS126, NU110 = @NU110, BA110 = @BA110, EDU110 = @EDU110 WHERE StudNo = '" & txtSNo2.Text & "'", DBConn)

            DBCmd.Parameters.Add("@MATH139", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU107", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA107", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU107", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS121", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU108", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA108", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU108", SqlDbType.Char, 5)

            DBCmd.Parameters("@MATH139").Value = txtMATH101.Text
            DBCmd.Parameters("@NU107").Value = txtFIL101.Text
            DBCmd.Parameters("@BA107").Value = txtENG101.Text
            DBCmd.Parameters("@EDU107").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS121").Value = txtCS101.Text
            DBCmd.Parameters("@NU108").Value = txtNU101.Text
            DBCmd.Parameters("@BA108").Value = txtBA101.Text
            DBCmd.Parameters("@EDU108").Value = txtEDU101.Text


            DBCmd.Parameters.Add("@CS124", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU109", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA109", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU109", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@CS126", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@NU110", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@BA110", SqlDbType.Char, 5)
            DBCmd.Parameters.Add("@EDU110", SqlDbType.Char, 5)

            DBCmd.Parameters("@CS124").Value = txtMATH101.Text
            DBCmd.Parameters("@NU109").Value = txtFIL101.Text
            DBCmd.Parameters("@BA109").Value = txtENG101.Text
            DBCmd.Parameters("@EDU109").Value = txtSOCIO101.Text
            DBCmd.Parameters("@CS126").Value = txtCS101.Text
            DBCmd.Parameters("@NU110").Value = txtNU101.Text
            DBCmd.Parameters("@BA110").Value = txtBA101.Text
            DBCmd.Parameters("@EDU110").Value = txtEDU101.Text

            DBCmd.ExecuteNonQuery()
            DBConn.Close()

            MsgBox("Data Save")

        Else

            MsgBox("Wala kasunod")

        End If
       

    End Sub

    Private Sub Grade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class