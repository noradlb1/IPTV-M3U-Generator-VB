Imports HtmlAgilityPack

Namespace IPTVM3UGenerator

	Public Class MyHtmlWeb
		Inherits HtmlWeb

		<System.Security.SecuritySafeCritical> _
		Public Sub New()
			MyBase.New()
			Me.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
		End Sub
	End Class
End Namespace
