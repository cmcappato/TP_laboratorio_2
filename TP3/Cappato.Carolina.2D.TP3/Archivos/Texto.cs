using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos

        /// <summary>
        /// Guarda una cadena de caracteres dentro de un archivo de texto
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Cadena con datos a guardar</param>
        /// <returns>Retorna TRUE si el guardado se hizo correctamente, sino se lanzará una excepcion</returns>
        public override bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter archivoTexto = new StreamWriter(archivo))
                {
                    archivoTexto.WriteLine(datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        /// <summary>
        /// Lee datos de un archivo de texto y los guarda en una cadena de caracteres
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Cadena en la cual se guardaran los datos leidos</param>
        /// <returns>Retorna TRUE si el archivo fue leido de manera correcta, sino lanza una excepcion</returns>
        public override bool Leer(string archivo, out string datos)
        {
            datos = "";

            try
            {
                using (StreamReader archivoTexto = new StreamReader(archivo))
                {
                    datos = archivoTexto.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        #endregion
    }
}
