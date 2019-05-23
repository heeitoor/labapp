using System.Windows;

namespace Lab.App.Helpers
{
    public static class UIHelper
    {
        public static void ErrorMessage(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

        public static void SuccessMessage(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }
    }
}
