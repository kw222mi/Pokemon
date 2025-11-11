using Pokemon.Domain;






try
{
    var pokemon = new PokemonCreature("Bulbasaur", 1);
    pokemon.PrintInfo();

    pokemon.UseSimpleAttack("Tackle", 5);
    //pokemon.UseSimpleAttack("Tackle", 0);
    //pokemon.UseSimpleAttack("Tackle", -3);
    //pokemon.UseSimpleAttack("", 5);
    pokemon.UseSimpleAttack(" Leafage ", 11);
}
catch (ArgumentException ex)
{
    // Fångar valideringsfel (t.ex. attackName/basePower)
    Console.WriteLine($"[FEL] {ex.Message}");
}
catch (Exception ex)
{
    // Fångar *oväntade* fel (t.ex. null-referenser eller skrivfel)
    Console.WriteLine($"[OVÄNTAT FEL] {ex.Message}");
}
finally
{
    // (valfritt) kod som alltid körs, t.ex. “Programmet avslutas.”
}
