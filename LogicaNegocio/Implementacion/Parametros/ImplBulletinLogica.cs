using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplBulletinLogica
    {
        private ImplBulletinDatos accesoDatos;

        public ImplBulletinLogica()
        {
            this.accesoDatos = new ImplBulletinDatos();
        }

        /// <summary>
        /// Listar Registros
        /// </summary>
        /// <param name="filtro">filtro de busqueda</param>
        /// <param name="numPagina">Pagina Actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a monstrar por pagina</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincidan con el filtro</returns>
        public IEnumerable<BulletinDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorBulletinLogica mapeador = new MapeadorBulletinLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<StudentDTO> ListarRegistroStudent()
        {
            var listado = this.accesoDatos.ListarRegistroStudent();
            MapeadorStudentLogica mapeador = new MapeadorStudentLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<GradeDTO> ListarRegistroGrade()
        {
            var listado = this.accesoDatos.ListarRegistroGrade();
            MapeadorGradeLogica mapeador = new MapeadorGradeLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<PeriodDTO> ListarRegistroPeriod()
        {
            var listado = this.accesoDatos.ListarRegistroPeriod();
            MapeadorPeriodLogica mapeador = new MapeadorPeriodLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        public BulletinDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorBulletinLogica mapeador = new MapeadorBulletinLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(BulletinDTO registro)
        {
            MapeadorBulletinLogica mapeador = new MapeadorBulletinLogica();
            BulletinDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(BulletinDTO registro)
        {
            MapeadorBulletinLogica mapeador = new MapeadorBulletinLogica();
            BulletinDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }
    }
}
