using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Mapeadores.Parametros
{
    public class MapeadorPeriodGUI : MapeadorBaseGUI<PeriodDTO, ModeloPeriodGUI>
    {
        public override ModeloPeriodGUI MapearTipo1Tipo2(PeriodDTO entrada)
        {
            return new ModeloPeriodGUI()
            {
                Id = entrada.Id,
                NumPeriod = entrada.NumPeriod
            };
        }

        public override IEnumerable<ModeloPeriodGUI> MapearTipo1Tipo2(IEnumerable<PeriodDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PeriodDTO MapearTipo2Tipo1(ModeloPeriodGUI entrada)
        {
            return new PeriodDTO()
            {
                Id = entrada.Id,
                NumPeriod = entrada.NumPeriod
            };
        }

        public override IEnumerable<PeriodDTO> MapearTipo2Tipo1(IEnumerable<ModeloPeriodGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}