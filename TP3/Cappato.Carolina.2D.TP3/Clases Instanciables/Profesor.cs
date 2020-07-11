using System;
using System.Collections.Generic;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos

        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Inicializa el atributo Random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Crea al profesor y le asigna dos clases al azar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Iniicializa la cola de Profesor asignandole dos clases al azar
        /// </summary>
        private void _randomClases()
        {
            int length = Enum.GetNames(typeof(Universidad.EClases)).Length;
            int random = Profesor.random.Next(1, length);

            claseDelDia.Enqueue((Universidad.EClases)random);

            random = Profesor.random.Next(1, length);
            claseDelDia.Enqueue((Universidad.EClases)random);
        }

        /// <summary>
        /// Crea una cadena con los datos de claseDelDia del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }

        /// <summary>
        /// Retorna una cadena con los datos claseDelDia del profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string datos = "\r\nCLASES DEL DÍA:\r\n";

            foreach (Universidad.EClases item in claseDelDia)
            {
                datos += item.ToString() + "\r\n";
            }

            return datos;
        }

        /// <summary>
		/// Retorna una cadena con los datos del profesor.
		/// </summary>
		/// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Sobrecarga de operadores

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool indice = false;

            foreach (Universidad.EClases item in i.claseDelDia)
            {
                if (item == clase)
                {
                    indice = true;
                    break;
                }
            }

            return indice;
        }

        #endregion
    }
}
