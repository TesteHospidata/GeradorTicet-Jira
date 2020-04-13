﻿using System;
using System.Windows.Forms;
using GeradorTicket_Jira.Entities;
using GeradorTicket_Jira.Entities.Enums;

namespace GeradorTicket_Jira
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        Ticket ticket;
        
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void descriçãoDeProblemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbProblemas.Visible = true;
            tbProblemas.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            if (tbEscolhas.SelectedTab.Equals(tbProblemas))
            {
                int cliente = int.Parse(tbCliente.Text);        //Armazena o código do cliente

                string anexos = rbAnexoSim.Checked == true ? "\n*Há PSR, vídeo ou outros anexos!* " : "\n*Não há PSR, vídeo ou outros anexos!* ";

                Boolean ambienteProducao = rbProducao.Checked ? true : false;   // Verifica se é um ambiente de produção (true) ou homologação (false)

                string reproduzido = " {panel:title=*REPRODUZIDO EM:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" +
                    "\n*HOSTNAME:* "
                                        + tbHostname.Text
                                        + "\n*PORTA:* "
                                        + tbPorta.Text
                                        + "\n*DATABASE:* "
                                        + tbDatabase.Text
                                        + "\n*USUÁRIO:* "
                                        + tbUsuario.Text
                                        + "\n*SENHA:* "
                                        + tbPassword.Text;

                TextosPadroes textos = new TextosPadroes(caminhos: tbCaminhos.Text, resumo: tbResumo.Text + anexos, funcionamento: tbFuncionamento.Text, reproduzido: reproduzido, passoAPasso: tbPassoAPasso.Text, parecer: tbParecer.Text);

                ticket = new Ticket(cliente, cbArea.Text, tbVersao.Text, cbSO.Text, cbAplicacao.Text, ambienteProducao, tbProblemas.Focus() == true ? TipoTicket.Problema : TipoTicket.Qualidade);

                Clipboard.SetText(ticket.ToString() + textos);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITPreteste))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(rbTesteUnit))
            {
                int cliente = int.Parse(tbCliente.Text);        //Armazena o código do cliente
                

                string reproduzido = "{panel:title=*TESTE UNITÁRIO REALIZADO PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#0000FF|titleBGColor=#EE7600|bgColor=#ee7600}"
                                        + "\n*Testes Realizados na Versão:* *{color:#0000FF}"
                                        + tbVersao.Text
                                        + "{color}* *Local Testado:* *{color:#0000FF}"
                                        + tbHostname.Text
                                        + " - "
                                        + tbDatabase.Text
                                        + " - "
                                        + tbPorta.Text
                                        + "{color}* - *Usuário:* *{color:#0000FF}"
                                        + tbUsuario.Text
                                        + "{color}* - *Senha:* *{color:#0000FF}"
                                        + tbPassword.Text
                                        + "{color}* \n*Registro de Testes em:*\n*Observações:**{color:#0000FF} TICKET BLOQUEADO, AGUARDANDO TESTE DE INTEGRAÇÃO!{color}*"
                                        + "{panel}";
  


                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbTesteIntegrado))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbLiberacaoTeste))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITQualidade))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRAResumido))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbReview))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbWorkshop))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbSprint))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbOrientacao))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta ferramenta foi desenvolvida com o intuíto de auxíliar na" +
                " rotina de registrar tickets no Jira, seja na abertura de tickets de" +
                " DEFEITO ou BUG, ou mesmo no registro de tickets de Implementações, " +
                " Testes ou Orientação ao desenvolvedor." +
                "\nCaso identifique problemas, tenha dúvidas ou deseje sugerir melhorias, favor contactar-me no e-mail dione.quevedo@mv.com.br", "Sobre!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void copiarF11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbEscolhas.SelectedTab.Equals(tbProblemas))
            {
                int cliente = int.Parse(tbCliente.Text);        //Armazena o código do cliente

                string anexos = rbAnexoSim.Checked == true ? "\n*Há PSR, vídeo ou outros anexos!* " : "\n*Não há PSR, vídeo ou outros anexos!* ";

                Boolean ambienteProducao = rbProducao.Checked ? true : false;   // Verifica se é um ambiente de produção (true) ou homologação (false)

                string reproduzido = " {panel:title=*REPRODUZIDO EM:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" +
                    "\n*HOSTNAME:* "
                                        + tbHostname.Text
                                        + "\n*PORTA:* "
                                        + tbPorta.Text
                                        + "\n*DATABASE:* "
                                        + tbDatabase.Text
                                        + "\n*USUÁRIO:* "
                                        + tbUsuario.Text
                                        + "\n*SENHA:* "
                                        + tbPassword.Text;

                TextosPadroes textos = new TextosPadroes(caminhos: tbCaminhos.Text, resumo: tbResumo.Text + anexos, funcionamento: tbFuncionamento.Text, reproduzido: reproduzido, passoAPasso: tbPassoAPasso.Text, parecer: tbParecer.Text);

                ticket = new Ticket(cliente, cbArea.Text, tbVersao.Text, cbSO.Text, cbAplicacao.Text, ambienteProducao, tbProblemas.Focus() == true ? TipoTicket.Problema : TipoTicket.Qualidade);

                Clipboard.SetText(ticket.ToString() + textos);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITPreteste))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(rbTesteUnit))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbTesteIntegrado))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbLiberacaoTeste))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITQualidade))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRAResumido))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbReview))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbWorkshop))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbSprint))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbOrientacao))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limparF10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbCaminhos.Text = tbCliente.Text = tbFuncionamento.Text = tbOrientacao.Text = tbParecer.Text = tbPassoAPasso.Text = tbResumo.Text = "";
            rbAnexoSim.Checked = true;
            rbProducao.Checked = true;
            tbPassword.Text = "1";
            tbPorta.Text = "5430";
            tbHostname.Text = "192.168.0.0";
            tbUsuario.Text = "QA.FUNCIONARIO";
            cbAplicacao.Text = "SIGH";
            cbArea.Text = "NÃO INFORMADO";
            tbDatabase.Text = "bd0000";
            tbVersao.Text = "5.74.00";
            tbCliente.Text = "0000";
            tbPassword.Text = "1";
            tbCliente.Focus();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            tbCaminhos.Text = tbCliente.Text = tbFuncionamento.Text = tbOrientacao.Text = tbParecer.Text = tbPassoAPasso.Text = tbResumo.Text = "";
            rbAnexoSim.Checked = true;
            rbProducao.Checked = true;
            tbPassword.Text = "1";
            tbPorta.Text = "5430";
            tbHostname.Text = "192.168.0.0";
            tbUsuario.Text = "QA.FUNCIONARIO";
            cbAplicacao.Text = "SIGH";
            cbArea.Text = "NÃO INFORMADO";
            tbDatabase.Text = "bd0000";
            tbVersao.Text = "5.74.00";
            tbCliente.Text = "0000";
            tbPassword.Text = "1";
            tbCliente.Focus();
        }
    }
}
