<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalonKetuaOsis
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtnourut = New System.Windows.Forms.TextBox()
        Me.Txtnamacalon = New System.Windows.Forms.TextBox()
        Me.Btntambah = New System.Windows.Forms.Button()
        Me.Btnsimpan = New System.Windows.Forms.Button()
        Me.Btnubah = New System.Windows.Forms.Button()
        Me.Btnhapus = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btkeluar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Urut"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Calon"
        '
        'Txtnourut
        '
        Me.Txtnourut.Location = New System.Drawing.Point(85, 22)
        Me.Txtnourut.Name = "Txtnourut"
        Me.Txtnourut.Size = New System.Drawing.Size(112, 20)
        Me.Txtnourut.TabIndex = 2
        '
        'Txtnamacalon
        '
        Me.Txtnamacalon.Location = New System.Drawing.Point(84, 53)
        Me.Txtnamacalon.Name = "Txtnamacalon"
        Me.Txtnamacalon.Size = New System.Drawing.Size(188, 20)
        Me.Txtnamacalon.TabIndex = 3
        '
        'Btntambah
        '
        Me.Btntambah.Location = New System.Drawing.Point(7, 95)
        Me.Btntambah.Name = "Btntambah"
        Me.Btntambah.Size = New System.Drawing.Size(61, 23)
        Me.Btntambah.TabIndex = 4
        Me.Btntambah.Text = "Clear"
        Me.Btntambah.UseVisualStyleBackColor = True
        '
        'Btnsimpan
        '
        Me.Btnsimpan.Location = New System.Drawing.Point(78, 95)
        Me.Btnsimpan.Name = "Btnsimpan"
        Me.Btnsimpan.Size = New System.Drawing.Size(61, 23)
        Me.Btnsimpan.TabIndex = 5
        Me.Btnsimpan.Text = "Simpan"
        Me.Btnsimpan.UseVisualStyleBackColor = True
        '
        'Btnubah
        '
        Me.Btnubah.Location = New System.Drawing.Point(148, 95)
        Me.Btnubah.Name = "Btnubah"
        Me.Btnubah.Size = New System.Drawing.Size(61, 23)
        Me.Btnubah.TabIndex = 6
        Me.Btnubah.Text = "Ubah"
        Me.Btnubah.UseVisualStyleBackColor = True
        '
        'Btnhapus
        '
        Me.Btnhapus.Location = New System.Drawing.Point(218, 95)
        Me.Btnhapus.Name = "Btnhapus"
        Me.Btnhapus.Size = New System.Drawing.Size(61, 23)
        Me.Btnhapus.TabIndex = 7
        Me.Btnhapus.Text = "Hapus"
        Me.Btnhapus.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 126)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(272, 130)
        Me.DataGridView1.TabIndex = 8
        '
        'btkeluar
        '
        Me.btkeluar.Location = New System.Drawing.Point(7, 262)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(272, 23)
        Me.btkeluar.TabIndex = 14
        Me.btkeluar.Text = "Keluar"
        Me.btkeluar.UseVisualStyleBackColor = True
        '
        'CalonKetuaOsis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 294)
        Me.Controls.Add(Me.btkeluar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Btnhapus)
        Me.Controls.Add(Me.Btnubah)
        Me.Controls.Add(Me.Btnsimpan)
        Me.Controls.Add(Me.Btntambah)
        Me.Controls.Add(Me.Txtnamacalon)
        Me.Controls.Add(Me.Txtnourut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CalonKetuaOsis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "caketos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtnourut As System.Windows.Forms.TextBox
    Friend WithEvents Txtnamacalon As System.Windows.Forms.TextBox
    Friend WithEvents Btntambah As System.Windows.Forms.Button
    Friend WithEvents Btnsimpan As System.Windows.Forms.Button
    Friend WithEvents Btnubah As System.Windows.Forms.Button
    Friend WithEvents Btnhapus As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btkeluar As System.Windows.Forms.Button
End Class
