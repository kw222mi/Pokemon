namespace Pokemon.Domain
{
    /// <summary>
    /// Abstract category class for all water-type Pokémon. 
    /// This class sets the elemental type automatically so that 
    /// each water species only needs to provide its name and starting level.
    /// </summary>
    public class WaterPokemon : PokemonCreature
    {
        /// <summary>
        /// Initializes a new water-type Pokémon with the given name and level.
        /// The elemental type is assigned automatically.
        /// </summary>
        public WaterPokemon(string name, int level)
            : base(name, level)
        {
            Type = ElementType.Water;
        }
    }
}
