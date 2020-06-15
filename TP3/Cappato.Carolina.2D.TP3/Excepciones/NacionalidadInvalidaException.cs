using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructores

        public NacionalidadInvalidaException() : this("DNI fuera de rango. Ingrese un DNI entre 1 y 89999999 para argentinos y desde 90000000 y 99999999 para extranjeros")
        {
        }
        
        public NacionalidadInvalidaException(string message) : base(message)
        {
        } 

        #endregion
    }
}
