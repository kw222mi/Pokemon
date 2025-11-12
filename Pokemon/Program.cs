using Pokemon.Domain;
using System;


try
{
    var bulbasaur = new PokemonCreature("Bulbasaur", 1, ElementType.Grass);
    bulbasaur.PrintInfo(); // => "Bulbasaur (Grass, Level 1)"


    var vineWhip = new Attack("Vine Whip", ElementType.Grass, 7);
    var leafage = new Attack("Leafage", ElementType.Grass, 11);

    bulbasaur.AddAttack(vineWhip);
    bulbasaur.AddAttack(leafage);

    bulbasaur.ListAttacks();

    bulbasaur.UseAttackAt(0);


    //bulbasaur.UseAttack(vineWhip); // "Bulbasaur använder Vine Whip – Skada: 8 (7+1)"
    //bulbasaur.UseAttack(leafage);  // "Bulbasaur använder Leafage – Skada: 12 (11+1)

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




        
