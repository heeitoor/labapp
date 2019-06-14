using Lab.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab.App.Windows.Aluno
{
    /// <summary>
    /// Interaction logic for Grid.xaml
    /// </summary>
    public partial class Grid : Window
    {
        public Grid()
        {
            InitializeComponent();
            //CarregarDados(new AlunoFiltro());
        }

        #region Campos e Propriedades

        //private Lazy<AlunoBusiness> Business = new Lazy<AlunoBusiness>(() => new AlunoBusiness());
        //private List<Models.Aluno> alunos = null;

        #endregion

        #region Eventos

        private void NomeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    CarregarDados(new AlunoFiltro
            //    {
            //        Nome = nomeTextBox.Text
            //    });
            //}
        }

        private void FiltrarButton_Click(object sender, RoutedEventArgs e)
        {
            //CarregarDados(new AlunoFiltro
            //{
            //    Nome = nomeTextBox.Text
            //});
        }

        private void NovoButton_Click(object sender, RoutedEventArgs e)
        {
            //Form alunoForm = new Form();
            //alunoForm.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //if (xmlRadioButton.IsChecked == true)
            //{
            //    string fileName = DateTime.Now.Ticks.ToString();

            //    string xml = XmlHelper.ToXml(alunos);

            //    IOHelper.Escrever($@"e:\{fileName}.xml", xml);
            //}
            //else if (jsonRadioButton.IsChecked == true)
            //{

            //}
            //else if (binarioRadioButton.IsChecked == true)
            //{

            //}
        }

        object t = null;
        private void AlunosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            t = e.AddedItems[0];
        }

        private void AlunosDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        #endregion

        #region Métodos

        void CarregarDados(AlunoFiltro filtro)
        {
            //alunosDataGrid.ItemsSource = alunos = Business.Value.Get(filtro);

            //Lab.App.Data.EF.LabEF context = new Data.EF.LabEF();

            //alunosDataGrid.ItemsSource = alunos =
            //    context.Aluno.Select(x => new Aluno
            //    {
            //        Id = x.Id,
            //        Nome = x.Nome,
            //        DataNascimento = x.Nascimento
            //    }).ToList();

            //alunosDataGrid.Items.Refresh();
        }

        #endregion
    }
}
