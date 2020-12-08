using System;
using System.ComponentModel.DataAnnotations.Schema;
using MCE.Domain.Entities.Endereco;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Enumeradores;

namespace MCE.Domain.Entities.Pessoa
{
    public class PessoaEntity : EntidadeBase
    {
        public string Nome { get; set; }
       
        public string NomePai { get; set; }
       
        public string NomeMae { get; set; }
                
        public EnumSexo Sexo { get; set; }
        
        public string Rg { get; set; }

        public string Cpf { get; set; }

        public string Naturalidade { get; set; }

        public EnumEstadoCivil EstadoCivil { get; set; }        

        public string OrgaoEmissorRg { get; set; }

        public string Nacionalidade { get; set; }

        public DateTime? DataNascimento { get; set; }

        public Guid IdPessoaMembro { get; set; }
    }
}
