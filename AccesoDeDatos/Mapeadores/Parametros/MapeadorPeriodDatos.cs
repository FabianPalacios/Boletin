using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorPeriodDatos : MapeadorBaseDatos<tb_period, PeriodDbModel>
    {
        public override PeriodDbModel MapearTipo1Tipo2(tb_period entrada)
        {
            return new PeriodDbModel()
            {
                Id = entrada.id,
                NumPeriod = entrada.numPeriod
            };
        }

        public override IEnumerable<PeriodDbModel> MapearTipo1Tipo2(IEnumerable<tb_period> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_period MapearTipo2Tipo1(PeriodDbModel entrada)
        {
            return new tb_period()
            {
                id = entrada.Id,
                numPeriod = entrada.NumPeriod
            };
        }

        public override IEnumerable<tb_period> MapearTipo2Tipo1(IEnumerable<PeriodDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
