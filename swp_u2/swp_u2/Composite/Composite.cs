using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using swp_u2.Model;

namespace swp_u2.Composite
{
    class Composite : ModelShape
    {
        public List<ModelShape> child {get; set;}
       
        public Composite()
        {
            child = new List<ModelShape>();
        }
        
        public void add(ModelShape component)
        {
            child.Add(component);
        }
        
        public void remove(ModelShape component)
        {
            child.Remove(component);
        }

    }
}
