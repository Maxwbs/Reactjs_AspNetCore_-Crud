using System;
using MCE.Domain.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace MCE.Domain.Dtos
{
    public class DtoMembro
    {
        public Guid Id { get; set; }

        public string Email { get; set; }        

        public EnumCargoMinisterial CargoMinisterial { get; set; }       
        
        public bool MembroEhAtivo { get; set; }
       
        public bool GerarCredencial { get; set; }
        
        public DateTime? DataBatismoEspiritoSanto { get; set; }   

        public DateTime? DataBatismoAguas { get; set; }
   
        public EnumCongregracao? Congregacao { get; set; }

        public DtoEndereco DtoEndereco { get; set; }

        public DtoPessoa DtoPessoa { get; set; }
    }
}
