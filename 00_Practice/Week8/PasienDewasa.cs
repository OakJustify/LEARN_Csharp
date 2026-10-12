namespace Praktikum8
{
    public class PasienDewasa : Pasien
    {
        public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
        {
        }

        public void Konsultasi()
        {
            Console.WriteLine($"[Konsultasi] {Nama} berkonsultasi tentang keluhan: {Keluhan}.");
            Console.WriteLine("              -> Tenang, keluhan bisa membaik dengan istirahat & obat.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"[PasienDewasa] {Nama} ({Umur} th) - Sedang berkonsultasi dengan dokter.");
        }

        public override string Peran() => "Pasien dewasa (13+ tahun)";
    }
}