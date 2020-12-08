

using System;
using MCE.Domain.Entities.Endereco;
using MCE.Domain.Entities.Pessoa;
using MCE.Domain.Enumeradores;

namespace MCE.Domain.Entities.Membro
{
    public class MembroEntity : EntidadeBase
    {
        public string Email { get; set; }        
        public EnumCargoMinisterial CargoMinisterial { get; set; }       
        public bool MembroEhAtivo { get; set; }
        public bool GerarCredencial { get; set; }
        public DateTime? DataBatismoEspiritoSanto { get; set; }       
        public DateTime? DataBatismoAguas { get; set; }
        public byte[] CredencialMinistro { get; set; }
        public EnumCongregracao? Congregacao { get; set; }
        public EnderecoEntity Endereco { get; set; }
        public PessoaEntity Pessoa { get; set; }
    }
}
