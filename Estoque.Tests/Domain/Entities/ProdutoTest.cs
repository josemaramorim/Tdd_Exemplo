using Estoque.Domain.Entities;
using Estoque.Domain.Enums;
using ExpectedObjects;
using System;
using Xunit;

namespace Estoque.Tests.Domain.Entities
{
    public class ProdutoTest
    {
        private string _nome;
        private CategoriaEnum _categoria;
        private double _preco;

        public ProdutoTest()
        {
            _nome = "Produto-1";
            _categoria = CategoriaEnum.Padaria;
            _preco = 10;
        }

        [Fact]
        public void IntanciandoProduto()
        {
            //arange
            var produtoEsperado = new
            {
                Nome = "Produto-1",
                Categoria = CategoriaEnum.Padaria,
                Preco = (double)10
            };

            //action
            var produto = new ProdutoEntity(produtoEsperado.Nome, produtoEsperado.Categoria, produtoEsperado.Preco);

            //assert
            produtoEsperado.ToExpectedObject().ShouldMatch(produto);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoPodeProdutoTerUmNomeInvalido(string nomeInvalido)
        {
            //arange

            //action

            //assert
            var message = Assert.Throws<ArgumentException>(() => new ProdutoEntity(nomeInvalido, _categoria, _preco)).Message;
            Assert.Equal("Nome invalido", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoPodeProdutoTerUmPrecoMenorQue1(double precoInvalido)
        {
            //arange          

            //action

            //assert
            var message = Assert.Throws<ArgumentException>(() => new ProdutoEntity(_nome, _categoria, precoInvalido)).Message;
            Assert.Equal("Preco invalido", message);
        }
    }

}
