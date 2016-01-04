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
      Me.components = New System.ComponentModel.Container()
      Me.lbDatos = New System.Windows.Forms.ListBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.tbDato = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.SuspendLayout()
      '
      'lbDatos
      '
      Me.lbDatos.FormattingEnabled = True
      Me.lbDatos.Location = New System.Drawing.Point(10, 72)
      Me.lbDatos.Name = "lbDatos"
      Me.lbDatos.Size = New System.Drawing.Size(264, 173)
      Me.lbDatos.TabIndex = 15
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(203, 28)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 14
      Me.Button1.Text = "Añadir"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'tbDato
      '
      Me.tbDato.Location = New System.Drawing.Point(10, 32)
      Me.tbDato.Name = "tbDato"
      Me.tbDato.Size = New System.Drawing.Size(168, 20)
      Me.tbDato.TabIndex = 13
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(7, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(71, 13)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Dato a añadir"
      '
      'ImageList1
      '
      Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
      Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 261)
      Me.Controls.Add(Me.lbDatos)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.tbDato)
      Me.Controls.Add(Me.Label1)
      Me.Name = "Form1"
      Me.Text = "Aplicación simple"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lbDatos As System.Windows.Forms.ListBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents tbDato As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
