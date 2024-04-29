using System;
using System.Collections.Generic;
using System.Linq;

public interface IManajerProduk
{
    void TambahProduk(string nama, double harga, int stok);
    void HapusProduk(string nama);
    void CariProduk(string nama = null, double? hargaMin = null, double? hargaMaks = null);
    void UrutkanProdukByStok();
}

public class Produk
{
    public string Nama { get; set; }
    public double Harga { get; set; }
    public int Stok { get; set; }

    public Produk(string nama, double harga, int stok)
    {
        Nama = nama;
        Harga = harga;
        Stok = stok;
    }

    public override string ToString()
    {
        return $"Nama: {Nama}, Harga: Rp{Harga}, Stok: {Stok}";
    }
}

public class ManajerProduk : IManajerProduk
{
    private List<Produk> produkList = new List<Produk>();

    public void TambahProduk(string nama, double harga, int stok)
    {
        produkList.Add(new Produk(nama, harga, stok));
        Console.WriteLine("Produk berhasil ditambahkan!");
    }

    public void HapusProduk(string nama)
    {
        var produkDitemukan = produkList.FirstOrDefault(p => p.Nama.ToLower() == nama.ToLower());
        if (produkDitemukan != null)
        {
            produkList.Remove(produkDitemukan);
            Console.WriteLine("Produk berhasil dihapus!");
        }
        else
        {
            Console.WriteLine("Produk tidak ditemukan!");
        }
    }

    public void CariProduk(string nama = null, double? hargaMin = null, double? hargaMaks = null)
    {
        var hasil = produkList.AsQueryable();
        if (!string.IsNullOrEmpty(nama))
            hasil = hasil.Where(p => p.Nama.ToLower().Contains(nama.ToLower()));
        if (hargaMin.HasValue)
            hasil = hasil.Where(p => p.Harga >= hargaMin.Value);
        if (hargaMaks.HasValue)
            hasil = hasil.Where(p => p.Harga <= hargaMaks.Value);

        if (!hasil.Any())
            Console.WriteLine("Tidak ada produk yang ditemukan.");
        else
            foreach (var p in hasil)
                Console.WriteLine(p);
    }

    public void UrutkanProdukByStok()
    {
        foreach (var p in produkList.OrderByDescending(p => p.Stok))
            Console.WriteLine(p);
    }
}
