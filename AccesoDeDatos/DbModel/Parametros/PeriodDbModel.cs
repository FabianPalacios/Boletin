using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Parametros
{
    public class PeriodDbModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string numPeriod;

        public string NumPeriod
        {
            get { return numPeriod; }
            set { numPeriod = value; }
        }
    }
}
