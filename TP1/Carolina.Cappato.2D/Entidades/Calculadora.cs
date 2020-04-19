using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos

        /// <summary>
        /// Realiza la operación deseada por el usuario entre el primer número y el segundo número
        /// </summary>
        /// <param name="num1">Primer número</param>
        /// <param name="num2">Segundo número</param>
        /// <param name="operador">Operador aritmético</param>
        /// <returns>Resultado de la operación en formato double</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double operacion;

            switch (operador)
            {
                case "+":
                    operacion = num1 + num2;
                    break;
                case "-":
                    operacion = num1 - num2;
                    break;
                case "*":
                    operacion = num1 * num2;
                    break;
                case "/":
                    operacion = num1 / num2;
                    break;
                default:
                    operacion = num1 + num2;
                    break;
            }

            return operacion;
        }

        /// <summary>
        /// Verifica que un string contenga un operador válido para una de las 4 operaciones básicas
        /// </summary>
        /// <param name="operador">Operador deseado</param>
        /// <returns>Operador ingresado, en caso de que no se haya ingresado ninguno, por defecto retorna "+"</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }

            return "+";
        }

        #endregion
    }
}
