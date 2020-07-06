using System;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region Metodos

        /// <summary>
        /// Guarda la cadena en un txt en el escritorio 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo;
            bool existe = File.Exists(path);

            try
            {
                using (StreamWriter stream = new StreamWriter(path, existe))
                {
                    stream.WriteLine(texto);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        } 

        #endregion
    }
}
