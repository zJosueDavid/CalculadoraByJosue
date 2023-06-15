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
        public void ButtonClick (object sender, RoutedEventArgs e)
        {
            
            try
            {
                Button button = (Button)sender;
                MessageBox.Show("Has dado un click");
            }
            catch (Exception ex)
            {

                throw new Exception ("ha ocurrido un error"+ex.Message);
            }
        }
    }
}
