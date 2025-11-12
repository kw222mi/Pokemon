

namespace Pokemon.Domain
{
    public class PokemonCreature
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public ElementType Type { get; private set; }
        private List <Attack> _attacks;

        public PokemonCreature(string name, int level, ElementType type)
            
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
            Type = type;

            _attacks = new List <Attack>();
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} ({Type}, Level {Level})");

        }

        public void UseSimpleAttack (string attackName, int basePower) {
            if (string.IsNullOrWhiteSpace(attackName)) { throw new ArgumentException("Attacknamn saknas. Ange minst 1 tecken."); }

            if(basePower <= 0) { throw new ArgumentException("BasePower måste vara > 0."); }

                int damage = basePower + Level;
            Console.WriteLine($"{Name} använder {attackName} – Skada: {damage} ({basePower}+{Level})");

        }

        public void RaiseLevel(int delta)
        {
            if (delta <= 0)
                throw new ArgumentException("Level-ökning måste vara > 0.", nameof(delta));

            int newLevel = checked(Level + delta);
            if (newLevel < 1)
                throw new ArgumentOutOfRangeException(nameof(delta), "Ogiltig level efter ökning.");

            Level = newLevel;
        }

        /// <summary>
        /// Use attack object
        /// </summary>
        public void UseAttack(Attack attack)
        {
            if (attack is null)
                throw new ArgumentNullException(nameof(attack), "Attack saknas.");


            Console.WriteLine(attack.FormatMessage(Name, Level));
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
                    Console.WriteLine($"{i}:  {item.Name}, {item.Type}, BP: {item.BasePower}");
                    i++;
                }
            }

            {
                
            }
        }

    }

   
}
