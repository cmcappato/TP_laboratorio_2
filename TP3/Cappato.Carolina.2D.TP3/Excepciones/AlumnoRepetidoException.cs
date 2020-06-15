using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Constructor

        public AlumnoRepetidoException() : base("Alumno repetido.")
        {
        } 

        #endregion
    }
}
