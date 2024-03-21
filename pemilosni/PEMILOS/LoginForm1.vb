Imports System.Data.OleDb
Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim sqlstr As String
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MsgBox("data belum lengkap")
            UsernameTextBox.Focus()
            Exit Sub

        Else
            sqlstr = "select * from pengguna where username='" & UsernameTextBox.Text & "' and password='" & PasswordTextBox.Text & "'"
            cmd = New OleDbCommand(sqlstr, conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("Anda Gagal Login...!!!", MsgBoxStyle.Information, "perhatian")
                UsernameTextBox.Focus()
            Else
                'jika login berhasil
                If rd("level") = "Admin" Then
                    fromMenu.masukadmin()
                    Me.Close()
                Else
                    fromMenu.masukuser()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class
