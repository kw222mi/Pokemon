using Pokemon.Domain;
using Pokemon.Domain.Species;


// Entry point for the Pokémon console demo.
// Demonstrates creation of a party, attacks, leveling, evolution and error handling.
try
{
    Console.WriteLine("=== Pokémon demo start ===");

    // 1) Create a party with three starter species.
    //    Each species configures its own type and starting moves in the constructor.
    var party = new List<PokemonCreature>
    {
        new Bulbasaur(),   // Grass, L1, Vine Whip / Leafage
        new Charmander(),  // Fire,  L1, Ember / Flame Burst
        new Squirtle()     // Water, L1, Water Gun / Bubble
    };

    // 2) Print basic info and starting attacks for each Pokémon.
    Console.WriteLine("\n-- Party info --");
    foreach (var p in party)
    {
        p.PrintInfo();
        p.ListAttacks();
    }

    // 3) Use attacks by index to demonstrate B3 (attack list + UseAttackAt).
    Console.WriteLine("\n-- UseAttackAt --");
    party[0].UseAttackAt(1); // Bulbasaur uses Leafage
    party[1].UseAttackAt(0); // Charmander uses Ember
    party[2].UseAttackAt(0); // Squirtle uses Water Gun

    // 4) Level up and verify that damage scales with level (B4).
    Console.WriteLine("\n--: RaiseLevel affects damage --");
    party[0].RaiseLevel(2);  // Bulbasaur L1 -> L3
    party[1].RaiseLevel(9);  // Charmander L1 -> L10 (ready for evolution in C3)

    // Reuse the same move as before for Bulbasaur; damage should increase by +2.
    party[0].UseAttackAt(1);

    // 5) Evolution – replace evolvable Pokémon in the party with their next form (C3).
    Console.WriteLine("\n-- Evolution --");
    for (int i = 0; i < party.Count; i++)
    {
        var mon = party[i];

        // Only Pokémon that implement IEvolvable can be evolved.
        if (mon is IEvolvable evo)
        {
            try
            {
                // Evolve returns a new instance of the next species (e.g. Charmeleon) with +10 levels.
                var evolved = evo.Evolve();
                party[i] = evolved; // Replace the old Pokémon in the party with the evolved one.

                Console.WriteLine($"[OK] {mon.Name} utvecklas till {evolved.Name}! Ny level: {evolved.Level}");

                evolved.PrintInfo();
                evolved.ListAttacks();

                // Try one attack after evolution to verify that everything still works.
                evolved.UseAttackAt(0);
            }
            catch (Exception ex)
            {
                // Local error handling for evolution: we log the problem but continue with the rest of the party.
                Console.WriteLine($"[FEL vid evolution av {mon.Name}] {ex.Message}");
            }
        }
        else
        {
            // Information for non-evolvable species (e.g. Bulbasaur if you chose not to implement evolution yet).
            Console.WriteLine($"[INFO] {mon.Name} kan inte evolva (IEvolvable saknas).");
        }
    }

    // 6) Error path demo – show that invalid input is handled and does not crash the program.
    Console.WriteLine("\n-- Felvägar (error paths) --");
    try
    {
        // Intentionally use an invalid index to trigger validation in UseAttackAt.
        party[1].UseAttackAt(99);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[FEL väntat] {ex.Message}");
    }

    Console.WriteLine("\n=== Pokémon demo slut ===");
}
catch (ArgumentOutOfRangeException ex)
{
    // Domain-level validation errors where a numeric argument is out of the allowed range.
    Console.WriteLine($"[FEL] {ex.Message}");
}
catch (ArgumentException ex)
{
    // General argument validation errors (e.g. empty name, invalid base power, etc.).
    Console.WriteLine($"[FEL] {ex.Message}");
}
catch (OverflowException ex)
{
    // Overflow in arithmetic (e.g. BasePower + Level exceeding int.MaxValue).
    Console.WriteLine($"[FEL] Overflow i beräkning: {ex.Message}");
}
catch (Exception ex)
{
    // Final safety net for any unexpected exception types.
    Console.WriteLine($"[OVÄNTAT FEL] {ex.Message}");
}
