using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.DTO.Parametros
{
    public class BulletinDTO
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int id_Student;
        public int Id_Student
        {
            get { return id_Student; }
            set { id_Student = value; }
        }

        private int id_Grade;

        public int Id_Grade
        {
            get { return id_Grade; }
            set { id_Grade = value; }
        }

        private int id_period;

        public int Id_Period
        {
            get { return id_period; }
            set { id_period = value; }
        }

        private string degree;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        private string numPeriod;

        public string NumPeriod
        {
            get { return numPeriod; }
            set { numPeriod = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
    }
}
