using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Guarda cualquier tipo de dato en un archivo XML
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a serializar en XML</param>
        /// <returns>Retorna TRUE si los datos se guardaron correctamente, sino lanza una excepcion</returns>
        public override bool Guardar(string archivo, T datos)
        {
            XmlTextWriter tw = new XmlTextWriter(archivo, Encoding.UTF8);

            try
            {               
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(tw, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                tw.Close();
            }

            return true;
        }

        /// <summary>
        /// Deserializa un aerchivo XML
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Variable que va a recibir los datos</param>
        /// <returns>Retorna TRUE si los datos se leyeron correctamente, sino lanza una excepcion</returns>
        public override bool Leer(string archivo, out T datos)
        {
            XmlTextReader tr = new XmlTextReader(archivo);

            try
            {
                XmlSerializer xmldeserializer = new XmlSerializer(typeof(T));
                datos = (T)xmldeserializer.Deserialize(tr);
                
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                tr.Close();
            }

            return true;

        } 

        #endregion
    }
}
