using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraByJosue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button boton = (Button)sender;
                string value = (string)boton.Content;


                if (Isnumber(value))
                {
                    HandleNumbers(value); ///verifica si el valor del botón es un número.
                }
                else if (IsOperador(value)) ///se verifica si el valor del botón es un operador
                {
                    HandleOperator(value); ///se encarga de que los operadores hagan una operacion aritmetica
                }
                else if (value == "C")

                {
                    if (Screen.Text.Length > 0) ///se encarga de quitarle un digito a la pantalla
                    {
                        //substring es caracter por carater.
                        string numeros = Screen.Text;
                        numeros = numeros.Substring(0, numeros.Length - 1);
                        Screen.Text = numeros;
                    }
                }

                else if (value == "CE") ///se encarga de borrar y limpiar la pantalla
                {
                    //no olvides agregar el boton C
                    Screen.Clear();
                }
                else if (value == "=")
                {
                    HandlerEquals(Screen.Text); ///se encarga de llamar al metodo para que realize la operacion
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        //metodo auxiliares
        private bool Isnumber(string num)
        {
            return double.TryParse(num, out _); ///se encarga de verificar si una cadena de texto num representa un número válido. 
        }

        private bool IsOperador(string posibleoperador)
        {
            return posibleoperador == "+" || posibleoperador == "-" || posibleoperador == "*" || posibleoperador == "/";
            ///se encarga de verificar si el objeto posibleoperador representa un operador valido

        }


        private void HandleNumbers(string value)  ///se encarga de establecer un orden en la pantalla con los numeros y las operaciones

        {
            if (string.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;
            }
        }
        private void HandleOperator(string value)
        {
            if (!string.IsNullOrEmpty(Screen.Text) && !Containtoperador(Screen.Text))
            {
                Screen.Text += value;
            }
        }
        //contains para evitar que se repita el operador una vez escrito un numero ejemplo:"5++"

        public bool Containtoperador(string screenContent) //validar y reconocer si ya hay un operador presente en el contenido de la pantalla de la calculadora antes de agregar uno nuevo.
        {
            return screenContent.Contains("+") ||
                   screenContent.Contains("-") ||
                   screenContent.Contains("*") ||
                   screenContent.Contains("/");
        }
        public void HandlerEquals(string screenContent) //Hace que al apretar = busque el operador que se selcciono y llame el metodo que le corresponde ese operador
        {
            string op = FindOperatodor(screenContent);
            if (op != null)
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = Suma();

                        break;
                    case "-":
                        Screen.Text = Resta();
                        break;
                    case "*":
                        Screen.Text = Multiplica();
                        break;
                    case "/":
                        Screen.Text = Dividi();
                        break;

                    default:
                        break;
                }
            }

        }
        private string FindOperatodor(string screenContent)
        {
            foreach (var item in screenContent)
            {
                if (IsOperador(item.ToString()))//Recorre cada carácter en la pantalla y verifica si es un operador despues devuelve ese operador como resultado.

                {
                    return item.ToString();
                }

            }

            return screenContent;//Si no se encuentra ningún operador no se hace nada en la pantalla
        }

        //Establece lo que hace cada metodo de las operaciones
        private string Suma()
        {
            //Esto sirve para separar en una misma linea de texto los dos numeros que se ingresaron, separandolos con el operador
            string[] numbers = Screen.Text.Split('+');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString(); //realiza la operación de suma y devuelve el resultado redondeado a 12 decimales como una cadena de texto
        }

        private string Resta()
        {
            string[] numbers = Screen.Text.Split('-');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 - n2, 12).ToString();
        }
        private string Multiplica()
        {
            string[] numbers = Screen.Text.Split('*');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Dividi()
        {
            string[] numbers = Screen.Text.Split('/');
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
        }
    }
}
