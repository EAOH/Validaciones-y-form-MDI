using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Pruebas.Modulo
{
    class Utileria
    {
       
       public static string Requeridos(Control Formulario)
        {
            string Validacion = "";
            foreach (Control Controles in Formulario.Controls)
            {
                if (Controles is TextBox & string.IsNullOrWhiteSpace(Controles.Text)){
                    if (Validacion != "") { Validacion += String.Format(", {0}", Controles.Name); }
                    else { Validacion += String.Format(" {0}", Controles.Name); }
                }
            }

            return Validacion; 
        }

        public static void NumerosEnteros(object sender, KeyPressEventArgs Caracter)
        {
            if (char.IsControl(Caracter.KeyChar) || char.IsDigit(Caracter.KeyChar)){Caracter.Handled = false;}
            else { Caracter.Handled = true;
                MessageBox.Show("Lo que esta tratando de ingresar no es acorde al dato solicitado", "Solo Caracteres numericos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            
        }

        public static void NumerosDecimales(object sender, KeyPressEventArgs Caracter)
        {
            if((Char.IsDigit(Caracter.KeyChar)) || (Char.IsControl(Caracter.KeyChar)) || (Caracter.KeyChar== 46)){ 
                if (string.IsNullOrWhiteSpace(((Control)sender).Text) && Caracter.KeyChar == 46) 
                { Caracter.Handled = true;
                  MessageBox.Show("No puede ingresar un punto decimal si no ha ingresado un numero primero", "Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else { Caracter.Handled = false; }
                }  else { Caracter.Handled = true;
                MessageBox.Show("Lo que esta tratando de ingresar no es acorde al dato solicitado", "Solo numeros caracteres decimales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if(((Control)sender).Text.Length>1 && Caracter.KeyChar == 46)
            {
                for (int i = 0; i <((Control)sender).Text.Length-1; i++)
                {
                    if (((Control)sender).Text.ElementAt(i) == Caracter.KeyChar)
                    {
                        Caracter.Handled = true;
                        MessageBox.Show("No puede ingresar 2 puntos decimal en este campo", "Solo un punto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public static void NumerosGuiones(object sender, KeyPressEventArgs Caracter)
        {
            if ((Char.IsDigit(Caracter.KeyChar)) || (Char.IsControl(Caracter.KeyChar))) { Caracter.Handled = false;
                if ((((Control)sender).Text.Length == 4 || ((Control)sender).Text.Length == 9) && !Char.IsControl(Caracter.KeyChar))
                {
                    ((Control)sender).Text = ((Control)sender).Text + "-";
                    ((TextBox)sender).Select(((Control)sender).Text.Length, 0);
                }
            }
            else
            {
                Caracter.Handled = true;
                MessageBox.Show("Lo que esta tratando de ingresar no es acorde al dato solicitado", "Ingrese su numero de identidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public static void NumerosTelefono(object sender, KeyPressEventArgs Caracter)
        {
            if ((Char.IsDigit(Caracter.KeyChar)) || (Char.IsControl(Caracter.KeyChar)) || ((Caracter.KeyChar == 43 ) && ((Control)sender).Text.Length==0)) { Caracter.Handled = false; }
            else
            {
                Caracter.Handled = true;
                MessageBox.Show("Lo que esta tratando de ingresar no es acorde al dato solicitado", "Su numero telefonico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void FocoOff (object sender, EventArgs Caracter)
        {
            if (!string.IsNullOrWhiteSpace(((Control)sender).Text))
            {
                if (((Control)sender).Text.ElementAt(0) == 46) { ((Control)sender).Text = "0" + ((Control)sender).Text; }
                if(((Control)sender).Text.ElementAt(((Control)sender).Text.Length-1) == 46) { ((Control)sender).Text = ((Control)sender).Text + "00"; }
                if (((Control)sender).Text.Length >= 2)
                {
                    if (((Control)sender).Text.ElementAt(((Control)sender).Text.Length - 2) == 46 && ((Control)sender).Text.ElementAt(((Control)sender).Text.Length - 1) == 48)
                    { ((Control)sender).Text = ((Control)sender).Text + "0"; }
                }
            }
        }


    }
}
