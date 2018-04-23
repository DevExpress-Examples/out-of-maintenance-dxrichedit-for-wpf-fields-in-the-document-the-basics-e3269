using System;
using System.Windows;
using DevExpress.XtraRichEdit.API.Native;

namespace FieldsExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnAddField_Click(object sender, RoutedEventArgs e) {
            Document document = richEditControl1.Document;
            document.Fields.Add(document.CaretPosition, "DATE");
        }

        private void btnUpdateField_Click(object sender, RoutedEventArgs e) {
            if (richEditControl1.Document.Fields.Count > 0)
                richEditControl1.Document.Fields.Update();
        }

        private void btnShowFieldCode_Click(object sender, RoutedEventArgs e) {
            if (richEditControl1.Document.Fields.Count > 0)
                foreach (Field _f in richEditControl1.Document.Fields){
                _f.ShowCodes = true;
                }
        }

        private void btnShowFieldResult_Click(object sender, RoutedEventArgs e) {
            if (richEditControl1.Document.Fields.Count > 0)
                foreach (Field _f in richEditControl1.Document.Fields){
                _f.ShowCodes = false;
                }
        }

        private void btnModifyFieldCode_Click(object sender, RoutedEventArgs e) {
            if (richEditControl1.Document.Fields.Count <= 0)
                return;
#region #coderange
Document document = richEditControl1.Document;
string fieldCode = document.GetText(document.Fields[0].CodeRange);
if (!fieldCode.Contains("\\@")) {
    DocumentPosition position = document.Fields[0].CodeRange.End;
    document.InsertText(position, @"\@ ""MMMM""");
    document.Fields[0].ShowCodes = true;
}
#endregion #coderange
        }

        private void btnCreateFieldFromSelection_Click(object sender, RoutedEventArgs e) {
            Document document = richEditControl1.Document;
            document.Fields.Add(document.Selection);
        }
    }
}
