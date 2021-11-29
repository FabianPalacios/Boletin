using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Mapeadores.Parametros
{
    public class MapeadorGradeGUI : MapeadorBaseGUI<GradeDTO, ModeloGradeGUI>
    {
        public override ModeloGradeGUI MapearTipo1Tipo2(GradeDTO entrada)
        {
            return new ModeloGradeGUI()
            {
                Id = entrada.Id,
                Degree = entrada.Degree
            };
        }

        public override IEnumerable<ModeloGradeGUI> MapearTipo1Tipo2(IEnumerable<GradeDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override GradeDTO MapearTipo2Tipo1(ModeloGradeGUI entrada)
        {
            return new GradeDTO()
            {
                Id = entrada.Id,
                Degree = entrada.Degree
            };
        }

        public override IEnumerable<GradeDTO> MapearTipo2Tipo1(IEnumerable<ModeloGradeGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}