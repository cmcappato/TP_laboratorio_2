using System;
using System.Data;
using System.Data.SqlClient;


namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion
        
        #region Constructores

        /// <summary>
        /// Inicializa los campos para conectarse con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.correo_sp_2017);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = conexion;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Agrega el paquete a la lista
        /// </summary>
        /// <param name="p">Paquete que se agregara a la base de datos</param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool indice = true;
            try
            {
                PaqueteDAO.comando.CommandText = String.Format("INSERT INTO [correo-sp-2017].[dbo].[Paquetes] " +
                    "(direccionEntrega,trackingID,alumno) VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Cappato Carolina");
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                indice = false;
            }
            finally
            {
                try
                {
                    PaqueteDAO.conexion.Close();
                }
                catch (Exception)
                {
                    indice = false;
                }

            }
            return indice;
        } 

        #endregion
    }
}
