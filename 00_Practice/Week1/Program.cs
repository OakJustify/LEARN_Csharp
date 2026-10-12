using System;
using System.Collections.Generic; // Wajib diimpor untuk menggunakan List<T> (Generics)

namespace Praktikum1
{
    class Program
    {
        // Entry point: Titik awal eksekusi program C#
        static void Main(string[] args)
        {
            // ====================================================
            // 1. STRUKTUR PROGRAM & OUTPUT DASAR
            // ====================================================
            Console.WriteLine("=== 1. STRUKTUR PROGRAM ===");
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            // ====================================================
            // 2. VARIABEL & TIPE DATA PRIMITIF
            // ====================================================
            Console.WriteLine("=== 2. VARIABEL & TIPE DATA PRIMITIF ===");
            int umur = 20;
            double ipk = 3.75;
            bool isLulus = true;
            char indeks = 'A';
            string nama = "Budi";

            Console.WriteLine($"Nama : {nama}");
            Console.WriteLine($"Umur : {umur} tahun");
            Console.WriteLine($"IPK  : {ipk} (Indeks: {indeks}, Status Lulus: {isLulus})");
            Console.WriteLine();

            // ====================================================
            // 3. OPERATOR UTAMA
            // ====================================================
            Console.WriteLine("=== 3. OPERATOR UTAMA ===");
            // Aritmatika (+, -, *, /, %)
            int angka1 = 10;
            int angka2 = 3;
            int sisaBagi = angka1 % angka2;
            Console.WriteLine($"Aritmatika: 10 % 3 = {sisaBagi}");

            // Perbandingan (==, !=, >, <, >=, <=) & Logika (&&, ||, !)
            bool kriteriaIpk = ipk >= 3.0;
            bool kriteriaUmur = umur < 25;
            bool bisaDaftarBeasiswa = kriteriaIpk && kriteriaUmur;
            Console.WriteLine($"Perbandingan & Logika (Beasiswa): {bisaDaftarBeasiswa}");
            Console.WriteLine();

            // ====================================================
            // 4. PERCABANGAN (BRANCHING)
            // ====================================================
            Console.WriteLine("=== 4. PERCABANGAN ===");
            // If-Else Statement (Evaluasi kondisi rentang nilai)
            if (ipk >= 3.5)
            {
                Console.WriteLine("Predikat: Cum Laude");
            }
            else if (ipk >= 3.0)
            {
                Console.WriteLine("Predikat: Sangat Memuaskan");
            }
            else
            {
                Console.WriteLine("Predikat: Memuaskan");
            }

            // Switch Statement (Evaluasi nilai konstanta tetap)
            int hari = 1;
            switch (hari)
            {
                case 1:
                    Console.WriteLine("Hari 1: Senin");
                    break;
                case 2:
                    Console.WriteLine("Hari 2: Selasa");
                    break;
                default:
                    Console.WriteLine("Hari tidak valid");
                    break;
            }
            Console.WriteLine();

            // ====================================================
            // 5. TIPE DATA KOLEKSI & GENERICS
            // ====================================================
            Console.WriteLine("=== 5. TIPE DATA KOLEKSI & GENERICS ===");
            
            // Array (Fixed-size / Ukuran tetap)
            string[] hobi = { "Coding", "Gaming", "Reading" };

            // List<T> (Dynamic-size / Type Safety dengan Generics Parameter T)
            List<string> keranjang = new List<string>(); // T diisi dengan string
            keranjang.Add("Laptop");
            keranjang.Add("Mouse");
            Console.WriteLine($"Jumlah item di keranjang: {keranjang.Count}");

            List<string> products = new List<string> { "Laptop", "Keyboard", "Kamera" };
            Console.WriteLine();

            // ====================================================
            // 6. PERULANGAN (LOOPING)
            // ====================================================
            Console.WriteLine("=== 6. PERULANGAN ===");

            // For Loop (Jumlah iterasi sudah pasti)
            Console.WriteLine("-- For Loop --");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Iterasi ke-{i}");
            }

            // While Loop (Cek kondisi di awal)
            Console.WriteLine("\n-- While Loop --");
            int j = 0;
            while (j < 3)
            {
                Console.WriteLine("Iterasi While ke-" + j);
                j++;
            }

            // Do-While Loop (Minimal berjalan 1x, cek kondisi di akhir)
            Console.WriteLine("\n-- Do-While Loop --");
            int k = 0;
            do
            {
                Console.WriteLine("Iterasi Do-While ke-" + k);
                k++;
            } while (k < 3);

            // Foreach Loop (Iterasi elemen Array)
            Console.WriteLine("\n-- Foreach Loop (Array) --");
            foreach (string item in hobi)
            {
                Console.WriteLine("Hobi: " + item);
            }

            // Foreach Loop (Iterasi elemen List)
            Console.WriteLine("\n-- Foreach Loop (List) --");
            foreach (string product in products)
            {
                Console.WriteLine("Produk: " + product);
            }
        }
    }
}