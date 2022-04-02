using ControllerProject1;
using ModelProject1;
using System;
using System.Windows.Forms;

namespace ViewProject1
{
    public partial class FormProduto : Form
    {
        private Produto Produto;
        private ProdutoController ProdutoController; 
        public FormProduto(Produto produto, ProdutoController produtoController)
        {
            InitializeComponent();
            this.Produto = produto;
            this.ProdutoController = produtoController; 
        }
        internal void Clear()
        {
            dgvProdutos.ClearSelection();
            txtId.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtEstoque.Text = string.Empty;
            txtCusto.Text = string.Empty;
            txtVenda.Text = string.Empty;
            txtDescricao.Focus(); 
        }
        internal void DataSourcerNull()
        {
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = ProdutoController.GetAll();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            var produto = new Produto() {
                Id = txtId.Text == string.Empty ? Guid.NewGuid() : new Guid(txtId.Text),
                Descricao = txtDescricao.Text,
                Estoque = Convert.ToDouble(txtEstoque.Text),
                PrecoDeCusto = Convert.ToDouble(txtCusto.Text),
                PrecoDeVenda = Convert.ToDouble(txtVenda.Text)
            };
            produto = txtId.Text == string.Empty ? this.ProdutoController.Insert(produto) : this.ProdutoController.Update(produto);
            DataSourcerNull(); 
            Clear(); 
   
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Clear(); 
        }

        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                txtId.Text = dgvProdutos.CurrentRow.Cells[0].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
                txtCusto.Text = dgvProdutos.CurrentRow.Cells[3].Value.ToString();
                txtVenda.Text = dgvProdutos.CurrentRow.Cells[4].Value.ToString(); 
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Selecione	o	FORNECEDOR	a	ser	removido	no GRID");
            }
            else
            {
                this.ProdutoController.Remove(new Produto()
                {
                    Id = new Guid(txtId.Text)
                });
                DataSourcerNull();
            }
        }

        private void btnCnacelar_Click(object sender, EventArgs e)
        {
            Clear(); 
        }
    }
}
