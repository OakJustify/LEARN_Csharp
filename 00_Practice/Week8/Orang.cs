namespace Praktikum8
{
    public class Orang
    {
        public string Nama { get; set; }
        public int Umur { get; set; }

        public Orang(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        // Virtual: boleh di-override oleh kelas anak (polymorphism)
        public virtual void Aktivitas()
        {
            Console.WriteLine($"[{GetType().Name}] {Nama} ({Umur} th) - Sedang melakukan kegiatan umum di rumah sakit.");
        }

        public void InfoOrang()
        {
            Console.WriteLine("  ----------------------------------");
            Console.WriteLine($"  Nama        : {Nama}");
            Console.WriteLine($"  Umur        : {Umur} tahun");
            Console.WriteLine($"  Kelas       : {GetType().Name}");
            Console.WriteLine($"  Peran       : {Peran()}");
            Console.WriteLine("  ----------------------------------");
        }

        public virtual string Peran() => "Orang biasa (pengunjung)";

        public string Ringkas() => $"{GetType().Name} - {Nama} ({Umur} th)";

        // Dipakai otomatis saat objek dicetak di dalam daftar
        public override string ToString() => $"| {GetType().Name,-13} | {Nama,-18} | {Umur,3} tahun |";
    }
}