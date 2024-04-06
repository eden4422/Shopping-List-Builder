using Shopping_list_builder.Classes;
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

namespace Shopping_list_builder
{
    /// <summary>
    /// Interaction logic for ShoppingListEditorPage.xaml
    /// </summary>
    public partial class ShoppingListEditorPage : Page
    {
        ShoppingList shoppingList;

        public ShoppingListEditorPage(ShoppingList shoppingList)
        {
            InitializeComponent();

            this.shoppingList = shoppingList;

            ShoppingList.ItemsSource = shoppingList.groceries;
        }

        public void updatePage()
        {
            ShoppingList.ItemsSource = null;
            ShoppingList.ItemsSource = shoppingList.groceries;
        }

        private void ShoppingListBuilderPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ShoppingListBuilderPage(shoppingList));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the item associated with the clicked button
            Button button = (Button)sender;
            Item item = (Item)button.DataContext;

            shoppingList.groceries.Remove(item);

            updatePage();
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the item associated with the clicked button
            Button button = (Button)sender;
            Item item = (Item)button.DataContext;

            foreach (Item i in shoppingList.groceries)
            {
                if (i == item)
                {
                    i.removePortion(1);
                }
            }

            updatePage();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the item associated with the clicked button
            Button button = (Button)sender;
            Item item = (Item)button.DataContext;

            foreach (Item i in  shoppingList.groceries)
            {
                if (i == item)
                {
                    i.addPortion(1);
                }
            }

            updatePage();
        }

        private void finalizeButton_Click(object sender, RoutedEventArgs e)
        {
            string returnString = ShoppingAlgorithm.DoStuff(shoppingList.ToList(), 2, 200);

            MessageBox.Show(returnString, "Totals:", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
