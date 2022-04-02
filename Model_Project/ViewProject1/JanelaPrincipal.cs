using ControllerProject1;
using ModelProject1;
using System;
using System.Windows.Forms;
using ViewProjetc1;

namespace ViewProject1
{
    public partial class FormJanelaPrincipal : Form
    {
        private FornecedorController Fornecedorcontroller = new FornecedorController();
        private ProdutoController ControllerProduto = new ProdutoController();
        private ProdutoNotaEntradaController notaEntradaController = new ProdutoNotaEntradaController(); 
        
        private Fornecedor fornecedor= new Fornecedor();
        private Produto produto = new Produto();
        private NotaEntrada notaEntrada = new NotaEntrada(); 
        public FormJanelaPrincipal()
        {
            InitializeComponent();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormFornecedor(Fornecedorcontroller, fornecedor).ShowDialog(); 
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormProduto(produto, ControllerProduto).ShowDialog(); 
        }

        private void notaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmNotaEntrada(notaEntradaController, Fornecedorcontroller, ControllerProduto, notaEntrada).ShowDialog(); 
        }
    }
}
