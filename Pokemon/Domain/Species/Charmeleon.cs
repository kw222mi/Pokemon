using Pokemon.Domain;

namespace Pokemon.Domain.Species
{
    /// <summary>
    /// Represents the second-stage evolution of Charmander.
    /// Charmeleon is a stronger fire-type Pokémon with improved base attacks.
    /// </summary>
    internal class Charmeleon : FirePokemon
    {
        /// <summary>
        /// Creates a Charmeleon at level 1 with its predefined fire-type attacks.
        /// </summary>
        public Charmeleon()
            : base("Charmeleon", 1)
        {
            var fireKick = new Attack("Fire Kick", ElementType.Fire, 15);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 10);
            var superFireKick = new LegendaryAttack(fireKick);

            AddAttack(fireKick);
            AddAttack(flameBurst);
            AddAttack(superFireKick);
        }

        /// <summary>
        /// Creates a Charmeleon at a specific level.
        /// Useful when evolving from Charmander or when testing higher-level scenarios.
        /// </summary>
        /// <param name="level">The level to assign to the new Charmeleon.</param>
        public Charmeleon(int level)
            : base("Charmeleon", level)
        {
            var fireKick = new Attack("Fire Kick", ElementType.Fire, 15);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 10);
            var superFireKick = new LegendaryAttack(fireKick);

            AddAttack(fireKick);
            AddAttack(flameBurst);
            AddAttack(superFireKick);
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} speaks: Charrrrrr");
        }
    }
}
