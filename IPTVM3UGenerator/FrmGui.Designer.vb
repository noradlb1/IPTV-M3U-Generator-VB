Namespace IPTVM3UGenerator
	Partial Public Class FrmGui
		''' <summary>
		''' Variable nécessaire au concepteur.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Nettoyage des ressources utilisées.
		''' </summary>
		''' <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Code généré par le Concepteur Windows Form"

		''' <summary>
		''' Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		''' le contenu de cette méthode avec l'éditeur de code.
		''' </summary>
		Private Sub InitializeComponent()
			Me.LvCountries = New System.Windows.Forms.ListView()
			Me.Pb = New System.Windows.Forms.ProgressBar()
			Me.BtnGen = New System.Windows.Forms.Button()
			Me.LblGen = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' LvCountries
			' 
			Me.LvCountries.Activation = System.Windows.Forms.ItemActivation.OneClick
			Me.LvCountries.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.LvCountries.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(56)))), (CInt((CByte(62)))), (CInt((CByte(66)))))
			Me.LvCountries.CheckBoxes = True
			Me.LvCountries.Font = New System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.LvCountries.HideSelection = False
			Me.LvCountries.LabelWrap = False
			Me.LvCountries.Location = New System.Drawing.Point(12, 12)
			Me.LvCountries.MultiSelect = False
			Me.LvCountries.Name = "LvCountries"
			Me.LvCountries.Size = New System.Drawing.Size(724, 413)
			Me.LvCountries.Sorting = System.Windows.Forms.SortOrder.Ascending
			Me.LvCountries.TabIndex = 0
			Me.LvCountries.UseCompatibleStateImageBehavior = False
			Me.LvCountries.View = System.Windows.Forms.View.List
'			Me.LvCountries.SelectedIndexChanged += New System.EventHandler(Me.LvCountries_SelectedIndexChanged)
			' 
			' Pb
			' 
			Me.Pb.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.Pb.Location = New System.Drawing.Point(12, 431)
			Me.Pb.Name = "Pb"
			Me.Pb.Size = New System.Drawing.Size(643, 23)
			Me.Pb.TabIndex = 1
			' 
			' BtnGen
			' 
			Me.BtnGen.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.BtnGen.Location = New System.Drawing.Point(661, 431)
			Me.BtnGen.Name = "BtnGen"
			Me.BtnGen.Size = New System.Drawing.Size(75, 23)
			Me.BtnGen.TabIndex = 2
			Me.BtnGen.Text = "Generate"
			Me.BtnGen.UseVisualStyleBackColor = True
'			Me.BtnGen.Click += New System.EventHandler(Me.BtnGen_Click)
			' 
			' LblGen
			' 
			Me.LblGen.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.LblGen.AutoSize = True
			Me.LblGen.ForeColor = System.Drawing.SystemColors.Info
			Me.LblGen.Location = New System.Drawing.Point(12, 436)
			Me.LblGen.Name = "LblGen"
			Me.LblGen.Size = New System.Drawing.Size(260, 17)
			Me.LblGen.TabIndex = 3
			Me.LblGen.Text = "Select some countries and clic on Generate button."
			Me.LblGen.UseCompatibleTextRendering = True
			' 
			' FrmGui
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(30)))), (CInt((CByte(30)))), (CInt((CByte(30)))))
			Me.ClientSize = New System.Drawing.Size(748, 467)
			Me.Controls.Add(Me.LblGen)
			Me.Controls.Add(Me.BtnGen)
			Me.Controls.Add(Me.Pb)
			Me.Controls.Add(Me.LvCountries)
			Me.MinimumSize = New System.Drawing.Size(400, 200)
			Me.Name = "FrmGui"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "IPTV M3U Generator"
'			Me.Shown += New System.EventHandler(Me.FrmGui_Shown)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents LvCountries As System.Windows.Forms.ListView
		Private Pb As System.Windows.Forms.ProgressBar
		Private WithEvents BtnGen As System.Windows.Forms.Button
		Private LblGen As System.Windows.Forms.Label
	End Class
End Namespace

