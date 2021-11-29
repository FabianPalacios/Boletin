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
    public class ImplMatterLogica
    {
        private ImplMatterDatos accesoDatos;

        public ImplMatterLogica()
        {
            this.accesoDatos = new ImplMatterDatos();
        }

        /// <summary>
        /// Listar Registros
        /// </summary>
        /// <param name="filtro">filtro de busqueda</param>
        /// <param name="numPagina">Pagina Actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a monstrar por pagina</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincidan con el filtro</returns>
        public IEnumerable<MatterDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorMatterLogica mapeador = new MapeadorMatterLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<BulletinDTO> ListarRegistroBulletin()
        {
            var listado = this.accesoDatos.ListarRegistroBulletin();
            MapeadorBulletinLogica mapeador = new MapeadorBulletinLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public MatterDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorMatterLogica mapeador = new MapeadorMatterLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(MatterDTO registro)
        {
            MapeadorMatterLogica mapeador = new MapeadorMatterLogica();
            MatterDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(MatterDTO registro)
        {
            MapeadorMatterLogica mapeador = new MapeadorMatterLogica();
            MatterDbModel reg = mapeador.MapearTipo2Tipo1(registro);
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
