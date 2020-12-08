using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCE.Domain.Enumeradores.Generic
{
    public abstract class DicionarioDeEnumeraodorAbstrato
    {
        private static IDictionary<Type, IDictionary> _enumeradoresGeral = new Dictionary<Type, IDictionary>();

        protected static void DefinaEnumeradores<T>(DicionarioDeEnumerodores<T> globalizacoes)
        {
            if (!EnumeradorDefinido(typeof(T)))
            {
                _enumeradoresGeral.Add(typeof(T), globalizacoes);
            }
        }
        
        public static DicionarioDeEnumerodores<T> ObtenhaEnumeradores<T>()
        {
            IDictionary retorno = null;

            _enumeradoresGeral.TryGetValue(typeof(T), out retorno);

            return retorno as DicionarioDeEnumerodores<T>;
        }

        public static bool EnumeradorDefinido(Type tipo)
        {
            IDictionary item;
            if (!_enumeradoresGeral.TryGetValue(tipo, out item))
            {
                return false;
            }

            return true;
        }
        public static List<ItemDoEnumerador<TCodigo>> CrieObjetoCodigoEDescricao<T, TCodigo>()
            where T : struct
            where TCodigo : struct
        {
            var listaCodigoDescricaoEnumerador =
                Enum.GetNames(typeof(T)).Select(nome => new ItemDoEnumerador<TCodigo>()
                {
                    Codigo = (TCodigo)Enum.Parse(typeof(T), nome),
                    Descricao = ObtenhaEnumeradores<T>()[(T)Enum.Parse(typeof(T), nome)]
                }).ToList();

            return listaCodigoDescricaoEnumerador;
        }
    }
}
