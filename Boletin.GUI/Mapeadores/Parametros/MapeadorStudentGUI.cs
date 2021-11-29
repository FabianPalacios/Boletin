using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Mapeadores.Parametros
{
    public class MapeadorStudentGUI : MapeadorBaseGUI<StudentDTO, ModeloStudentGUI>
    {
        public override ModeloStudentGUI MapearTipo1Tipo2(StudentDTO entrada)
        {
            return new ModeloStudentGUI()
            {
                Id = entrada.Id,
                FirstName = entrada.FirstName,
                SecondName = entrada.SecondName,
                FirstSurName = entrada.FirstSurName,
                SecondSurName = entrada.SecondSurName,
                Documento = entrada.Documento
            };
        }

        public override IEnumerable<ModeloStudentGUI> MapearTipo1Tipo2(IEnumerable<StudentDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override StudentDTO MapearTipo2Tipo1(ModeloStudentGUI entrada)
        {
            return new StudentDTO()
            {
                Id = entrada.Id,
                FirstName = entrada.FirstName,
                SecondName = entrada.SecondName,
                FirstSurName = entrada.FirstSurName,
                SecondSurName = entrada.SecondSurName,
                Documento = entrada.Documento
            };
        }

        public override IEnumerable<StudentDTO> MapearTipo2Tipo1(IEnumerable<ModeloStudentGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}