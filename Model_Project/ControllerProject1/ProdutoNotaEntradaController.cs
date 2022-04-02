using System;
using System.Collections.Generic;
using ModelProject1;
using PersistenceProject1; 

namespace ControllerProject1
{
    public class ProdutoNotaEntradaController
    {
		private Repository repository = new Repository();
		public NotaEntrada InsertNotaEntrada(NotaEntrada notaEntrada)
		{
			return this.repository.InsertNotaEntrada(notaEntrada);
		}
		public void RemoveNotaEntrada(NotaEntrada notaEntrada)
		{
			this.repository.RemoveNotaEntrada(notaEntrada);
		}
		public IList<NotaEntrada> GetAllNotaEntrada()
		{
			return this.repository.GetAllNotaEntrada();
		}
		public NotaEntrada UpdateNotaEntrada(NotaEntrada notaEntrada)
		{
			return this.repository.UpdateNotaEntrada(notaEntrada);
		}
		public NotaEntrada GetNotaEntradaById(Guid Id)
		{
			return this.repository.GetNotaEntradaById(Id);
		}
	}
}
