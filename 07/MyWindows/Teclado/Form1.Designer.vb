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
      Me.cbScroll = New System.Windows.Forms.CheckBox()
      Me.cbMayus = New System.Windows.Forms.CheckBox()
      Me.cbControl = New System.Windows.Forms.CheckBox()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.cbNum = New System.Windows.Forms.CheckBox()
      Me.cbCaps = New System.Windows.Forms.CheckBox()
      Me.cbAlt = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      '
      'cbScroll
      '
      Me.cbScroll.AutoSize = True
      Me.cbScroll.Location = New System.Drawing.Point(151, 90)
      Me.cbScroll.Name = "cbScroll"
      Me.cbScroll.Size = New System.Drawing.Size(80, 17)
      Me.cbScroll.TabIndex = 23
      Me.cbScroll.Text = "Bloq. Despl"
      '
      'cbMayus
      '
      Me.cbMayus.AutoSize = True
      Me.cbMayus.Location = New System.Drawing.Point(25, 90)
      Me.cbMayus.Name = "cbMayus"
      Me.cbMayus.Size = New System.Drawing.Size(57, 17)
      Me.cbMayus.TabIndex = 20
      Me.cbMayus.Text = "Mayús"
      '
      'cbControl
      '
      Me.cbControl.AutoSize = True
      Me.cbControl.Location = New System.Drawing.Point(25, 55)
      Me.cbControl.Name = "cbControl"
      Me.cbControl.Size = New System.Drawing.Size(59, 17)
      Me.cbControl.TabIndex = 19
      Me.cbControl.Text = "Control"
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      '
      'cbNum
      '
      Me.cbNum.AutoSize = True
      Me.cbNum.Location = New System.Drawing.Point(151, 55)
      Me.cbNum.Name = "cbNum"
      Me.cbNum.Size = New System.Drawing.Size(75, 17)
      Me.cbNum.TabIndex = 22
      Me.cbNum.Text = "Bloq. Núm"
      '
      'cbCaps
      '
      Me.cbCaps.AutoSize = True
      Me.cbCaps.Location = New System.Drawing.Point(151, 21)
      Me.cbCaps.Name = "cbCaps"
      Me.cbCaps.Size = New System.Drawing.Size(84, 17)
      Me.cbCaps.TabIndex = 21
      Me.cbCaps.Text = "Bloq. Mayús"
      '
      'cbAlt
      '
      Me.cbAlt.AutoSize = True
      Me.cbAlt.Location = New System.Drawing.Point(25, 21)
      Me.cbAlt.Name = "cbAlt"
      Me.cbAlt.Size = New System.Drawing.Size(38, 17)
      Me.cbAlt.TabIndex = 18
      Me.cbAlt.Text = "Alt"
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(274, 127)
      Me.Controls.Add(Me.cbScroll)
      Me.Controls.Add(Me.cbMayus)
      Me.Controls.Add(Me.cbControl)
      Me.Controls.Add(Me.cbNum)
      Me.Controls.Add(Me.cbCaps)
      Me.Controls.Add(Me.cbAlt)
      Me.Name = "Form1"
      Me.Text = "Estado del teclado"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cbScroll As System.Windows.Forms.CheckBox
   Friend WithEvents cbMayus As System.Windows.Forms.CheckBox
   Friend WithEvents cbControl As System.Windows.Forms.CheckBox
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents cbNum As System.Windows.Forms.CheckBox
   Friend WithEvents cbCaps As System.Windows.Forms.CheckBox
   Friend WithEvents cbAlt As System.Windows.Forms.CheckBox

End Class
