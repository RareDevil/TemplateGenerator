using System.Text;
using System.Windows;

namespace TemplateGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StringBuilder howToInfo = new();
            howToInfo.AppendLine("How to use:");
            howToInfo.AppendLine("- Fill in the template field with the text you want to have a replaced something in with the different strings.");
            howToInfo.AppendLine("Use §§§ the places where you want the strings to be placed, you can have as many as you need.");
            howToInfo.AppendLine();
            howToInfo.AppendLine("- Fill in the items list with the strings you want to have replaced in the template.");
            howToInfo.Append("Use , to seperate the string you want to use.");
            HowToUseInfo.Text = howToInfo.ToString();
        }

        private void GenerateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!ItemsBox.Text.Contains(','))
            {
                MessageBox.Show("Please make sure there is a , in the items list.");
            }
            else if (!ItemsBox.Text.Trim().Trim(',').Contains(','))
            {
                MessageBox.Show("Dont just add , and hope that something magic will happen.");
            }
            else if (!TemplateBox.Text.Contains("§§§"))
            {
                MessageBox.Show("Please make sure there is §§§ in the template.");
            }
            else
            {
                GenerateButton.IsEnabled = false;
                TemplateBox.IsReadOnly = true;
                ItemsBox.IsReadOnly = true;
                // §§§
                StringBuilder newText = new();
                foreach (string s in ItemsBox.Text.Trim().Trim(',').Split(','))
                {
                    newText.AppendLine(TemplateBox.Text.Replace("§§§", s.Trim()));
                    newText.AppendLine();
                }

                ResultDialog dialog = new ResultDialog(newText.ToString());

                dialog.Show();

                dialog.Closed += (o, args) =>
                {
                    GenerateButton.IsEnabled = true;
                    TemplateBox.IsReadOnly = false;
                    ItemsBox.IsReadOnly = false;
                };
            }
        }
    }
}
