using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Models.Parametros
{
    public class ModeloPeriodGUI
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