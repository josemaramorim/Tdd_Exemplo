using Estoque.Domain.Enums;

namespace Estoque.Domain.Business.Produtos
{
    public class ProdutoInput
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Preco { get; set; }
    }
}
