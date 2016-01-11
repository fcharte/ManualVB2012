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
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.bibliotecaDataSet = New Informes.bibliotecaDataSet()
      Me.librosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.librosTableAdapter = New Informes.bibliotecaDataSetTableAdapters.librosTableAdapter()
      CType(Me.bibliotecaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.librosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "DataSet1"
      ReportDataSource1.Value = Me.librosBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Informes.Report1.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.Size = New System.Drawing.Size(420, 271)
      Me.ReportViewer1.TabIndex = 0
      '
      'bibliotecaDataSet
      '
      Me.bibliotecaDataSet.DataSetName = "bibliotecaDataSet"
      Me.bibliotecaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'librosBindingSource
      '
      Me.librosBindingSource.DataMember = "libros"
      Me.librosBindingSource.DataSource = Me.bibliotecaDataSet
      '
      'librosTableAdapter
      '
      Me.librosTableAdapter.ClearBeforeFill = True
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(420, 271)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "Form1"
      Me.Text = "Informe"
      CType(Me.bibliotecaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.librosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents librosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents bibliotecaDataSet As Informes.bibliotecaDataSet
   Friend WithEvents librosTableAdapter As Informes.bibliotecaDataSetTableAdapters.librosTableAdapter

End Class
