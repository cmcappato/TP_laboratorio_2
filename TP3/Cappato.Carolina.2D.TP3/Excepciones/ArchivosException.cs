using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Constructor

        public ArchivosException(Exception innerException) : base("Error durante la manipulacion de archivos", innerException)
        {
        } 

        #endregion
    }
}
