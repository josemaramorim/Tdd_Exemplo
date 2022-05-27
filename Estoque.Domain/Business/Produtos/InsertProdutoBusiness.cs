using Estoque.Domain.Business.Produtos;
using Estoque.Domain.Entities;
using Estoque.Domain.Enums;
using Estoque.Domain.Interfaces.Data;

namespace Estoque.Domain.Domain.Business.Produtos
{
    public class InsertProdutoBusiness
    {
        private readonly IProdutoData _produtoData;
        public InsertProdutoBusiness(IProdutoData produtoData)
        {
            _produtoData = produtoData;
        }

        public void Handler(ProdutoInput input)
        {
            Enum.TryParse(typeof(CategoriaEnum), input.Categoria, out var categoria);

            if (categoria == null)
                throw new ArgumentException("Categoria invalida");

            var produto = new ProdutoEntity(input.Nome, (CategoriaEnum)categoria, input.Preco);
            _produtoData.Insert(produto);
        }
    }
}