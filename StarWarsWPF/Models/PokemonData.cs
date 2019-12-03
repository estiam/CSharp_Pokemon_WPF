using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWPF.Models
{
    public class PokemonData
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Pokemon> Results { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public String Url { get; set; }

        public PokemonImgData Sprites { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }

    public class PokemonImgData
    {
        public string front_default { get; set; }
    }


}
