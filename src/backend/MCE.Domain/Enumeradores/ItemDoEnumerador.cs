using System;
using System.Collections.Generic;
using System.Text;

namespace MCE.Domain.Enumeradores
{
    public class ItemDoEnumerador<T> where T : struct
    {
        public T? Codigo { get; set; }

        public string Descricao { get; set; }
    }
}
