using Microsoft.Win32;
using Shopping_list_builder.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


            MessageBoxResult result = MessageBox.Show("Do you want to Save your Shopping list?", "Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes
                MessageBox.Show("Please select location to store Grocery List");

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string fileName = saveFileDialog.FileName;

                    // Example text content to save


                    try
                    {
                        // Write the text content to the selected file
                        File.WriteAllText(fileName, returnString);
                        MessageBox.Show("File saved successfully!");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}");
                    }
                }
            }
            else
            {
                // User clicked No or closed the dialog
                MessageBox.Show("You cancelled saving Grocery List");
            }

            
        }


        private void OpenBrowserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // URL of the webpage you want to open
                string url = "https://www.safeway.com/";

                // Open the default web browser to the specified URL
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur while opening the web browser
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regular expression to match numeric characters
            Regex regex = new Regex("[^0-9]+");

            // If the input text does not match the regular expression, cancel the input
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
