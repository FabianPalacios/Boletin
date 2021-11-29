using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorGradeDatos : MapeadorBaseDatos<tb_grade, GradeDbModel>
    {
        public override GradeDbModel MapearTipo1Tipo2(tb_grade entrada)
        {
            return new GradeDbModel()
            {
                Id = entrada.id,
                Degree = entrada.degree
            };
        }

        public override IEnumerable<GradeDbModel> MapearTipo1Tipo2(IEnumerable<tb_grade> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_grade MapearTipo2Tipo1(GradeDbModel entrada)
        {
            return new tb_grade()
            {
                id = entrada.Id,
                degree = entrada.Degree
            };
        }

        public override IEnumerable<tb_grade> MapearTipo2Tipo1(IEnumerable<GradeDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
