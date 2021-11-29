using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Parametros
{
    public class ResultDbModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_matter;

        public int Id_Matter
        {
            get { return id_matter; }
            set { id_matter = value; }
        }

        private string nota;

        public string Nota
        {
            get { return nota; }
            set { nota = value; }
        }

        private string nameMatter;

        public string NameMatter
        {
            get { return nameMatter; }
            set { nameMatter = value; }
        }


    }
}
