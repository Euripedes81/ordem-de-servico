﻿using OrdemDeServico.Model;
using OrdemDeServico.Views.Manutencao.NsMaquina;
using OrdemDeServico.Views.Manutencao.NsSecretaria;
using OrdemDeServico.Views.Manutencao.NsSetor;
using OrdemDeServico.Views.Manutencao.NsSolicitante;
using OrdemDeServico.Views.OS.NsAbrir;
using System;
using System.Windows.Forms;

namespace OrdemDeServico.Views
{
    public partial class FrmPrincipal : Form
    {
        FrmLogin frmLogin = new FrmLogin();
        public static Atendente atendenteLogin { get; set; }
        public FrmPrincipal()
        {            
            InitializeComponent();
            frmLogin.ShowDialog();
        }
        private void secretariaTsmi_Click(object sender, EventArgs e)
        {
            FrmSecretaria frmSecretaria = new FrmSecretaria();
            frmSecretaria.MdiParent = this;
            frmSecretaria.Show();

        }

        private void setorTsmi_Click(object sender, EventArgs e)
        {
            FrmSetor frmSetor = new FrmSetor();
            frmSetor.MdiParent = this;
            frmSetor.Show();
        }

        private void funcionarioTsmi_Click(object sender, EventArgs e)
        {
            FrmSolicitante frmSolicitante = new FrmSolicitante();
            frmSolicitante.MdiParent = this;
            frmSolicitante.Show();
        }

        private void maquinaTsmi_Click(object sender, EventArgs e)
        {
            FrmMaquina frmMaquina = new FrmMaquina();
            frmMaquina.MdiParent = this;
            frmMaquina.Show();
        }

        private void gerenciadorOsTsmi_Click(object sender, EventArgs e)
        {
            FrmAbreOs frmAbreOs = new FrmAbreOs(atendenteLogin);
            frmAbreOs.MdiParent = this;
            frmAbreOs.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaOs frmConsultaOs = new FrmConsultaOs();
            frmConsultaOs.MdiParent = this;
            frmConsultaOs.Show();
        }
        
    }
}