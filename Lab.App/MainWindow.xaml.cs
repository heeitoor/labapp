using System;
using System.Configuration;
using System.Windows;
using NotaUI = Lab.App.Windows.Nota;
using AlunoUi = Lab.App.Windows.Aluno;
using Lab.App.Windows.Autenticacao;

namespace Lab.App
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            bool inDevelopment =
                ConfigurationManager.AppSettings["InDevelopment"] == "true";

            if (!inDevelopment)
            {
                Identificacao login = new Identificacao();

                bool? resultado = login.ShowDialog();

                if (!resultado.Value)
                {
                    Environment.Exit(0);
                }
            }

            InitializeComponent();
        }

        private void AlunoButton_Click(object sender, RoutedEventArgs e)
        {
            AlunoUi.Grid alunoGrid = new AlunoUi.Grid();
            alunoGrid.ShowDialog();
        }

        private void NotasButton_Click(object sender, RoutedEventArgs e)
        {
            NotaUI.Grid grid = new NotaUI.Grid();
            grid.ShowDialog();
        }
    }
}
