using EntidadesAbstractas;
using Clases_Instanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class ValidarRangoNumerico
    {
        #region VerificarDniErroneo

        /// <summary>
        /// Verifica que al cargar un DNI (Dato numérico cargado como string) en un objeto Persona no numérico , nulo o demasiado extenso se haga la validación correcta.
        /// </summary>
        [TestMethod]

        public void VerificarDniErroneo()
        {
            bool huboError = false;
            try
            {
                Alumno alumno = new Alumno(44, "Maria", "Vazquez", "lalalala", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            }
            catch (DniInvalidoException)
            {
                huboError = true;
            }
            Assert.IsTrue(huboError, "DNI no numérico");

            try
            {
                Alumno alumno = new Alumno(44, "Maria", "Vazquez", "91000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            }
            catch (Exception)
            {
                Assert.Fail("Ninguna excepción debería haber aparecido.");
            }

            try
            {
                Alumno alumno = new Alumno(44, "Maria", "Vazquez", null, Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            }
            catch (DniInvalidoException)
            {
                huboError = true;
            }
            Assert.IsTrue(huboError, "Excepcion de tipo DniInvalidoException, el DNI no es de formato correcto");

        } 

        #endregion
    }
}
