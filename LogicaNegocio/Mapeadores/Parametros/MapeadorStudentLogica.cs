using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorStudentLogica : MapeadorBaseLogica<StudentDbModel, StudentDTO>
    {
        public override StudentDTO MapearTipo1Tipo2(StudentDbModel entrada)
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

        public override IEnumerable<StudentDTO> MapearTipo1Tipo2(IEnumerable<StudentDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override StudentDbModel MapearTipo2Tipo1(StudentDTO entrada)
        {
            return new StudentDbModel()
            {
                Id = entrada.Id,
                FirstName = entrada.FirstName,
                SecondName = entrada.SecondName,
                FirstSurName = entrada.FirstSurName,
                SecondSurName = entrada.SecondSurName,
                Documento = entrada.Documento
            };
        }

        public override IEnumerable<StudentDbModel> MapearTipo2Tipo1(IEnumerable<StudentDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
