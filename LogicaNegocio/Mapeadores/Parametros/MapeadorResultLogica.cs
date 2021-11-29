using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorResultLogica : MapeadorBaseLogica<ResultDbModel, ResultDTO>
    {
        public override ResultDTO MapearTipo1Tipo2(ResultDbModel entrada)
        {
            return new ResultDTO()
            {
                Id = entrada.Id,
                Id_Matter = entrada.Id_Matter,
                Nota = entrada.Nota,
                NameMatter = entrada.NameMatter
            };
        }

        public override IEnumerable<ResultDTO> MapearTipo1Tipo2(IEnumerable<ResultDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ResultDbModel MapearTipo2Tipo1(ResultDTO entrada)
        {
            return new ResultDbModel()
            {
                Id = entrada.Id,
                Id_Matter = entrada.Id_Matter,
                Nota = entrada.Nota
            };
        }

        public override IEnumerable<ResultDbModel> MapearTipo2Tipo1(IEnumerable<ResultDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }

    }
}
