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
      Me.lbDatos = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'lbDatos
      '
      Me.lbDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lbDatos.FormattingEnabled = True
      Me.lbDatos.Location = New System.Drawing.Point(0, 0)
      Me.lbDatos.Name = "lbDatos"
      Me.lbDatos.Size = New System.Drawing.Size(284, 261)
      Me.lbDatos.TabIndex = 3
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 261)
      Me.Controls.Add(Me.lbDatos)
      Me.Name = "Form1"
      Me.Text = "Información del entorno"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lbDatos As System.Windows.Forms.ListBox

End Class
