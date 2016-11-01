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
using Evo01;

namespace Evo01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal List<Models.Species> Population;

        public MainWindow()
        {
            InitializeComponent();
            this.Population = new List<Models.Species>();
        }

        private void populate_Click(object sender, RoutedEventArgs e)
        {
            this.Population.Add(new Models.Species("Test subject Alpha"));
        }
    }
}
