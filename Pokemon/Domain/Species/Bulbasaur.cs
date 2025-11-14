using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    /// <summary>
    /// Represents the first-stage Grass-type Pokémon Bulbasaur.
    /// Bulbasaur starts with two basic Grass-type attacks.
    /// </summary>
    public class Bulbasaur : GrassPokemon
    {
        /// <summary>
        /// Creates a Bulbasaur at level 1 with its predefined starting attacks.
        /// </summary>
        public Bulbasaur()
            : base("Bulbasaur", 1)
        {
            var vineWhip = new Attack("Vine Whip", ElementType.Grass, 7);
            var leafage = new Attack("Leafage", ElementType.Grass, 11);

            AddAttack(vineWhip);
            AddAttack(leafage);
        }

        /// <summary>
        /// Creates a Bulbasaur at a specified level.
        /// Useful for testing scenarios or when manually constructing the species.
        /// </summary>
        /// <param name="level">The starting level for the Bulbasaur.</param>
        public Bulbasaur(int level)
            : base("Bulbasaur", level)
        {
            var vineWhip = new Attack("Vine Whip", ElementType.Grass, 7);
            var leafage = new Attack("Leafage", ElementType.Grass, 11);

            AddAttack(vineWhip);
            AddAttack(leafage);
        }
    }
}

// NOTE: In a real game, species data (names, types, moves, evolutions)
// would typically be stored in a registry or database.
// For this assignment, hardcoded species classes are used intentionally 
// to demonstrate inheritance and constructor chaining.
