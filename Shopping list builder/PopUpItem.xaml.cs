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

namespace Shopping_list_builder
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    { 
        public string name = string.Empty;
        public string unit = string.Empty;
        public double amount;

        public Window2()
        {
            InitializeComponent();
        }


        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {

            // You can access the text fields like this:
            this.name = ItemNameTextField.Text;
            this.unit = ItemUnitTextField.Text; 
            this.amount = Double.Parse(ItemQuantityTextField.Text);
            this.DialogResult = true;
            this.Close();
        }
    }
}
