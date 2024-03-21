Imports System.Data.OleDb

Public Class Pengguna
    Sub clear() 'clear form'
        TxtIdPengguna.Clear()
        TxtUsername.Clear()
        TxtPassword.Text = ""
        ComboBox1.Text = ""

    End Sub

    Sub isi() 'mengisi form'
        TxtUsername.Clear()
        TxtUsername.Focus()

    End Sub

    Sub aturgrid() 'mengatur grid view'
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(0).HeaderText = "Id Pengguna"
        DataGridView1.Columns(1).HeaderText = "Username"
        DataGridView1.Columns(2).HeaderText = "Paswword"
        DataGridView1.Columns(3).HeaderText = "Level"
    End Sub

    Sub TampilData() 'menampilkan data'
        da = New OleDbDataAdapter("select * from pengguna", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "pengguna")

        DataGridView1.DataSource = ds.Tables("pengguna")
        DataGridView1.Refresh()
    End Sub

    Private Sub Pengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
        aturgrid()
        clear()
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(i)
            Me.TxtIdPengguna.Text = .Cells(0).Value
            Me.TxtUsername.Text = .Cells(1).Value
            Me.TxtPassword.Text = .Cells(2).Value
            Me.ComboBox1.Text = .Cells(3).Value
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TxtIdPengguna.Text = "" Or TxtUsername.Text = "" Or TxtPassword.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TxtIdPengguna.Focus()
            Exit Sub
        Else
            cmd = New OleDbCommand("select * from pengguna where id_pengguna='" & TxtIdPengguna.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then 'jika tidak dapat record'
                Dim Simpan As String = "insert into pengguna values" & _
                    "('" & TxtIdPengguna.Text & "','" & TxtUsername.Text & "','" & TxtPassword.Text & "','" & ComboBox1.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasl Di Simpan", MsgBoxStyle.Information, "Perhatian")
            Else
                'Update Data'
               Dim Ubah As String = "update pengguna set [username]= '" & TxtUsername.Text & "', [password] ='" & TxtPassword.Text & "', [level] ='" & ComboBox1.Text & "' where id_pengguna ='" & TxtIdPengguna.Text & "'"
                cmd = New OleDbCommand(Ubah, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Ubah Data Berhasl ", MsgBoxStyle.Information, "Perhatian")
            End If
            TampilData()
            clear()
            TxtIdPengguna.Enabled = True
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TxtIdPengguna.Text = "" Then
            MsgBox("No Urut Belum Diisi")
            TxtIdPengguna.Enabled = True
            Exit Sub
        Else
            Dim Ubah As String = "update pengguna set [username]= '" & TxtUsername.Text & "', [password] ='" & TxtPassword.Text & "', [level] ='" & ComboBox1.Text & "' where id_pengguna ='" & TxtIdPengguna.Text & "'"
            cmd = New OleDbCommand(Ubah, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Ubah Data Berhasl ", MsgBoxStyle.Information, "Perhatian")
            Call TampilData()
            Call clear()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TxtIdPengguna.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TxtIdPengguna.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Yakin Mau Di Hapus" & TxtIdPengguna.Text &
                               " ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New OleDbCommand("Delete * from pengguna where id_pengguna='" & TxtIdPengguna.Text & "'", conn)
                cmd.ExecuteNonQuery()
                Call clear()
                Call TampilData()
            Else
                Call clear()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clear()
    End Sub
End Class