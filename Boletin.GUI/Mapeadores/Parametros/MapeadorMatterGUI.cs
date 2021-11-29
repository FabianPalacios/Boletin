using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Mapeadores.Parametros
{
    public class MapeadorMatterGUI : MapeadorBaseGUI<MatterDTO, ModeloMatterGUI>
    {
        public override ModeloMatterGUI MapearTipo1Tipo2(MatterDTO entrada)
        {
            return new ModeloMatterGUI()
            {
                Id = entrada.Id,
                Id_Bulletin = entrada.Id_Bulletin,
                Name = entrada.Name,
                Description = entrada.Description
            };
        }

        public override IEnumerable<ModeloMatterGUI> MapearTipo1Tipo2(IEnumerable<MatterDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MatterDTO MapearTipo2Tipo1(ModeloMatterGUI entrada)
        {
            return new MatterDTO()
            {
                Id = entrada.Id,
                Id_Bulletin = entrada.Id_Bulletin,
                Name = entrada.Name,
                Description = entrada.Description
            };
        }

        public override IEnumerable<MatterDTO> MapearTipo2Tipo1(IEnumerable<ModeloMatterGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}