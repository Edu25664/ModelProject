using System;
using System.Collections.Generic;
using ModelProject1;

namespace PersistenceProject1
{
    public class Repository
    {
		#region listas
		private IList<Fornecedor> fornecedores = new List<Fornecedor>();
		private IList<Produto> produtos = new List<Produto>();
		private IList<NotaEntrada> notasEntrada = new List<NotaEntrada>();
		#endregion

		#region métodos de configuração da Lista de Fornecedores
		public Fornecedor InsertFornecedor(Fornecedor fornecedor)
		{
			this.fornecedores.Add(fornecedor);
			return fornecedor;
		}
		public void RemoveFornecedor(Fornecedor fornecedor)
		{
			this.fornecedores.Remove(fornecedor);
		}
		public IList<Fornecedor> GetAllFornecedores()
		{
			return this.fornecedores;
		}
		public Fornecedor UpdateFornecedor(Fornecedor fornecedor)
		{
			this.fornecedores[this.fornecedores.IndexOf(fornecedor)] = fornecedor;
			return fornecedor;
		}
		#endregion

		#region Método de configuração da lista de Produtos 
		public Produto InsertProduto(Produto produto)
		{
			this.produtos.Add(produto);
			return produto;
		}
		public void RemoveProduto(Produto produto)
		{
			this.produtos.Remove(produto);
		}
		public IList<Produto> GetAllProduto()
		{
			return this.produtos;
		}
		public Produto UpdateFornecedor(Produto produto)
		{
			this.produtos[this.produtos.IndexOf(produto)] = produto;
			return produto;
		}

		#endregion

		#region Método de configuração da lista de NotasEntrada 
		public NotaEntrada InsertNotaEntrada(NotaEntrada notaentrada)
		{
			this.notasEntrada.Add(notaentrada);
			return notaentrada;
		}
		public void RemoveNotaEntrada(NotaEntrada notaEntrada)
		{
			this.notasEntrada.Remove(notaEntrada);
		}
		public IList<NotaEntrada> GetAllNotaEntrada()
		{
			return this.notasEntrada;
		}
		public NotaEntrada UpdateNotaEntrada(NotaEntrada notaEntrada)
		{
			this.notasEntrada[this.notasEntrada.IndexOf(notaEntrada)] = notaEntrada;
			return notaEntrada;
		}
		public NotaEntrada GetNotaEntradaById(Guid Id)
		{
			var notaEntrada = this.notasEntrada[this.notasEntrada.IndexOf( new NotaEntrada() { Id = Id })];
			return notaEntrada;
		}



		#endregion

	}
}

