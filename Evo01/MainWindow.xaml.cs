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

namespace Evo01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Models.Population Population;

        public MainWindow()
        {
            InitializeComponent();          
        }

        private void populate_Click(object sender, RoutedEventArgs e)
        {
            Population = new Models.Population(10, true);

            Debug.Text = Population.ToString();
        }
    }
}
