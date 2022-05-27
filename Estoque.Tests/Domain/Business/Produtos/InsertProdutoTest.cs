using Estoque.Domain.Business.Produtos;
using Estoque.Domain.Domain.Business.Produtos;
using Estoque.Domain.Entities;
using Estoque.Domain.Enums;
using Estoque.Domain.Interfaces.Data;
using Moq;
using System;
using Xunit;

namespace Estoque.Tests.Domain.Business.Produtos
{
    public class InsertProdutoTest
    {
        private readonly ProdutoInput _input;
        private readonly Mock<IProdutoData> _produtoDataMock;
        private readonly InsertProdutoBusiness _business;

        public InsertProdutoTest()
        {
            _input = new ProdutoInput
            {
                Nome = "Produto-1",
                Categoria = "Padaria",
                Preco = 10
            };
            
            _produtoDataMock = new Mock<IProdutoData>();
            
            _business = new InsertProdutoBusiness(_produtoDataMock.Object);
        }

        [Fact]
        public void DeveInserirProduto()
        {
            _business.Handler(_input);
            _produtoDataMock.Verify(x => x.Insert(It.Is<ProdutoEntity>(x => x.Nome == _input.Nome)));
        }

        [Fact]
        public void NaoDeveInformarCategoriaInvalida()
        {
            var categoriaInvalida = "Caixa";
            _input.Categoria = categoriaInvalida;

            var message = Assert.Throws<ArgumentException>(() => _business.Handler(_input)).Message;
            Assert.Equal("Categoria invalida", message);
        }
    }


}
