﻿using AccesoDeDatos.DbModel.Parametros;
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
    public class ImplMatterDatos
    {
        public object tb_matter;

        /// <summary>
        /// Metodo para listar Registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<MatterDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<MatterDbModel>();

            using (BoletinBDEntities bd = new BoletinBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //lista = bd.tb_matter.Where(x => x.nombre.Contains(filtro)).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                var listaDatos = (from g in bd.tb_matter
                                  select g).OrderBy(m => m.id).ToList();
                totalRegistros = lista.Count();
                listaDatos = listaDatos.OrderBy(g => g.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorMatterDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        public IEnumerable<BulletinDbModel> ListarRegistroBulletin()
        {
            var lista = new List<BulletinDbModel>();

            using (BoletinBDEntities bd = new BoletinBDEntities())
            {
                var listaDatos = (from e in bd.tb_bulletin
                                  select e).ToList();
                lista = new MapeadorBulletinDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para almacenar un registro
        /// </summary>
        /// <param name="registro">El registro a almacenar </param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción/returns>
        public bool GuardarRegistro(MatterDbModel registro)
        {
            try
            {
                using (BoletinBDEntities bd = new BoletinBDEntities())
                {
                    //Verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_matter.Where(x => x.name.ToLower().Equals(registro.Name.ToLower())).Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        MapeadorMatterDatos mapeador = new MapeadorMatterDatos();
                        var reg = mapeador.MapearTipo2Tipo1(registro);
                        bd.tb_matter.Add(reg);
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
        public MatterDbModel BuscarRegistro(int id)
        {
            using (BoletinBDEntities bd = new BoletinBDEntities())
            {
                tb_matter registro = bd.tb_matter.Find(id);
                return new MapeadorMatterDatos().MapearTipo1Tipo2(registro);
            }
        }


        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">Registro editado</param>
        /// <returns>true cuando almacena, false cuando existe un registro o una excepción</returns>
        public bool EditarRegistro(MatterDbModel registro)
        {
            try
            {
                using (BoletinBDEntities bd = new BoletinBDEntities())
                {
                    //Verificación de la existencia de un registro con el mismo id
                    if (bd.tb_matter.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    else
                    {
                        MapeadorMatterDatos mapeador = new MapeadorMatterDatos();
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
                    tb_matter registo = bd.tb_matter.Find(id);
                    if (registo == null)
                    {
                        return false;
                    }
                    else
                    {
                        bd.tb_matter.Remove(registo);
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
