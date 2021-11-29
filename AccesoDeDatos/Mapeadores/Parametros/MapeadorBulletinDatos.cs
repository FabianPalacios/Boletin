using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorBulletinDatos: MapeadorBaseDatos<tb_bulletin, BulletinDbModel>
    {
        public override BulletinDbModel MapearTipo1Tipo2(tb_bulletin entrada)
        {
            return new BulletinDbModel()
            {
                Id = entrada.id,
                Id_Student = entrada.id_student,
                Id_Grade = entrada.id_grade,
                Id_Period = entrada.id_period,
                Documento = entrada.tb_student.documento,
                Degree = entrada.tb_grade.degree,
                NumPeriod = entrada.tb_period.numPeriod
            };
        }

        public override IEnumerable<BulletinDbModel> MapearTipo1Tipo2(IEnumerable<tb_bulletin> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_bulletin MapearTipo2Tipo1(BulletinDbModel entrada)
        {
            return new tb_bulletin()
            {
                id = entrada.Id,
                id_student = entrada.Id_Student,
                id_grade = entrada.Id_Grade,
                id_period = entrada.Id_Period,
            };
        }

        public override IEnumerable<tb_bulletin> MapearTipo2Tipo1(IEnumerable<BulletinDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
