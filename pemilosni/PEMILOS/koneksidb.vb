Imports System.Data.OleDb

Module koneksidb
    'perintah untuk koneksi ke database'
    Public conn As OleDbConnection

    'perintah untuk penghubung database dengan dataset'
    Public da As OleDbDataAdapter

    'perintah untuk memanipulasi data dari database'
    Public ds As DataSet

    'perintah untuk memanipulasi perintah SQL'
    Public cmd As OleDbCommand

    'perintah untuk membaca data dari database'
    Public rd As OleDbDataReader

    Public Sub koneksi() 'Untuk Koneksi OLEDB'
        On Error GoTo Cek
        Dim Sumber As String
        Sumber = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\PEMILOS.accdb"
        conn = New OleDb.OleDbConnection(Sumber)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
            Exit Sub
        End If
Cek:
        MsgBox(Err.Description, MsgBoxStyle.Information, "KONEKSI ERROR")
    End Sub
End Module
