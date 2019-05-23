namespace Lab.App.Models.Interfaces
{
    public interface IUsuario : IModel
    {
        int Id { get; set; }

        string Nome { get; set; }

        string Login { get; set; }

        string Senha { get; set; }
    }
}
