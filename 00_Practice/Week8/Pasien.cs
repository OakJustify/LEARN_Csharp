namespace Praktikum8
{
    public class Pasien : Orang
    {
        public string Keluhan { get; set; }

        public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
        {
            Keluhan = keluhan;
        }

        public void CekKeluhan()
        {
            Console.WriteLine($"  Keluhan     : {Keluhan}");
            Console.WriteLine($"  Tindakan    : diteruskan ke {(Umur < 12 ? "poliklinik anak" : "poliklinik dewasa")}.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"[Pasien] {Nama} ({Umur} th) - Sedang menunggu giliran berobat, keluhan: {Keluhan}.");
        }

        public override string Peran() => "Pasien (orang yang berobat)";
    }
}