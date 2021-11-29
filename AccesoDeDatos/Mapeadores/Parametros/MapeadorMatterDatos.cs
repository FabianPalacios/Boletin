using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorMatterDatos : MapeadorBaseDatos<tb_matter, MatterDbModel>
    {
        public override MatterDbModel MapearTipo1Tipo2(tb_matter entrada)
        {
            return new MatterDbModel()
            {
                Id = entrada.id,
                Id_Bulletin = entrada.id_bulletin,
                Name = entrada.name,
                Description = entrada.description
            };
        }

        public override IEnumerable<MatterDbModel> MapearTipo1Tipo2(IEnumerable<tb_matter> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_matter MapearTipo2Tipo1(MatterDbModel entrada)
        {
            return new tb_matter()
            {
                id = entrada.Id,
                id_bulletin = entrada.Id_Bulletin,
                name = entrada.Name,
                description = entrada.Description
            };
        }

        public override IEnumerable<tb_matter> MapearTipo2Tipo1(IEnumerable<MatterDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
