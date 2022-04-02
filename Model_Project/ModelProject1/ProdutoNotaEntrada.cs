﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelProject1
{
    public class ProdutoNotaEntrada
    {
		public Guid Id { get; set; }
		public Produto ProdutoNota { get; set; }
		public double PrecoCustoCompra { get; set; }
		public double QuantidadeComprada { get; set; }
		protected bool Equals(ProdutoNotaEntrada other)
		{
			return Id.Equals(other.Id);
		}
		protected bool Equals(Produto others)
        {
			return Id.Equals(others.Id); 
        }
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ProdutoNotaEntrada))
				return false;
			return Equals((ProdutoNotaEntrada)obj);
		}

		public override int GetHashCode()
		{
			return ProdutoNota.GetHashCode();
		}


	}
}
