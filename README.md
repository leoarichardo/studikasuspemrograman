Leo Adi Richardo
19.11.2796

# STUDIKASUSPROMOS 
Aplikasi ini bertujuan seperti simulasi pembelian makanan dan minuman dengan menggunakan promo/voucher.

# Scope and Functionalities
- User dapat melihat daftar makanan dan minuman yang tersedia
- User dapat melihat voucher yang di tawarkan
- User dapat menggunakan voucher
- User dapat melihat potongan harga setelah menggunakan salh satu voucher

# How Does It Works?
Dalam kasus yang diberikan saya menggunakan 4 buah model dan 3 buah controller yang bertujuan untuk 
menjalankan program tersebut.
How is the Flow ? let's chek it out...!

Dimulai dari `Penawaran.xaml.cs` yg bertujuan untuk menawarkan sebuah list makanan yang bisa menggunakan sebuah voucher
untuk di tampilkan di listbox.
```c#
 private void generateContentPenawaran()
        {
            Item coffeLate = new Item("Coffe Late", 30000);
            Item blackTea = new Item("BlackTea", 20000);
            Item milkShake = new Item("Milk Shake", 15000);
            Item watermelonJuice = new Item("Watermelon Juice", 25000);
            Item lemonSquash = new Item("Lemon Squash", 30000);
            Item pizza = new Item("Pizza", 75000);
            Item friedRice = new Item("Fried Rice Special", 45000);
        }
```
Kemudian dilanjutkan pada `Voucher.xaml.cs`, yang bertujuan untuk mengsingkronisasi voucher dan model penawaran,
yang akan di tampilkan pada listbox juga.
```c#
  private void generateListVoucher()
        {
            Model.Voucher awalTahun = new Model.Voucher(title: "Promo Awal Tahun Diskon 25%", discInPercent: 25);
            Model.Voucher tebusMurah = new Model.Voucher(title: "Promo Tebus Murah Diskon 30% atau max. 30.000", discInPercent: 30);
            Model.Voucher promoNatal = new Model.Voucher(title: "Promo Natal Potongan 10000", disc: 10000);

            voucherController.addItem(awalTahun);
            voucherController.addItem(tebusMurah);
            voucherController.addItem(promoNatal);

            DaftarVoucher.Items.Refresh();
        }
```
Lalu pada `MainWindow.xaml.cs` kita menginisiasi object dari `Penawaran.xaml.cs` dan juga `Voucher.xaml.cs`,
untuk di masukan dalam sebuah list KeranjangBelanja. Dan tampilan Total dari semua belanja akan di tampilkan pada ListBox.
```cs

        public MainWindow()
        {
            InitializeComponent();

            payment = new Payment(this);
            payment.setBalance(500000);
            payment.setPromo(0);

            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);

            controller = new MainWindowController(keranjangBelanja);

            listBoxPesanan.ItemsSource = controller.getSelectedItems();
            listBoxPakaiVoucher.ItemsSource = controller.getSelectedVouchers();

            initializeView();

        }

        private void initializeView()
        {
            labelSubtotal.Content = 0;
            labelGrantTotal.Content = 0;
            labelPromoFee.Content = (payment.getPromo() > 0) ? - payment.getPromo() : 0;
        }

        public void onPenawaranSelected(Item item)
        {
            controller.addItem(item);
        }

        private void onButtonAddItemClicked(object sender, RoutedEventArgs e)
        {
            Penawaran penawaranWindow = new Penawaran();
            penawaranWindow.SetOnItemSelectedListener(this);
            penawaranWindow.Show();
        }

        private void listBoxPesanan_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin menghapus item ini?",
                    "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.deleteSelectedItem(item);
            }
        }
```

