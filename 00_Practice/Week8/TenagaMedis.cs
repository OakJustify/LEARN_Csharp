namespace Praktikum8
{
    public class TenagaMedis : Orang
    {
        public string Spesialisasi { get; set; }

        public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
        {
            Spesialisasi = spesialisasi;
        }

        public void CekSpesialis()
        {
            Console.WriteLine($"  Spesialisasi: {Spesialisasi}");
            Console.WriteLine($"  Lokasi      : Ruang Praktek {Spesialisasi}");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"[TenagaMedis] {Nama} ({Umur} th) - Bekerja sebagai tenaga medis ({Spesialisasi}).");
        }

        public override string Peran() => $"Tenaga medis ({Spesialisasi})";
    }
}