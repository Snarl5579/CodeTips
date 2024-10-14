using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeCore
{
    public class BaseConfig<CType>
    {
        public string Version { get; set; }

        public void Write(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(JsonSerializer.Serialize(
                    this, typeof(CType), new JsonSerializerOptions() { WriteIndented = true }));
                sw.Close();
            }
        }

        public void Read(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"{path} no found.");

            string jsonString;
            using (StreamReader file = new StreamReader(path))
            {
                jsonString = file.ReadToEnd();
                file.Close();
            }

            CType config = JsonSerializer.Deserialize<CType>(jsonString);
            if (!this.CheckValue(config))
            {
                this.Write(path);
            }
        }

        protected virtual bool CheckValue(CType t)
        {
            return true;
        }
    }
}
