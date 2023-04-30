Imports HtmlAgilityPack
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Namespace IPTVM3UGenerator
	Partial Public Class FrmGui
		Inherits Form

		Private Const FLAGS_DIR As String = "Flags"
		Private Const OUTPUT_DIR As String = "Output"

		Private sSelectedCountry As String

		Public Sub New()
			InitializeComponent()

			Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)

			Me.BtnGen.Visible = False
			Me.LblGen.Visible = False
			Me.LvCountries.Enabled = False
		End Sub

		Private Sub GetCountries()
			Dim w As New MyHtmlWeb()
			Dim d As HtmlAgilityPack.HtmlDocument = w.Load("https://iptvcat.com/")

			Dim flags As HtmlNodeCollection = d.DocumentNode.SelectNodes("//td[@style='padding-left:45px;']//td[@class='no-padding-right pl-5 flag']//img")
			Dim countries As HtmlNodeCollection = d.DocumentNode.SelectNodes("//td[@style='padding-left:45px;']//td[@class='pl-5']")

			Me.Invoke(CType(Sub()
				Me.Pb.Minimum = 0
				Me.Pb.Maximum = countries.Count - 1
				Me.Pb.Value = 0
				Me.Pb.Visible = True
				Me.LvCountries.BeginUpdate()
				If Me.LvCountries.SmallImageList Is Nothing Then
					Me.LvCountries.SmallImageList = New ImageList()
				Else
					Me.LvCountries.SmallImageList.Images.Clear()
				End If
			End Sub, MethodInvoker)
		   )

			For i As Integer = 0 To countries.Count - 1
				Dim countryCode As String = flags(i).Attributes("src").Value.Replace("assets/images/flags/", "").Replace(".png", "")
				Dim filename As String = String.Format("{0}\{1}.png", FLAGS_DIR, countryCode)

				Dim di As New DirectoryInfo(OUTPUT_DIR)
				If Not di.Exists Then
					di.Create()
				End If

				di = New DirectoryInfo(FLAGS_DIR)
				If Not di.Exists Then
					di.Create()
				End If

				If Not File.Exists(filename) Then
					Using wc As New MyWebClient()
						Dim buf() As Byte = wc.DownloadData(String.Concat("https://countryflagsapi.com/png/", countryCode))
						Using ms As New MemoryStream(buf, 0, buf.Length)
							ms.Write(buf, 0, buf.Length)

							Using img As Image = Image.FromStream(ms, True)
'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
								Dim width_Renamed As Integer = 24
'INSTANT VB NOTE: The variable height was renamed since Visual Basic does not handle local variables named the same as class members well:
								Dim height_Renamed As Integer
								Dim ratio As Double = CDbl(width_Renamed) / img.Width

								height_Renamed = CInt(Math.Truncate(Math.Ceiling(img.Height * ratio)))

								Using bmp As New Bitmap(width_Renamed, height_Renamed)

									Graphics.FromImage(bmp).DrawImage(img, 0, 0, width_Renamed, height_Renamed)

									bmp.Save(filename, ImageFormat.Png)
								End Using
							End Using
						End Using
					End Using
				End If

				Me.Invoke(CType(Sub()
					Me.LvCountries.SmallImageList.Images.Add(Image.FromFile(filename))
					Me.LvCountries.Items.Add(countries(i).InnerText, i)
					Me.Pb.Value = i
				End Sub, MethodInvoker)
			   )
			Next i

			Me.Invoke(CType(Sub()
				Me.LvCountries.Sort()
				Me.LvCountries.EndUpdate()
				Me.Pb.Visible = False
				Me.BtnGen.Visible = True
				Me.LblGen.Visible = True
				Me.LvCountries.Enabled = True
			End Sub, MethodInvoker)
		   )
		End Sub

		Private Sub BtnGen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGen.Click
			Me.BtnGen.Visible = False
			Me.LblGen.Visible = False

			Me.Pb.Minimum = 0
			Me.Pb.Maximum = Me.LvCountries.CheckedItems.Count
			Me.Pb.Value = 0
			Me.Pb.Visible = True


			For i As Integer = 0 To Me.LvCountries.CheckedItems.Count - 1
				Application.DoEvents()

				Dim item As ListViewItem = Me.LvCountries.CheckedItems(i)

				Me.sSelectedCountry = item.Text.Replace(" ", "_")
				Me.GetChannels(Me.sSelectedCountry)
			Next i

			Me.Pb.Visible = False
			Me.BtnGen.Visible = True
			Me.LblGen.Visible = True
		End Sub

		Private Sub GetChannels(ByVal _countryCode As String, Optional ByVal _nextPage As Boolean = False)
			Dim w As New MyHtmlWeb()
			Dim d As HtmlAgilityPack.HtmlDocument = w.Load(String.Concat("https://iptvcat.com/", _countryCode))

			Dim m3u8 As HtmlNodeCollection = d.DocumentNode.SelectNodes("//span[@class='label label-flat border-info text-info-600 get_vlc y']")
			Dim onlines As HtmlNodeCollection = d.DocumentNode.SelectNodes("//tbody//tr//td[4]//div")

			If m3u8 IsNot Nothing AndAlso onlines IsNot Nothing Then
				Dim filename As String = String.Format("{0}\{1}.m3u", OUTPUT_DIR, Me.sSelectedCountry)

				Dim sb As New StringBuilder()
				If File.Exists(filename) Then
					sb.AppendLine(File.ReadAllText(filename))
				Else
					sb.AppendLine("#EXTM3U")
				End If

				For i As Integer = 0 To m3u8.Count - 1
					If onlines(i).InnerText.Equals("-") Then
						Continue For
					End If

					Using wc As New MyWebClient()
						Dim s As String = wc.DownloadString(m3u8(i).Attributes("data-clipboard-text").Value).Replace("#EXTM3U" & ControlChars.Lf, "")

						sb.Append(s)
					End Using

					Application.DoEvents()
				Next i

				File.WriteAllText(filename, sb.ToString())

				Dim buttons As HtmlNodeCollection = d.DocumentNode.SelectNodes("//li//a")
				If buttons IsNot Nothing Then
					For Each button In buttons
						If button.InnerHtml.Equals("<i class=""icon-arrow-right5""></i>") Then
							If button.Attributes.Count = 3 AndAlso button.Attributes(0).Name.Equals("href") Then
								GetChannels(button.Attributes(0).Value, True)

								Exit For
							End If
						End If
					Next button
				End If
			End If

			If Not _nextPage Then
				Me.Pb.Value += 1
			End If
		End Sub

		Private Sub FrmGui_Shown(ByVal _sender As Object, ByVal _e As EventArgs) Handles MyBase.Shown
			Dim thd As New Thread(AddressOf GetCountries)
			thd.Start()
		End Sub

		Private Sub LvCountries_SelectedIndexChanged(ByVal _sender As Object, ByVal _e As EventArgs) Handles LvCountries.SelectedIndexChanged
			For Each i As ListViewItem In Me.LvCountries.SelectedItems
				i.Checked = Not i.Checked
				i.Focused = False
			Next i
		End Sub
	End Class
End Namespace
