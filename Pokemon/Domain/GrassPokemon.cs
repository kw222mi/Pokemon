namespace Pokemon.Domain
{
    /// <summary>
    /// Category class for all grass-type Pokémon.
    /// This class ensures that any subclass is automatically assigned the Grass element type,
    /// so species classes only need to provide their name and starting level.
    /// </summary>
    public abstract class GrassPokemon : PokemonCreature
    {
        /// <summary>
        /// Initializes a new grass-type Pokémon with the specified name and level.
        /// The elemental type is set automatically.
        /// </summary>
        /// <param name="name">The species name (passed by the concrete subclass).</param>
        /// <param name="level">The starting level for this Pokémon.</param>
        public GrassPokemon(string name, int level)
            : base(name, level)
        {
            Type = ElementType.Grass;
        }
    }
}
