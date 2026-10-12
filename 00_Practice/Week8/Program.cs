using System.Text;
using Praktikum8;

namespace Praktikum8.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Judul("WEEK 8 - INHERITANCE & POLYMORPHISM (SISTEM RUMAH SAKIT)");

            // Kasus 1: membuat objek dan mendaftarkannya ke rumah sakit
            Judul("KASUS 1: MEMBUAT OBJEK & MENAMBAHKAN KE RUMAH SAKIT");

            RumahSakit rs = new RumahSakit();

            Orang pengunjung     = new Orang("Pak Budi", 45);
            Pasien pasienUmum   = new Pasien("Ibu Sari", 32, "Batuk kering");
            PasienAnak andik    = new PasienAnak("Andik", 7, "Demam");
            PasienDewasa hendra = new PasienDewasa("Pak Hendra", 55, "Nyeri dada");
            Dokter drAndi       = new Dokter("Andi", 41, "Penyakit Dalam");
            Perawat susRina     = new Perawat("Rina", 29, "Perawatan Intensif");

            rs.TambahOrang(pengunjung);
            rs.TambahOrang(pasienUmum);
            rs.TambahOrang(andik);
            rs.TambahOrang(hendra);
            rs.TambahOrang(drAndi);
            rs.TambahOrang(susRina);
            Console.WriteLine();

            // Kasus 2: menampilkan semua data orang
            Judul("KASUS 2: MENAMPILKAN SEMUA DATA (DaftarOrang + InfoOrang)");
            rs.DaftarOrang();
            rs.DetailOrang();

            // Kasus 3: polymorphism - satu method, banyak perilaku
            Judul("KASUS 3: POLYMORPHISM - SATU METHOD, BANYAK PERILAKU");

            List<Orang> daftarPolimorfis = new List<Orang>
            {
                new Orang("Pak Budi", 45),
                new Pasien("Ibu Sari", 32, "Batuk kering"),
                new PasienAnak("Andik", 7, "Demam"),
                new PasienDewasa("Pak Hendra", 55, "Nyeri dada"),
                new Dokter("Andi", 41, "Penyakit Dalam"),
                new Perawat("Rina", 29, "Perawatan Intensif"),
                new PasienAnak("Caca", 5, "Batuk pilek"),
            };

            foreach (Orang o in daftarPolimorfis)
            {
                o.Aktivitas();
            }
            Console.WriteLine();

            // Kasus 4: memanggil method khusus tiap kelas
            Judul("KASUS 4: MEMANGGIL METHOD KHUSUS (pattern matching)");

            foreach (Orang o in rs.DaftarSeluruhOrang())
            {
                Console.WriteLine($"\n  Objek: {o.Ringkas()}");

                if (o is PasienAnak pa)
                {
                    Console.WriteLine("  -> bertipe PasienAnak:");
                    pa.Menangis();
                    pa.CekKeluhan();
                }
                else if (o is PasienDewasa pd)
                {
                    Console.WriteLine("  -> bertipe PasienDewasa:");
                    pd.Konsultasi();
                    pd.CekKeluhan();
                }
                else if (o is Pasien p)
                {
                    Console.WriteLine("  -> bertipe Pasien:");
                    p.CekKeluhan();
                }
                else if (o is Dokter d)
                {
                    Console.WriteLine("  -> bertipe Dokter:");
                    d.Diagnosa();
                    d.CekSpesialis();
                }
                else if (o is Perawat pr)
                {
                    Console.WriteLine("  -> bertipe Perawat:");
                    pr.CekPasien();
                    pr.CekSpesialis();
                }
                else
                {
                    Console.WriteLine("  -> hanya orang biasa (tidak punya method khusus).");
                }
            }
            Console.WriteLine();

            // Kasus 5: upcasting & downcasting
            Judul("KASUS 5: UPCASTING & DOWNCASTING");

            PasienAnak dita = new PasienAnak("Dita", 6, "Demam tinggi");
            Orang jadiOrang = dita;
            Console.WriteLine($"  [Upcasting] Objek {dita.GetType().Name} disimpan pada variabel bertipe {nameof(Orang)}.");
            Console.WriteLine($"              Tipe deklarasi  : {nameof(Orang)}");
            Console.WriteLine($"              Tipe runtime    : {jadiOrang.GetType().Name}");
            Console.WriteLine("              -> tetap memanggil Aktivitas() versi PasienAnak.\n");

            Orang refill = new Perawat("Rina", 29, "Perawatan Intensif");
            if (refill is Perawat perawatRina)
            {
                Console.WriteLine($"  [Downcasting \"is\"] Berhasil: {refill.Nama} adalah Perawat.");
                perawatRina.CekPasien();
            }
            else
            {
                Console.WriteLine("  [Downcasting \"is\"] Gagal: objek tersebut bukan Perawat.");
            }

            Orang orangBiasa = new Orang("Pak Budi", 45);
            Dokter? bukanDokter = orangBiasa as Dokter;
            Console.WriteLine($"\n  [Downcasting \"as\"] 'Pak Budi' as Dokter -> {(bukanDokter == null ? "null (tidak bisa di-cast)" : "berhasil")}");
            Console.WriteLine();

            // Kasus 6: kumpulan polimorfis (List<TipeDasar>)
            Judul("KASUS 6: KUMPULAN POLIMORFIS (List<TipeDasar>)");

            List<Pasien> daftarPasien = new List<Pasien>
            {
                new Pasien("Ibu Sari", 32, "Batuk kering"),
                new PasienAnak("Andik", 7, "Demam"),
                new PasienDewasa("Pak Hendra", 55, "Nyeri dada"),
            };

            foreach (Pasien p in daftarPasien)
            {
                Console.WriteLine($"  {p.GetType().Name,-13} -> {p.Nama} ({p.Umur} th)");
                p.CekKeluhan();
            }

            List<TenagaMedis> daftarMedis = new List<TenagaMedis>
            {
                new Dokter("Andi", 41, "Penyakit Dalam"),
                new Perawat("Rina", 29, "Perawatan Intensif"),
                new Dokter("Sari", 38, "Anak"),
            };

            foreach (TenagaMedis t in daftarMedis)
            {
                Console.WriteLine($"  {t.GetType().Name,-13} -> {t.Nama} ({t.Spesialisasi})");
                t.CekSpesialis();
            }
            Console.WriteLine();

            // Kasus 7: ringkasan data rumah sakit
            Judul("KASUS 7: RINGKASAN DATA RUMAH SAKIT");

            List<Orang> semua = rs.DaftarSeluruhOrang();
            Console.WriteLine($"  Total orang terdaftar : {rs.JumlahOrang} orang");
            Console.WriteLine($"  Jumlah pasien         : {rs.JumlahPasien} orang");
            Console.WriteLine($"  Jumlah tenaga medis   : {rs.JumlahTenagaMedis} orang");
            Console.WriteLine($"  Jumlah dokter         : {semua.Count(o => o is Dokter)} orang");
            Console.WriteLine($"  Jumlah perawat        : {semua.Count(o => o is Perawat)} orang");
            Console.WriteLine($"  Jumlah pasien anak    : {semua.Count(o => o is PasienAnak)} orang");
            Console.WriteLine($"  Jumlah pasien dewasa  : {semua.Count(o => o is PasienDewasa)} orang");
            Console.WriteLine("\n  CATATAN: PasienAnak & PasienDewasa ikut terhitung sebagai Pasien,");
            Console.WriteLine("          begitu juga Dokter & Perawat ikut terhitung sebagai TenagaMedis.\n");

            Console.WriteLine("============================================================");
            Console.WriteLine("  PROGRAM SELESAI");
            Console.WriteLine("============================================================");
        }

        static void Judul(string teks)
        {
            Console.WriteLine($"=== {teks} ===\n");
        }
    }
}