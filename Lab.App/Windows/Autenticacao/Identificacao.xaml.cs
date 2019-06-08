﻿using System;
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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Lab.App.WCF.Security;

namespace Lab.App.Windows.Autenticacao
{
    /// <summary>
    /// Interaction logic for Identificacao.xaml
    /// </summary>
    public partial class Identificacao : Window
    {
        public Lazy<IdentificacaoClient> Client = new Lazy<IdentificacaoClient>(() =>
        {
            return new IdentificacaoClient();
        });

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
            Models.ProfessorCredencial credencial = new Models.ProfessorCredencial
            {
                Login = loginTextBox.Text,
                Senha = senhaPasswordBox.Password
            };

            Models.Identificacao result = Client.Value.Login(credencial);

            if (string.IsNullOrEmpty(result.Token))
            {
                MessageBox.Show("Dados inválidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}

