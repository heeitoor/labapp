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

namespace Lab.App.UserControls
{
    /// <summary>
    /// Interaction logic for AlunoForm.xaml
    /// </summary>
    public partial class AlunoForm : Window
    {
        public AlunoForm()
        {
            InitializeComponent();
        }

        private void SalvarButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) || nascimentoDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Dados inválidos.");
            }
            else
            {
                Aluno aluno = new Aluno
                {
                    Nome = nameTextBox.Text,
                    DataNascimento = nascimentoDatePicker.SelectedDate.Value
                };

                MessageBox.Show("Dados inseridos com sucesso.");

                LimparFormulario();
            }
        }

        private void LimparButton_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }

        void LimparFormulario()
        {
            nameTextBox.Text = string.Empty;
            nascimentoDatePicker.SelectedDate = null;
        }
    }
}
