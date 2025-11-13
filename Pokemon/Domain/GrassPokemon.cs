namespace Pokemon.Domain
{
    public class GrassPokemon : PokemonCreature
    {
        public GrassPokemon(string name, int level)
            : base(name, level)
        {
            Type = ElementType.Grass;
        }
    }
}
