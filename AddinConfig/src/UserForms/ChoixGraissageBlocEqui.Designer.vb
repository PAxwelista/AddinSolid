<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoixGraissageBlocEqui
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BlocEqui = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.CommandButtonOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BlocEqui
        '
        Me.BlocEqui.AutoSize = True
        Me.BlocEqui.Location = New System.Drawing.Point(244, 59)
        Me.BlocEqui.Name = "BlocEqui"
        Me.BlocEqui.Size = New System.Drawing.Size(81, 17)
        Me.BlocEqui.TabIndex = 0
        Me.BlocEqui.Text = "CheckBox1"
        Me.BlocEqui.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Sans graissage centralisé", "Graissage TRAD", "Graissage TWIN"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(29, 31)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(177, 79)
        Me.CheckedListBox1.TabIndex = 1
        '
        'CommandButtonOk
        '
        Me.CommandButtonOk.Location = New System.Drawing.Point(58, 164)
        Me.CommandButtonOk.Name = "CommandButtonOk"
        Me.CommandButtonOk.Size = New System.Drawing.Size(75, 23)
        Me.CommandButtonOk.TabIndex = 2
        Me.CommandButtonOk.Text = "Ok"
        Me.CommandButtonOk.UseVisualStyleBackColor = True
        '
        'ChoixGraissageBlocEqui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CommandButtonOk)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.BlocEqui)
        Me.Name = "ChoixGraissageBlocEqui"
        Me.Text = "ChoixGraissageBlocEqui"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlocEqui As Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox1 As Windows.Forms.CheckedListBox
    Friend WithEvents CommandButtonOk As Windows.Forms.Button
End Class
