using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Common.Helpers
{
    public class WordHelper : IDisposable
    {
        public void Dispose()
        {

        }

        //public void Read(string path)
        //{
        //    Application word = new Application();

        //    Document doc = word.Documents.Open(path);

        //    foreach (Paragraph objParagraph in doc.Paragraphs)
        //    {
        //        Console.WriteLine(objParagraph.Range.Text.Trim());
        //    }

        //    doc.Close();
        //    word.Quit();
        //}

        //public void Write(string path, string text)
        //{
        //    Application winword = new Application();
        //    winword.Visible = false;

        //    Document document = winword.Documents.Add();

        //    document.Content.Text = text + Environment.NewLine;

        //    object fileName = path;

        //    document.SaveAs2(ref fileName);
        //    document.Close();
        //    winword.Quit();
        //}
    }

    //public static class OfficeHelper
    //{
    //    public static void Read(string path = @"C:\Users\heito\Desktop\teste2.docx")
    //    {
    //        using (WordHelper wordHelper = new WordHelper())
    //        {
    //            wordHelper.Read(path);
    //        }
    //    }

    //    public static void Create(string path = @"C:\Users\heito\Desktop\teste2.docx", string text = "Texto qualquer!")
    //    {
    //        using (WordHelper wordHelper = new WordHelper())
    //        {
    //            wordHelper.Write(path, text);
    //        }
    //    }
    //}
}
