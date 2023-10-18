using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.Mime;
using Microsoft.Win32;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditorView.xaml
    /// </summary>
    public partial class TextEditorView : UserControl
    {
        TextProps _textProps = new TextProps();
       public List<FontFamily> fonts = new List<FontFamily>();

        public TextEditorView()
        {
            InitializeComponent();
            DataContext = _textProps;
            fonts = _textProps.FontFamilies;
        }


        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }


        private void small_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontSize = 12;
        }

        private void medium_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontSize = 24;
        }

        private void large_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontSize = 36;
        }

        private void BoldBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (boldBtn.IsChecked == true)
            {
                TextField.FontWeight = FontWeights.ExtraBold;
            }
            else
            {
                TextField.FontWeight = FontWeights.Normal;
            }
        }

        private void ItalicBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (italicBtn.IsChecked == true)
            {
                TextField.FontStyle = FontStyles.Italic;
            }
            else
            {
            }
        }

        private void UnderscoreBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TextRange text = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd);
            if (UnderscoreBtn.IsChecked == true)
            {
                text.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                text.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }

        private void ConsolasFont_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontFamily = new FontFamily("Consolas");
        }

        private void ArialFont_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontFamily = new FontFamily("Arial");
        }

        private void TimesNewRomanFont_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontFamily = new FontFamily("Times New Roman");

        }
    }
}
