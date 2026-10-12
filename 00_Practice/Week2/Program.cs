using System;

// ====================================================
// 4. NAMESPACE (Mencegah Konflik Penamaan Kelas)
// ====================================================
namespace Folder.Kuliah
{
    public class Tugas
    {
        public void Info()
        {
            Console.WriteLine("Ini adalah tugas dari Mata Kuliah.");
        }
    }
}

namespace Folder.Pribadi
{
    public class Tugas
    {
        public void Info()
        {
            Console.WriteLine("Ini adalah tugas Pribadi/Hobi.");
        }
    }
}

// Namespace Utama Proyek
namespace Praktikum2
{
    // ====================================================
    // 1, 2, 3, 5 & 6. DEFINISI CLASS 'Rumah'
    // ====================================================
    class Rumah
    {
        // 6. Static Attribute (Milik bersama seluruh class Rumah, bukan milik individu objek)
        public static string NamaDeveloper = "Perumahan Indah Jaya";

        // 2. Atribut (Fields) Non-Static
        public string warna;
        public int jumlahKamar;
        public int jumlahLantai;

        // 3. Constructor Default (Tanpa Parameter)
        public Rumah()
        {
            warna = "Putih";
            jumlahKamar = 2;
            jumlahLantai = 1;
        }

        // 3 & 5. Constructor dengan Parameter & Keyword 'this'
        public Rumah(string warna, int jumlahKamar, int jumlahLantai)
        {
            // Keyword 'this' digunakan untuk membedakan atribut class dengan variabel parameter
            this.warna = warna;
            this.jumlahKamar = jumlahKamar;
            this.jumlahLantai = jumlahLantai;
        }

        // 2. Method Non-Static (Perilaku dari Objek Rumah)
        public void TampilkanInformasi()
        {
            Console.WriteLine($"[Dev: {NamaDeveloper}] Rumah Warna: {warna}, Kamar: {jumlahKamar}, Lantai: {jumlahLantai}");
        }
    }

    // ====================================================
    // 6. DEFINISI CLASS 'Kalkulator' (Static Method)
    // ====================================================
    class Kalkulator
    {
        // Static Method: Dapat langsung dipanggil tanpa perlu membuat instance objek baru
        public static int Tambah(int a, int b)
        {
            return a + b;
        }
    }

    // ====================================================
    // TITIK UTAMA PROGRAM (ENTRY POINT)
    // ====================================================
    class Program
    {
        static void Main(string[] args)
        {
            // ================================================
            // 1 & 2. INSTANSIASI OBJEK, ATRIBUT, & METHOD
            // ================================================
            Console.WriteLine("=== 1. CLASS & OBJECT DASAR ===");
            // Membuat objek menggunakan Constructor Default
            Rumah rumahDefault = new Rumah();
            rumahDefault.TampilkanInformasi();
            Console.WriteLine();

            // ================================================
            // 3 & 5. CONSTRUCTOR & KEYWORD 'this'
            // ================================================
            Console.WriteLine("=== 2. CONSTRUCTOR & KEYWORD 'this' ===");
            // Membuat objek menggunakan Constructor Berparameter
            Rumah rumahSaya = new Rumah("Biru", 4, 2);
            rumahSaya.TampilkanInformasi();
            Console.WriteLine();

            // ================================================
            // 6. KEYWORD 'static' (ATRIBUT & METHOD)
            // ================================================
            Console.WriteLine("=== 3. KEYWORD 'static' ===");
            // Mengakses Atribut Static langsung dari Nama Class
            Console.WriteLine("Developer Awal : " + Rumah.NamaDeveloper);

            // Mengubah nilai atribut static (otomatis berdampak ke SEMUA objek Rumah)
            Rumah.NamaDeveloper = "Perumahan Asri Permai";
            Console.WriteLine("\nSetelah NamaDeveloper Diubah:");
            rumahDefault.TampilkanInformasi();
            rumahSaya.TampilkanInformasi();

            // Memanggil Static Method tanpa instansiasi objek
            int hasilPenjumlahan = Kalkulator.Tambah(5, 3);
            Console.WriteLine($"\nHasil Kalkulator.Tambah(5, 3) = {hasilPenjumlahan}");
            Console.WriteLine();

            // ================================================
            // 4. DEMO NAMESPACE
            // ================================================
            Console.WriteLine("=== 4. DEMO NAMESPACE ===");
            // Mengakses kelas Tugas dari Namespace Folder.Kuliah
            Folder.Kuliah.Tugas tugasKuliah = new Folder.Kuliah.Tugas();
            tugasKuliah.Info();

            // Mengakses kelas Tugas dari Namespace Folder.Pribadi
            Folder.Pribadi.Tugas tugasPribadi = new Folder.Pribadi.Tugas();
            tugasPribadi.Info();
        }
    }
}