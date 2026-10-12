namespace Praktikum8
{
    public class Perawat : TenagaMedis
    {
        public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
        {
        }

        public void CekPasien()
        {
            Console.WriteLine($"[CekPasien] Suster {Nama} mengecek kondisi vital pasien (tensi, nadi, suhu).");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"[Perawat] Suster {Nama} ({Umur} th) - Memantau kondisi pasien dan membantu dokter.");
        }

        public override string Peran() => $"Perawat {Spesialisasi}";
    }
}