using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Evo01.Models;
using Evo01.Forms;
namespace Evo01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Population Population;

        public MainWindow()
        {
            InitializeComponent();          
        }

        private void populate_Click(object sender, RoutedEventArgs e)
        {
            Population = new Population(1, true);

            Individual fasser = Population.getIndividual(0);
            Individual indi = new Individual(new Species("DumbFish"));
            indi.createIndividual(fasser);
            Population.addIndividual(indi);

            Debug.Text = DisplayObjectInfo(Population) + "\n\n" + Population.ToString(0);
        }

        public static string DisplayObjectInfo(Object o)
        {
            StringBuilder sb = new StringBuilder();

            // Include the type of the object
            Type type = o.GetType();
            sb.Append("Type: " + type.Name);

            // Include information for each Field
            sb.Append("\r\n\r\nFields:");
            FieldInfo[] fi = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f.ToString() + " = " + f.GetValue(o));
                }
            }
            else
                sb.Append("\r\n None");

            // Include information for each Property
            sb.Append("\r\n\r\nProperties:");
            PropertyInfo[] pi = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            if (pi.Length > 0)
            {
                foreach (PropertyInfo p in pi)
                {
                    sb.Append("\r\n " + p.ToString() + " = " + p.GetValue(o, null));
                }
            }
            else
            {
                sb.Append("\r\n None");
            }

            return sb.ToString();
        }

        private void startRenderer_Click(object sender, RoutedEventArgs e)
        {
            Simulation form = new Simulation("test 01");

            form.Run();
        }
    }
}
