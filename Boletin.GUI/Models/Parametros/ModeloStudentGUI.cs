using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boletin.GUI.Models.Parametros
{
    public class ModeloStudentGUI
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string secondName;

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        private string firstSurName;

        public string FirstSurName
        {
            get { return firstSurName; }
            set { firstSurName = value; }
        }

        private string secondSurName;

        public string SecondSurName
        {
            get { return secondSurName; }
            set { secondSurName = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
    }
}