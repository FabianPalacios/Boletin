using Boletin.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Mapeadores.Parametros
{
    public class MapeadorBulletinGUI : MapeadorBaseGUI<BulletinDTO, ModeloBulletinGUI>
    {
        public override ModeloBulletinGUI MapearTipo1Tipo2(BulletinDTO entrada)
        {
            return new ModeloBulletinGUI()
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

        public override IEnumerable<ModeloBulletinGUI> MapearTipo1Tipo2(IEnumerable<BulletinDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override BulletinDTO MapearTipo2Tipo1(ModeloBulletinGUI entrada)
        {
            return new BulletinDTO()
            {
                Id = entrada.Id,
                Id_Student = entrada.Id_Student,
                Id_Grade = entrada.Id_Grade,
                Id_Period = entrada.Id_Period
            };
        }

        public override IEnumerable<BulletinDTO> MapearTipo2Tipo1(IEnumerable<ModeloBulletinGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}