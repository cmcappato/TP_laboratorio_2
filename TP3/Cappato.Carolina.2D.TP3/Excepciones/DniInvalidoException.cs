using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos

        private const string mensajeBase = "Formato de DNI incorrecto. Debe tener entre 1 y 8 caracteres para" +
            " documentos argentinos u 8 caracteres para documentos extranjeros"; 

        #endregion

        #region Constructores

        public DniInvalidoException() : this(mensajeBase)
        {
        }

        public DniInvalidoException(Exception e) : this(mensajeBase, e)
        {
        }

        public DniInvalidoException(string message) : this(message, null)
        {
        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {
        } 

        #endregion
    }
}
