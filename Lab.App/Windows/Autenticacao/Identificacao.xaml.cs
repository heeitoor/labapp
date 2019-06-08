using Lab.App.Business;
using Lab.App.Models;
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

namespace Lab.App.Windows.Autenticacao
{
    /// <summary>
    /// Interaction logic for Identificacao.xaml
    /// </summary>
    public partial class Identificacao : Window
    {
        public Identificacao()
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
