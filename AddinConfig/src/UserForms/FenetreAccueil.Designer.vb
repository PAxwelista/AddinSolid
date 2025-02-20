<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FenetreAccueil
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
        Me.Copier = New System.Windows.Forms.Button()
        Me.Coller = New System.Windows.Forms.Button()
        Me.Paramètres = New System.Windows.Forms.Button()
        Me.GetPosition = New System.Windows.Forms.Button()
        Me.Annuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Copier
        '
        Me.Copier.Location = New System.Drawing.Point(147, 31)
        Me.Copier.Name = "Copier"
        Me.Copier.Size = New System.Drawing.Size(75, 23)
        Me.Copier.TabIndex = 0
        Me.Copier.Text = "Copier"
        Me.Copier.UseVisualStyleBackColor = True
        '
        'Coller
        '
        Me.Coller.Location = New System.Drawing.Point(147, 60)
        Me.Coller.Name = "Coller"
        Me.Coller.Size = New System.Drawing.Size(75, 23)
        Me.Coller.TabIndex = 1
        Me.Coller.Text = "Coller"
        Me.Coller.UseVisualStyleBackColor = True
        '
        'Paramètres
        '
        Me.Paramètres.Location = New System.Drawing.Point(147, 89)
        Me.Paramètres.Name = "Paramètres"
        Me.Paramètres.Size = New System.Drawing.Size(75, 23)
        Me.Paramètres.TabIndex = 2
        Me.Paramètres.Text = "Paramètre"
        Me.Paramètres.UseVisualStyleBackColor = True
        '
        'GetPosition
        '
        Me.GetPosition.Location = New System.Drawing.Point(348, 45)
        Me.GetPosition.Name = "GetPosition"
        Me.GetPosition.Size = New System.Drawing.Size(75, 23)
        Me.GetPosition.TabIndex = 3
        Me.GetPosition.Text = "Quelle position"
        Me.GetPosition.UseVisualStyleBackColor = True
        '
        'Annuler
        '
        Me.Annuler.Location = New System.Drawing.Point(348, 78)
        Me.Annuler.Name = "Annuler"
        Me.Annuler.Size = New System.Drawing.Size(75, 23)
        Me.Annuler.TabIndex = 4
        Me.Annuler.Text = "Annuler"
        Me.Annuler.UseVisualStyleBackColor = True
        '
        'FenetreAccueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Annuler)
        Me.Controls.Add(Me.GetPosition)
        Me.Controls.Add(Me.Paramètres)
        Me.Controls.Add(Me.Coller)
        Me.Controls.Add(Me.Copier)
        Me.Name = "FenetreAccueil"
        Me.Text = "FenetreAccueil"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Copier As Windows.Forms.Button
    Friend WithEvents Coller As Windows.Forms.Button
    Friend WithEvents Paramètres As Windows.Forms.Button
    Friend WithEvents GetPosition As Windows.Forms.Button
    Friend WithEvents Annuler As Windows.Forms.Button
End Class
