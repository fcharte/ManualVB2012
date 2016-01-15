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
      Me.lbTamano = New System.Windows.Forms.Label()
      Me.btnDescomprimir = New System.Windows.Forms.Button()
      Me.btnComprimir = New System.Windows.Forms.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.lbArchivos = New System.Windows.Forms.ListBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.lbCarpetas = New System.Windows.Forms.ListBox()
      Me.cbUnidades = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'lbTamano
      '
      Me.lbTamano.AutoSize = True
      Me.lbTamano.Location = New System.Drawing.Point(207, 206)
      Me.lbTamano.Name = "lbTamano"
      Me.lbTamano.Size = New System.Drawing.Size(41, 13)
      Me.lbTamano.TabIndex = 42
      Me.lbTamano.Text = "0 bytes"
      '
      'btnDescomprimir
      '
      Me.btnDescomprimir.Location = New System.Drawing.Point(309, 239)
      Me.btnDescomprimir.Name = "btnDescomprimir"
      Me.btnDescomprimir.Size = New System.Drawing.Size(86, 23)
      Me.btnDescomprimir.TabIndex = 41
      Me.btnDescomprimir.Text = "Descomprimir"
      '
      'btnComprimir
      '
      Me.btnComprimir.Location = New System.Drawing.Point(207, 238)
      Me.btnComprimir.Name = "btnComprimir"
      Me.btnComprimir.Size = New System.Drawing.Size(75, 23)
      Me.btnComprimir.TabIndex = 40
      Me.btnComprimir.Text = "Comprimir"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(208, 18)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(113, 13)
      Me.Label3.TabIndex = 35
      Me.Label3.Text = "Seleccione un archivo"
      '
      'lbArchivos
      '
      Me.lbArchivos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lbArchivos.FormattingEnabled = True
      Me.lbArchivos.Location = New System.Drawing.Point(208, 34)
      Me.lbArchivos.Name = "lbArchivos"
      Me.lbArchivos.Size = New System.Drawing.Size(279, 160)
      Me.lbArchivos.TabIndex = 39
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 66)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(120, 13)
      Me.Label2.TabIndex = 34
      Me.Label2.Text = "Seleccione una carpeta"
      '
      'lbCarpetas
      '
      Me.lbCarpetas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lbCarpetas.FormattingEnabled = True
      Me.lbCarpetas.Location = New System.Drawing.Point(16, 82)
      Me.lbCarpetas.Name = "lbCarpetas"
      Me.lbCarpetas.Size = New System.Drawing.Size(160, 186)
      Me.lbCarpetas.TabIndex = 38
      '
      'cbUnidades
      '
      Me.cbUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbUnidades.DropDownWidth = 120
      Me.cbUnidades.FormattingEnabled = True
      Me.cbUnidades.Location = New System.Drawing.Point(16, 34)
      Me.cbUnidades.Name = "cbUnidades"
      Me.cbUnidades.Size = New System.Drawing.Size(160, 21)
      Me.cbUnidades.TabIndex = 37
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 18)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(116, 13)
      Me.Label1.TabIndex = 36
      Me.Label1.Text = "Seleccione una unidad"
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(508, 279)
      Me.Controls.Add(Me.lbTamano)
      Me.Controls.Add(Me.btnDescomprimir)
      Me.Controls.Add(Me.btnComprimir)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.lbArchivos)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.lbCarpetas)
      Me.Controls.Add(Me.cbUnidades)
      Me.Controls.Add(Me.Label1)
      Me.Name = "Form1"
      Me.Text = "Compresión de archivos"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lbTamano As System.Windows.Forms.Label
   Friend WithEvents btnDescomprimir As System.Windows.Forms.Button
   Friend WithEvents btnComprimir As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lbArchivos As System.Windows.Forms.ListBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents lbCarpetas As System.Windows.Forms.ListBox
   Friend WithEvents cbUnidades As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
