using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Models.Parametros
{
    public class ModeloMatterGUI
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_bulletin;

        public int Id_Bulletin
        {
            get { return id_bulletin; }
            set { id_bulletin = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}