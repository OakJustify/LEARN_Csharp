using System;

namespace Praktikum5
{
    // ====================================================
    // 1. SEBELUM ENKAPSULASI (Bermasalah / Data Rentan)
    // Field bernilai public sehingga dapat diakses dan diubah 
    // secara bebas oleh class lain tanpa kontrol/validasi.
    // ====================================================
    public class RekeningTanpaEnkapsulasi
    {
        public string NamaPemilik;
        public decimal Saldo; // Risiko: Saldo bisa diisi angka negatif dari luar
    }

    // ====================================================
    // 2. SESUDAH ENKAPSULASI (Aman / Data Terlindung)
    // Menggabungkan data & perilaku, menyembunyikan field internal, 
    // dan mengontrol akses melalui Properties & Methods.
    // ====================================================
    public class RekeningBank
    {
        // Field Private (Data Hiding):
        // Hanya dapat diakses dan dimodifikasi langsung di dalam class RekeningBank
        private decimal saldo;

        // Auto-Property untuk data yang tidak membutuhkan validasi khusus
        public string NamaPemilik { get; set; }

        // Full Property dengan Private Set:
        // - 'get' public: Boleh dibaca dari luar class
        // - 'set' private: Hanya boleh diubah dari dalam class ini
        public decimal Saldo
        {
            get
            {
                return saldo;
            }
            private set
            {
                // Validasi data bisnis internal
                if (value >= 0)
                {
                    saldo = value;
                }
                else
                {
                    Console.WriteLine("[ERROR] Gagal Mengubah Saldo: Saldo tidak boleh negatif!");
                }
            }
        }

        // Constructor dengan validasi saldo awal
        public RekeningBank(string namaPemilik, decimal saldoAwal)
        {
            NamaPemilik = namaPemilik;

            if (saldoAwal >= 0)
            {
                saldo = saldoAwal;
            }
            else
            {
                throw new ArgumentException("Saldo awal tidak boleh negatif.");
            }
        }

        // Operasi Setor Tunai (Interface Terkontrol)
        public void Setor(decimal jumlah)
        {
            if (jumlah > 0)
            {
                Saldo += jumlah; // Menggunakan setter internal
                Console.WriteLine($"[SETOR SUCCESS] Berhasil setor: Rp{jumlah:N0}");
            }
            else
            {
                Console.WriteLine("[SETOR FAILED] Jumlah setor harus lebih dari 0.");
            }
        }

        // Operasi Tarik Tunai (Interface Terkontrol)
        public void Tarik(decimal jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("[TARIK FAILED] Jumlah tarik harus lebih dari 0.");
            }
            else if (jumlah > Saldo)
            {
                Console.WriteLine("[TARIK FAILED] Saldo tidak mencukupi untuk melakukan penarikan.");
            }
            else
            {
                Saldo -= jumlah; // Menggunakan setter internal
                Console.WriteLine($"[TARIK SUCCESS] Berhasil tarik: Rp{jumlah:N0}");
            }
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
            Console.WriteLine("    PEMROGRAMAN OOP: ENKAPSULASI (DATA)     ");
            Console.WriteLine("============================================\n");

            // ----------------------------------------------------
            // DEMO 1: MASALAH TANPA ENKAPSULASI
            // ----------------------------------------------------
            Console.WriteLine("=== 1. KODE SEBELUM ENKAPSULASI (Tanpa Validasi) ===");
            RekeningTanpaEnkapsulasi rekLama = new RekeningTanpaEnkapsulasi();
            rekLama.NamaPemilik = "Budi";
            rekLama.Saldo = 500000;
            Console.WriteLine($"Pemilik     : {rekLama.NamaPemilik}");
            Console.WriteLine($"Saldo Awal  : Rp{rekLama.Saldo:N0}");

            // Class luar merusak integritas data secara langsung
            rekLama.Saldo = -1000000; 
            Console.WriteLine($"Saldo Akhir : Rp{rekLama.Saldo:N0} (TIDAK VALID!)");
            Console.WriteLine();

            // ----------------------------------------------------
            // DEMO 2: SOLUSI DENGAN ENKAPSULASI
            // ----------------------------------------------------
            Console.WriteLine("=== 2. KODE SESUDAH ENKAPSULASI (Terproteksi) ===");
            RekeningBank rekeningBudi = new RekeningBank("Budi", 500000);

            Console.WriteLine($"Pemilik     : {rekeningBudi.NamaPemilik}");
            Console.WriteLine($"Saldo Awal  : Rp{rekeningBudi.Saldo:N0}\n");

            // Melakukan transaksi resmi melalui Method
            Console.WriteLine("--- Transaksi Normal ---");
            rekeningBudi.Setor(200000);
            rekeningBudi.Tarik(100000);
            Console.WriteLine($"Saldo Akhir : Rp{rekeningBudi.Saldo:N0}\n");

            // ----------------------------------------------------
            // DEMO 3: UJI COBA TRANSAKSI TIDAK VALID
            // ----------------------------------------------------
            Console.WriteLine("--- Pengujian Validasi & Aturan Bisnis ---");
            
            // Coba setor jumlah negatif
            rekeningBudi.Setor(-50000);

            // Coba tarik melebihi saldo yang ada
            rekeningBudi.Tarik(1000000);

            // TIDAK DIPERBOLEHKAN (Akan Kompilasi Error jika di-uncomment):
            // rekeningBudi.saldo = -1000000; // Error: 'saldo' is inaccessible due to its protection level
            // rekeningBudi.Saldo = -1000000; // Error: The property 'Saldo' set accessor is inaccessible

            Console.WriteLine($"\nSaldo Akhir Tetap Aman: Rp{rekeningBudi.Saldo:N0}");
            Console.WriteLine();
        }
    }
}