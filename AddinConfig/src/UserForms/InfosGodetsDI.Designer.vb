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
        Me.AngPosReco = New System.Windows.Forms.Label()
        Me.AngDosReco = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxClasse
        '
        Me.ComboBoxClasse.FormattingEnabled = True
        Me.ComboBoxClasse.Location = New System.Drawing.Point(69, 56)
        Me.ComboBoxClasse.Name = "ComboBoxClasse"
        Me.ComboBoxClasse.Size = New System.Drawing.Size(100, 21)
        Me.ComboBoxClasse.TabIndex = 0
        '
        'ComboBoxLargeur
        '
        Me.ComboBoxLargeur.FormattingEnabled = True
        Me.ComboBoxLargeur.Location = New System.Drawing.Point(69, 98)
        Me.ComboBoxLargeur.Name = "ComboBoxLargeur"
        Me.ComboBoxLargeur.Size = New System.Drawing.Size(100, 21)
        Me.ComboBoxLargeur.TabIndex = 1
        '
        'CheckBoxDeflecteur
        '
        Me.CheckBoxDeflecteur.AutoSize = True
        Me.CheckBoxDeflecteur.Location = New System.Drawing.Point(69, 139)
        Me.CheckBoxDeflecteur.Name = "CheckBoxDeflecteur"
        Me.CheckBoxDeflecteur.Size = New System.Drawing.Size(75, 17)
        Me.CheckBoxDeflecteur.TabIndex = 2
        Me.CheckBoxDeflecteur.Text = "Déflecteur"
        Me.CheckBoxDeflecteur.UseVisualStyleBackColor = True
        '
        'CheckBoxCaisson
        '
        Me.CheckBoxCaisson.AutoSize = True
        Me.CheckBoxCaisson.Location = New System.Drawing.Point(69, 176)
        Me.CheckBoxCaisson.Name = "CheckBoxCaisson"
        Me.CheckBoxCaisson.Size = New System.Drawing.Size(63, 17)
        Me.CheckBoxCaisson.TabIndex = 3
        Me.CheckBoxCaisson.Text = "Caisson"
        Me.CheckBoxCaisson.UseVisualStyleBackColor = True
        '
        'ComboBoxFlanc
        '
        Me.ComboBoxFlanc.FormattingEnabled = True
        Me.ComboBoxFlanc.Location = New System.Drawing.Point(69, 213)
        Me.ComboBoxFlanc.Name = "ComboBoxFlanc"
        Me.ComboBoxFlanc.Size = New System.Drawing.Size(100, 21)
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
        Me.CheckBoxCR.Size = New System.Drawing.Size(103, 17)
        Me.CheckBoxCR.TabIndex = 8
        Me.CheckBoxCR.Text = "Caisson rallongé"
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
        Me.CommandButtonOK.Location = New System.Drawing.Point(342, 438)
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
        Me.Frame1.Location = New System.Drawing.Point(309, 253)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(131, 129)
        Me.Frame1.TabIndex = 13
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Recommandé"
        Me.Frame1.Visible = False
        '
        'AngPosReco
        '
        Me.AngPosReco.AutoSize = True
        Me.AngPosReco.Location = New System.Drawing.Point(30, 83)
        Me.AngPosReco.Name = "AngPosReco"
        Me.AngPosReco.Size = New System.Drawing.Size(33, 13)
        Me.AngPosReco.TabIndex = 11
        Me.AngPosReco.Text = "None"
        '
        'AngDosReco
        '
        Me.AngDosReco.AutoSize = True
        Me.AngDosReco.Location = New System.Drawing.Point(30, 47)
        Me.AngDosReco.Name = "AngDosReco"
        Me.AngDosReco.Size = New System.Drawing.Size(33, 13)
        Me.AngDosReco.TabIndex = 10
        Me.AngDosReco.Text = "None"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Classe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Largeur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(176, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Flanc"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 260)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Volume"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(175, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Angle dos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(175, 343)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = " Angle position"
        '
        'InfosGodetsDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 498)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
End Class
