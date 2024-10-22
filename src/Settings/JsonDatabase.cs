using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.Settings
{
    public class JsonDatabase<T> where T : new()
    {

        public JsonDatabase(string file)
        {
            this.file = file;
        }

        public T Data { get; private set; }
        
        private readonly string file;

        public void Load()
        {
            try
            {
                string json = File.ReadAllText(file);
                Data = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                Data = new T();
            }
        }

        public void Save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Data);
                File.WriteAllText(file, json);
            }
            catch (Exception)
            {
                
            }
        }

    }
}
