using System;
using System.Windows.Forms;
using ControllerProject1;
using ModelProject1;

namespace ViewProjetc1
{
    public partial class frmNotaEntrada : Form
    {
        //controladores injetados 
        #region Controladores 
        private ProdutoNotaEntradaController ProdutoNotaEntradaController;
        private FornecedorController fornecedorController;
        private ProdutoController produtoController;
        private NotaEntrada notaAtual;
        #endregion

        //Construtor que inicaliza os componentes 
        #region Construtor com injeção de dependência 
        public frmNotaEntrada(ProdutoNotaEntradaController NotaEntrada, FornecedorController fornecedorController, ProdutoController produtoController, NotaEntrada notaEntrada)
        {
            InitializeComponent();
            this.ProdutoNotaEntradaController = NotaEntrada;
            this.fornecedorController = fornecedorController;
            this.produtoController = produtoController;
            this.notaAtual = notaEntrada;
            InicializaCombobox();
        }
        #endregion

        //Metodos auxiliares criados 
        #region Métodos auxiliares 
        private void ClearControlsNota()
        {
            dgvNotas.ClearSelection();
            dgvProdutos.ClearSelection();
            txtIdNota.Text = string.Empty;
            cbxFornecedor.SelectedIndex = -1;
            txtNumero.Text = string.Empty;
            dtpEmissao.Value = DateTime.Now;
            cbxFornecedor.Focus();
        }
        private void InicializaCombobox()
        {
            cbxFornecedor.Items.Clear();
            cbxProdutos.Items.Clear();

            foreach (Fornecedor fornecedor in this.fornecedorController.GetAll())
            {
                cbxFornecedor.Items.Add(fornecedor);
            }

            foreach (Produto produto in this.produtoController.GetAll())
            {
                cbxProdutos.Items.Add(produto);
            }

        }
        private void UpdateProdutosGrid()
        {
            dgvProdutos.DataSource = null;
            if (this.notaAtual.Produtos.Count > 0)
            {
                dgvProdutos.DataSource = this.notaAtual.Produtos;
            }
        }
        private void ClearControlsProduto()
        {
            dgvProdutos.ClearSelection();
            txtIdProdutos.Text = string.Empty;
            cbxProdutos.SelectedIndex = -1;
            txtCusto.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            cbxProdutos.Focus();
        }
        private void ChangeStatusOfControls(bool newStatus)
        {
            cbxProdutos.Enabled = newStatus;
            txtCusto.Enabled = newStatus;
            txtQuantidade.Enabled = newStatus;
            btnNovoProduto.Enabled = !newStatus;
            btnGravaProduto.Enabled = newStatus;
            btnCancelaProduto.Enabled = newStatus;
            btnRemoverproduto.Enabled = newStatus;
        }

        #endregion

        // botões da nota configurados 
        #region Configurações dos eventos Clicks da nota 
        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            ClearControlsNota();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            //método gravar cria uma nova instancia da classe notaEntrada Ja com uma condicional no id não dar erro quando for atualizar
            var notaEntrada = new NotaEntrada()
            {
                Id = txtIdNota.Text == string.Empty ? Guid.NewGuid() : new Guid(txtIdNota.Text),
                DataEmissao = dtpEmissao.Value,
                DataEntrada = dtpEntrada.Value,
                FornecedorNota = (Fornecedor)cbxFornecedor.SelectedItem,
                Numero = txtNumero.Text
            };
            // método aqui já de fato insere o objeto dentro da lista de dados, objeto já com os valores atribuídos
            notaEntrada = txtIdNota.Text == string.Empty ? this.ProdutoNotaEntradaController.InsertNotaEntrada(notaEntrada) : this.ProdutoNotaEntradaController.UpdateNotaEntrada(notaEntrada);
            dgvNotas.DataSource = null;
            dgvNotas.DataSource = this.ProdutoNotaEntradaController.GetAllNotaEntrada();
            ClearControlsNota();

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearControlsNota();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtIdNota.Text == string.Empty)
            {
                MessageBox.Show("Selecione	a	NOTA	a	ser	removida	no	GRID");
            }
            else
            {
                this.ProdutoNotaEntradaController.RemoveNotaEntrada(new NotaEntrada()
                {
                    Id = new Guid(txtIdNota.Text)
                }
                );
                dgvNotas.DataSource = null;
                dgvProdutos.DataSource = this.ProdutoNotaEntradaController.GetAllNotaEntrada();
                ClearControlsNota();
            }
        }

        #endregion

        //Evento selectionChanged configurado
        #region Eventos dos DataGridVew
        private void dgvNotas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.notaAtual = this.ProdutoNotaEntradaController.GetNotaEntradaById((Guid) dgvNotas.CurrentRow.Cells[0].Value);
                txtIdNota.Text = notaAtual.Id.ToString();
                txtNumero.Text = notaAtual.Numero;
                cbxFornecedor.SelectedItem = notaAtual.FornecedorNota;
                dtpEmissao.Value = notaAtual.DataEmissao;
                dtpEntrada.Value = notaAtual.DataEntrada;
                UpdateProdutosGrid();
            }
            catch (Exception)
            {
                this.notaAtual = new NotaEntrada();
            }


        }
        #endregion
        
        //botões do design produtos comprados
        #region Eventos Clicks dos produtos comprados 
        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            ClearControlsProduto();
            if (txtIdNota.Text == string.Empty)
            {
                MessageBox.Show("Selecione	a	NOTA,	que	terá	inserção	de	produtos, no  GRID");
            }
            else
            {
                ChangeStatusOfControls(true);
            }

        }

        private void btnGravaPorduto_Click(object sender, EventArgs e)
        {
            var produtoNota = new ProdutoNotaEntrada()
            {
                Id = (txtIdProdutos.Text == string.Empty ? Guid.NewGuid() : new Guid(txtIdProdutos.Text)),
                PrecoCustoCompra = Convert.ToDouble(txtCusto.Text),
                ProdutoNota = (Produto)cbxProdutos.SelectedItem,
                QuantidadeComprada = Convert.ToDouble(txtQuantidade.Text)
            };
            this.notaAtual.RegistrarProduto(produtoNota);
            this.notaAtual = this.ProdutoNotaEntradaController.UpdateNotaEntrada(this.notaAtual);
            ChangeStatusOfControls(false);
            UpdateProdutosGrid();
            ClearControlsProduto();
        }

        private void btnCancelaProduto_Click(object sender, EventArgs e)
        {
            ClearControlsProduto();
            ChangeStatusOfControls(false);
        }

        private void btnRemoverproduto_Click(object sender, EventArgs e)
        {
            this.notaAtual.RemoverProduto(new ProdutoNotaEntrada()
            {
                Id = new Guid(txtIdProdutos.Text)
            });

            this.ProdutoNotaEntradaController.UpdateNotaEntrada(this.notaAtual);
            UpdateProdutosGrid();
            ClearControlsProduto();
            ChangeStatusOfControls(false);
        }
        #endregion

        

    }
}

