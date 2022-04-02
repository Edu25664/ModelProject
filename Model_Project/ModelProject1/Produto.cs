using System;

namespace ModelProject1
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public double PrecoDeCusto { get; set; }
        public double PrecoDeVenda { get; set; }
        public double Estoque { get; set; }

        protected bool Equals(Produto other)
        {
            return Id.Equals(other.Id);

        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Produto))
                return false;
            return Equals((Produto)obj);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return this.Descricao;
        }

    }
}
