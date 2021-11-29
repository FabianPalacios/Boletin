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
    public class ImplResultLogica
    {
        private ImplResultDatos accesoDatos;

        public ImplResultLogica()
        {
            this.accesoDatos = new ImplResultDatos();
        }

        /// <summary>
        /// Listar Registros
        /// </summary>
        /// <param name="filtro">filtro de busqueda</param>
        /// <param name="numPagina">Pagina Actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a monstrar por pagina</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincidan con el filtro</returns>
        public IEnumerable<ResultDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorResultLogica mapeador = new MapeadorResultLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public IEnumerable<MatterDTO> ListarRegistroMatter()
        {
            var listado = this.accesoDatos.ListarRegistroMatter();
            MapeadorMatterLogica mapeador = new MapeadorMatterLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        public ResultDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorResultLogica mapeador = new MapeadorResultLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(ResultDTO registro)
        {
            MapeadorResultLogica mapeador = new MapeadorResultLogica();
            ResultDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(ResultDTO registro)
        {
            MapeadorResultLogica mapeador = new MapeadorResultLogica();
            ResultDbModel reg = mapeador.MapearTipo2Tipo1(registro);
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
