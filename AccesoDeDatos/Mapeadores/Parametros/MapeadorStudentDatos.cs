using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorStudentDatos : MapeadorBaseDatos<tb_student, StudentDbModel>
    {
        public override StudentDbModel MapearTipo1Tipo2(tb_student entrada)
        {
            return new StudentDbModel()
            {
                Id = entrada.id,
                FirstName = entrada.firstName,
                SecondName = entrada.secondName,
                FirstSurName = entrada.firstSurName,
                SecondSurName = entrada.secondSurName,
                Documento = entrada.documento
            };
        }

        public override IEnumerable<StudentDbModel> MapearTipo1Tipo2(IEnumerable<tb_student> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_student MapearTipo2Tipo1(StudentDbModel entrada)
        {
            return new tb_student()
            {
                id = entrada.Id,
                firstName = entrada.FirstName,
                secondName = entrada.SecondName,
                firstSurName = entrada.FirstSurName,
                secondSurName = entrada.SecondSurName,
                documento = entrada.Documento
            };
        }

        public override IEnumerable<tb_student> MapearTipo2Tipo1(IEnumerable<StudentDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
