﻿using OrdemDeServico.DAO;
using OrdemDeServico.Model;
using System;
using System.Collections.Generic;

namespace OrdemDeServico.Helpers
{
    class SelectData
    {
        public static List<Secretaria> PesquisarSecretaria(string nome)
        {
            List<Secretaria> secretarias;
            SecretariaDAO secretariaDAO = new SecretariaDAO();
            secretarias = secretariaDAO.SelectNome(nome);
            return secretarias;
        }
        public static Secretaria PesquisarSecretariaId(int id)
        {
            SecretariaDAO secretariaDAO = new SecretariaDAO();
            Secretaria secretaria;
            secretaria = secretariaDAO.SelectId(id);
            return secretaria;
        }
        public static List<Setor> PesquisarSetor(string nome)
        {
            List<Setor> setores;
            SetorDAO setorDAO = new SetorDAO();
            setores = setorDAO.SelectNome(nome);
            return setores;
        }
        public static Setor PesquisarSetorId(int id)
        {
            SetorDAO setorDAO = new SetorDAO();
            Setor setor;
            setor = setorDAO.SelectId(id);
            return setor;
        }
        public static List<Setor> PesquisarSetoresId(int id)
        {
            SetorDAO setorDAO = new SetorDAO();
            List<Setor> setores;
            setores = setorDAO.SelectSetorFk(id);
            return setores;
        }
        public static Solicitante PesquisarSolicitanteId(int id)
        {
            SolicitanteDAO solicitanteDAO = new SolicitanteDAO();
            Solicitante solicitante;
            solicitante = solicitanteDAO.SelectId(id);
            return solicitante;
        }
        public static List<Solicitante> PesquisarSolicitante(string nome)
        {
            List<Solicitante> solicitante;
            SolicitanteDAO solicitanteDAO = new SolicitanteDAO();
            solicitante = solicitanteDAO.SelectNome(nome);
            return solicitante;
        }
        public static List<Atendente> PesquisarAtendente(string nome)
        {
            List<Atendente> atendente;
            AtendenteDAO atendenteDAO = new AtendenteDAO();
            atendente = atendenteDAO.SelectNome(nome);
            return atendente;
        }
        public static List<Maquina> PesquisarMaquinaPatrimonio(int patrimonio )
        {
            List<Maquina> maquinas;
            MaquinaDAO maquinaDAO = new MaquinaDAO();
            maquinas = maquinaDAO.SelectNome(patrimonio);
            return maquinas;
        }
        public static List<Maquina> PesquisarTudoMaquinaPatrimonio()
        {
            List<Maquina> maquinas;
            MaquinaDAO maquinaDAO = new MaquinaDAO();
            maquinas = maquinaDAO.SelectTudo();
            return maquinas;
        }
        public static Maquina PesquisarMaquinaId(int id)
        {
            Maquina maquina;
            MaquinaDAO maquinaDAO = new MaquinaDAO();
            maquina = maquinaDAO.SelectId(id);
            return maquina;
        }
        public static List<OrdemServico> PesquisarOrdemServicoSolicitante(int idSolicitante)
        {
            List<OrdemServico> ordemServicos;
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            ordemServicos = ordemServicoDAO.SelectIdSolicitante(idSolicitante);
            return ordemServicos;
        }
        public static List<OrdemServico> PesquisarOrdemServico(int numeroOs)
        {
            List<OrdemServico> ordemServicos;
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            ordemServicos = ordemServicoDAO.SelectListaId(numeroOs);
            return ordemServicos;
        }
        public static List<OrdemServico> PesquisarOrdemServicos(int idSolicitante, DateTime dtInicio, DateTime dtFim )
        {
            List<OrdemServico> ordemServicos;
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            ordemServicos = ordemServicoDAO.SelectIdSolicitante(idSolicitante, dtInicio, dtFim);
            return ordemServicos;
        }
        public static List<OrdemServico> PesquisarOrdemServicoIdSetor(int idSetor, DateTime dtInicio, DateTime dtFim)
        {
            List<OrdemServico> ordemServicos;
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            ordemServicos = ordemServicoDAO.SelectIdSetor(idSetor, dtInicio, dtFim);
            return ordemServicos;
        }
        public static OrdemServico PesquisarOrdemServicoId(int numeroOs)
        {
            OrdemServico ordemServico;
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            ordemServico = ordemServicoDAO.SelectId(numeroOs);
            return ordemServico;
        }
        public static Atendente PesquisarAtendenteId(int id)
        {
            AtendenteDAO atendenteDAO = new AtendenteDAO();
            Atendente atendente;
            atendente = atendenteDAO.SelectId(id);
            return atendente;
        }
        public static Atendente PesquisarAtendenteNome(string usuario)
        {
            AtendenteDAO atendenteDAO = new AtendenteDAO();            
            return atendenteDAO.SelectUsuarioExiste(usuario);
        }
        public static bool PesquisarAtendenteSenha(int id, string senha)
        {
            AtendenteDAO atendenteDAO = new AtendenteDAO();
            return atendenteDAO.SelectUsuarioSenha(id, senha);
        }       
    }
}
