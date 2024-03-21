Imports System.Data.OleDb

Public Class guru
    Sub clear() 'clear form'
        TxtIdGuru.Clear()
        TxtNama.Clear()
        ComboBox1.Text = ""
    End Sub

    Sub isi() 'mengisi form'
        TxtNama.Clear()
        TxtNama.Focus()
    End Sub

    Sub aturgrid() 'mengatur grid view'
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(0).HeaderText = "Id Guru"
        DataGridView1.Columns(1).HeaderText = "Nama Guru"
        DataGridView1.Columns(2).HeaderText = "Jenis Kelamin"
    End Sub

    Sub TampilData()
        da = New OleDbDataAdapter("select * from guru", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "guru")

        DataGridView1.DataSource = ds.Tables("guru")
        DataGridView1.Refresh()
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub guru_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
        aturgrid()
        clear()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(i)
            Me.TxtIdGuru.Text = .Cells(0).Value
            Me.TxtNama.Text = .Cells(1).Value
            Me.ComboBox1.Text = .Cells(2).Value
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TxtIdGuru.Text = "" Or TxtNama.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TxtIdGuru.Focus()
            Exit Sub
        Else
            cmd = New OleDbCommand("select * from guru where id_guru='" & TxtIdGuru.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then 'jika tidak dapat record'
                Dim simpan As String = "insert into guru(id_guru,nama,jenis_kelamin) values" & _
                    "('" & TxtIdGuru.Text & "','" & TxtNama.Text & "','" & ComboBox1.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasl Di Simpan", MsgBoxStyle.Information, "Perhatian")
            Else
                'Update Data'
                

                Dim Ubah As String = "update guru set " & _
                    "nama ='" & TxtNama.Text & "', " & _
                     "jenis_kelamin ='" & ComboBox1.Text & "' " & _
                    "where id_guru ='" & TxtIdGuru.Text & "'"
                cmd = New OleDbCommand(Ubah, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Ubah Data Berhasl ", MsgBoxStyle.Information, "Perhatian")
            End If
            TampilData()
            clear()
            TxtIdGuru.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TxtIdGuru.Text = "" Then
            MsgBox("No Urut Belum Diisi")
            TxtIdGuru.Focus()
            Exit Sub
        Else
            Dim Ubah As String = "update guru set " & _
                    "nama ='" & TxtNama.Text & "', " & _
                    "jenis_kelamin ='" & ComboBox1.Text & "' " & _
                    "where id_guru ='" & TxtIdGuru.Text & "'"
            cmd = New OleDbCommand(Ubah, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Ubaah Data Sukses...!!", MsgBoxStyle.Information, "Perhatian")
            Call TampilData()
            Call clear()
            TxtIdGuru.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TxtIdGuru.Text = "" Then
            MsgBox("Data Belum Lengkap")
            TxtIdGuru.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Yakin Mau Di Hapus" & TxtIdGuru.Text &
                               " ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New OleDbCommand("Delete * from guru where id_guru='" & TxtIdGuru.Text & "'", conn)
                cmd.ExecuteNonQuery()
                Call clear()
                Call TampilData()
            Else
                Call clear()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call clear()
    End Sub
End Class