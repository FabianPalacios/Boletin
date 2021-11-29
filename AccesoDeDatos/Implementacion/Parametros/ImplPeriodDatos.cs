using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplPeriodDatos
    {
        public object tb_period;

        /// <summary>
        /// Metodo para listar Registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<PeriodDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<PeriodDbModel>();

            using (BoletinBDEntities bd = new BoletinBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //lista = bd.tb_grade.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from p in bd.tb_period
                                  where p.numPeriod.Contains(filtro)
                                  select p).OrderBy(p => p.id).ToList();
                totalRegistros = lista.Count();
                listaDatos = listaDatos.OrderBy(p => p.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorPeriodDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para almacenar un registro
        /// </summary>
        /// <param name="registro">El registro a almacenar </param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción/returns>
        public bool GuardarRegistro(PeriodDbModel registro)
        {
            try
            {
                using (BoletinBDEntities bd = new BoletinBDEntities())
                {
                    //Verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_period.Where(x => x.numPeriod.ToLower().Equals(registro.NumPeriod.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        MapeadorPeriodDatos mapeador = new MapeadorPeriodDatos();
                        var reg = mapeador.MapearTipo2Tipo1(registro);
                        bd.tb_period.Add(reg);
                        bd.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de búsqueda de un registro
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>el objeto con id buscado o null cuando no exista</returns>
        public PeriodDbModel BuscarRegistro(int id)
        {
            using (BoletinBDEntities bd = new BoletinBDEntities())
            {
                tb_period registro = bd.tb_period.Find(id);
                return new MapeadorPeriodDatos().MapearTipo1Tipo2(registro);
            }
        }


        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">Registro editado</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción</returns>
        public bool EditarRegistro(PeriodDbModel registro)
        {
            try
            {
                using (BoletinBDEntities bd = new BoletinBDEntities())
                {
                    //Verificación de la existencia de un registro con el mismo id
                    if (bd.tb_period.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        MapeadorPeriodDatos mapeador = new MapeadorPeriodDatos();
                        var reg = mapeador.MapearTipo2Tipo1(registro);
                        bd.Entry(reg).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo de eliminar un registro por id
        /// </summary>
        /// <param name="id">Id del registro a elimniar</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción</returns>
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (BoletinBDEntities bd = new BoletinBDEntities())
                {

                    //Verificación de la existencia de un registro con el mismo id
                    tb_period registo = bd.tb_period.Find(id);
                    if (registo == null)
                    {
                        return false;
                    }
                    else
                    {
                        bd.tb_period.Remove(registo);
                        bd.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
