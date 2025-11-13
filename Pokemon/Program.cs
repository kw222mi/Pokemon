using Pokemon.Domain;
using Pokemon.Domain.Species;
using System;


try
{
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




        
