﻿using OrdemDeServico.Helpers;
using OrdemDeServico.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrdemDeServico.Views.Manutencao.NsMaquina
{
    public partial class FrmMaquina : Form
    {
        private Maquina maquina = new Maquina();
        private List<Maquina> maquinas = new List<Maquina>();
        private Setor setor;
        public FrmMaquina()
        {
            InitializeComponent();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            FrmAddMaquina frmAddMaquina = new FrmAddMaquina();
            frmAddMaquina.MdiParent = FrmPrincipal.ActiveForm;
            frmAddMaquina.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtPesquisar.Text != "")
            {
                HandlerDataGridView.PesquisaDgv(dgv, txtPesquisar.Text, maquinas, setor);
            }
            else
            {
                HandlerDataGridView.PesquisaDgvTudoMaquina(dgv, maquinas, setor);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (HandlerDataGridView.ObterLinhaDgv(dgv, maquina))
            {
                FrmEdtMaquina frmEdtMaquina = new FrmEdtMaquina(maquina);
                frmEdtMaquina.MdiParent = FrmPrincipal.ActiveForm;
                frmEdtMaquina.Show();
            }
        }
        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (HandlerDataGridView.ObterLinhaDgv(dgv, maquina))
            {
                FrmRelatorioMaquina relatorioMaquina = new FrmRelatorioMaquina(maquina);
                relatorioMaquina.ShowDialog();

            }
        }
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if(HandlerDataGridView.ObterLinhaDgv(dgv, maquina))
            {
                if (MessageBox.Show("Deseja excluir este registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == DialogResult.Yes)
                {
                    try
                    {
                        DeleteData.Excluir(maquina);
                        HandlerDataGridView.ObterLinhaDgv(dgv, maquina);
                    }
                    catch (Exception)
                    {

                        MensagemEntidades.MaquinaMsgExcluir();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (txtPesquisar.Text != "")
            {
                HandlerDataGridView.PesquisaDgv(dgv,txtPesquisar.Text, maquinas, setor);
            }
        }
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }       
                     
    }
}
