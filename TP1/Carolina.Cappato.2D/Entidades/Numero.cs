using System;
using System.Linq;

namespace Entidades
{
    public class Numero
    {
        #region Atributos

        private double numero;

        #endregion

        #region Propiedades

        /// <summary>
        /// Establece un numero en el atributo numero si la cadena es transformable a double, sino retorna 0
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa numero en 0
        /// </summary>
        public Numero()
        {
            numero = 0;
        }

        /// <summary>
        /// Genera una instancia de la clase Numero
        /// </summary>
        /// <param name="numero">Numero en formato double para inicializar la instancia</param>
        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Genera una instancia de la clase Numero
        /// </summary>
        /// <param name="strNumero">Numero en formato string para inicializar instancia</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Convierte un string a decimal si es un numero positivo, sino retorna Valor invalido
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>El numero convertido o Valor invalido</returns>
        public static string BinarioDecimal(string binario)
        {
            string resultado = "";
            char[] array = binario.ToCharArray(); // Convierto string en array
            Array.Reverse(array); // Invierto el array de derecha a izquierda
            bool validacion = true;
            int suma = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '0' && array[i] != '1')
                {
                    validacion = false;
                    break;
                }
            }

            if (validacion)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                }

                resultado = suma.ToString();
            }
            else
            {
                resultado = "Valor inválido";
            }

            return resultado;
        }

        /// <summary>
        /// Convierte un numero en formato doble a binario en caso de que sea positivo, sino retorna Valor invalido
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero convertido, o Valor invalido</returns>
        public static string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        /// <summary>
        /// Convierte un string a decimal si es un numero positivo, sino retorna Valor invalido
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>El numero convertido o Valor invalido</returns>
        public static string DecimalBinario(string numero)
        {
            string resultado = "";
            double numeroAConvertir = int.Parse(numero);

            if (numeroAConvertir > 0)
            {
                while (numeroAConvertir > 0)
                {
                    if (numeroAConvertir % 2 == 0)
                    {
                        resultado = "0" + resultado;
                    }
                    else
                    {
                        resultado = "1" + resultado;
                    }
                    numeroAConvertir = (int)(numeroAConvertir / 2);
                }
            }   
            else
            {
                if(numeroAConvertir == 0)
                {
                    resultado = "0";
                }
                else
                {
                    resultado = "Valor inválido";
                }            
            }

            return resultado;
        }

        /// <summary>
        /// Verifica que un numero en string pueda ser transformado a double y lo retorna, sino retorna 0
        /// </summary>
        /// <param name="strNumero">Numero a verificar en formato string</param>
        /// <returns>El numero transformado, o 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double resultado;

            if(double.TryParse(strNumero, out resultado) == false)
            {
                resultado = 0;
            }

            return resultado;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Realiza la resta de dos numeros ingresados
        /// </summary>
        /// <param name="n1">Minuendo</param>
        /// <param name="n2">Sustraendo</param>
        /// <returns>Resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        /// Realiza el producto de dos numeros ingresados
        /// </summary>
        /// <param name="n1">Primer factor</param>
        /// <param name="n2">Segundo factor</param>
        /// <returns>Resultado del producto</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

        /// <summary>
        /// Realiza la division de dos numeros ingresados
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Resultado de la division, en caso de que el divisor sea distinto de 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la suma de dos numeros ingresados
        /// </summary>
        /// <param name="n1">Sumando 1</param>
        /// <param name="n2">Sumando 2</param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }

        #endregion
    }
}