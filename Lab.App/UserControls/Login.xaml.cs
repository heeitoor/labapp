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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Login = loginTextBox.Text,
                Senha = senhaTextBox.Text
            };

            string connectionString
                = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\Projects\labapp\Lab.App\App_Data\Lab.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql
                    = $"SELECT * FROM Usuario WHERE Login = '{usuario.Login}' AND Senha = '{usuario.Senha}'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        bool sucesso = reader.Read();
                        //while (reader.Read())
                        //{
                        //    string login = reader["Login"].ToString();
                        //    string senha = reader["Senha"].ToString();
                        //}
                    }
                }

                connection.Close();
            }

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
