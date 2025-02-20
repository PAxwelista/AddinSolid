<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoixMachine
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
        Me.Marque = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBoxMarque = New System.Windows.Forms.ListBox()
        Me.ListBoxModele = New System.Windows.Forms.ListBox()
        Me.ListBoxVersion = New System.Windows.Forms.ListBox()
        Me.CheckBoxAD = New System.Windows.Forms.CheckBox()
        Me.CommandButtonOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Marque
        '
        Me.Marque.AutoSize = True
        Me.Marque.Location = New System.Drawing.Point(42, 24)
        Me.Marque.Name = "Marque"
        Me.Marque.Size = New System.Drawing.Size(43, 13)
        Me.Marque.TabIndex = 0
        Me.Marque.Text = "Marque"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modèle"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(381, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Version"
        '
        'ListBoxMarque
        '
        Me.ListBoxMarque.FormattingEnabled = True
        Me.ListBoxMarque.Location = New System.Drawing.Point(12, 55)
        Me.ListBoxMarque.Name = "ListBoxMarque"
        Me.ListBoxMarque.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxMarque.TabIndex = 3
        '
        'ListBoxModele
        '
        Me.ListBoxModele.FormattingEnabled = True
        Me.ListBoxModele.Location = New System.Drawing.Point(178, 55)
        Me.ListBoxModele.Name = "ListBoxModele"
        Me.ListBoxModele.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxModele.TabIndex = 4
        '
        'ListBoxVersion
        '
        Me.ListBoxVersion.FormattingEnabled = True
        Me.ListBoxVersion.Location = New System.Drawing.Point(344, 55)
        Me.ListBoxVersion.Name = "ListBoxVersion"
        Me.ListBoxVersion.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxVersion.TabIndex = 5
        '
        'CheckBoxAD
        '
        Me.CheckBoxAD.AutoSize = True
        Me.CheckBoxAD.Location = New System.Drawing.Point(45, 393)
        Me.CheckBoxAD.Name = "CheckBoxAD"
        Me.CheckBoxAD.Size = New System.Drawing.Size(98, 17)
        Me.CheckBoxAD.TabIndex = 6
        Me.CheckBoxAD.Text = "Attahce directe"
        Me.CheckBoxAD.UseVisualStyleBackColor = True
        '
        'CommandButtonOk
        '
        Me.CommandButtonOk.Location = New System.Drawing.Point(330, 393)
        Me.CommandButtonOk.Name = "CommandButtonOk"
        Me.CommandButtonOk.Size = New System.Drawing.Size(75, 23)
        Me.CommandButtonOk.TabIndex = 7
        Me.CommandButtonOk.Text = "OK"
        Me.CommandButtonOk.UseVisualStyleBackColor = True
        '
        'ChoixMachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CommandButtonOk)
        Me.Controls.Add(Me.CheckBoxAD)
        Me.Controls.Add(Me.ListBoxVersion)
        Me.Controls.Add(Me.ListBoxModele)
        Me.Controls.Add(Me.ListBoxMarque)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Marque)
        Me.Name = "ChoixMachine"
        Me.Text = "ChoixMachine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Marque As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ListBoxMarque As Windows.Forms.ListBox
    Friend WithEvents ListBoxModele As Windows.Forms.ListBox
    Friend WithEvents ListBoxVersion As Windows.Forms.ListBox
    Friend WithEvents CheckBoxAD As Windows.Forms.CheckBox
    Friend WithEvents CommandButtonOk As Windows.Forms.Button
End Class
