using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Mapeadores.Parametros
{
    public class MapeadorResultGUI : MapeadorBaseGUI<ResultDTO, ModeloResultGUI>
    {
        public override ModeloResultGUI MapearTipo1Tipo2(ResultDTO entrada)
        {
            return new ModeloResultGUI()
            {
                Id = entrada.Id,
                Id_Matter = entrada.Id_Matter,
                Nota = entrada.Nota,
                NameMatter = entrada.NameMatter
            };
        }

        public override IEnumerable<ModeloResultGUI> MapearTipo1Tipo2(IEnumerable<ResultDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ResultDTO MapearTipo2Tipo1(ModeloResultGUI entrada)
        {
            return new ResultDTO()
            {
                Id = entrada.Id,
                Id_Matter = entrada.Id_Matter,
                Nota = entrada.Nota
            };
        }

        public override IEnumerable<ResultDTO> MapearTipo2Tipo1(IEnumerable<ModeloResultGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}