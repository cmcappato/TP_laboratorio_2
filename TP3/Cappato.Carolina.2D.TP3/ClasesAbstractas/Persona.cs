using System.Text;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Campos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades

        /// <summary>
        /// El apellido solo será cargado si la cadena es válida
        /// </summary>
        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Se lanzará una excepcion si el DNI no es valido
        /// </summary>
        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                dni = ValidarDni(Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        /// <summary>
        /// El nombre solo será cargado si la cadena es válida
        /// </summary>
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Se lanzará una excepcion si el DNI no es valido
        /// </summary>
        public string StringToDNI
        {
            set
            {
                dni = ValidarDni(Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Crea a la persona sin DNI, dejando este dato en 0
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }
        
        /// <summary>
        /// Crea a la persona con todos sus datos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        /// <summary>
        /// Crea a la persona con todos sus datos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Muestra todos detalles de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} \r\n", Apellido, Nombre );
            sb.AppendLine("NACIONALIDAD: " + Nacionalidad.ToString() + "\r\n");
            sb.AppendLine("DNI: " + DNI);

            return sb.ToString();
        }

        /// <summary>
        /// Verifica que el DNI ingresado sea de 1 a 89999999 si la persona es Argentina y de 90000000 a 99999999
        /// para extranjeros. Si esto no es asi se lanzará una excepcion
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI</param>
        /// <returns>Retorna el DNI validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if (nacionalidad == ENacionalidad.Argentino && dni >= 1 && dni <= 89999999 || nacionalidad == ENacionalidad.Extranjero && dni > 89999999 && dni <= 99999999)
            {
                return dni;               
            }

            throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el numero de DNI.");
        }

        /// <summary>
        /// Verifica que el DNI tenga la cantidad correcta de caracteres. Se lanzara una excepcion si hay error
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI</param>
        /// <returns>Retorna el DNI validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!string.IsNullOrEmpty(dato) && int.TryParse(dato, out int datoInt))
            {
                return ValidarDni(nacionalidad, datoInt);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Verifica que la cadena sea unicamente de caracteres alfabeticos. En caso de no serlo, retornara una cadena vacia
        /// </summary>
        /// <param name="dato">Cadena a verificar</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrEmpty(dato) && !string.IsNullOrWhiteSpace(dato))
            {
                return dato;
            }
            
            return "";
        }

        #endregion

        #region Tipos anidados

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
