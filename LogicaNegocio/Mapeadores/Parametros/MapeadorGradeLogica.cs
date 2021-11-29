using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorGradeLogica : MapeadorBaseLogica<GradeDbModel, GradeDTO>
    {
        public override GradeDTO MapearTipo1Tipo2(GradeDbModel entrada)
        {
            return new GradeDTO()
            {
                Id = entrada.Id,
                Degree = entrada.Degree
            };
        }

        public override IEnumerable<GradeDTO> MapearTipo1Tipo2(IEnumerable<GradeDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override GradeDbModel MapearTipo2Tipo1(GradeDTO entrada)
        {
            return new GradeDbModel()
            {
                Id = entrada.Id,
                Degree = entrada.Degree
            };
        }

        public override IEnumerable<GradeDbModel> MapearTipo2Tipo1(IEnumerable<GradeDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
