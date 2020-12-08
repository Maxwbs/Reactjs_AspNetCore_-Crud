using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MCE.Integracao.Utils
{
    public class AjudanteDeImagem
    {
        public Image credencial { get; set; }
        public Image ObtenhaImagemDaCarteiraMembro(byte[] credencial)
        {
            Image imagem = null;
            try
            {
                using (var ms = new MemoryStream(credencial))
                {
                    imagem = Image.FromStream(ms);
                }

                //imagem = Image.FromFile(caminhoDaImagem);
            }
            catch { }


            return imagem;
        }

        public byte[] GeraCarteiraMembro(Image imagem,
                                       string nome,
                                       string cargoMinisterial,
                                       DateTime dataBatismoAguas,
                                       string nomePai,
                                       string nomeMae,
                                       string naturalidade,
                                       string nacionalidade,
                                      string estadoCivil,
                                      DateTime dataNascimento,
                                      string rg,
                                      string orgaoEmissorRg,
                                      string congregacao)
        {
            var memStream = new MemoryStream();

            if (imagem != null)
            {
                using (var grafico = Graphics.FromImage(imagem))
                {
                    var dataDeEmissao = DateTime.Now.ToString("dd/MM/yyyy");
                    var nomeDoMinistro = string.IsNullOrEmpty(nome) ? string.Empty : nome.ToUpper();
                    var matriculaDoMinistro = new Random().Next(1, 9999999).ToString();
                    var cargoDoMinistro = string.IsNullOrEmpty(cargoMinisterial) ? string.Empty : cargoMinisterial.ToUpper();
                    var dataBatismoAguasDoMinistro = dataBatismoAguas == DateTime.MinValue ? string.Empty : dataBatismoAguas.ToString("dd/MM/yyyy");
                    var congregacaoDoMinistro = string.IsNullOrEmpty(congregacao) ? string.Empty : congregacao.ToUpper(); ;
                    var nomePaiDoMinistro = string.IsNullOrEmpty(nomePai) ? string.Empty : nomePai.ToUpper();
                    var nomeMaeDoMinistro = string.IsNullOrEmpty(nomeMae) ? string.Empty : nomeMae.ToUpper();
                    var naturalidadeDoMinistro = string.IsNullOrEmpty(naturalidade) ? string.Empty : naturalidade.ToUpper();
                    var nacionalidadeDoMinistro = string.IsNullOrEmpty(nacionalidade) ? string.Empty : nacionalidade.ToUpper();
                    var estadoCivilDoMinistro = string.IsNullOrEmpty(estadoCivil) ? string.Empty : estadoCivil.ToUpper();
                    var dataNascimentoDoMinistro = dataNascimento == DateTime.MinValue ? string.Empty : dataNascimento.ToString("dd/MM/yyyy");
                    var rgDoMinistro = string.IsNullOrEmpty(rg) ? string.Empty : rg.ToUpper();
                    var orgaoEmissorRgDoMinistro = string.IsNullOrEmpty(orgaoEmissorRg) ? string.Empty : orgaoEmissorRg.ToUpper();

                    var pincel = new SolidBrush(Color.Black);

                    var fontePadrao = new Font("Arial", 7, FontStyle.Bold | FontStyle.Italic);

                    /* Data de Emissão */
                    grafico.DrawString(dataDeEmissao, fontePadrao, pincel, 250, 105);

                    /* Nome do ministro */
                    grafico.DrawString(nomeDoMinistro, fontePadrao, pincel, 60, 130);

                    /* Matricula do ministro */
                    grafico.DrawString(matriculaDoMinistro, fontePadrao, pincel, 60, 163);

                    /* Cargo do ministro */
                    grafico.DrawString(cargoDoMinistro, fontePadrao, pincel, 220, 163);

                    /* Data do batismo/aguas */
                    grafico.DrawString(dataBatismoAguasDoMinistro, fontePadrao, pincel, 60, 190);

                    /* Congregação */
                    grafico.DrawString(congregacaoDoMinistro, fontePadrao, pincel, 220, 190);

                    /* Nome do Pai do ministro */
                    grafico.DrawString(nomePaiDoMinistro, fontePadrao, pincel, 415, 30);

                    /* Nome da Mãe do ministro */
                    grafico.DrawString(nomeMaeDoMinistro, fontePadrao, pincel, 415, 55);

                    /* Naturalidade do ministro */
                    grafico.DrawString(naturalidadeDoMinistro, fontePadrao, pincel, 440, 89);

                    /* Nacionalidade do ministro */
                    grafico.DrawString(nacionalidadeDoMinistro, fontePadrao, pincel, 560, 89);

                    /* Estado Civil do ministro */
                    grafico.DrawString(estadoCivilDoMinistro, fontePadrao, pincel, 440, 115);

                    /* Data de Nascimento do ministro */
                    grafico.DrawString(dataNascimentoDoMinistro, fontePadrao, pincel, 560, 115);

                    /* RG do ministro */
                    grafico.DrawString(rgDoMinistro, fontePadrao, pincel, 440, 142);

                    grafico.DrawString(orgaoEmissorRgDoMinistro, fontePadrao, pincel, 560, 142);
                }

                imagem.Save(memStream, ImageFormat.Jpeg);

            }

            return memStream.ToArray();
        }

        public void SalvarCredencial(byte[] dados, string nome)
        {
            try
            {
                var caminhoPadrao = "C:\\Credencial\\" + string.Format("{0}_{1}", Guid.NewGuid().ToString(), nome) + ".jpg";
                File.WriteAllBytes(caminhoPadrao, dados);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
