using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorMatterLogica: MapeadorBaseLogica<MatterDbModel, MatterDTO>
    {
        public override MatterDTO MapearTipo1Tipo2(MatterDbModel entrada)
        {
            return new MatterDTO()
            {
                Id = entrada.Id,
                Id_Bulletin = entrada.Id_Bulletin,
                Name = entrada.Name,
                Description = entrada.Description
            };
        }

        public override IEnumerable<MatterDTO> MapearTipo1Tipo2(IEnumerable<MatterDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MatterDbModel MapearTipo2Tipo1(MatterDTO entrada)
        {
            return new MatterDbModel()
            {
                Id = entrada.Id,
                Id_Bulletin = entrada.Id_Bulletin,
                Name = entrada.Name,
                Description = entrada.Description
            };
        }

        public override IEnumerable<MatterDbModel> MapearTipo2Tipo1(IEnumerable<MatterDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
