using System.Windows;

namespace TemplateGenerator
{
    /// <summary>
    /// Interaction logic for ResultDialog.xaml
    /// </summary>
    public partial class ResultDialog : Window
    {
        public ResultDialog(string resultText)
        {
            InitializeComponent();

            ResultBox.Text = resultText;
        }

        private void CopyToClipboard_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ResultBox.Text))
            {
                MessageBox.Show("Dont know how you got to here, but there is nothing to add to your clipboard...");
                return;
            }
            Clipboard.SetText(ResultBox.Text);
        }

        private void CloseDialog_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
