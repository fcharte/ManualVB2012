﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchivo
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
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.CambiarColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.MenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TextBox1
      '
      Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TextBox1.Location = New System.Drawing.Point(0, 24)
      Me.TextBox1.Multiline = True
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(284, 237)
      Me.TextBox1.TabIndex = 6
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CambiarColorToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
      Me.MenuStrip1.TabIndex = 7
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'CambiarColorToolStripMenuItem
      '
      Me.CambiarColorToolStripMenuItem.Name = "CambiarColorToolStripMenuItem"
      Me.CambiarColorToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
      Me.CambiarColorToolStripMenuItem.Text = "Cambiar color"
      '
      'frmArchivo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 261)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.MenuStrip1)
      Me.Name = "frmArchivo"
      Me.Text = "frmArchivo"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents CambiarColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
