using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;


namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Campos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades

        /// <summary>
        /// La lista solo se creara si no apunta a NULL
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        /// <summary>
        /// La lista solo se creara si no apunta a NULL
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }

        /// <summary>
        /// La lista solo se creara si no apunta a NULL
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornada;
            }
            set
            {
                jornada = value;
            }
        }

        #endregion

        #region Indexador

        /// <summary>
        /// Indexa la lista de jornadas. Se lanza una excepcion si el indice al cual se quiere acceder es invalido
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada jornada = null;
                if (i >= 0 && i < Jornadas.Count)
                {
                    jornada = Jornadas[i];
                }
                return jornada;
            }
            set
            {

                if (i >= 0 && i < Jornadas.Count)
                {
                    Jornadas[i] = value;
                }
                else if (i == Jornadas.Count)
                {
                    Jornadas.Add(value);
                }
            }
        }

        #endregion

        #region Metodos

        public static bool Guardar(Universidad uni)
        {
            return new Xml<Universidad>().Guardar(@".\Universidad.xml", uni);
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in uni.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>\r\n");

            sb.AppendLine("PROFESORES:");
            foreach (Profesor item in uni.Instructores)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
		/// Una universidad será igual a un alumno si este NO se encuentra inscripto
		/// </summary>
		/// <param name="g">Universidad a comparar</param>
		/// <param name="a">Alumno a comparar</param>
		/// <returns>Retorna TRUE si la universidad es igual al alumno, FALSE en caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool indice = false;

            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    indice = true;
                    break;
                }
            }

            return indice;
        }

        /// <summary>
		/// Una universidad será distinta a un alumno si este NO se encuentra inscripto
		/// </summary>
		/// <param name="g">Universidad a comparar</param>
		/// <param name="a">Alumno a comparar</param>
		/// <returns>Retorna TRUE si la universidad es distinta al alumno, FALSE en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
		/// Una universidad será igual a un profesor si no dicta clases en ella
		/// </summary>
		/// <param name="g">Universidad a comparar</param>
		/// <param name="i">Profesor a comparar</param>
		/// <returns>Retorna TRUE si la universidad es igual al profesor, FALSE en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool indice = false;

            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    indice = true;
                    break;
                }
            }

            return indice;
        }

        /// <summary>
		/// Una universidad será distinta a un profesor si no dicta clases en ella
		/// </summary>
		/// <param name="g">Universidad a comparar</param>
		/// <param name="i">Profesor a comparar</param>
		/// <returns>Retorna TRUE si la universidad es distinta al profesor, FALSE en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
		/// Una universidad será igual a un alumno si se encuentra inscripto
		/// </summary>
		/// <param name="g">Universidad a comparar</param>
		/// <param name="a">Alumno a comparar</param>
		/// <returns>Retorna TRUE si la universidad es igual al alumno, FALSE en caso contrario</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
		/// Una universidad será disntinta a una clase si hay un profesor en ella que no dicte la clase
		/// </summary>
		/// <param name="u">Universidad a comparar</param>
		/// <param name="clase">Clase a comparar</param>
		/// <returns>Retorna el primer profesor que no puede dictar la clase o lanza una excepción si todos la pueden dar</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }

            return profesor;
        }

        #endregion

        #region Operadores aritmeticos

        /// <summary>
        /// Añade una jornada a la universidad. Sera pasada por parametro y tendra un profesor que la dicte
        /// Todos los alumnos de la universidad que coincidan con la clase agregada a la jornada serán adicionados a la misma. 
        /// Puede lanzar una excepción a falta de un profesor
        /// </summary>
        /// <param name="g">Universidad en la cual se agregara la clase</param>
        /// <param name="clase">Clase que se agregara</param>
        /// <returns>Retorna la universidad cargada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = g == clase;
            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno item in g.Alumnos)
            {
                jornada += item;
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Añade un alumno a la universidad si es que no se encuentra en ella. Si esta inscripto en la universidad
        /// lanzara una excepcion
        /// </summary>
        /// <param name="u">Universidad en la cual se agregara al alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }

            throw new AlumnoRepetidoException();
        }

        /// <summary>
		/// Agrega un profesor a la lista de la universidad si este no está registrado
		/// </summary>
		/// <param name="u">Universidad donde agregar al profesor</param>
		/// <param name="i">Profesor a agregar</param>
		/// <returns>Devuelve el objeto de tipo universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == i)
                    return u;
            }
            u.Instructores.Add(i);
            return u;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto que instancia las listas de Profesores, Alumnos y Jornadas
        /// </summary>
        public Universidad()
        {
            Instructores = new List<Profesor>();
            Alumnos = new List<Alumno>();
            Jornadas = new List<Jornada>();
        }

        #endregion

        #region Tipos anidados

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion
    }
}
