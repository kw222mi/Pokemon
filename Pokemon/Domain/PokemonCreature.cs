

namespace Pokemon.Domain
{
    public abstract class PokemonCreature
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public ElementType Type { get; protected set; }
        private readonly List <Attack> _attacks;

        protected PokemonCreature(string name, int level )
            
        {
            // Validate
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Namn saknas. Ange 2–15 tecken.", nameof(name));

            name = name.Trim();
            if (name.Length < 2 || name.Length > 15)
                throw new ArgumentOutOfRangeException(nameof(name), "Ogiltigt namn. Längd måste vara 2–15 tecken.");

            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Ogiltig level. Level måste vara ≥ 1.");

            //Set
            Name = name;
            Level = level;

            _attacks = new List <Attack>();
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} ({Type}, Level {Level})");

        }

        public void RaiseLevel(int delta)
        {
            if (delta <= 0)
                throw new ArgumentException("Level-ökning måste vara > 0.", nameof(delta));

            int newLevel = checked(Level + delta);
            if (newLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(delta), "Ogiltig level efter ökning.");

            Level = newLevel;

            Console.WriteLine($"Level höjs till {Level} ");
        }

        /// <summary>
        /// Use attack object
        /// </summary>
        public void UseAttack(Attack attack)
        {
            if (attack is null)
                throw new ArgumentNullException(nameof(attack), "Attack saknas.");

            int damage = attack.CalculateDamage(this.Level);
            
            Console.WriteLine(attack.FormatMessage(Name, Level, damage));
        }

        /// <summary>
        /// Add attack object
        /// </summary>
        public void AddAttack(Attack attack) {

            if (attack is null)
                throw new ArgumentNullException(nameof(attack), "Attack saknas.");

            // only attacks for the pokemon type
            if (attack.Type != this.Type)
                throw new ArgumentException($"Fel typ: {Name} ({Type}) kan inte lära {attack.Name} ({attack.Type}).");

          //check for doubles
            if (_attacks.Any(a => string.Equals(a.Name, attack.Name, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Attacken '{attack.Name}' finns redan.");

            _attacks.Add(attack);
        }

        public void UseAttackAt(int index)
        {
            if (_attacks.Count == 0)
                throw new InvalidOperationException($"{Name} har inga attacker.");

            if (index < 0 || index >= _attacks.Count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Attackindex {index} är utanför 0..{_attacks.Count - 1}.");

            var attack = _attacks[index];
            UseAttack(attack);
        }


        public void ListAttacks() {
            if (_attacks.Count == 0) Console.WriteLine("Det finns inga attacker");

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

            {
                
            }
        }

    }

   
}
