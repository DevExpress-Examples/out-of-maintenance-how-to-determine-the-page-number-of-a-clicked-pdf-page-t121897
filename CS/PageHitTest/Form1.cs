using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Pdf;
using DevExpress.XtraBars.Ribbon;


namespace PageHitTest {

    public partial class Form1 : RibbonForm {
        public Form1() {
            InitializeComponent();

            Stream stream = GetResourceStream("PageHitTest.demo.pdf");
            pdfViewer.LoadDocument(stream);
        }

        static Stream GetResourceStream(string resourceName) {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        void pdfViewer_MouseClick(object sender, MouseEventArgs e) {
            PdfDocumentPosition position = pdfViewer.GetDocumentPosition(e.Location, true);
            MessageBox.Show(string.Format("You clicked on page {0}", position.PageNumber));
        }
    }
}
