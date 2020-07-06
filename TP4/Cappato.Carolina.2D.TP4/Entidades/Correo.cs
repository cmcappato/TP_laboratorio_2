using System.Collections.Generic;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Campos

        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// Asocia el correo a la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Nueva instancia de "Correo"
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Cierra los hilos que fueron generados por el paquete
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        /// <summary>
        /// Muestra todos paquetes de la lista
        /// </summary>
        /// <param name="elementos">Va a implementar IMostrar para una lista de paquetes</param>
        /// <returns>Retorna los datos de todos los paquetes de su lista</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";
            if (!object.Equals(elementos, null))
            {
                foreach (Paquete item in ((Correo)elementos).Paquetes)
                {
                    datos += string.Format("{0} para {1} ({2})\r\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                }
            }
            return datos;
        }

        /// <summary>
        /// Controla si el paquete ya está en la lista, lanzando una excepcion si el Tracking ID se repite
        /// </summary>
        /// <param name="c">Correo donde se agregará el paquete</param>
        /// <param name="p">Paquete que se agregará al correo</param>
        /// <returns>Devuelve el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (!object.Equals(c, null) && !object.Equals(p, null))
            {
                foreach (Paquete item in c.Paquetes)
                {
                    if (item == p)
                    {
                        throw new TrackingIdRepetidoException(string.Format("El Tracking ID {0} ya figura en la lista de envios.", p.TrackingID));
                    }
                }
                c.Paquetes.Add(p);
                Thread cicloDeVida = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(cicloDeVida);
                cicloDeVida.Start();
            }
            return c;
        }

        #endregion
    }
}
