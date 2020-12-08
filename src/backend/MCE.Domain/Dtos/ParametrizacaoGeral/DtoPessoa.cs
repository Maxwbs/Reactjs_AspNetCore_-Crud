using System;
using MCE.Domain.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace MCE.Domain.Dtos
{
    public class DtoPessoa
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
                
        public DateTime? DataNascimento { get; set;}
    }
}
