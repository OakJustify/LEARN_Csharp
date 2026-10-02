using System;

namespace GudangLibrary
{
    // Interface distribusi barang
    public interface IDistribusi
    {
        void MasukGudang();
        void KeluarGudang();
    }

    // Abstract class Barang
    public abstract class Barang
    {
        public string Nama { get; set; }
        public string KodeSKU { get; set; }

        protected Barang(string nama, string kodeSKU)
        {
            Nama = nama;
            KodeSKU = kodeSKU;
        }

        public abstract void TampilkanInfoBarang();
    }

    // Class Elektronik: mewarisi Barang dan mengimplementasikan IDistribusi
    public class Elektronik : Barang, IDistribusi
    {
        public int GaransiBulan { get; set; }

        public Elektronik(string nama, string kodeSKU, int garansiBulan)
            : base(nama, kodeSKU)
        {
            GaransiBulan = garansiBulan;
        }

        public override void TampilkanInfoBarang()
        {
            Console.WriteLine("[Elektronik]");
            Console.WriteLine($"Nama barang : {Nama}");
            Console.WriteLine($"Kode SKU    : {KodeSKU}");
            Console.WriteLine($"Garansi     : {GaransiBulan} bulan");
        }

        public void MasukGudang()
        {
            Console.WriteLine($"{Nama} (SKU: {KodeSKU}) masuk gudang: dicek fungsi dan disimpan di rak elektronik.");
        }

        public void KeluarGudang()
        {
            Console.WriteLine($"{Nama} (SKU: {KodeSKU}) keluar gudang: dikemas dengan bubble wrap lalu dikirim.");
        }
    }

    // Class Pakaian: mewarisi Barang dan mengimplementasikan IDistribusi
    public class Pakaian : Barang, IDistribusi
    {
        public string Ukuran { get; set; }

        public Pakaian(string nama, string kodeSKU, string ukuran)
            : base(nama, kodeSKU)
        {
            Ukuran = ukuran;
        }

        public override void TampilkanInfoBarang()
        {
            Console.WriteLine("[Pakaian]");
            Console.WriteLine($"Nama barang : {Nama}");
            Console.WriteLine($"Kode SKU    : {KodeSKU}");
            Console.WriteLine($"Ukuran      : {Ukuran}");
        }

        public void MasukGudang()
        {
            Console.WriteLine($"{Nama} (SKU: {KodeSKU}) masuk gudang: dilipat dan disimpan di rak pakaian.");
        }

        public void KeluarGudang()
        {
            Console.WriteLine($"{Nama} (SKU: {KodeSKU}) keluar gudang: dikemas dalam plastik lalu dikirim.");
        }
    }
}