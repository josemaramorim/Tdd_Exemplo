using Estoque.Domain.Enums;

namespace Estoque.Domain.Entities
{
    public class ProdutoEntity
    {
        public ProdutoEntity(string nome, CategoriaEnum categoria, double preco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome invalido");

            if (preco < 1)
                throw new ArgumentException("Preco invalido");

            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public CategoriaEnum Categoria { get; private set; }
        public double Preco { get; private set; }
    }
}