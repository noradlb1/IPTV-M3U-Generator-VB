Imports System.Net

Namespace IPTVM3UGenerator

	Public Class MyWebClient
		Inherits WebClient

		<System.Security.SecuritySafeCritical> _
		Public Sub New()
			MyBase.New()
			Me.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36")
			Me.Headers.Add("Accept-Language", "en-us,en;q=0.5")
		End Sub

		Public m_cookieContainer As New CookieContainer()

		Protected Overrides Function GetWebResponse(ByVal _wRequest As WebRequest) As WebResponse
			If TypeOf _wRequest Is HttpWebRequest Then
				Dim wRequest As HttpWebRequest = (TryCast(_wRequest, HttpWebRequest))

				wRequest.CookieContainer = m_cookieContainer
				wRequest.AllowAutoRedirect = True
				wRequest.MaximumAutomaticRedirections = 4
			End If

			Return MyBase.GetWebResponse(_wRequest)
		End Function
	End Class
End Namespace
