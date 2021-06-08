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
