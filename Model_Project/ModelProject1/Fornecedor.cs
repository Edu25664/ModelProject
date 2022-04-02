using System;
using System.Collections.Generic;
using System.Text;

namespace ModelProject1
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

        #region Equals
        protected bool Equals(Fornecedor other)
        {
            return Id.Equals(other.Id);

        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Fornecedor))
                return false;
            return Equals((Fornecedor)obj);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return this.Nome;
        }
        #endregion

    }
}
