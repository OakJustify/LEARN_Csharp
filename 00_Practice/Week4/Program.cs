using System;
using System.Collections.Generic;

namespace Praktikum4
{
    // ====================================================
    // 1. OVERLOADING (Polimorfisme Statis / Compile-Time)
    // Nama method sama, tetapi parameter berbeda (tipe/jumlah)
    // terjadi dalam kelas yang sama.
    // ====================================================
    public class Kasir
    {
        // Overload 1: Bayar Tunai (Parameter: int)
        public void Bayar(int jumlah)
        {
            Console.WriteLine($"[Tunai] Pembayaran berhasil sebesar Rp{jumlah:N0}");
        }

        // Overload 2: Bayar Kartu (Parameter: string)
        public void Bayar(string nomorKartu)
        {
            Console.WriteLine($"[Kartu Kredit/Debit] Pembayaran diproses untuk kartu: {nomorKartu}");
        }

        // Overload 3: Bayar Tunai dengan Voucher (Parameter: int, string)
        public void Bayar(int jumlah, string kodeVoucher)
        {
            Console.WriteLine($"[Voucher] Pembayaran Rp{jumlah:N0} menggunakan kode voucher: {kodeVoucher}");
        }
    }

    // ====================================================
    // 2. OVERRIDING (Polimorfisme Dinamis / Runtime)
    // Melibatkan Pewarisan (Inheritance).
    // Keyword 'virtual' pada Parent Class, 'override' pada Child Class.
    // ====================================================

    // Parent Class (Base Class)
    public class Hewan
    {
        // Keyword 'virtual' mengizinkan kelas turunan untuk mengabaikan/mengubah perilaku method ini
        public virtual void Suara()
        {
            Console.WriteLine("Hewan mengeluarkan suara umum.");
        }
    }

    // Child Class 1
    public class Anjing : Hewan
    {
        // Keyword 'override' menggantikan implementasi method Suara() milik Hewan
        public override void Suara()
        {
            Console.WriteLine("Anjing menggonggong: Guk Guk!");
        }
    }

    // Child Class 2
    public class Kucing : Hewan
    {
        public override void Suara()
        {
            Console.WriteLine("Kucing mengeong: Meong!");
        }
    }

    // Child Class 3
    public class Burung : Hewan
    {
        public override void Suara()
        {
            Console.WriteLine("Burung berkicau: Cuit Cuit!");
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
            Console.WriteLine("       PEMROGRAMAN OOP: POLYMORPHISM        ");
            Console.WriteLine("============================================\n");

            // ----------------------------------------------------
            // DEMO 1: METHOD OVERLOADING (Polimorfisme Statis)
            // ----------------------------------------------------
            Console.WriteLine("=== 1. OVERLOADING (Compile-Time Polymorphism) ===");
            Kasir kasirResto = new Kasir();

            // Memanggil nama method yang sama 'Bayar', namun C# otomatis 
            // memilih variasi method berdasarkan argumen yang dikirim
            kasirResto.Bayar(50000);                      // Memanggil Bayar(int)
            kasirResto.Bayar("4567-8901-2345");           // Memanggil Bayar(string)
            kasirResto.Bayar(100000, "PROMO2026");        // Memanggil Bayar(int, string)
            Console.WriteLine();

            // ----------------------------------------------------
            // DEMO 2: METHOD OVERRIDING (Polimorfisme Dinamis)
            // ----------------------------------------------------
            Console.WriteLine("=== 2. OVERRIDING (Runtime Polymorphism) ===");

            // Tipe data referensi adalah Base Class (Hewan), 
            // tetapi instansiasi objek spesifik ke Child Class
            Hewan peliharaan1 = new Anjing();
            Hewan peliharaan2 = new Kucing();
            Hewan peliharaan3 = new Burung();
            Hewan hewanUmum = new Hewan();

            Console.Write("Peliharaan 1 : ");
            peliharaan1.Suara(); // Output: Anjing menggonggong

            Console.Write("Peliharaan 2 : ");
            peliharaan2.Suara(); // Output: Kucing mengeong

            Console.Write("Peliharaan 3 : ");
            peliharaan3.Suara(); // Output: Burung berkicau

            Console.Write("Hewan Umum   : ");
            hewanUmum.Suara();   // Output: Suara umum
            Console.WriteLine();

            // ----------------------------------------------------
            // DEMO 3: MANFAAT POLIMORFISME DALAM KOLEKSI DATA
            // ----------------------------------------------------
            Console.WriteLine("=== 3. MANFAAT: KOLEKSI POLYMORPHIC (List<Hewan>) ===");
            
            // Seluruh objek turunan Hewan dapat disimpan dalam 1 List bertipe Hewan
            List<Hewan> daftarHewan = new List<Hewan>
            {
                new Anjing(),
                new Kucing(),
                new Burung(),
                new Anjing()
            };

            // Satu perulangan dapat memproses perilaku masing-masing objek secara otomatis
            foreach (Hewan h in daftarHewan)
            {
                h.Suara();
            }
        }
    }
}