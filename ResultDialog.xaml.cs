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
using System.Windows.Shapes;

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
