namespace Pokemon.Domain.Species
{
    /// <summary>
    /// Represents the evolved form of Squirtle.
    /// Wartortle is a water-type Pokémon with stronger starting moves.
    /// </summary>
    internal class Wartortle : WaterPokemon
    {
        /// <summary>
        /// Creates a Wartortle at level 1 with its predefined starting attacks.
        /// </summary>
        public Wartortle()
            : base("Wartortle", 1)
        {
            var waterGun = new Attack("Water Gun", ElementType.Water, 15);
            var bubble = new Attack("Bubble", ElementType.Water, 11);
            var legendaryBubble = new LegendaryAttack(bubble);

            AddAttack(waterGun);
            AddAttack(bubble);
            AddAttack(legendaryBubble);
        }

        /// <summary>
        /// Creates a Wartortle at a specific level. 
        /// Useful when evolving from Squirtle or for testing scenarios.
        /// </summary>
        /// <param name="level">The level to assign to the new Wartortle.</param>
        public Wartortle(int level)
            : base("Wartortle", level)
        {
            var waterGun = new Attack("Water Gun", ElementType.Water, 15);
            var bubble = new Attack("Bubble", ElementType.Water, 11);
            var legendaryBubble = new LegendaryAttack(bubble);

            AddAttack(waterGun);
            AddAttack(bubble);
            AddAttack(legendaryBubble);
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} speaks: Turtle roar!!");
        }
    }
}
