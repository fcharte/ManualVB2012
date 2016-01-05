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
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'ListBox1
      '
      Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ListBox1.FormattingEnabled = True
      Me.ListBox1.Location = New System.Drawing.Point(12, 12)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(436, 342)
      Me.ListBox1.TabIndex = 3
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(460, 373)
      Me.Controls.Add(Me.ListBox1)
      Me.Name = "Form1"
      Me.Text = "Acceso al registro"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

End Class
