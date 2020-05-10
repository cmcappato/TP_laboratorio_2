using System;
using System.Text;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region Campos

        private ETipo tipo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializara el Automóvil
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string codigo, ConsoleColor color) :  base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }

        #endregion

        #region Métodos
        
        /// <summary>
        /// Muestro los datos del vehículo 
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO: {0}", this.Tamanio);
            sb.AppendFormat("TIPO: {0}", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region Enumerados

        public enum ETipo
        {
            Monovolumen,
            Sedan
        }

        #endregion
    }
}
