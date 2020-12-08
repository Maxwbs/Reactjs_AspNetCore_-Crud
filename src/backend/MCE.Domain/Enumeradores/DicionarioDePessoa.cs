using MCE.Domain.Enumeradores.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCE.Domain.Enumeradores
{
    public class DicionarioDePessoa : DicionarioDeEnumeraodorAbstrato
    {
        public DicionarioDePessoa()
        {
            DefinaEnumeradores(new DicionarioDeEnumerodores<EnumCargoMinisterial>
                    {
                        { EnumCargoMinisterial.PASTOR, "Pastor" },
                        { EnumCargoMinisterial.PASTORA, "Pastora" },
                        { EnumCargoMinisterial.PRESBITERO, "Presbítero" },
                        { EnumCargoMinisterial.AUXILIAR, "Auxiliar" },
                        { EnumCargoMinisterial.EVANGELISTA, "Evangelista" },
                        { EnumCargoMinisterial.DIACONO, "Diácono" },
                        { EnumCargoMinisterial.DIACONISA, "Diaconisa" },
                        { EnumCargoMinisterial.MISSIONARIO, "Missionário" },
                        { EnumCargoMinisterial.MISSIONARIA, "Missionária" },
                        { EnumCargoMinisterial.MEMBRO, "Membro" }
                    });

            DefinaEnumeradores(new DicionarioDeEnumerodores<EnumSexo>
                    {
                        { EnumSexo.MASCULINO, "Masculino" },
                        { EnumSexo.FEMININO, "Feminino" }                        
                    });

            DefinaEnumeradores(new DicionarioDeEnumerodores<EnumEstadoCivil>
                    {
                        { EnumEstadoCivil.CASADO, "Casado(a)" },
                        { EnumEstadoCivil.SOLTEIRO, "Solteiro(a)" },
                        { EnumEstadoCivil.VIUVO, "Viúvo(a)" }
                    });
        }
        public static DicionarioDeEnumerodores<EnumSexo> DicionarioEnumeradorSexo
        {
            get
            {
                return ObtenhaEnumeradores<EnumSexo>();
            }
        }
        public static DicionarioDeEnumerodores<EnumEstadoCivil> DicionarioEnumeradorEstadoCivil
        {
            get
            {
                return ObtenhaEnumeradores<EnumEstadoCivil>();
            }
        }

        public static DicionarioDeEnumerodores<EnumCargoMinisterial> DicionarioEnumeradorCargoMinisterial
        {
            get
            {
                return ObtenhaEnumeradores<EnumCargoMinisterial>();
            }
        }
    }
}
