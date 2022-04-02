using ModelProject1;
using PersistenceProject1;
using System;
using System.Collections.Generic;


namespace ControllerProject1
{
    public class ProdutoController
    {
		private Repository repository = new Repository();
		public Produto Insert(Produto produto)
		{
			return this.repository.InsertProduto(produto);
		}
		public void Remove(Produto produto)
		{
			this.repository.RemoveProduto(produto);
		}
		public IList<Produto> GetAll()
		{
			return this.repository.GetAllProduto();
		}
        public Produto Update(Produto produto)
		{
			return this.repository.UpdateFornecedor(produto);
		}
	}
}
