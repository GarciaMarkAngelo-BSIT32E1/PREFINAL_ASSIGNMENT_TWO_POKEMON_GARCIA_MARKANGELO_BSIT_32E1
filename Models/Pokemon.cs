namespace PokemonCatcher.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<PokemonMove> Moves { get; set; }
        public List<PokemonAbility> Abilities { get; set; }

    }

    public class PokemonMove
    {
        public PokemonMoveDetails Move { get; set; }

    }

    public class PokemonAbility
    {
        public PokemonAbilityDetails Ability { get; set; }

    }

    public class PokemonMoveDetails
    {
        public string Name { get; set; }
  
    }

    public class PokemonAbilityDetails
    {
        public string Name { get; set; }

    }
}
