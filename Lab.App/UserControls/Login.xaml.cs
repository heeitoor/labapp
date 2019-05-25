using System.Windows;
using Lab.App.Models;
using Lab.App.Business;

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

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EntrarButton_Click(object sender, RoutedEventArgs e)
        {
            Professor professor = new Professor
            {
                Login = loginTextBox.Text,
                Senha = senhaPasswordBox.Password
            };

            ProfessorBusiness professorBusiness = new ProfessorBusiness();

            bool success = professorBusiness.Login(professor);

            if (success)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Dados inválidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
