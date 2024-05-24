using System.Collections.Generic;

namespace PokemonCatcher.Models
{
    public class PokemonDetailResponse
    {
        public string Name { get; set; }
        public List<Move> Moves { get; set; }
        public List<Ability> Abilities { get; set; }
    }

    public class Move
    {
        public MoveDetail MoveDetail { get; set; }
    }

    public class MoveDetail
    {
        public string Name { get; set; }
    }

    public class Ability
    {
        public AbilityDetail AbilityDetail { get; set; }
    }

    public class AbilityDetail
    {
        public string Name { get; set; }
    }
}
