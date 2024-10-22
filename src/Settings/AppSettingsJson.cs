using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificReviews.Settings
{
    public class AppSettingsJson<T> where T : new()
    {
        private SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        public AppSettingsJson(string settingsFile)
        {
            this.settingsFile = settingsFile;
            this.Data = new T();
        }

        public T Data { get; set; }

        private string settingsFile;

        public void LoadSettings()
        {
            LoadSettings(this.settingsFile);
        }

        public void LoadSettings(string fileName)
        {
            string json;
            try
            {
                semaphoreSlim.Wait();
                try
                {
                    json = File.ReadAllText(fileName);                    
                }
                finally
                {
                    semaphoreSlim.Release();
                }
                Data = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                File.WriteAllText(settingsFile, string.Empty);
                Data = new T();
                SaveSettings();
            }
        }


        public void SaveSettings(string message = "Unknown call")
        {
            SaveSettings(this.settingsFile, message);
        }

        public void SaveSettings(string fileName, string message = "Unknown call")
        {
            tries = 0;
            SaveSettingsSafe(fileName, message);
        }
        int tries = 0;
        private void SaveSettingsSafe(string fileName, string message)
        {

            string json = JsonConvert.SerializeObject(Data);
            semaphoreSlim.Wait();
            try
            {
                File.WriteAllText(fileName, json);
            }
            finally
            {
                semaphoreSlim.Release();
            }
            try
            {
                AppSettingsJson<T> tmp = new AppSettingsJson<T>(this.settingsFile);
                tmp.LoadSettings();

                if (IsDataEqual(this.Data, tmp.Data) == false)
                {
                    throw new Exception("Load settings check fails.");
                }
                

            }
            catch
            {                
                tries++;
                if (tries < 3)
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(3000); // Další pokus o uložení po 3 s
                        SaveSettingsSafe(fileName, message + " " + tries.ToString());
                    });
                }                
            }

        }

        private bool IsDataEqual(T data1, T data2)
        {
            string json1 = JsonConvert.SerializeObject(data1);
            string json2 = JsonConvert.SerializeObject(data2);
            return json1 == json2;
        }
    }
}
