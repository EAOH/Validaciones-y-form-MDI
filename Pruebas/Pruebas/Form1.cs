using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pruebas.Modulo;
using Pruebas;
namespace Pruebas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Txt_Cantidad.KeyPress += new KeyPressEventHandler(Utileria.NumerosEnteros);
            this.Txt_Precio.KeyPress += new KeyPressEventHandler(Utileria.NumerosDecimales);
            this.Txt_Precio.Leave += new EventHandler(Utileria.FocoOff);
            this.Txt_ID.KeyPress += new KeyPressEventHandler(Utileria.NumerosGuiones);
            this.Txt_Telefono.KeyPress += new KeyPressEventHandler(Utileria.NumerosTelefono);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            //En esta forma usaremos el metodo tradicional
            if (Txt_Cantidad.Text =="" && Txt_Precio.Text == "" && Txt_ID.Text == "")
            {
                MessageBox.Show("Se necesitan el llenado de todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Se ingreso la informacion", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Este metodo aunque efectivo que hueva estar copiando y pegando esta estructura y estarla editando a cada momento no te parece
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string Faltantes;
            if ((Faltantes=Utileria.Requeridos(this.groupBox1)) != "")
            {
                MessageBox.Show("Se necesitan el llenado de todos los datos:" + Faltantes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Se ingreso la informacion", "Gracias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void formulario2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Formulario = Application.OpenForms.OfType<Form2>().FirstOrDefault();//Evita que los formularios se habran mas de una vez buscando si el formulario existe
           
            Form2 Entrada = Formulario ?? new Form2(); //Condicion de validacion del formulario
            //?? Condicion SI Si Form es nulo quiere decir que jamas de ha creado la instancia por lo cual toma valor formulario de lo contrario hace referencia a Form
            //? Si simplificado (Condicion)? True :False
            Abrir(Entrada);
        }

        private void formulario3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Formulario = Application.OpenForms.OfType<Form3>().FirstOrDefault();//Evita que los formularios se habran mas de una vez buscando si el formulario existe
           
            Form3 Entrada = Formulario ?? new Form3(); //Condicion de validacion del formulario
            //?? Condicion SI Si Form es nulo quiere decir que jamas de ha creado la instancia por lo cual toma valor formulario de lo contrario hace referencia a Form
            //? Si simplificado (Condicion)? True :False
            Abrir(Entrada);
        }

        private void formulario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Abrir(Form Formulario)
        {
            //if (this.panel1.Controls.Count > 0)
            // this.panel1.Controls.RemoveAt(0);//Provocar la destruccion del formulario
            Formulario.TopLevel = false;
            //hijo.FormBorderStyle = FormBorderStyle.None; //Acoplar al formulario actual
            //hijo.Dock = DockStyle.Fill; //Proporcionar las mismas dimenciones del formulario actualx
            this.panel1.Controls.Add(Formulario);
            //this.panel1.Tag = Formulario;
            Formulario.Show();
            Formulario.BringToFront();
        }
    }
}
