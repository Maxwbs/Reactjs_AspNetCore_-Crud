using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MCE.Domain.Enumeradores.Generic
{
    [Serializable]
    public class DicionarioDeEnumerodores<TChave> : Dictionary<TChave, string>, IDictionary<TChave, string>
    {       
        public DicionarioDeEnumerodores()
            : base()
        {
        }      
        protected DicionarioDeEnumerodores(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }               
        public new string this[TChave key]
        {
            get
            {
                if (base.ContainsKey(key))
                {
                    var valor = base[key];

                    return  valor;
                }

                return key.ToString();
            }

            set
            {
                base[key] = value;
            }
        }

    }
}
