using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Campos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades

        /// <summary>
        /// Solo se instanciaran listas que no contengan referencias en NULL
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                if (!Equals(value, null))
                {
                    alumnos = value;
                }
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                clase = value;
            }
        }

        /// <summary>
        /// Sera instanciado el instructor solo si no contiene una referencia en NULL
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                if (!Equals(value, null))
                {
                    instructor = value;
                }
            }
        } 

        #endregion

        #region Constructores 

        /// <summary>
        /// Inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa un objeto jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto y devuelve una cadena con su contenido
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            return Equals(jornada, null) ? false : new Texto().Guardar(@".\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee los datos de la jornada de un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            new Texto().Leer(@".\Jornada.txt", out string datos);
            return datos;
        }

        /// <summary>
        /// Retorna una cadena con los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR ", Clase.ToString());
            sb.AppendLine((object.Equals(Instructor, null)) ? "" : Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno item in Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        /// <summary>
		/// Una jornada será distinta a un alumno si el alumno NO puede tomar la clase de la jornada
		/// </summary>
		/// <param name="j">Jornada a comparar</param>
		/// <param name="a">Alumno a comparar</param>
		/// <returns>Retorna TRUE si la jornada es distinta al alumno, FALSE en caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
		/// Una jornada será igual a un alumno si el alumno NO puede tomar la clase de la jornada
		/// </summary>
		/// <param name="j">Jornada a comparar</param>
		/// <param name="a">Alumno a comparar</param>
		/// <returns>Retorna TRUE si la jornada es distinta al alumno, FALSE en caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return !Equals(j, null) && a == j.Clase;
        }

        /// <summary>
        /// Agrega un alumno a la jornada si se la puede cursar y ya no se encuentra en la misma
        /// </summary>
        /// <param name="j">Jornada a agregar</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la jornada con el alumno cargado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == a)
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
                j.Alumnos.Add(a);
            }

            return j;
        } 

        #endregion
    }
}
