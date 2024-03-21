Imports System.Data.OleDb

Public Class CalonKetuaOsis
    Sub clear() 'clear form'
        Txtnourut.Clear()
        Txtnamacalon.Clear()

    End Sub

    Sub isi() 'mengisi form'
        Txtnamacalon.Clear()
        Txtnamacalon.Focus()
    End Sub


    Sub TampilData() 'menampilkan data'
        da = New OleDbDataAdapter("select * from caketos", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "caketos")

        DataGridView1.DataSource = ds.Tables("caketos")
        DataGridView1.Refresh()
    End Sub

    Sub aturgrid() 'mengatur grid view'
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(0).HeaderText = "No Urut"
        DataGridView1.Columns(1).HeaderText = "Nama Calon"
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub CalonKetuaOsis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
        aturgrid()
        clear()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = Me.DataGridView1.CurrentRow.Index
        With DataGridView1.Rows.Item(i)
            Me.Txtnourut.Text = .Cells(0).Value
            Me.Txtnamacalon.Text = .Cells(1).Value
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub Btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsimpan.Click
        If Txtnourut.Text = "" Or Txtnamacalon.Text = "" Then
            MsgBox("Data Belum Lengkap")
            Txtnourut.Focus()
            Exit Sub
        Else
            cmd = New OleDbCommand("select * from caketos where NoUrut='" & Txtnourut.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then 'jika tidak dapat record'
                Dim simpan As String = "insert into caketos(NoUrut,NamaCalon) values" & _
                    "('" & Txtnourut.Text & "','" & Txtnamacalon.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasl Di Simpan", MsgBoxStyle.Information, "Perhatian")
            Else
                'Update Data'
                Dim Ubah As String = "update caketos set " & _
                    "NamaCalon ='" & Txtnamacalon.Text & "' " & _
                    "where NoUrut ='" & Txtnourut.Text & "'"
                cmd = New OleDbCommand(Ubah, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Ubah Data Berhasl ", MsgBoxStyle.Information, "Perhatian")
            End If
            TampilData()
            clear()
            Txtnourut.Focus()
        End If
    End Sub

    Private Sub Txtnourut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtnourut.TextChanged
       
    End Sub

    Private Sub Btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnubah.Click
        If Txtnourut.Text = "" Then
            MsgBox("No Urut Belum Diisi")
            Txtnourut.Focus()
            Exit Sub
        Else
            Dim Ubah As String = "Update caketos set " & _
                "NamaCalon='" & Txtnamacalon.Text & "' " & _
                "where NoUrut='" & Txtnourut.Text & "'"
            cmd = New OleDbCommand(Ubah, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Ubaah Data Sukses...!!", MsgBoxStyle.Information, "Perhatian")
            Call TampilData()
            Call clear()
            Txtnourut.Focus()
        End If
    End Sub

    Private Sub Btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btntambah.Click
        Call clear()

    End Sub

    Private Sub Btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnhapus.Click
        If Txtnourut.Text = "" Then
            MsgBox("Data Belum Lengkap")
            Txtnourut.Focus()
            Exit Sub
        Else
            If MessageBox.Show("Yakin Mau Di Hapus" & Txtnourut.Text &
                               " ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New OleDbCommand("Delete * from caketos where NoUrut='" & Txtnourut.Text & "'", conn)
                cmd.ExecuteNonQuery()
                Call clear()
                Call TampilData()
            Else
                Call clear()
            End If
        End If
    End Sub
End Class