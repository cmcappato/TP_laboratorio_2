using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        #region Campos

        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor privado que inicializa la lista de Vehículos
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor publico que seteará el espacio disponible dentro del estacionamiento
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");

            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Automovil:
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if (c.vehiculos.Count >= c.espacioDisponible)
            {
                return c;
            }

            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    return c;
                }
            }

            c.vehiculos.Add(p);
            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            for (int i= 0; i < c.vehiculos.Count; ++i)
            {
                if (c.vehiculos[i] == p)
                {
                    c.vehiculos.RemoveAt(i);
                    break;
                }
            }
            return c;
        }

        #endregion

        #region Enumerados

        public enum ETipo
        {
            Moto,
            Automovil,
            Camioneta,
            Todos
        }

        #endregion
    }
}
