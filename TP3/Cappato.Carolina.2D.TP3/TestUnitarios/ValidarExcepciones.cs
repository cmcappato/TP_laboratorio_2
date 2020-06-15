using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class ValidarExcepciones
    {
        #region ExcepcionDniInvalido

        [TestMethod]
        public void ValidarExcepcionDniInvalido()
        {
            bool huboError = false;
            try
            {
                Alumno nuevoAlumno = new Alumno(0, "Juan", "Perez", "AAAAA", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (DniInvalidoException)
            {
                huboError = true;
            }
            Assert.IsTrue(huboError);
        } 

        #endregion

        #region ExcepcionSinProfesor

        [TestMethod]
        public void ValidarExcepcionSinProfesor()
        {
            Universidad uni = new Universidad();
            bool huboError = false;

            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException)
            {
                huboError = true;
            }
            Assert.IsTrue(huboError);

            huboError = false;

            try
            {
                Profesor profe = uni != Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException)
            {
                huboError = true;
            }
            Assert.IsTrue(huboError);
        } 

        #endregion
    }
}
