Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports DevExpress.Pdf
Imports DevExpress.XtraBars.Ribbon

Namespace PageHitTest

    Public Partial Class Form1
        Inherits RibbonForm

        Public Sub New()
            InitializeComponent()
            Dim stream As Stream = GetResourceStream("PageHitTest.demo.pdf")
            pdfViewer.LoadDocument(stream)
        End Sub

        Private Shared Function GetResourceStream(ByVal resourceName As String) As Stream
            Return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
        End Function

        Private Sub pdfViewer_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim position As PdfDocumentPosition = pdfViewer.GetDocumentPosition(e.Location, True)
            MessageBox.Show(String.Format("You clicked on page {0}", position.PageNumber))
        End Sub
    End Class
End Namespace
