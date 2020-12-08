using MCE.Domain.Entities.Pessoa;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCE.Domain.Entities.Endereco
{
    public class EnderecoEntity : EntidadeBase
    {
        public  string Cep { get; set; }
        public  string Logradouro { get; set; }
        public  string Complemento { get; set ;}
        public  string Bairro { get; set; }
        public  string Localidade { get; set; }
        public  string Uf { get; set; }
        public  string Ddd { get; set; }       
        public  Guid IdPessoaEndereco { get; set; }
    }
}
