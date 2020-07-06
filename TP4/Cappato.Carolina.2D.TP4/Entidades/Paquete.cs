using System;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Campos

        private string direccionEntrega;
        private string trackingId;
        private EEstado estado;

        #endregion

        #region Propiedades

        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }

        public string TrackingID
        {
            get { return trackingId; }
            set { trackingId = value; }
        }

        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        } 

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa la clase Paquete
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del paquete</param>
        /// <param name="trackingID">Tracking ID del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
            Estado = EEstado.Ingresado;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Cambia el estado del paquete cada 4 segundos hasta que el estado sea Entregado. Finalmente guarda los
        /// datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(null, null);
            } while (this.Estado != EEstado.Entregado);

            if (!PaqueteDAO.Insertar(this))
            {
                this.ServerError();
            }
        }

        /// <summary>
        /// Retorna una cadena del objeto Paquete
        /// </summary>
        /// <param name="elemento">Implementara la interfaz IMostrar paquetes</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            String s = String.Format("{0} para {1}\r\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);

            return s;
        }

        /// <summary>
        /// Retorna una cadena del objeto Paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Dos paquetes seran iguales si su Tracking ID es el mismo
        /// </summary>
        /// <param name="p1">Paquete Uno</param>
        /// <param name="p2">Paquete Dos</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Dos paquetes seran diferentes si su Tracking ID es diferente
        /// </summary>
        /// <param name="p1">Paquete Uno</param>
        /// <param name="p2">Paquete Dos</param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1.TrackingID == p2.TrackingID);
        }

        #endregion

        #region Eventos

        public event DelegadoEstado InformaEstado;
        public event DelegadoSqlError ServerError;

        #endregion

        #region Delegados 

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoSqlError();

        #endregion}

        #region Enumerados

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        } 

        #endregion
    }
}
