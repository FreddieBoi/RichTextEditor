using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Win32;

namespace RichTextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string _fileName;

        private string _dataFormat;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutMenuItemClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("RichTextEditor is a text editor by Freddie Pettersson.",
                            "About RichTextEditor", MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void OpenMenuItemClick(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void Open(object sender, ExecutedRoutedEventArgs e)
        {
            Open();
        }

        private void Open()
        {
            // Create an OpenFileDialog.
            var openFileDialog = new OpenFileDialog { FileName = "Document", DefaultExt = ".rtf", Filter = "Rich Text Format|*.rtf|Plain Text|*.txt" };

            // Show open file dialog box, abort if not successful
            if (openFileDialog.ShowDialog() != true) return;

            // Load the specified file into the document
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            var fileStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
            textRange.Load(fileStream, openFileDialog.FilterIndex == 2 ? DataFormats.Text : DataFormats.Rtf);
            fileStream.Close();
        }

        private void SaveMenuItemClick(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            // First time? Should use SaveAs first...
            if (_fileName == null)
            {
                SaveAs();
                return;
            }

            // Save the document text to the selected file
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            var fileStream = new FileStream(_fileName, FileMode.Create);

            textRange.Save(fileStream, _dataFormat);
            fileStream.Close();
        }

        private void SaveAsMenuItemClick(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void SaveAs(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            // Create a SaveFileDialog.
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "Document",
                DefaultExt = ".rtf",
                Filter = "Rich Text Format|*.rtf|Plain Text|*.txt"
            };

            // Show save file dialog box, abort if not successful
            if (saveFileDialog.ShowDialog() != true) return;

            // Store the file name
            _fileName = saveFileDialog.FileName;

            // Use Rtf format by default, if not explicitly set to Text
            _dataFormat = saveFileDialog.FilterIndex == 2 ? DataFormats.Text : DataFormats.Rtf;

            // Save the document
            Save();
        }

        private void PrintMenuItemClick(object sender, RoutedEventArgs e)
        {
            Print();
        }

        private void Print(object sender, ExecutedRoutedEventArgs e)
        {
            Print();
        }

        private void Print()
        {
            // Create a PrintDialog.
            var printDialog = new PrintDialog();

            // Show the dialog and print the document if successful
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument((((IDocumentPaginatorSource)richTextBox.Document).DocumentPaginator),
                                          "printing as paginator");
            }
        }

    }

}
