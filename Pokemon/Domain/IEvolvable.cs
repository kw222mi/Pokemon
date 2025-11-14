namespace Pokemon.Domain
{
    /// <summary>
    /// Interface for Pokémon species that are capable of evolving.
    /// Implementing classes must provide the logic for returning
    /// the next evolutionary form as a new <see cref="PokemonCreature"/> instance.
    /// </summary>
    public interface IEvolvable
    {
        /// <summary>
        /// Evolves the Pokémon into its next evolutionary form.
        /// Implementations should:
        /// - Validate that evolution is allowed (e.g., minimum required level).
        /// - Create and return a new instance of the next species.
        /// - Increase the Pokémon's level appropriately (e.g., +10).
        /// </summary>
        /// <returns>
        /// A new <see cref="PokemonCreature"/> representing the evolved form.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the Pokémon cannot evolve (wrong form or insufficient level).
        /// </exception>
        PokemonCreature Evolve();
    }
}
