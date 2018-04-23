
#region #Reference
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Pdf;
using DevExpress.XtraBars.Ribbon;
// ...
#endregion #Reference

namespace PageHitTest {
    #region #Code
    public partial class Form1 : RibbonForm {
        public Form1() {
            InitializeComponent();

            using (Stream stream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("PageHitTest.demo.pdf"))
                pdfViewer.LoadDocument(stream);
        }

        void pdfViewer_MouseClick(object sender, MouseEventArgs e) {
            PdfDocumentPosition position = pdfViewer.GetDocumentPosition(e.Location, true);
            MessageBox.Show(String.Format("You clicked on page {0}", position.PageNumber));
        }
    }
    #endregion #Code
}
