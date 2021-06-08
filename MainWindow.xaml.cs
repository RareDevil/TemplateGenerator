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
            // Testing
        }

        private void GenerateButton_OnClick(object sender, RoutedEventArgs e)
        {
            GenerateButton.IsEnabled = false;

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
                // §§§
                StringBuilder newText = new();
                foreach (string s in ItemsBox.Text.Split(','))
                {
                    newText.AppendLine(TemplateBox.Text.Replace("§§§", s));
                    newText.AppendLine();
                }

                MessageBox.Show(newText.ToString());
            }

            GenerateButton.IsEnabled = true;
        }
    }
}
