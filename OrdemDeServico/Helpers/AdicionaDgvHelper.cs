﻿using OrdemDeServico.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrdemDeServico.Helpers
{
    class AdicionaDgvHelper
    {
        private static void CriarDgvMaquina(DataGridView dgv)
        {
            string[] nomeColuna = new string[] { "Id", "Patrimonio", "Tipo", "Descricao", "Setor", "IdSetor", "Secretaria" };
            string[] textoColuna = new string[] { "Id", "Patrimônio", "Tipo", "Descrição", "Setor", "IdSetor", "Secretaria" };
            int[] tamanho = new[] { 50, 100, 250, 250, 250, 50, 250 };
            bool[] visibilidade = new[] { true, true, true, true, true, false, true };
            Criador.CriaDataGridView(dgv, nomeColuna, textoColuna, tamanho, visibilidade);
        }
        private static void CriarDgvSolicitante(DataGridView dgv)
        {
            string[] nomeColuna = new string[] { "Id", "Nome", "Descricao", "Setor", "IdSetor", "Secretaria" };
            string[] textoColuna = new string[] { "Id", "Nome", "Descrição", "Setor", "IdSetor", "Secretaria" };
            int[] tamanho = new[] { 50, 250, 250, 250, 50, 250 };
            bool[] visibilidade = new[] { true, true, true, true, false, true };
            Criador.CriaDataGridView(dgv, nomeColuna, textoColuna, tamanho, visibilidade);
        }
        private static void CriarDgvOrdemServico(DataGridView dgv, string status)
        {
            if (status == "abertura")
            {

                string[] nomeColuna = new string[] { "Id", "Solicitante", "Maquina", "Tipo", "Diagnostico", "DataAbertura",  "Atendente" };
                string[] textoColuna = new string[] { "Número", "Solicitante", "Máquina", "Tipo", "Diagnóstico", "Abertura", "Atendente" };
                int[] tamanho = new[] { 50, 250, 250, 250, 250, 250, 150 };                
                Criador.CriaDataGridView(dgv, nomeColuna, textoColuna, tamanho);
            }
            else
            {
                string[] nomeColuna = new string[] { "Id", "Solicitante", "Maquina","Tipo", "Diagnostico", "DataAbertura", "Solucao", "DataFechamento",
                    "Observacao", "Atendente" };
                string[] textoColuna = new string[] { "Número", "Solicitante", "Máquina", "Tipo", "Diagnóstico", "Abertura", "Solução", "Fechamento",
                    "Observação", "Atendente" };
                int[] tamanho = new[] { 50, 250, 250, 250, 250, 250, 250, 250, 250, 150 };                
                Criador.CriaDataGridView(dgv, nomeColuna, textoColuna, tamanho);
            }
        }
        public static void PesquisaDgv(DataGridView dgv, string txtPesquisar, List<Maquina> maquinas, Setor setor )
        {
            CriarDgvMaquina(dgv);

            int patrimonio = Convert.ToInt32(txtPesquisar);
            if ((maquinas = PesquisadorHelper.PesquisarMaquinaPatrimonio(patrimonio)) != null)
            {
                foreach (Maquina maquina in maquinas)
                {
                    if ((setor = PesquisadorHelper.PesquisarSetor(maquina.SetorMqn.Id)) != null)
                    {
                        maquina.SetorMqn = setor;
                        if ((maquina.SetorMqn.SecretariaStr = PesquisadorHelper.PesquisarSecretaria(maquina.SetorMqn.SecretariaStr.Id)) != null)
                        {
                            dgv.Rows.Add(maquina.Id, maquina.Patrimonio, maquina.Tipo, maquina.Descricao, maquina.SetorMqn.Nome,
                                maquina.SetorMqn.Id, maquina.SetorMqn.SecretariaStr.Nome);
                        }

                    }
                }
            }
        }
        public static void PesquisaDgv(DataGridView dgv, string textoPesquisa, List<Solicitante> solicitantes, Setor setor)
        {
            CriarDgvSolicitante(dgv);
            if ((solicitantes = PesquisadorHelper.PesquisarSolicitante(textoPesquisa)) != null)
            {
                foreach (Solicitante solicitante in solicitantes)
                {
                    if ((setor = PesquisadorHelper.PesquisarSetor(solicitante.SetorSlc.Id)) != null)
                    {
                        solicitante.SetorSlc = setor;
                        if ((solicitante.SetorSlc.SecretariaStr = PesquisadorHelper.PesquisarSecretaria(solicitante.SetorSlc.SecretariaStr.Id)) != null)
                        {
                            dgv.Rows.Add(solicitante.Id, solicitante.Nome, solicitante.Descricao, solicitante.SetorSlc.Nome,
                                solicitante.SetorSlc.Id, solicitante.SetorSlc.SecretariaStr.Nome);
                        }                        
                    }
                }                
            }
        }
        public static void PesquisaDgv(DataGridView dgv, string textoPesquisa, Atendente atendente)
        {
            List<Solicitante> solicitantes;
            List<OrdemServico> ordemServicos;

            CriarDgvOrdemServico(dgv, "abertura");
            if ((solicitantes = PesquisadorHelper.PesquisarSolicitante(textoPesquisa)) != null)
            {
                foreach (Solicitante solicitante in solicitantes)
                {
                    if ((ordemServicos = PesquisadorHelper.PesquisarOrdemServicoSolicitante(solicitante.Id, atendente.Id)) != null)
                    {
                       foreach(OrdemServico ordemServico in ordemServicos)
                       {
                            ordemServico.SolicitanteOs = PesquisadorHelper.PesquisarSolicitanteId(ordemServico.SolicitanteOs.Id);
                            ordemServico.MaquinaOs = PesquisadorHelper.PesquisarMaquinaId(ordemServico.MaquinaOs.Id);
                            ordemServico.AtendenteOs = PesquisadorHelper.PesquisarAtendenteId(atendente.Id);
                            dgv.Rows.Add(ordemServico.Id, ordemServico.SolicitanteOs.Nome, ordemServico.MaquinaOs.Patrimonio, ordemServico.MaquinaOs.Tipo,
                                ordemServico.Diagnostico, ordemServico.DataAbertura, ordemServico.AtendenteOs.Nome);
                       }
                    }
                }
            }
        }
        public static void PesquisaDgv(DataGridView dgv, int numeroOs, Atendente atendente)
        {
            List<OrdemServico> ordemServicos;

            CriarDgvOrdemServico(dgv, "abertura");

            if ((ordemServicos = PesquisadorHelper.PesquisarOrdemServico(numeroOs)) != null)
            {
                foreach (OrdemServico ordemServico in ordemServicos)
                {
                    ordemServico.SolicitanteOs = PesquisadorHelper.PesquisarSolicitanteId(ordemServico.SolicitanteOs.Id);
                    ordemServico.MaquinaOs = PesquisadorHelper.PesquisarMaquinaId(ordemServico.MaquinaOs.Id);
                    ordemServico.AtendenteOs = PesquisadorHelper.PesquisarAtendenteId(atendente.Id);
                    dgv.Rows.Add(ordemServico.Id, ordemServico.SolicitanteOs.Nome, ordemServico.MaquinaOs.Patrimonio, ordemServico.MaquinaOs.Tipo,
                        ordemServico.Diagnostico, ordemServico.DataAbertura, ordemServico.AtendenteOs.Nome);
                }
            }

        }
        public static bool ObterLinhaDgv(DataGridView dgv, Maquina maquina)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                maquina.Id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
                maquina.Patrimonio = Convert.ToInt32(dgv.CurrentRow.Cells[1].Value.ToString());
                maquina.Tipo = dgv.CurrentRow.Cells[2].Value.ToString();
                maquina.Descricao = dgv.CurrentRow.Cells[3].Value.ToString();
                maquina.SetorMqn.Nome = dgv.CurrentRow.Cells[4].Value.ToString();
                maquina.SetorMqn.Id = Convert.ToInt32(dgv.CurrentRow.Cells[5].Value);
                return true;
            }
            else
            {
                return false;
            }
        }       
       
        public static bool ObterLinhaDgv(DataGridView dgv, Solicitante solicitante)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                solicitante.Id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
                solicitante.Nome = dgv.CurrentRow.Cells[1].Value.ToString();
                solicitante.Descricao = dgv.CurrentRow.Cells[2].Value.ToString();
                solicitante.SetorSlc.Nome = dgv.CurrentRow.Cells[3].Value.ToString();
                solicitante.SetorSlc.Id = Convert.ToInt32(dgv.CurrentRow.Cells[4].Value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
