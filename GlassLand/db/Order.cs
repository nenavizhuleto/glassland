using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public struct Window
    {
        public float width;
        public float height;
    }
    public class Order
    {
        public string CustomerName { get; set; }
        public float WindowWidth { get; set; }
        public float WindowHeight { get; set; }
        public string Measurer { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

    }
}
