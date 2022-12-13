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

namespace GlassLand.pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public static Measurements measurementsView { get; set; } = new Measurements();
        public static Montages montagesView { get; set; } = new Montages();
        public MainMenu()
        {
            InitializeComponent();
            measurements.Content = measurementsView;
            montages.Content = montagesView;
        }
    }
}
