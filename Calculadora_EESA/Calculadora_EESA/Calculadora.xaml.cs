using System;
using System.Reflection;
using Xamarin.Forms;

namespace Calculadora_EESA
{
    public partial class MainPage : ContentPage
    {
        string entrada = "";
        double resultado = 0;
        string operador = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Numero(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string textoBoton = boton.Text;

            if (textoBoton == "AC")
            {
                entrada = "";
                resultado = 0;
                operador = "";
            }
            else if (textoBoton == "C")
            {
                if (entrada.Length > 0)
                {
                    entrada = entrada.Substring(0, entrada.Length - 1);
                }
            }
            else if (textoBoton == "=")
            {
                if (!string.IsNullOrEmpty(entrada))
                {
                    double numeroActual;
                    if (double.TryParse(entrada, out numeroActual))
                    {
                        switch (operador)
                        {
                            case "+":
                                if (numeroActual != 0)
                                    resultado += numeroActual;
                                else
                                    Resultado.Text = "Error Syntax";
                                break;
                            case "-":
                                if (numeroActual != 0)
                                    resultado -= numeroActual;
                                else
                                    Resultado.Text = "Error Syntax";
                                break;
                            case "x":
                                if (numeroActual != 0)
                                    resultado *= numeroActual;
                                else
                                    Resultado.Text = "Error Syntax";
                                break;
                            case "÷":
                                if (numeroActual != 0)
                                    resultado /= numeroActual;
                                else
                                    Resultado.Text = "Error Syntax";
                                break;
                            default:
                                resultado = numeroActual;
                                break;
                        }
                        entrada = resultado.ToString();
                        operador = "";
                    }
                    else
                    {
                        Resultado.Text = "Error Syntax";
                    }
                }
            }
            else
            {
                if (char.IsDigit(textoBoton[0]) || textoBoton == ".")
                {
                    if (textoBoton == "." && entrada.Contains("."))
                        return;
                    entrada += textoBoton;
                }
                else
                {
                    if (!string.IsNullOrEmpty(entrada))
                    {
                        if (operador != "") 
                        {
                            double numeroActual;
                            if (double.TryParse(entrada, out numeroActual))
                            {
                                switch (operador)
                                {
                                    case "+":
                                        if (numeroActual != 0)
                                            resultado += numeroActual;
                                        else
                                            Resultado.Text = "Error Syntax";
                                        break;
                                    case "-":
                                        if (numeroActual != 0)
                                            resultado -= numeroActual;
                                        else
                                            Resultado.Text = "Error Syntax";
                                        break;
                                    case "x":
                                        if (numeroActual != 0)
                                            resultado *= numeroActual;
                                        else
                                            Resultado.Text = "Error Syntax";
                                        break;
                                    case "÷":
                                        if (numeroActual != 0)
                                            resultado /= numeroActual;
                                        else
                                            Resultado.Text = "Error Syntax";
                                        break;
                                }
                            }
                        }
                        else
                        {
                            resultado = double.Parse(entrada);
                        }
                        operador = textoBoton;
                        entrada = "";
                    }
                }
            }

            Resultado.Text = entrada == "" ? resultado.ToString() : entrada;
        }
    }
}
