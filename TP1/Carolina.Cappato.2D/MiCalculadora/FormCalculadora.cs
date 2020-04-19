using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region Constructor

        /// <summary>
        /// Inicializa el formulario Calculadora, establece los operadores para el ComboBox
        /// y el operador seleccionado por defecto 
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.SelectedItem = "+";
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Reestablece los valores numéricos de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Reestablece el valor por defecto de los textBox, comboBox y label resultado
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "0";
            cmbOperador.Text = "+";
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Realiza una operación cuando se hace click en el botón "Operar" y muestra el resultado en el label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Cierra el formulario al clickear el boton "Cerrar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Convierte a decimal el numero binario (en caso de ser posible) que se encuentre en el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);

            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Convierte el binario a decimal (en caso de ser posible) que se encuentre en el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = Numero.DecimalBinario(lblResultado.Text);

            if (resultado != "Valor inválido")
            {
                btnConvertirADecimal.Enabled = true;
            }
                
            lblResultado.Text = resultado;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Funcion privada y estática para hacer las operaciones
        /// </summary>
        /// <param name="numero1">Primer numero para realizar la operación/param>
        /// <param name="numero2">Segundo numero para realizar la operación</param>
        /// <param name="operador">Tipo de operador</param>
        /// <returns>Resultado de operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);
            
            return Calculadora.Operar(primerNumero, segundoNumero, operador);
        } 

        #endregion
    }
}
