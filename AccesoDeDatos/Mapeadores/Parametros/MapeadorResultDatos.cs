using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorResultDatos : MapeadorBaseDatos<tb_result, ResultDbModel>
    {
        public override ResultDbModel MapearTipo1Tipo2(tb_result entrada)
        {
            return new ResultDbModel()
            {
                Id = entrada.id,
                Id_Matter = entrada.id_matter,
                Nota = entrada.nota,
                NameMatter = entrada.tb_matter.name
            };
        }

        public override IEnumerable<ResultDbModel> MapearTipo1Tipo2(IEnumerable<tb_result> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_result MapearTipo2Tipo1(ResultDbModel entrada)
        {
            return new tb_result()
            {
                id = entrada.Id,
                id_matter = entrada.Id_Matter,
                nota = entrada.Nota
            };
        }

        public override IEnumerable<tb_result> MapearTipo2Tipo1(IEnumerable<ResultDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
