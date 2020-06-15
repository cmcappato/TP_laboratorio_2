using EntidadesAbstractas;
using Clases_Instanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class ValidarAtributosNulos
    {
        #region AtributosNulosProfesor

        [TestMethod]
        public void VerificarAtributosNulosProfesor()
        {
            Profesor profesorUno = new Profesor(6, "Jose", "Suarez", "123123", Persona.ENacionalidad.Argentino);


            Assert.IsNotNull(profesorUno.Apellido, "Apellido no debería ser nulo.");
            Assert.IsNotNull(profesorUno.Nombre, "Nombre no debería ser nulo.");
            Assert.AreNotEqual(profesorUno.DNI, 0, "DNI no debería ser 0.");

            Profesor profesorDos = new Profesor(14, "123", "123", "44", Persona.ENacionalidad.Argentino);

            Assert.AreEqual(profesorDos.Apellido, "", "Apellido mal cargado, debería quedar en NULL.");
            Assert.AreEqual(profesorDos.Nombre, "", "Nombre mal cargado, debería quedar en NULL.");
        }

        #endregion
    }
}
