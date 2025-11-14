namespace Pokemon.Domain
{
    /// <summary>
    /// Abstract base class for all Pokémon creatures.
    /// Handles validation of name and level, elemental type,
    /// and management of the move list (attacks).
    /// </summary>
    public abstract class PokemonCreature
    {
        /// <summary>
        /// Gets the Pokémon's name. Guaranteed to be 2–15 non-whitespace characters.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Pokémon's current level. Always ≥ 1.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Gets or sets the elemental type for this Pokémon.
        /// The setter is protected so only subclasses can assign it.
        /// </summary>
        public ElementType Type { get; protected set; }

        /// <summary>
        /// Backing list for this Pokémon's attacks. Never null.
        /// </summary>
        private readonly List<Attack> _attacks;

        /// <summary>
        /// Creates a new Pokémon creature with the given name and level.
        /// Performs validation of the name and level before assigning them.
        /// </summary>
        /// <param name="name">The Pokémon's name (2–15 non-whitespace characters).</param>
        /// <param name="level">Starting level (must be ≥ 1).</param>
        /// <exception cref="ArgumentException">Thrown if the name is null/whitespace.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the name length is outside 2–15 characters or level is &lt; 1.
        /// </exception>
        protected PokemonCreature(string name, int level)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Namn saknas. Ange 2–15 tecken.", nameof(name));

            name = name.Trim();
            if (name.Length < 2 || name.Length > 15)
                throw new ArgumentOutOfRangeException(nameof(name),
                    "Ogiltigt namn. Längd måste vara 2–15 tecken.");

            // Validate level
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level),
                    "Ogiltig level. Level måste vara ≥ 1.");

            // Assign state
            Name = name;
            Level = level;

            _attacks = new List<Attack>();
        }

        /// <summary>
        /// Prints a one-line summary of this Pokémon to the console:
        /// "Name (Type, Level X)".
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} ({Type}, Level {Level})");
        }

        /// <summary>
        /// Raises the Pokémon's level by the specified positive delta.
        /// Uses checked arithmetic to detect overflow.
        /// </summary>
        /// <param name="delta">The positive amount to increase the level by.</param>
        /// <exception cref="ArgumentException">Thrown if delta is ≤ 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the resulting level would be invalid.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Thrown if the addition overflows the int range.
        /// </exception>
        public void RaiseLevel(int delta)
        {
            if (delta <= 0)
                throw new ArgumentException("Level-ökning måste vara > 0.", nameof(delta));

            int newLevel = checked(Level + delta);

            // This guard is mostly defensive, given the earlier checks.
            if (newLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(delta),
                    "Ogiltig level efter ökning.");

            Level = newLevel;

            Console.WriteLine($"Level höjs till {Level} ");
        }

        /// <summary>
        /// Uses a specific attack object for this Pokémon.
        /// Damage is calculated based on the attack's base power and this Pokémon's level,
        /// and the result is printed to the console.
        /// </summary>
        /// <param name="attack">The attack to use.</param>
        /// <exception cref="ArgumentNullException">Thrown if attack is null.</exception>
        public void UseAttack(Attack attack)
        {
            if (attack is null)
                throw new ArgumentNullException(nameof(attack), "Attack saknas.");

            int damage = attack.CalculateDamage(this.Level);

            Console.WriteLine(attack.FormatMessage(Name, Level, damage));
        }

        /// <summary>
        /// Adds a new attack to this Pokémon's move list.
        /// Ensures that the attack is not null, matches the Pokémon's elemental type,
        /// and that there are no duplicate names (case-insensitive).
        /// </summary>
        /// <param name="attack">The attack to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if attack is null.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the attack type does not match this Pokémon's type
        /// or if an attack with the same name already exists.
        /// </exception>
        public void AddAttack(Attack attack)
        {
            if (attack is null)
                throw new ArgumentNullException(nameof(attack), "Attack saknas.");

            // Only allow attacks that match this Pokémon's elemental type.
            if (attack.Type != this.Type)
                throw new ArgumentException(
                    $"Fel typ: {Name} ({Type}) kan inte lära {attack.Name} ({attack.Type}).");

            // Prevent duplicate attacks by name (case-insensitive).
            if (_attacks.Any(a =>
                    string.Equals(a.Name, attack.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Attacken '{attack.Name}' finns redan.");
            }

            _attacks.Add(attack);
        }

        /// <summary>
        /// Uses the attack at the specified index in this Pokémon's move list.
        /// Validates that at least one attack exists and that the index is in range.
        /// </summary>
        /// <param name="index">Zero-based index of the attack to use.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the Pokémon has no attacks.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is outside the valid range 0..Count-1.
        /// </exception>
        public void UseAttackAt(int index)
        {
            if (_attacks.Count == 0)
                throw new InvalidOperationException($"{Name} har inga attacker.");

            if (index < 0 || index >= _attacks.Count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Attackindex {index} är utanför 0..{_attacks.Count - 1}.");

            var attack = _attacks[index];
            UseAttack(attack);
        }

        /// <summary>
        /// Prints all attacks for this Pokémon to the console as a numbered list.
        /// If there are no attacks, an informational message is printed instead.
        /// </summary>
        public void ListAttacks()
        {
            if (_attacks.Count == 0)
            {
                Console.WriteLine("Det finns inga attacker");
            }
            else
            {
                Console.WriteLine("Attacker: ");
                int i = 0;
                foreach (var item in _attacks)
                {
                    Console.WriteLine($"{i}: {item}");
                    i++;
                }
            }
        }

        public virtual void Speak ()
        {
            Console.WriteLine($"{Name} makes a sound");

        }
    }
}
