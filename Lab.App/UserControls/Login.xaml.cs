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
using Lab.App.Models;
using System.Data;
using System.Data.SqlClient;
using Lab.App.Data;

namespace Lab.App.UserControls
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
            cancelarButton.Dispatcher.BeginInvoke(new Action(() =>
            {
                while (true)
                {
                    cancelarButton.Content = DateTime.Now.ToString("mm:ss");
                    System.Threading.Thread.Sleep(1000);
                }
            }));
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EntrarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Login = loginTextBox.Text,
                Senha = senhaPasswordBox.Password
            };


            if (usuario.Login == "heitor" && usuario.Senha == "123")
            {
                MessageBox.Show("Tudo certo!", "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Dados inválidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
