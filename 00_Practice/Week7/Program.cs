using System;

// ====================================================
// SIMULASI CLASS LIBRARY (Namespace Terpisah)
// Dalam proyek nyata, bagian ini berada di proyek terpisah (.csproj)
// yang di-build menjadi file .dll (misal: PaymentLibrary.dll)
// ====================================================
namespace PaymentLibrary
{
    // Interface sebagai Kontrak dalam Library
    public interface IPembayaran
    {
        void Bayar(decimal jumlah);
    }

    // Kelas Implementasi dari Library
    public class TransferBankLibrary : IPembayaran
    {
        public void Bayar(decimal jumlah)
        {
            Console.WriteLine($"[Class Library] Transfer Rp{jumlah:N0} melalui bank.");
        }
    }
}

// ====================================================
// APLIKASI UTAMA (MAIN PROGRAM)
// ====================================================
namespace Praktikum7
{
    // Mengimpor Class Library yang sudah dibuat
    using PaymentLibrary;

    // ====================================================
    // 1. ABSTRACT CLASS (Abstraksi Berbasis Parent-Child)
    // - Tidak dapat di-instansiasi langsung (new Pembayaran() -> Error).
    // - Dapat memiliki field, property, constructor, method biasa, & abstract method.
    // ====================================================
    public abstract class Pembayaran
    {
        public string NamaMetode { get; set; }

        public Pembayaran(string nama)
        {
            NamaMetode = nama;
        }

        // Abstract Method: Belum ada isi, WAJIB di-override oleh kelas turunan
        public abstract void ProsesPembayaran(decimal jumlah);

        // Concrete Method: Method biasa yang sudah memiliki implementasi
        public void TampilkanInfo()
        {
            Console.WriteLine($"Metode Pembayaran: {NamaMetode}");
        }
    }

    // Turunan Abstract Class 1
    public class TransferBank : Pembayaran
    {
        public TransferBank() : base("Transfer Bank") { }

        public override void ProsesPembayaran(decimal jumlah)
        {
            Console.WriteLine($"[Abstract Class] Transfer Rp{jumlah:N0} melalui bank.");
        }
    }

    // Turunan Abstract Class 2
    public class EWallet : Pembayaran
    {
        public EWallet() : base("E-Wallet") { }

        public override void ProsesPembayaran(decimal jumlah)
        {
            Console.WriteLine($"[Abstract Class] Bayar Rp{jumlah:N0} menggunakan E-Wallet.");
        }
    }

    // ====================================================
    // 2. INTERFACE (Kontrak Perilaku / Capability Contract)
    // - Hanya menentukan 'apa yang harus ada', bukan 'bagaimana cara kerjanya'.
    // - Sebuah class bisa mengimplementasikan lebih dari satu interface.
    // ====================================================
    public interface IPembayaranApp
    {
        void ProsesPembayaran(decimal jumlah);
    }

    public class KartuKredit : IPembayaranApp
    {
        public void ProsesPembayaran(decimal jumlah)
        {
            Console.WriteLine($"[Interface] Memproses Kartu Kredit sebesar Rp{jumlah:N0}");
        }
    }

    // Service class yang fleksibel menggunakan Interface (Loose Coupling)
    public class PaymentService
    {
        public void Bayar(IPembayaranApp metode, decimal jumlah)
        {
            // Tidak peduli objek apa yang masuk, selama memenuhi kontrak IPembayaranApp
            metode.ProsesPembayaran(jumlah);
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
            Console.WriteLine(" OOP: ABSTRACT CLASS, INTERFACE & LIBRARY   ");
            Console.WriteLine("============================================\n");

            // ----------------------------------------------------
            // DEMO 1: ABSTRACT CLASS
            // ----------------------------------------------------
            Console.WriteLine("=== 1. ABSTRACT CLASS (Parent-Child Base) ===");
            // Pembayaran p = new Pembayaran("Test"); // ERROR! Abstract Class tidak bisa di-instansiasi.

            Pembayaran p1 = new TransferBank();
            p1.TampilkanInfo();
            p1.ProsesPembayaran(100000);
            Console.WriteLine();

            Pembayaran p2 = new EWallet();
            p2.TampilkanInfo();
            p2.ProsesPembayaran(50000);
            Console.WriteLine();

            // ----------------------------------------------------
            // DEMO 2: INTERFACE & PAYMENT SERVICE
            // ----------------------------------------------------
            Console.WriteLine("=== 2. INTERFACE & PAYMENT SERVICE (Contract) ===");
            PaymentService service = new PaymentService();
            IPembayaranApp kartu = new KartuKredit();

            // Mengirimkan objek KartuKredit ke PaymentService
            service.Bayar(kartu, 250000);
            Console.WriteLine();

            // ----------------------------------------------------
            // DEMO 3: CLASS LIBRARY (Memanggil Namespace Terpisah)
            // ----------------------------------------------------
            Console.WriteLine("=== 3. CLASS LIBRARY (Simulasi File .dll) ===");
            
            // Memanggil class TransferBankLibrary dari namespace PaymentLibrary
            PaymentLibrary.IPembayaran libraryPayment = new TransferBankLibrary();
            libraryPayment.Bayar(500000);
            Console.WriteLine();
        }
    }
}