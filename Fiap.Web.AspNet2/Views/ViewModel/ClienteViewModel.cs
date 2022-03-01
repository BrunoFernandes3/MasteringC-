namespace Fiap.Web.AspNet2.Views.ViewModel
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public ClienteViewModel(int clienteId, string clienteNome)
        {
            ClienteId = clienteId;
            Nome = clienteNome;
        }

        public ClienteViewModel()
        {
        }

    }

}

