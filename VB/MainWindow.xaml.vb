Imports System.Windows
Imports DevExpress.XtraRichEdit.API.Native

Namespace FieldsExample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub btnAddField_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim document As Document = Me.richEditControl1.Document
            document.Fields.Create(document.CaretPosition, "DATE")
        End Sub

        Private Sub btnUpdateField_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.richEditControl1.Document.Fields.Count > 0 Then Me.richEditControl1.Document.Fields.Update()
        End Sub

        Private Sub btnShowFieldCode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.richEditControl1.Document.Fields.Count > 0 Then
                For Each _f As Field In Me.richEditControl1.Document.Fields
                    _f.ShowCodes = True
                Next
            End If
        End Sub

        Private Sub btnShowFieldResult_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.richEditControl1.Document.Fields.Count > 0 Then
                For Each _f As Field In Me.richEditControl1.Document.Fields
                    _f.ShowCodes = False
                Next
            End If
        End Sub

        Private Sub btnModifyFieldCode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.richEditControl1.Document.Fields.Count <= 0 Then Return
'#Region "#coderange"
            Dim document As Document = Me.richEditControl1.Document
            Dim fieldCode As String = document.GetText(document.Fields(0).CodeRange)
            If Not fieldCode.Contains("\@") Then
                Dim position As DocumentPosition = document.Fields(0).CodeRange.End
                document.InsertText(position, "\@ ""MMMM""")
                document.Fields(0).ShowCodes = True
            End If
'#End Region  ' #coderange
        End Sub

        Private Sub btnCreateFieldFromSelection_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim document As Document = Me.richEditControl1.Document
            document.Fields.Create(document.Selection)
        End Sub
    End Class
End Namespace
