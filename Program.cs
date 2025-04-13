using tpmodul8_103022300121;

CovidConfig covidConfig = new CovidConfig();


Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.GetSatuanSuhu()}: ");
double suhuBadan = double.Parse(Console.ReadLine());
Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
int hariDemam = int.Parse(Console.ReadLine());

bool allowed = CheckAllowed(covidConfig, suhuBadan, hariDemam);

Console.WriteLine();
Console.WriteLine(allowed ? covidConfig.GetPesanDiterima() : covidConfig.GetPesanDitolak());

Console.WriteLine("=== ubah satuan ===");
covidConfig.UbahSatuan();
Console.WriteLine($"Satuan suhu telah diubah menjadi {covidConfig.GetSatuanSuhu()}");

Console.WriteLine("=== data dnegan satuan baru ===");
Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.GetSatuanSuhu()}: ");
suhuBadan = double.Parse(Console.ReadLine());
Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
hariDemam = int.Parse(Console.ReadLine());

allowed = CheckAllowed(covidConfig, suhuBadan, hariDemam);

Console.WriteLine();
Console.WriteLine(allowed ? covidConfig.GetPesanDiterima() : covidConfig.GetPesanDitolak());


static bool CheckAllowed(CovidConfig config, double suhu, int hariDemam)
{
    bool suhuValid = false;
    if (config.GetSatuanSuhu().ToLower() == "celcius")
    {
        suhuValid = (suhu >= 36.5 && suhu <= 37.5);
    }
    else
    {
        suhuValid = (suhu >= 97.7 && suhu <= 99.5);
    }

    bool hariValid = hariDemam < config.GetBatasHariDemam();
    return suhuValid && hariValid;
}