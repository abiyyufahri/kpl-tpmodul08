using System;
using System.Text.Json;
using System.IO;

namespace tpmodul8_103022300121
{
    class CovidConfig
    {
        public class ConfigData
        {
            public string satuan_suhu { get; set; } = "celcius";
            public string batas_hari_deman { get; set; } = "14";
            public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        private ConfigData _config;
        private readonly string _configPath = "covid_config.json";

        public CovidConfig()
        {
            _config = LoadConfig();
        }

        public string GetSatuanSuhu() => _config.satuan_suhu;
        public int GetBatasHariDemam() => int.Parse(_config.batas_hari_deman);
        public string GetPesanDitolak() => _config.pesan_ditolak;
        public string GetPesanDiterima() => _config.pesan_diterima;

        public void UbahSatuan()
        {
            _config.satuan_suhu = _config.satuan_suhu.ToLower() == "celcius" ? "fahrenheit" : "celcius";
            SaveConfig();
        }

        private ConfigData LoadConfig()
        {
            if (File.Exists(_configPath))
            {
                try
                {
                    string jsonString = File.ReadAllText(_configPath);
                    return JsonSerializer.Deserialize<ConfigData>(jsonString);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error : {e.Message}");
                    return new ConfigData();
                }
            }
            else
            {
                var defaultConfig = new ConfigData();
                SaveConfig(defaultConfig);
                return defaultConfig;
            }
        }

        private void SaveConfig(ConfigData config = null)
        {
            config = config ?? _config;
            try
            {
                string jsonString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_configPath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}