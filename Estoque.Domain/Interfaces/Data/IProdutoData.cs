using Estoque.Domain.Business.Produtos;
using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces.Data
{
    public interface IProdutoData
    {
        void Insert(ProdutoEntity produtoEntity);
    }
}
