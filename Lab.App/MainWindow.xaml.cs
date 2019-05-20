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
using Lab.App.UserControls;

namespace Lab.App
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Login login = new Login();

            bool? resultado = login.ShowDialog();

            if (!resultado.Value)
            {
                MessageBox.Show("O app será fechado...");
                Environment.Exit(0);
            }

            InitializeComponent();
        }

        private void AlunoButton_Click(object sender, RoutedEventArgs e)
        {
            AlunoManager alunoManager = new AlunoManager();
            alunoManager.ShowDialog();
        }

        private void NotasButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
