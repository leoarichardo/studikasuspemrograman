using System;
using System.Collections.Generic;
using System.Text;
using Promos.Model;

namespace Promos.Controller
{
    class MainWindowController 
    {
        KeranjangBelanja keranjangBelanja;

        public MainWindowController(KeranjangBelanja keranjangBelanja)
        {
            this.keranjangBelanja = keranjangBelanja;
        }

        public void addItem(Item item)
        {
            this.keranjangBelanja.addItem(item);
        }

        public void addVoucher(Voucher item)
        {
            this.keranjangBelanja.addVoucher(item);
        }
        public List<Item> getSelectedItems()
        {
            return this.keranjangBelanja.getItems();
        }

        public List<Voucher> getSelectedVouchers()
        {
            return this.keranjangBelanja.getVouchers();
        }

        public void deleteSelectedItem(Item item)
        {
            this.keranjangBelanja.removeItem(item);
        }

        public void deleteSelectedVoucher(Voucher item)
        {
            this.keranjangBelanja.removeVoucher(item);
        }


    }

}
