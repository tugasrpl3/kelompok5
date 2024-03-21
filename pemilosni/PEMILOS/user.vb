Imports System.Data.OleDb

Public Class user
    Sub TampilData() 'menampilkan data'
        da = New OleDbDataAdapter("select * from pengguna", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "pengguna")

        DataGridView1.DataSource = ds.Tables("pengguna")
        DataGridView1.Refresh()
    End Sub

    Sub aturgrid() 'mengatur grid view'
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(0).HeaderText = "Id User"
        DataGridView1.Columns(1).HeaderText = "Username"
        DataGridView1.Columns(2).HeaderText = "Paswword"
        DataGridView1.Columns(3).HeaderText = "Level"
    End Sub

    Private Sub btkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

    Private Sub user_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        TampilData()
        aturgrid()
    End Sub
End Class