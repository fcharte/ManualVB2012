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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Button2 = New System.Windows.Forms.Button()
      Me.tbNombreImpresora = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.Button3 = New System.Windows.Forms.Button()
      Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
      Me.SuspendLayout()
      '
      'PrintDocument1
      '
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(226, 254)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 13
      Me.Button1.Text = "Imprimir"
      '
      'PrintPreviewDialog1
      '
      Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
      Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
      Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
      Me.PrintPreviewDialog1.Document = Me.PrintDocument1
      Me.PrintPreviewDialog1.Enabled = True
      Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
      Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
      Me.PrintPreviewDialog1.UseAntiAlias = True
      Me.PrintPreviewDialog1.Visible = False
      '
      'ListBox1
      '
      Me.ListBox1.Location = New System.Drawing.Point(24, 105)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(277, 95)
      Me.ListBox1.TabIndex = 20
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(24, 89)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(208, 23)
      Me.Label2.TabIndex = 19
      Me.Label2.Text = "Impresoras disponibles"
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(245, 42)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(56, 24)
      Me.Button2.TabIndex = 18
      Me.Button2.Text = "Cambiar"
      '
      'tbNombreImpresora
      '
      Me.tbNombreImpresora.Location = New System.Drawing.Point(21, 45)
      Me.tbNombreImpresora.Name = "tbNombreImpresora"
      Me.tbNombreImpresora.ReadOnly = True
      Me.tbNombreImpresora.Size = New System.Drawing.Size(208, 20)
      Me.tbNombreImpresora.TabIndex = 17
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(21, 29)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(136, 23)
      Me.Label1.TabIndex = 16
      Me.Label1.Text = "Impresora seleccionada"
      '
      'PrintDialog1
      '
      Me.PrintDialog1.UseEXDialog = True
      '
      'Button3
      '
      Me.Button3.Location = New System.Drawing.Point(24, 254)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(104, 23)
      Me.Button3.TabIndex = 21
      Me.Button3.Text = "Configurar página"
      '
      'PageSetupDialog1
      '
      Me.PageSetupDialog1.Document = Me.PrintDocument1
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(334, 305)
      Me.Controls.Add(Me.Button3)
      Me.Controls.Add(Me.ListBox1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.tbNombreImpresora)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Button1)
      Me.Name = "Form1"
      Me.Text = "Impresión de un documento"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents tbNombreImpresora As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents Button3 As System.Windows.Forms.Button
   Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog

End Class
