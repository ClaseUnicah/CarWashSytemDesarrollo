<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGestionColor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LsvColor = New System.Windows.Forms.ListView()
        Me.ChIdColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ChColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.CmsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'LsvColor
        '
        Me.LsvColor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ChIdColor, Me.ChColor})
        Me.LsvColor.ContextMenuStrip = Me.CmsMenu
        Me.LsvColor.FullRowSelect = True
        Me.LsvColor.GridLines = True
        Me.LsvColor.Location = New System.Drawing.Point(2, 57)
        Me.LsvColor.Name = "LsvColor"
        Me.LsvColor.Size = New System.Drawing.Size(417, 359)
        Me.LsvColor.TabIndex = 0
        Me.LsvColor.UseCompatibleStateImageBehavior = False
        Me.LsvColor.View = System.Windows.Forms.View.Details
        '
        'ChIdColor
        '
        Me.ChIdColor.Text = "Código Color"
        Me.ChIdColor.Width = 100
        '
        'ChColor
        '
        Me.ChColor.Text = "Color"
        Me.ChColor.Width = 300
        '
        'CmsMenu
        '
        Me.CmsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.CmsMenu.Name = "CmsMenu"
        Me.CmsMenu.Size = New System.Drawing.Size(133, 52)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(132, 24)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(132, 24)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Location = New System.Drawing.Point(13, 12)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(75, 39)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'FrmGestionColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(420, 420)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.LsvColor)
        Me.Name = "FrmGestionColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión Color"
        Me.CmsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LsvColor As ListView
    Friend WithEvents ChIdColor As ColumnHeader
    Friend WithEvents ChColor As ColumnHeader
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents CmsMenu As ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
End Class
