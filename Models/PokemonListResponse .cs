namespace PokemonCatcher.Models
{
    public class PokemonListResponse
    {
        public List<PokemonListItem> Results { get; set; }
    }

    public class PokemonListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
