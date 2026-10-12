namespace Praktikum8
{
    public class PasienAnak : Pasien
    {
        public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
        {
        }

        public void Menangis()
        {
            Console.WriteLine($"[Menangis] {Nama} menangis terus karena keluhan: {Keluhan}.");
            Console.WriteLine("            Perlu dihibur orang tua agar tetap tenang dan mau diperiksa.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"[PasienAnak] {Nama} ({Umur} th) - Sedang menangis, perlu dihibur oleh orang tua.");
        }

        public override string Peran() => "Pasien anak (0-12 tahun)";
    }
}