namespace Praktikum8
{
    public class Dokter : TenagaMedis
    {
        public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
        {
        }

        public void Diagnosa()
        {
            Console.WriteLine($"[Diagnosa] dr. {Nama} (spesialis {Spesialisasi}) memeriksa & menetapkan diagnosis.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"[Dokter] dr. {Nama} ({Umur} th) - Sedang memeriksa pasien sebagai spesialis {Spesialisasi}.");
        }

        public override string Peran() => $"Dokter spesialis {Spesialisasi}";
    }
}