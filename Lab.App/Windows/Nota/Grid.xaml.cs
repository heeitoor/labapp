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

namespace Lab.App.Windows.Nota
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Grid : Window
    {
        public Grid()
        {
            InitializeComponent();

            turmasComboBox.Items.Add(new
            {
                Id = 1,
                Label = "T1"
            });

            
        }

        private void TurmasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            notasDataGrid.Items.Add(new
            {
                Aluno = "heitor"
            });

            notasDataGrid.Items.Refresh();
        }

        private void NotasDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
