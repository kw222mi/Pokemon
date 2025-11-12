
namespace Pokemon.Domain
{
    public class Attack
    {
        public string Name { get; }
        public ElementType Type { get; }
        public int BasePower { get; }

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
        /// Calculate damage for level
        /// </summary>
        public int CalculateDamage(int attackerLevel)
        {
            if (attackerLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(attackerLevel), "Level måste vara ≥ 1.");

            return checked(BasePower + attackerLevel);

        }

        /// <summary>
        /// format message for standard attack 
        /// </summary>
        public string FormatMessage(string attackerName, int attackerLevel, int damage)
        {
           
            return $"{attackerName} använder {Name} – Skada: {damage} ({BasePower}+{attackerLevel})";
        }

        public override string ToString()
        {
            return $"{Name} ({Type}, BP {BasePower})";
        }

    }
}
