<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FenetreChoixCopier
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxType = New System.Windows.Forms.ComboBox()
        Me.ValideCopie = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Séléectionner le type de godet que vous voulez copier"
        '
        'ComboBoxType
        '
        Me.ComboBoxType.FormattingEnabled = True
        Me.ComboBoxType.Location = New System.Drawing.Point(29, 52)
        Me.ComboBoxType.Name = "ComboBoxType"
        Me.ComboBoxType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxType.TabIndex = 1
        '
        'ValideCopie
        '
        Me.ValideCopie.Location = New System.Drawing.Point(184, 50)
        Me.ValideCopie.Name = "ValideCopie"
        Me.ValideCopie.Size = New System.Drawing.Size(75, 23)
        Me.ValideCopie.TabIndex = 2
        Me.ValideCopie.Text = "OK"
        Me.ValideCopie.UseVisualStyleBackColor = True
        '
        'FenetreChoixCopier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ValideCopie)
        Me.Controls.Add(Me.ComboBoxType)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FenetreChoixCopier"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ComboBoxType As Windows.Forms.ComboBox
    Friend WithEvents ValideCopie As Windows.Forms.Button
End Class
