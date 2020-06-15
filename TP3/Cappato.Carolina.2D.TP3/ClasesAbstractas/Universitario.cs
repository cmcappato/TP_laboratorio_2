using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos

        private int legajo;

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra todos los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: "+ legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos universitarios seran iguales si su legajo o DNI no coinciden
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (!Equals(pg1, null) && pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        /// <summary>
        /// Dos universitarios seran distintos si su legajo o DNI no coinciden
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Crea un universitario con todos sus datos
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        } 

        #endregion
    }
}
