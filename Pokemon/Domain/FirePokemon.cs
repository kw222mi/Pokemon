namespace Pokemon.Domain
{
    /// <summary>
    /// Category class for all fire-type Pokémon.
    /// This class ensures that any fire species automatically receives
    /// the Fire elemental type, leaving only name and level for subclasses to define.
    /// </summary>
    public abstract class FirePokemon : PokemonCreature
    {
        /// <summary>
        /// Initializes a new fire-type Pokémon with the specified name and level.
        /// The elemental type is set automatically by this base category class.
        /// </summary>
        /// <param name="name">The species name (provided by the subclass).</param>
        /// <param name="level">The starting level of the Pokémon.</param>
        public FirePokemon(string name, int level)
            : base(name, level)
        {
            Type = ElementType.Fire;
        }

       
    }
}
