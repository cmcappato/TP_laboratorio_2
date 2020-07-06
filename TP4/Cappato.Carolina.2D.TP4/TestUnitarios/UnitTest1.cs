using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la lista de paquetes del Correo este instanciada.
        /// </summary>
        [TestMethod]
        public void VerificarListaDePaquetesEnCorreo()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes, "La lista de paquetes de la instancia de Correo no se inicializó");
        }

        /// <summary>
        /// Verifica que no se puedan cargar dos paquetes con el mismo Tracking ID
        /// </summary>
        [TestMethod]
        public void VerificarCargaPaquetes()
        {
            bool excepcion = false;

            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("paqueteuno@gmail.com", "123");
            Paquete paqueteDos = new Paquete("paquetedos@hotmail.com", "123");

            try
            {
                correo += paqueteUno;
                correo += paqueteDos;
            }
            catch (TrackingIdRepetidoException)
            {
                excepcion = true;
            }

            Assert.IsTrue(excepcion, "No se produjo la excepción esperada al intentar agregar dos paquetes con el mismo TrackingID");
        }
    }
}
