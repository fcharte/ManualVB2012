<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLapices
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
      Me.cbTerminadores = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cbTrazo = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'cbTerminadores
      '
      Me.cbTerminadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbTerminadores.DropDownWidth = 121
      Me.cbTerminadores.Location = New System.Drawing.Point(151, 30)
      Me.cbTerminadores.Name = "cbTerminadores"
      Me.cbTerminadores.Size = New System.Drawing.Size(121, 21)
      Me.cbTerminadores.TabIndex = 12
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(151, 14)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(71, 13)
      Me.Label2.TabIndex = 11
      Me.Label2.Text = "Terminadores"
      '
      'cbTrazo
      '
      Me.cbTrazo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbTrazo.DropDownWidth = 121
      Me.cbTrazo.Location = New System.Drawing.Point(7, 30)
      Me.cbTrazo.Name = "cbTrazo"
      Me.cbTrazo.Size = New System.Drawing.Size(121, 21)
      Me.cbTrazo.TabIndex = 13
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(7, 14)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(69, 13)
      Me.Label1.TabIndex = 10
      Me.Label1.Text = "Tipo de trazo"
      '
      'frmLapices
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 261)
      Me.Controls.Add(Me.cbTerminadores)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cbTrazo)
      Me.Controls.Add(Me.Label1)
      Me.Name = "frmLapices"
      Me.Text = "Lápices"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbTerminadores As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cbTrazo As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
