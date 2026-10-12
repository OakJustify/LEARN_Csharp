using System;
using System.Collections.Generic;
using GudangLibrary;

namespace AplikasiGudang
{
    class Program
    {
        static void Main(string[] args)
        {
            // Daftar barang bertipe Barang (polymorphism)
            List<Barang> daftarBarang = new List<Barang>
            {
                new Elektronik("Laptop Gaming", "ELK-001", 24),
                new Elektronik("Smartphone", "ELK-002", 12),
                new Pakaian("Kemeja Flanel", "PKN-001", "L"),
                new Pakaian("Jaket Hoodie", "PKN-002", "M")
            };

            Console.WriteLine("=== Data Barang Gudang ===\n");
            foreach (Barang barang in daftarBarang)
            {
                barang.TampilkanInfoBarang();
                Console.WriteLine();
            }

            Console.WriteLine("=== Proses Masuk Gudang ===");
            foreach (Barang barang in daftarBarang)
            {
                if (barang is IDistribusi distribusi)
                {
                    distribusi.MasukGudang();
                }
            }

            Console.WriteLine("\n=== Proses Keluar Gudang ===");
            foreach (Barang barang in daftarBarang)
            {
                if (barang is IDistribusi distribusi)
                {
                    distribusi.KeluarGudang();
                }
            }

            Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
            Console.ReadKey();
        }
    }
}