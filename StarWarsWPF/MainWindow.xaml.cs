using Newtonsoft.Json;
using PokemonWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public List<Pokemon> pokemons = new List<Pokemon>();
        public Pokemon SelectedPokemon = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri("https://pokeapi.co/api/v2/pokemon/?limit=151"));
            string json = Encoding.UTF8.GetString(data);
            PokemonData result = JsonConvert.DeserializeObject<PokemonData>(json);

            lb_pokemons.ItemsSource = result.Results;

            pokemons = result.Results;

        }

        private void lb_pokemons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataAsync(pokemons[lb_pokemons.SelectedIndex].Url);
        }

        public async void LoadDataAsync(string url)
        {
            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(url));
            string json = Encoding.UTF8.GetString(data);
            Pokemon result = JsonConvert.DeserializeObject<Pokemon>(json);

            SelectedPokemon = result;

            UpdateUI(result);

            //lb_pokemons.ItemsSource = result.Results;
        }

        public void UpdateUI(Pokemon p)
        {
            PokemonName.Text = p.Name;
            PokemonImage.Source = new BitmapImage(new Uri(p.Sprites.front_default));
        }
    }
}
