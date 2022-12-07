using GlassLand.db;
using GlassLand.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        ObservableCollection<Order> OrdersList;
        public Orders()
        {
            InitializeComponent();
            OrdersList = new ObservableCollection<Order>();
            OrdersList.Add(new Order() { CustomerName = "asdasd", WindowWidth = 10, WindowHeight = 20 });
            OrdersList.Add(new Order() { CustomerName = "2"});
            OrdersList.Add(new Order() { Address = "123123123"});
            OrdersList.Add(new Order() { Measurer = "daddddddddddddd"});
            ordersList.ItemsSource = OrdersList;
        }

        private void newOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var view = new CreateOrder();

            if (view.ShowDialog() == null)
            {
                MessageBox.Show("Error");
            }

            var order = view.Tag as Order;
            OrdersList.Add(order);
            MessageBox.Show($"{OrdersList.Count}");
        }
    }
}
