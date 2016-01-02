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
      Me.Button1 = New System.Windows.Forms.Button()
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(56, 178)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 7
      Me.Button1.Text = "Ordenar"
      '
      'ListBox1
      '
      Me.ListBox1.FormattingEnabled = True
      Me.ListBox1.Location = New System.Drawing.Point(12, 12)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(179, 160)
      Me.ListBox1.TabIndex = 6
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(198, 211)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.ListBox1)
      Me.Name = "Form1"
      Me.Text = "Lista ordenada"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

End Class
