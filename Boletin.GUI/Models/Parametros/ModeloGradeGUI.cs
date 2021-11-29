using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Models.Parametros
{
    public class ModeloGradeGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string degree;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }
    }
}