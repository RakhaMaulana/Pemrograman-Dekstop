using System;

public class LayananAutentikasi
{
    public bool Masuk(string username, string password)
    {
        return username == "admin" && password == "1234";
    }
}

class Program
{
    static IManajerProduk manajerProduk = new ManajerProduk();
    static LayananAutentikasi layananAutentikasi = new LayananAutentikasi();

    static void TampilkanHeader(string judul)
    {
        Console.WriteLine("\n++++++++++++++++++++++++++++++++++");
        Console.WriteLine($"++++++++++++{judul}++++++++++++");
        Console.WriteLine("++++++++++++++++++++++++++++++++++");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di Aplikasi Manajemen Produk!");
        while (true)
        {
            Console.Write("\nMasukkan username: ");
            string username = Console.ReadLine();
            Console.Write("Masukkan password: ");
            string password = Console.ReadLine();

            if (layananAutentikasi.Masuk(username, password))
            {
                Console.WriteLine("\nLogin berhasil!");
                break;
            }
            else
            {
                Console.WriteLine("Kredensial tidak valid!");
                Console.Write("Coba lagi atau Keluar? (C/K): ");
                string keputusan = Console.ReadLine().ToUpper();
                if (keputusan == "K")
                {
                    return;
                }
            }
        }

        bool berjalan = true;
        while (berjalan)
        {
            TampilkanHeader("MENU");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tambah Produk");
            Console.WriteLine("2. Hapus Produk");
            Console.WriteLine("3. Cari Produk");
            Console.WriteLine("4. Urutkan Produk Berdasarkan Stok");
            Console.WriteLine("5. Keluar");
            Console.Write("Masukkan pilihan: ");
            int pilihan = int.Parse(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    TampilkanHeader("Tambah Produk");
                    Console.Write("Masukkan nama produk: ");
                    string nama = Console.ReadLine();
                    Console.Write("Masukkan harga produk: ");
                    double harga = double.Parse(Console.ReadLine());
                    Console.Write("Masukkan stok produk: ");
                    int stok = int.Parse(Console.ReadLine());
                    manajerProduk.TambahProduk(nama, harga, stok);
                    break;
                case 2:
                    TampilkanHeader("Hapus Produk");
                    Console.Write("Masukkan nama produk yang ingin dihapus: ");
                    string namaHapus = Console.ReadLine();
                    manajerProduk.HapusProduk(namaHapus);
                    break;
                case 3:
                    TampilkanHeader("Cari Produk");
                    Console.Write("Masukkan nama produk (opsional): ");
                    string cariNama = Console.ReadLine();
                    Console.Write("Masukkan harga minimal (opsional): ");
                    string strHargaMin = Console.ReadLine();
                    double? hargaMin = string.IsNullOrEmpty(strHargaMin) ? (double?)null : double.Parse(strHargaMin);
                    Console.Write("Masukkan harga maksimal (opsional): ");
                    string strHargaMaks = Console.ReadLine();
                    double? hargaMaks = string.IsNullOrEmpty(strHargaMaks) ? (double?)null : double.Parse(strHargaMaks);
                    manajerProduk.CariProduk(cariNama, hargaMin, hargaMaks);
                    break;
                case 4:
                    TampilkanHeader("Urut Produk");
                    manajerProduk.UrutkanProdukByStok();
                    break;
                case 5:
                    Console.WriteLine("\nLogout!");
                    berjalan = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid!");
                    break;
            }
        }
    }
}
