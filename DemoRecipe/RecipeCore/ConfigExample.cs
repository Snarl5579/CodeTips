using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCore
{
    public class ConfigExample : BaseConfig<ConfigExample>
    {
        readonly string configVersion = "example_202411111111";

        public int intExample { get; set; }
        public double doubleExample { get; set; }
        public string stringExample { get; set; }
        public List<int> listExample { get; set; }

        public ConfigExample()
        {
            this.intExample = 3;
            this.doubleExample = 3.1415;
            this.stringExample = "HelloConfig";
            this.listExample = new List<int>();
        }
        

        protected override bool CheckValue(ConfigExample t)
        {
            this.intExample = t.intExample;

            this.doubleExample = t.doubleExample;

            this.stringExample = t.stringExample;

            foreach(int value in t.listExample)
            {
                this.listExample.Add(value);
            }

            this.Version = this.configVersion;

            if (this.Version != t.Version)
                return false;
            else
                return true;
        }
    }
}
