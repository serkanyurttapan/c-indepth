 
public class Program
{
   public delegate bool IsSuccessful(string message);

   public class DosyaIndirme
   {
       public void Indir(string dosyaAdi, IsSuccessful callback)
       {
           Console.WriteLine($"{dosyaAdi} indiriliyor...");
           System.Threading.Thread.Sleep(2000); // 2 saniye bekleme (simülasyon)
           callback($"{dosyaAdi} indirildi!"); // İşlem tamamlanınca callback çağrılır
           System.Threading.Thread.Sleep(8000);
       }
   }

   public static bool IndirmeSonrasiMesaj(string mesaj)
   {
       Console.WriteLine(mesaj);
       return true;
   }
    public static void Main()
    {
        MMPSIntegration.getPaid().GetAwaiter().GetResult();
        // var file = new DosyaIndirme();
        // file.Indir("tes",IndirmeSonrasiMesaj);
    }
}
