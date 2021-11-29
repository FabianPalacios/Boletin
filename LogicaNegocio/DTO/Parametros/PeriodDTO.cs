using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class PeriodDTO
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
