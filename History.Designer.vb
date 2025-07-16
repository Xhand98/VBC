<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
        title = New Label()
        DataGridView1 = New DataGridView()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' title
        ' 
        title.AutoSize = True
        title.Font = New Font("SF Mono", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        title.Location = New Point(125, 22)
        title.Name = "title"
        title.Size = New Size(118, 23)
        title.TabIndex = 0
        title.Text = "Historial"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 64)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(343, 374)
        DataGridView1.TabIndex = 1
        ' 
        ' History
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(378, 472)
        Controls.Add(DataGridView1)
        Controls.Add(title)
        Name = "History"
        Text = "History"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents title As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
