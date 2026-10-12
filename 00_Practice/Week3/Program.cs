using System;

namespace Praktikum3
{
    // ====================================================
    // PARENT CLASS (BASE CLASS)
    // Dalam UML Class Diagram:
    // + Nama: string        ( + menandakan public )
    // + IDPegawai: string   ( + menandakan public )
    // ====================================================
    public class PegawaiRestoran
    {
        // Atribut Public (UML Symbol: +)
        public string Nama;
        public string IDPegawai;

        // Constructor Default (Tanpa Parameter)
        public PegawaiRestoran() { }

        // Constructor Berparameter
        public PegawaiRestoran(string nama, string idPegawai)
        {
            this.Nama = nama;
            this.IDPegawai = idPegawai;
        }

        // Method Public yang akan diwariskan ke seluruh Child Class
        public void Bekerja()
        {
            Console.WriteLine($"{Nama} (ID: {IDPegawai}) sedang bekerja.");
        }
    }

    // ====================================================
    // 1. CHILD CLASS - Tanpa Constructor Eksplisit
    // Relationship: Chef "is-a" PegawaiRestoran
    // ====================================================
    public class Chef : PegawaiRestoran
    {
        // Method spesifik hanya milik Chef
        public void Memasak()
        {
            Console.WriteLine($"{Nama} sedang memasak hidangan di dapur.");
        }
    }

    // ====================================================
    // 2. CHILD CLASS - Menggunakan Constructor 'base'
    // Relationship: Kasir "is-a" PegawaiRestoran
    // ====================================================
    public class Kasir : PegawaiRestoran
    {
        // Keyword 'base' meneruskan nilai parameter nama & idPegawai ke constructor Parent Class
        public Kasir(string nama, string idPegawai) : base(nama, idPegawai)
        {
        }

        // Method spesifik hanya milik Kasir
        public void MemprosesPembayaran()
        {
            Console.WriteLine($"{Nama} sedang memproses transaksi pembayaran kasir.");
        }
    }

    // ====================================================
    // 3. CHILD CLASS - Dengan Constructor 'base' & Atribut Tambahan
    // Relationship: Pelayan "is-a" PegawaiRestoran
    // ====================================================
    public class Pelayan : PegawaiRestoran
    {
        // Atribut Tambahan khusus Pelayan
        public string AreaTugas;

        // Meneruskan parameter ke Parent (base) sekaligus mengisi atribut spesifik Child
        public Pelayan(string nama, string idPegawai, string areaTugas) 
            : base(nama, idPegawai)
        {
            this.AreaTugas = areaTugas;
        }

        // Method spesifik hanya milik Pelayan
        public void MelayaniPelanggan()
        {
            Console.WriteLine($"{Nama} sedang melayani pelanggan di area {AreaTugas}.");
        }
    }

    // ====================================================
    // ENTRY POINT PROGRAM
    // ====================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("    PEMROGRAMAN OOP: INHERITANCE (PEWARISAN) ");
            Console.WriteLine("============================================\n");

            // 1. Demo Child Class Tanpa Constructor (Mengisi atribut manual)
            Console.WriteLine("=== 1. DATA CHEF (Child Class tanpa Constructor) ===");
            Chef chef1 = new Chef();
            chef1.Nama = "Budi";
            chef1.IDPegawai = "PG001";

            Console.WriteLine($"Nama       : {chef1.Nama}");
            Console.WriteLine($"ID Pegawai : {chef1.IDPegawai}");
            chef1.Bekerja(); // Memanggil method warisan dari Parent Class
            chef1.Memasak(); // Memanggil method spesifik Child Class
            Console.WriteLine();

            // 2. Demo Child Class dengan Constructor 'base'
            Console.WriteLine("=== 2. DATA KASIR (Child Class dengan 'base' Constructor) ===");
            Kasir kasir1 = new Kasir("Andi", "PG002");

            Console.WriteLine($"Nama       : {kasir1.Nama}");
            Console.WriteLine($"ID Pegawai : {kasir1.IDPegawai}");
            kasir1.Bekerja();             // Method warisan
            kasir1.MemprosesPembayaran(); // Method spesifik
            Console.WriteLine();

            // 3. Demo Child Class dengan Constructor 'base' & Atribut Tambahan
            Console.WriteLine("=== 3. DATA PELAYAN (Child Class + Atribut Tambahan) ===");
            Pelayan pelayan1 = new Pelayan("Siti", "PG003", "Lantai 2");

            Console.WriteLine($"Nama       : {pelayan1.Nama}");
            Console.WriteLine($"ID Pegawai : {pelayan1.IDPegawai}");
            Console.WriteLine($"Area Tugas : {pelayan1.AreaTugas}");
            pelayan1.Bekerja();            // Method warisan
            pelayan1.MelayaniPelanggan();  // Method spesifik
            Console.WriteLine();
        }
    }
}