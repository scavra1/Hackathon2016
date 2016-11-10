using System.Windows;
using Microsoft.Win32;

namespace ProjektJA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Window initialization and data binding
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        /// <summary>
        /// Code-behind method that creates file search dialog and assigns its result to Input Path textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" };

            if (dialog.ShowDialog() == true)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Code-behind method that creates file search dialog and assigns its result to Output Path textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog {Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"};
            if (dialog.ShowDialog() == true)
            {
                textBox1.Text = dialog.FileName;
            }
        }
    }
}
