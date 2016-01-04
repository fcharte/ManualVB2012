<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.MenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
      Me.MenuStrip1.TabIndex = 4
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'ArchivoToolStripMenuItem
      '
      Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem})
      Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
      Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
      Me.ArchivoToolStripMenuItem.Text = "Archivo"
      '
      'NuevoToolStripMenuItem
      '
      Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
      Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.NuevoToolStripMenuItem.Text = "Nuevo"
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 261)
      Me.Controls.Add(Me.MenuStrip1)
      Me.IsMdiContainer = True
      Me.Name = "Form1"
      Me.Text = "Editor MDI"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
