namespace Archivos
{
    public class IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Guarda los datos en un archivo especificado
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos que se guardaran en el archivo</param>
        /// <returns>Retorna TRUE si se guardo correctamente el archivo</returns>
        public abstract bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee los datos en un archivo especificado
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos que se almacenan para ser leidos</param>
        /// <returns>Retorna TRUE si se leyo correctamente el archivo</returns>
        public abstract bool Leer(string archivo, out T datos); 

        #endregion
    }
}
