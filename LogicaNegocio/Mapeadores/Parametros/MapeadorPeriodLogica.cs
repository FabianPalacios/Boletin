using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
   public class MapeadorPeriodLogica : MapeadorBaseLogica<PeriodDbModel, PeriodDTO>

    {
        public override PeriodDTO MapearTipo1Tipo2(PeriodDbModel entrada)
        {
            return new PeriodDTO()
            {
                Id = entrada.Id,
                NumPeriod = entrada.NumPeriod
            };
        }

        public override IEnumerable<PeriodDTO> MapearTipo1Tipo2(IEnumerable<PeriodDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PeriodDbModel MapearTipo2Tipo1(PeriodDTO entrada)
        {
            return new PeriodDbModel()
            {
                Id = entrada.Id,
                NumPeriod = entrada.NumPeriod
            };
        }

        public override IEnumerable<PeriodDbModel> MapearTipo2Tipo1(IEnumerable<PeriodDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
