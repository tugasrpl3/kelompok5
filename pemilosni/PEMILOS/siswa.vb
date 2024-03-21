Imports System.Data.OleDb

Public Class siswa
    Sub clear() 'clear form'
        TxtNis.Clear()
        TxtNama.Clear()
        TxtKelas.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Sub isi() 'mengisi form'
        TxtNama.Clear()
        TxtNama.Focus()
    End Sub

    Sub aturgrid() 'mengatur grid view'
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 35
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(0).HeaderText = "Nis"
        DataGridView1.Columns(1).HeaderText = "Nama Siswa"
        DataGridView1.Columns(2).HeaderText = "Jenis Kelamin"
        DataGridView1.Columns(3).HeaderText = "Kelas"
        DataGridView1.Columns(4).HeaderText = "Jurusan"
    End Sub

    Sub TampilData()
        da = New OleDbDataAdapter("select * from siswa", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "siswa")

        DataGridView1.DataSource = ds.Tables("siswa")
        DataGridView1.Refresh()
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub siswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
        aturgrid()
        clear()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(i)
            Me.TxtNis.Text = .Cells(0).Value
            Me.TxtNama.Text = .Cells(1).Value
            Me.ComboBox1.Text = .Cells(2).Value
            Me.TxtKelas.Text = .Cells(3).Value
            Me.ComboBox2.Text = .Cells(4).Value
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TxtNis.Text = "" Or TxtNama.Text = "" Or ComboBox1.Text = "" Or TxtKelas.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TxtNis.Focus()
            Exit Sub
        Else
            cmd = New OleDbCommand("select * from siswa where nis='" & TxtNis.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then 'jika tidak dapat record'
                Dim simpan As String = "insert into siswa(nis,nama,jenis_kelamin,kelas,jurusan) values" & _
                    "('" & TxtNis.Text & "','" & TxtNama.Text & "','" & ComboBox1.Text & "','" & TxtKelas.Text & "','" & ComboBox2.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasl Di Simpan", MsgBoxStyle.Information, "Perhatian")
            Else
                'Update Data'
                Dim Ubah As String = "update siswa set " & _
                    "nama ='" & TxtNama.Text & "', " & _
                     "jenis_kelamin ='" & ComboBox1.Text & "', " & _
                     "kelas ='" & TxtKelas.Text & "', " & _
                     "jurusan ='" & ComboBox2.Text & "' " & _
                    "where nis ='" & TxtNis.Text & "'"
                cmd = New OleDbCommand(Ubah, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Ubah Data Berhasl ", MsgBoxStyle.Information, "Perhatian")
            End If
            TampilData()
            clear()
            TxtNis.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TxtNis.Text = "" Then
            MsgBox("No Urut Belum Diisi")
            TxtNis.Focus()
            Exit Sub
        Else
            Dim Ubah As String = "update siswa set " & _
                     "nama ='" & TxtNama.Text & "', " & _
                      "jenis_kelamin ='" & ComboBox1.Text & "', " & _
                      "kelas ='" & TxtKelas.Text & "', " & _
                      "jurusan ='" & ComboBox2.Text & "' " & _
                     "where nis ='" & TxtNis.Text & "'"
            cmd = New OleDbCommand(Ubah, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Ubah Data Berhasl ", MsgBoxStyle.Information, "Perhatian")
            Call TampilData()
            Call clear()
            TxtNis.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TxtNis.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TxtNis.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Yakin Mau Di Hapus" & TxtNis.Text &
                               " ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New OleDbCommand("Delete * from siswa where nis='" & TxtNis.Text & "'", conn)
                cmd.ExecuteNonQuery()
                Call clear()
                Call TampilData()
            Else
                Call clear()
            End If
        End If
    End Sub
End Class