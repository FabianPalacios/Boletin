using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorBulletinLogica : MapeadorBaseLogica<BulletinDbModel, BulletinDTO>
    {
        public override BulletinDTO MapearTipo1Tipo2(BulletinDbModel entrada)
        {
            return new BulletinDTO()
            {
                Id = entrada.Id,
                Id_Student = entrada.Id_Student,
                Id_Grade = entrada.Id_Grade,
                Id_Period = entrada.Id_Period,
                Documento = entrada.Documento,
                Degree = entrada.Degree,
                NumPeriod = entrada.NumPeriod
            };
        }

        public override IEnumerable<BulletinDTO> MapearTipo1Tipo2(IEnumerable<BulletinDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override BulletinDbModel MapearTipo2Tipo1(BulletinDTO entrada)
        {
            return new BulletinDbModel()
            {
                Id = entrada.Id,
                Id_Student = entrada.Id_Student,
                Id_Grade = entrada.Id_Grade,
                Id_Period = entrada.Id_Period
            };
        }

        public override IEnumerable<BulletinDbModel> MapearTipo2Tipo1(IEnumerable<BulletinDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
