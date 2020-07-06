using System;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Nueva instancia de TrackingIdRepetidoException con mensaje personalizado
        /// </summary>
        /// <param name="mensaje">Mensaje que se muestra en la excepcion</param>
        /// 
        public TrackingIdRepetidoException(string mensaje) : this(mensaje, null)
        {
        }

        /// <summary>
        /// Nueva instancia de TrackingIdRepetidoException con mensaje personalizado
        /// </summary>
        /// <param name="mensaje">Mensaje que se muestra en la excepcion</param>
        /// <param name="inner">Excepcion de la instancia</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        } 

        #endregion
    }
}
