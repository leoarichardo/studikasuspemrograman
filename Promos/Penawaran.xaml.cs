using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Promos.Controller;
using Promos.Model;

namespace Promos
{
    /// <summary>
    /// Interaction logic for Penawaran.xaml
    /// </summary>

    public partial class Penawaran : Window
    {
        PenawaranController Penawarancontroller;
        OnPenawaranChangedListener listener;
        public Penawaran()
        {
            InitializeComponent();

            Penawarancontroller = new PenawaranController();
            listPenawaran.ItemsSource = Penawarancontroller.getItems();

            generateContentPenawaran();

        }

        public void SetOnItemSelectedListener(OnPenawaranChangedListener listener)
        {
            this.listener = listener;
        }

        private void generateContentPenawaran()
        {
            Item coffeLate = new Item("Coffe Late", 30000);
            Item blackTea = new Item("BlackTea", 20000);
            Item milkShake = new Item("Milk Shake", 15000);
            Item watermelonJuice = new Item("Watermelon Juice", 25000);
            Item lemonSquash = new Item("Lemon Squash", 30000);
            Item pizza = new Item("Pizza", 75000);
            Item friedRice = new Item("Fried Rice Special", 45000);

            Penawarancontroller.addItem(coffeLate);
            Penawarancontroller.addItem(blackTea);
            Penawarancontroller.addItem(milkShake);
            Penawarancontroller.addItem(watermelonJuice);
            Penawarancontroller.addItem(lemonSquash);
            Penawarancontroller.addItem(pizza);
            Penawarancontroller.addItem(friedRice);

            listPenawaran.Items.Refresh();
        }

        private void listPenawaran_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Item item = listbox.SelectedItem as Item;

            this.listener.onPenawaranSelected(item);
        }
    }

    public interface OnPenawaranChangedListener
    {
        void onPenawaranSelected(Item item);
    }
}
