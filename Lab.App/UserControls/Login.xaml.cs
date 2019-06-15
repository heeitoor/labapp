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

namespace Lab.App.UserControls
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public string Senha { get => senhaPasswordBox.Password; }

        public string Emoji
        {
            get { return (string)GetValue(EmojiProperty); }
            set { SetValue(EmojiProperty, value); }
        }

        public static readonly DependencyProperty EmojiProperty =
            DependencyProperty.Register("Emoji", typeof(string), typeof(Login), new PropertyMetadata(string.Empty));

        public Login()
        {
            InitializeComponent();

            DataContext = new Models.ProfessorCredencial();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            emojiText.Text = Emoji;
        }
    }
}
