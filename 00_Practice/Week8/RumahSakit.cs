namespace Praktikum8
{
    // RumahSakit "memiliki" daftar orang (composition, diamond filled)
    public class RumahSakit
    {
        private readonly List<Orang> daftarOrang = new List<Orang>();

        public void TambahOrang(Orang orang)
        {
            daftarOrang.Add(orang);
            Console.WriteLine($"  [Tambah] {orang.Ringkas()} berhasil ditambahkan.");
        }

        public void DaftarOrang()
        {
            Console.WriteLine("  +---------------+------------------+-------------+");
            Console.WriteLine("  | KELAS         | NAMA              | UMUR        |");
            Console.WriteLine("  +---------------+------------------+-------------+");

            foreach (Orang o in daftarOrang)
            {
                Console.WriteLine($"  {o}");
            }

            Console.WriteLine("  +---------------+------------------+-------------+");
            Console.WriteLine($"  Total orang terdaftar: {daftarOrang.Count}\n");
        }

        public void DetailOrang()
        {
            int no = 1;
            foreach (Orang o in daftarOrang)
            {
                Console.WriteLine($"\n  [{no++}] Objek bertipe {o.GetType().Name}");
                o.InfoOrang();
                o.Aktivitas();
            }

            Console.WriteLine();
        }

        public int JumlahOrang => daftarOrang.Count;

        public int JumlahPasien => daftarOrang.Count(o => o is Pasien);

        public int JumlahTenagaMedis => daftarOrang.Count(t => t is TenagaMedis);

        // Salinan, supaya isi daftar asli tidak bisa diubah dari luar
        public List<Orang> DaftarSeluruhOrang() => daftarOrang.ToList();
    }
}