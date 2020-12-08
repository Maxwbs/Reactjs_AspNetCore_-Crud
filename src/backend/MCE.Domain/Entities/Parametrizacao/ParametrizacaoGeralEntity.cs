using System;
using System.Collections.Generic;
using System.Text;

namespace MCE.Domain.Entities.Parametrizacao
{
    public class ParametrizacaoGeralEntity : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Extensao { get; set; }
        public long Tamanho { get; set; }
        public string Imagem { get; set; }
        public string ContentType { get; set; }
    }
}
