Imports System.Data.OleDb
Public Class fromMenu
    Sub keluar()
        MasterToolStripMenuItem.Visible = False
        PemilihanToolStripMenuItem.Visible = False
        LaporanToolStripMenuItem.Visible = False
        LoginToolStripMenuItem.Enabled = True
        LogoutToolStripMenuItem.Enabled = False
    End Sub
    Sub masukadmin()
        MasterToolStripMenuItem.Visible = True
        PemilihanToolStripMenuItem.Visible = True
        LaporanToolStripMenuItem.Visible = True
        LoginToolStripMenuItem.Enabled = False
        LogoutToolStripMenuItem.Enabled = True
    End Sub
    Sub masukuser()
        MasterToolStripMenuItem.Visible = False
        PemilihanToolStripMenuItem.Visible = True
        LaporanToolStripMenuItem.Visible = False
        LoginToolStripMenuItem.Enabled = False
        LogoutToolStripMenuItem.Enabled = True
    End Sub

    Private Sub SiswaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SiswaToolStripMenuItem.Click
        siswa.Show()
        siswa.MdiParent = Me

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub GuruToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuruToolStripMenuItem.Click
        guru.Show()
        guru.MdiParent = Me
    End Sub

    Private Sub CaketosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaketosToolStripMenuItem.Click
        CalonKetuaOsis.Show()
        CalonKetuaOsis.MdiParent = Me
    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        user.Show()
        user.MdiParent = Me
    End Sub

    Private Sub CaketosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaketosToolStripMenuItem1.Click
        FrmPemilihan.Show()
        FrmPemilihan.MdiParent = Me

    End Sub

    Private Sub HasilPemilihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HasilPemilihanToolStripMenuItem.Click
        TPS.Show()
        TPS.MdiParent = Me
    End Sub

    Private Sub PenggunaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenggunaToolStripMenuItem.Click
        Pengguna.Show()
        Pengguna.MdiParent = Me
    End Sub

    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call keluar()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        LoginForm1.Show()
        LoginForm1.MdiParent = Me
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Call keluar()

    End Sub
End Class
