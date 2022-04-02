using System.Collections.Generic;
using ModelProject1;
using PersistenceProject1; 

namespace ControllerProject1
{
    public class FornecedorController
	{
		private Repository repository = new Repository();
		public Fornecedor Insert(Fornecedor fornecedor)
		{
			return this.repository.InsertFornecedor(fornecedor);
		}
		public void Remove(Fornecedor fornecedor)
		{
			this.repository.RemoveFornecedor(fornecedor);
		}
		public IList<Fornecedor> GetAll()
		{
			return this.repository.GetAllFornecedores();
		}
		public Fornecedor Update(Fornecedor fornecedor)
		{
			return this.repository.UpdateFornecedor(fornecedor);
		}
	}
}
