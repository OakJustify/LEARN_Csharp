class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        TransferBank transferBank = new TransferBank();
        transferBank.ProsesPembayaran(Jumlah : 10000);
        EWallet eWallet = new EWallet();
        eWallet.ProsesPembayaran(Jumlah: 5000);


    }

    //Pembayaran pembayaran = new Pembayaran(); gabisa di instance\

   




}

abstract class Pembayaran
{
    public string NamaMetode { get; set; }
    public Pembayaran(string NamaMetode)
    {
        this.NamaMetode = NamaMetode;
    }

    public abstract void ProsesPembayaran(decimal Jumlah);
}

class TransferBank : Pembayaran
{
    public TransferBank() : base("Transfer Bank")
    {

    }

    public override void ProsesPembayaran(decimal Jumlah)
    {
        Console.WriteLine($"Proses Pembayaran Sebesar {Jumlah} Berhasil dibayarakan Melalui Metode {NamaMetode}");
    }
}

class EWallet : Pembayaran
{
    public EWallet() : base("EWAllET")
    {

    }

    public override void ProsesPembayaran(decimal Jumlah)
    {
        Console.WriteLine($"Proses Pembayaran Sebesar {Jumlah} Berhasil dibayarakan Melalui Metode {NamaMetode}");
    }
}