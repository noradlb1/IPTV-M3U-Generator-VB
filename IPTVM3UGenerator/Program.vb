Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace IPTVM3UGenerator
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' Point d'entrée principal de l'application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New FrmGui())
		End Sub
	End Class
End Namespace
