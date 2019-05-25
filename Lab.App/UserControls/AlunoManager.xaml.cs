using Lab.App.Business;
using Lab.App.Helpers;
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
using System.Linq;

namespace Lab.App.UserControls
{
    /// <summary>
    /// Lógica interna para AlunoManager.xaml
    /// </summary>
    public partial class AlunoManager : Window
    {
        private Lazy<AlunoBusiness> Business = new Lazy<AlunoBusiness>(() => new AlunoBusiness());
        private List<Aluno> alunos = null;

        public AlunoManager()
        {
            InitializeComponent();
            CarregarDados(new AlunoFiltro());
        }

        private void NomeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CarregarDados(new AlunoFiltro
                {
                    Nome = nomeTextBox.Text
                });
            }
        }

        private void FiltrarButton_Click(object sender, RoutedEventArgs e)
        {
            CarregarDados(new AlunoFiltro
            {
                Nome = nomeTextBox.Text
            });
        }

        void CarregarDados(AlunoFiltro filtro)
        {
            //alunosDataGrid.ItemsSource = alunos = Business.Value.Get(filtro);

            Lab.App.Data.EF.LabEF context = new Data.EF.LabEF();
            
            alunosDataGrid.ItemsSource = alunos =
                context.Aluno.Select(x => new Aluno
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataNascimento = x.Nascimento
                }).ToList();

            alunosDataGrid.Items.Refresh();
        }

        private void NovoButton_Click(object sender, RoutedEventArgs e)
        {
            AlunoForm alunoForm = new AlunoForm();
            alunoForm.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XmlButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = DateTime.Now.Ticks.ToString();

                string xml = XmlHelper.ToXml(alunos);

                IOHelper.Escrever($@"e:\{fileName}.xml", xml);
            }
            catch (Exception x)
            {

            }
        }

        private void JsonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BinaryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        object t = null;
        private void AlunosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            t = e.AddedItems[0];
        }

        private void AlunosDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
