using Pokemon.Domain;


try
{
    // A2 – giltig skapelse + utskrift
    var bulbasaur = new PokemonCreature("Bulbasaur", 1);
    bulbasaur.PrintInfo();

    // A3 – gröna testfall (ska fungera)
    bulbasaur.UseSimpleAttack("Tackle", 5);
    bulbasaur.UseSimpleAttack("Vine Whip", 7);
    bulbasaur.UseSimpleAttack("  Leafage  ", 11); // visar trim
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

// Röda testfall – visar felhantering (ska INTE krascha programmet)
try
{
    var badName = new PokemonCreature(" ", 1); // Namn saknas
}
catch (Exception ex)
{
    Console.WriteLine($"[FEL vid skapande] {ex.Message}");
}

try
{
    var p = new PokemonCreature("Pi", 3);
    p.UseSimpleAttack("", 5); // Ogiltigt attacknamn
}
catch (Exception ex)
{
    Console.WriteLine($"[FEL vid attack] {ex.Message}");
}

try
{
    var p = new PokemonCreature("Eevee", 2);
    p.UseSimpleAttack("Quick Attack", 0); // basePower ≤ 0
}
catch (Exception ex)
{
    Console.WriteLine($"[FEL vid attack] {ex.Message}");
}

Console.WriteLine("Programmet avslutas.");
        
