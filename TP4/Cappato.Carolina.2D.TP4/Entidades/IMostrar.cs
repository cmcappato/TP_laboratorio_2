namespace Entidades
{
    public interface IMostrar <T>
    {
        #region Metodos

        /// <summary>
        /// Muestra los datos con tipo de dato generico
        /// </summary>
        /// <param name="elemento">Elemento a mostrar</param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento); 

        #endregion
    }
}