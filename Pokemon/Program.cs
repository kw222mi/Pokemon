using Pokemon.Domain;
using Pokemon.Domain.Species;
using System;


try
{
    Console.WriteLine("=== Pokémon demo start ===");

    // Party med tre arter
    var party = new List<PokemonCreature>
            {
                new Bulbasaur(),   // Grass, L1, Vine Whip / Leafage
                new Charmander(),  // Fire,  L1, Ember / Flame Burst
                new Squirtle()     // Water, L1, Water Gun / Bubble
            };

    // Visa info och startattacker
    Console.WriteLine("\n-- Party info --");
    foreach (var p in party)
    {
        p.PrintInfo();
        p.ListAttacks();
    }

    // Använd attacker via index
    Console.WriteLine("\n-- B3: UseAttackAt --");
    party[0].UseAttackAt(1); // Bulbasaur kör Leafage
    party[1].UseAttackAt(0); // Charmander kör Ember
    party[2].UseAttackAt(0); // Squirtle kör Water Gun

    // Levla och bekräfta att skadan påverkas
    Console.WriteLine("\n-- B4: RaiseLevel påverkar skada --");
    party[0].RaiseLevel(2);  // Bulbasaur L1 -> L3
    party[1].RaiseLevel(9); //Charmander L1 -> L10
    party[0].UseAttackAt(1); // Samma attack som tidigare, skadan ska öka med +2

    // Evolution – ersätt i listan om arten är evolvable
    Console.WriteLine("\n-- C3: Evolution --");
    for (int i = 0; i < party.Count; i++)
    {
        var mon = party[i];

        if (mon is IEvolvable evo)
        {
            try
            {
                var evolved = evo.Evolve(); // returnerar ny art (t.ex. Charmeleon) med +10 level
                party[i] = evolved;         // ersätt i listan
                Console.WriteLine($"[OK] {mon.Name} utvecklas till {evolved.Name}! Ny level: {evolved.Level}");
                evolved.PrintInfo();
                evolved.ListAttacks();
                // Provkör en attack efter evolution
                evolved.UseAttackAt(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FEL vid evolution av {mon.Name}] {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"[INFO] {mon.Name} kan inte evolva (IEvolvable saknas).");
        }
    }

    // Felvägar: ogiltigt index & tom lista
    Console.WriteLine("\n-- Felvägar --");
    try
    {
        party[1].UseAttackAt(99); // index utanför intervall
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[FEL väntat] {ex.Message}");
    }


    Console.WriteLine("\n=== Pokémon demo slut ===");

    /*

    List<PokemonCreature> party = new List<PokemonCreature>();


    var bulbasaur = new GrassPokemon("Bulbasaur", 1);
    bulbasaur.PrintInfo(); // => "Bulbasaur (Grass, Level 1)"

    var vineWhip = new Attack("Vine Whip", ElementType.Grass, 7);
    var leafage = new Attack("Leafage", ElementType.Grass, 11);
    bulbasaur.AddAttack(vineWhip);
    bulbasaur.AddAttack(leafage);
    bulbasaur.ListAttacks();
    bulbasaur.UseAttackAt(0);
    bulbasaur.RaiseLevel(2);
    bulbasaur.UseAttackAt(0);

    var charmander = new Charmander();
    charmander.PrintInfo();
    charmander.ListAttacks();
    */

}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[FEL] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[FEL] {ex.Message}");
}
catch (OverflowException ex)
{
    Console.WriteLine($"[FEL] Overflow i beräkning: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"[OVÄNTAT FEL] {ex.Message}");
}




        
