Imports System.Data.OleDb
Public Class FrmPemilihan
    Sub clear() 'clear form'
        'TxtId.Clear()
        ComboBox1.Items.Clear()
        TxtNama1.Clear()
        ComboBox2.Items.Clear()
        TxtNama2.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TxtId.Focus()

    End Sub

    Sub Tampil()
        Dim sqlstr As String
        Dim no As Integer = 1
        sqlstr = "select count (*) as jumlah from TPS "
        cmd = New OleDbCommand(sqlstr, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TxtId.Text = no
        Else
            no = rd.Item(0) + 1
            TxtId.Text = no
        End If
        rd.Close()

        sqlstr = "select * from siswa order by nis"
        cmd = New OleDbCommand(sqlstr, conn)
        rd = cmd.ExecuteReader
        While rd.Read
            ComboBox1.Items.Add(rd("nis"))
        End While
        rd.Close()

        sqlstr = "select * from caketos order by NoUrut "
        cmd = New OleDbCommand(sqlstr, conn)
        rd = cmd.ExecuteReader
        While rd.Read
            ComboBox2.Items.Add(rd("NoUrut"))
        End While
        rd.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub FrmPemilihan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
        Call clear()
        Call Tampil()

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim sql1 As String
        sql1 = "select * from siswa where nis ='" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(sql1, conn)
        rd = cmd.ExecuteReader
        While rd.Read
            TxtNama1.Text = rd("nama")
        End While
        rd.Close()
    End Sub

    Private Sub ComboBox2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedValueChanged
        Dim sql2 As String
        sql2 = "select * from caketos where NoUrut ='" & ComboBox2.Text & "'"
        cmd = New OleDbCommand(sql2, conn)
        rd = cmd.ExecuteReader
        While rd.Read
            TxtNama2.Text = rd("NamaCalon")
        End While
        rd.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtId.Text = "" Or ComboBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data Belum Lengkap")
            ComboBox1.Focus()
            Exit Sub
        Else
            cmd = New OleDbCommand("select * from TPS where NIS='" & ComboBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                'Tambah Data
                Dim simpan As String
                simpan = "insert into TPS values ('" & TxtId.Text & "','" & ComboBox2.Text & "','" & ComboBox1.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Kamu Berhasil Menyoblos", MsgBoxStyle.Information, "Perhatian")
            Else
                MsgBox("Anda Sudah Memilih", MsgBoxStyle.Information, "Perhatian")
            End If
            clear()
            Tampil()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()
        Tampil()

    End Sub
End Class