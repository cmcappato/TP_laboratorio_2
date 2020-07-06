using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.FormClosing += new FormClosingEventHandler(this.FrmPpal_FormClosing);
        }

        /// <summary>
        /// Cierra todos los hilos antes de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra los paquetes en el cuadro inferior izquierdo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)this.correo);
        }

        /// <summary>
        /// Realiza la carga de los datos y guarda un archivo de texto con informacion en el escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            bool error = false;
            if (!(elemento is null))
            {
                string datos = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = datos;
                if (!datos.Guardar("salida.txt"))
                {
                    error = true;
                }
            }
            if (error)
            {
                MessageBox.Show("Se produjo un error durante la manipulación del fichero de salida.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia las listasdel formulario y luego carga los paquetes donde corresponden
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }

        /// <summary>
        /// Actualiza los estados de los listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Muestra un mensaje de error indicando que la conexion a la base de datos no se hizo correctamente
        /// </summary>
        private void SqlError()
        {
            MessageBox.Show("Carga errónea. Fallo durante conexión con la base de datos de paquetes.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            paquete.ServerError += new Paquete.DelegadoSqlError(this.SqlError);
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException excepcion)
            {
                MessageBox.Show(excepcion.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            this.ActualizarEstados();
        }
    }
}
