<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfosGodetsDI
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
        Me.ComboBoxClasse = New System.Windows.Forms.ComboBox()
        Me.ComboBoxLargeur = New System.Windows.Forms.ComboBox()
        Me.CheckBoxDeflecteur = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCaisson = New System.Windows.Forms.CheckBox()
        Me.ComboBoxFlanc = New System.Windows.Forms.ComboBox()
        Me.TextBoxVolume = New System.Windows.Forms.TextBox()
        Me.TextBoxAngDos = New System.Windows.Forms.TextBox()
        Me.TextBoxAngPos = New System.Windows.Forms.TextBox()
        Me.CheckBoxCR = New System.Windows.Forms.CheckBox()
        Me.CommandButton1 = New System.Windows.Forms.Button()
        Me.CommandButtonOK = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.AngDosReco = New System.Windows.Forms.Label()
        Me.AngPosReco = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxClasse
        '
        Me.ComboBoxClasse.FormattingEnabled = True
        Me.ComboBoxClasse.Location = New System.Drawing.Point(69, 56)
        Me.ComboBoxClasse.Name = "ComboBoxClasse"
        Me.ComboBoxClasse.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxClasse.TabIndex = 0
        '
        'ComboBoxLargeur
        '
        Me.ComboBoxLargeur.FormattingEnabled = True
        Me.ComboBoxLargeur.Location = New System.Drawing.Point(69, 98)
        Me.ComboBoxLargeur.Name = "ComboBoxLargeur"
        Me.ComboBoxLargeur.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxLargeur.TabIndex = 1
        '
        'CheckBoxDeflecteur
        '
        Me.CheckBoxDeflecteur.AutoSize = True
        Me.CheckBoxDeflecteur.Location = New System.Drawing.Point(69, 139)
        Me.CheckBoxDeflecteur.Name = "CheckBoxDeflecteur"
        Me.CheckBoxDeflecteur.Size = New System.Drawing.Size(81, 17)
        Me.CheckBoxDeflecteur.TabIndex = 2
        Me.CheckBoxDeflecteur.Text = "CheckBox1"
        Me.CheckBoxDeflecteur.UseVisualStyleBackColor = True
        '
        'CheckBoxCaisson
        '
        Me.CheckBoxCaisson.AutoSize = True
        Me.CheckBoxCaisson.Location = New System.Drawing.Point(69, 176)
        Me.CheckBoxCaisson.Name = "CheckBoxCaisson"
        Me.CheckBoxCaisson.Size = New System.Drawing.Size(81, 17)
        Me.CheckBoxCaisson.TabIndex = 3
        Me.CheckBoxCaisson.Text = "CheckBox2"
        Me.CheckBoxCaisson.UseVisualStyleBackColor = True
        '
        'ComboBoxFlanc
        '
        Me.ComboBoxFlanc.FormattingEnabled = True
        Me.ComboBoxFlanc.Location = New System.Drawing.Point(69, 213)
        Me.ComboBoxFlanc.Name = "ComboBoxFlanc"
        Me.ComboBoxFlanc.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxFlanc.TabIndex = 4
        '
        'TextBoxVolume
        '
        Me.TextBoxVolume.Location = New System.Drawing.Point(69, 253)
        Me.TextBoxVolume.Name = "TextBoxVolume"
        Me.TextBoxVolume.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxVolume.TabIndex = 5
        '
        'TextBoxAngDos
        '
        Me.TextBoxAngDos.Location = New System.Drawing.Point(69, 293)
        Me.TextBoxAngDos.Name = "TextBoxAngDos"
        Me.TextBoxAngDos.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxAngDos.TabIndex = 6
        '
        'TextBoxAngPos
        '
        Me.TextBoxAngPos.Location = New System.Drawing.Point(69, 336)
        Me.TextBoxAngPos.Name = "TextBoxAngPos"
        Me.TextBoxAngPos.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxAngPos.TabIndex = 7
        '
        'CheckBoxCR
        '
        Me.CheckBoxCR.AutoSize = True
        Me.CheckBoxCR.Location = New System.Drawing.Point(69, 379)
        Me.CheckBoxCR.Name = "CheckBoxCR"
        Me.CheckBoxCR.Size = New System.Drawing.Size(81, 17)
        Me.CheckBoxCR.TabIndex = 8
        Me.CheckBoxCR.Text = "CheckBox3"
        Me.CheckBoxCR.UseVisualStyleBackColor = True
        '
        'CommandButton1
        '
        Me.CommandButton1.Location = New System.Drawing.Point(69, 438)
        Me.CommandButton1.Name = "CommandButton1"
        Me.CommandButton1.Size = New System.Drawing.Size(75, 23)
        Me.CommandButton1.TabIndex = 11
        Me.CommandButton1.Text = "Annuler"
        Me.CommandButton1.UseVisualStyleBackColor = True
        '
        'CommandButtonOK
        '
        Me.CommandButtonOK.Location = New System.Drawing.Point(274, 438)
        Me.CommandButtonOK.Name = "CommandButtonOK"
        Me.CommandButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.CommandButtonOK.TabIndex = 12
        Me.CommandButtonOK.Text = "OK"
        Me.CommandButtonOK.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.AngPosReco)
        Me.Frame1.Controls.Add(Me.AngDosReco)
        Me.Frame1.Location = New System.Drawing.Point(241, 253)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(131, 129)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "GroupBox1"
        '
        'AngDosReco
        '
        Me.AngDosReco.AutoSize = True
        Me.AngDosReco.Location = New System.Drawing.Point(30, 47)
        Me.AngDosReco.Name = "AngDosReco"
        Me.AngDosReco.Size = New System.Drawing.Size(39, 13)
        Me.AngDosReco.TabIndex = 10
        Me.AngDosReco.Text = "Label1"
        '
        'AngPosReco
        '
        Me.AngPosReco.AutoSize = True
        Me.AngPosReco.Location = New System.Drawing.Point(30, 83)
        Me.AngPosReco.Name = "AngPosReco"
        Me.AngPosReco.Size = New System.Drawing.Size(39, 13)
        Me.AngPosReco.TabIndex = 11
        Me.AngPosReco.Text = "Label2"
        '
        'InfosGodetsDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 498)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.CommandButtonOK)
        Me.Controls.Add(Me.CommandButton1)
        Me.Controls.Add(Me.CheckBoxCR)
        Me.Controls.Add(Me.TextBoxAngPos)
        Me.Controls.Add(Me.TextBoxAngDos)
        Me.Controls.Add(Me.TextBoxVolume)
        Me.Controls.Add(Me.ComboBoxFlanc)
        Me.Controls.Add(Me.CheckBoxCaisson)
        Me.Controls.Add(Me.CheckBoxDeflecteur)
        Me.Controls.Add(Me.ComboBoxLargeur)
        Me.Controls.Add(Me.ComboBoxClasse)
        Me.Name = "InfosGodetsDI"
        Me.Text = "InfosGodetsDI"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxClasse As Windows.Forms.ComboBox
    Friend WithEvents ComboBoxLargeur As Windows.Forms.ComboBox
    Friend WithEvents CheckBoxDeflecteur As Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCaisson As Windows.Forms.CheckBox
    Friend WithEvents ComboBoxFlanc As Windows.Forms.ComboBox
    Friend WithEvents TextBoxVolume As Windows.Forms.TextBox
    Friend WithEvents TextBoxAngDos As Windows.Forms.TextBox
    Friend WithEvents TextBoxAngPos As Windows.Forms.TextBox
    Friend WithEvents CheckBoxCR As Windows.Forms.CheckBox
    Friend WithEvents CommandButton1 As Windows.Forms.Button
    Friend WithEvents CommandButtonOK As Windows.Forms.Button
    Friend WithEvents Frame1 As Windows.Forms.GroupBox
    Friend WithEvents AngPosReco As Windows.Forms.Label
    Friend WithEvents AngDosReco As Windows.Forms.Label
End Class
