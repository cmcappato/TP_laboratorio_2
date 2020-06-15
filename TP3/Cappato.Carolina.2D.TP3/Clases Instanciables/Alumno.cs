using System.Text;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Campos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Crea al alumno dejando por defecto el estado de la cuenta AlDia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {

        }

        /// <summary>
        /// Crea al alumno con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Crea una cadena que contiene todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0} \n", estadoCuenta.ToString());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString(); ;
        }

        /// <summary>
        /// Muestra los datos generados en MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Devuelve una cadena de caracteres que contiene el dato del atributo claseQueToma del alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}", claseQueToma.ToString());
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Un alumno será distinto a una clase si está en la misma y su estado de cuenta no es deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna TRUE si el alumno es igual a la clase, FALSE si no lo es</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return Equals(a, null) ? true : a.claseQueToma != clase;
        }

        /// <summary>
        /// Un alumno será igual a una clase si está en la misma y su estado de cuenta no es deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna TRUE si el alumno es igual a la clase, FALSE si no lo es</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return !Equals(a, null) && a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        #endregion

        #region Tipos anidados

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion
    }
}
