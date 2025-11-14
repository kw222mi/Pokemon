namespace Pokemon.Domain
{
    /// <summary>
    /// Represents a single attack (move) that a Pokémon can use,
    /// including its name, elemental type and base power.
    /// </summary>
    public class Attack
    {
        /// <summary>
        /// Gets the name of the attack. Guaranteed to be non-empty.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the elemental type of this attack.
        /// </summary>
        public ElementType Type { get; }

        /// <summary>
        /// Gets the base power of this attack. Always &gt; 0.
        /// </summary>
        public int BasePower { get; }

        /// <summary>
        /// Creates a new attack with the given name, type and base power.
        /// Validates that the name is not empty and that base power is positive.
        /// </summary>
        /// <param name="name">The attack name (at least 1 non-whitespace character).</param>
        /// <param name="type">The elemental type of the attack.</param>
        /// <param name="basePower">The base power (must be &gt; 0).</param>
        /// <exception cref="ArgumentException">Thrown if the name is null or whitespace.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if basePower is ≤ 0.</exception>
        public Attack(string name, ElementType type, int basePower)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Attacknamn saknas. Ange minst 1 tecken.", nameof(name));

            name = name.Trim();
            if (basePower <= 0)
                throw new ArgumentOutOfRangeException(nameof(basePower), "BasePower måste vara > 0.");

            Name = name;
            Type = type;
            BasePower = basePower;
        }

        /// <summary>
        /// Calculates the damage for this attack at a given attacker level.
        /// Uses checked arithmetic to detect overflow.
        /// </summary>
        /// <param name="attackerLevel">The level of the attacking Pokémon (must be ≥ 1).</param>
        /// <returns>The total damage as base power + attacker level.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the attacker level is less than 1.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Thrown if the addition of base power and level overflows the int range.
        /// </exception>
        public int CalculateDamage(int attackerLevel)
        {
            if (attackerLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(attackerLevel), "Level måste vara ≥ 1.");

            return checked(BasePower + attackerLevel);
        }

        /// <summary>
        /// Formats a standard battle message for this attack,
        /// including the attacker name, total damage and the breakdown.
        /// </summary>
        /// <param name="attackerName">The name of the attacking Pokémon.</param>
        /// <param name="attackerLevel">The level of the attacking Pokémon.</param>
        /// <param name="damage">The already calculated damage value.</param>
        /// <returns>
        /// A formatted message, for example:
        /// "Bulbasaur använder Vine Whip – Skada: 8 (7+1)".
        /// </returns>
        public string FormatMessage(string attackerName, int attackerLevel, int damage)
        {
            return $"{attackerName} använder {Name} – Skada: {damage} ({BasePower}+{attackerLevel})";
        }

        /// <summary>
        /// Returns a short string representation of the attack,
        /// including its name, type and base power.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} ({Type}, BP {BasePower})";
        }
    }
}
