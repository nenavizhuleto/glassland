using GlassLand.db;
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
using System.Windows.Shapes;

namespace GlassLand.views
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : System.Windows.Window
    {
        public CreateOrder()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            

            var order = new Order()
            {
                CustomerName = customerTb.Text,
                WindowWidth = float.Parse(windowWidthTb.Text), 
                WindowHeight = float.Parse(windowHeightTb.Text),
                Measurer = measurerTb.Text,
                Date = (dateTb.SelectedDate != null) ? (DateTime)dateTb.SelectedDate: DateTime.Now,
                Address= addressTb.Text,
            };

            this.Tag = order;

            this.DialogResult = true;
            return;
        }
    }
}
