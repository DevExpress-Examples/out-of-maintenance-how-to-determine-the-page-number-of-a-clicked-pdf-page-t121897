Imports Microsoft.VisualBasic
#Region "#Reference"
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports DevExpress.Pdf
Imports DevExpress.XtraBars.Ribbon
' ...
#End Region ' #Reference

Namespace PageHitTest
#Region "#Code"
Partial Public Class Form1
	Inherits RibbonForm
	Public Sub New()
		InitializeComponent()

		Using stream As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PageHitTest.demo.pdf")
			pdfViewer.LoadDocument(stream)
		End Using
	End Sub

	Private Sub pdfViewer_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pdfViewer.MouseClick
		Dim position As PdfDocumentPosition = pdfViewer.GetDocumentPosition(e.Location)
		If position Is Nothing Then
			MessageBox.Show("You clicked outside the page bounds")
		Else
			MessageBox.Show(String.Format("You clicked on page {0}", position.PageNumber))
		End If
	End Sub
End Class
#End Region ' #Code
End Namespace
