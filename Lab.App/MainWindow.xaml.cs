using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using Lab.App.Models;
using Lab.App.UserControls;
using HELP = Lab.App.Helpers;
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
            //HELP.IOHelper.Escrever(@"c:\escrita.txt", "valor da escrita de texto");

            //string conteudo = HELP.IOHelper.Ler(@"c:\teste.txt");

            //var k = HELP.IOHelper.GetDirectoryInfo(@"C:\test.e.bin");

            //Aluno[] alunos = new[]
            //{
            //    new Aluno
            //    {
            //        Id = 10,
            //        Nome = "Fulano",
            //        DataNascimento = DateTime.Now.AddYears(-20)
            //    },
            //    new Aluno
            //    {
            //        Id = 11,
            //        Nome = "Maluco Beleza",
            //        DataNascimento = DateTime.Now.AddYears(-100)
            //    }
            //};

            //HELP.SimpleIniFormatter initSerializer = new HELP.SimpleIniFormatter();

            //using (StreamWriter streamWriter = new StreamWriter(@"e:\file.ini"))
            //{
            //    initSerializer.Serialize(streamWriter.BaseStream,
            //    new Aluno
            //    {
            //        Id = 11,
            //        Nome = "Maluco Beleza",
            //        DataNascimento = DateTime.Now.AddYears(-100)
            //    });
            //}

            //HELP.SerializationHelper.Serialize

            //HELP.SerializationHelper.Serialize(new HELP.ClassTeste
            //{
            //    Name = "AppLab"
            //}, @"e:\classTeste.ttt");

            //            var p = HELP.SerializationHelper.DeSerialize<HELP.ClassTeste>(@"e:\classTeste.ttt");

            //HELP.SerializationHelper.Serialize(new Aluno
            //{
            //    Id = 10,
            //    Nome = "Fulano",
            //    DataNascimento = DateTime.Now.AddYears(-20)
            //});

            //var arr = HELP.SerializationHelper.DeSerialize<Aluno>();

            //string json = HELP.JsonHelper.ToJson(alunos);

            //HELP.IOHelper.Escrever(@"c:\alunos.json", json);


            //string jsonFromDisk = HELP.IOHelper.Ler(@"c:\alunos.json");

            //var o = HELP.JsonHelper.FromJson<Aluno[]>(jsonFromDisk);

            //string s = HELP.XmlHelper.ToXml(alunos);

            //HELP.IOHelper.Escrever(@"c:\aluno.xml", s);

            //string xml = HELP.IOHelper.Ler(@"c:\aluno.xml");

            //var arr = HELP.XmlHelper.FromXml<Aluno[]>(s);

            //throw new Exception("controlado...");

            bool inDevelopment =
                ConfigurationManager.AppSettings["InDevelopment"] == "true";

            if (inDevelopment)
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

        private async void NotasButton_Click(object sender, RoutedEventArgs e)
        {
            NotaUI.Grid grid = new NotaUI.Grid();
            grid.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
