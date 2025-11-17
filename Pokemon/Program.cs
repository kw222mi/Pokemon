using System;
using System.Collections.Generic;
using Pokemon.Domain;
using Pokemon.Domain.Species;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Pokémon trainer simulation start ===");

                // 1) Create a small party with different Pokémon.
                // Charmander and Squirtle can evolve, Bulbasaur stays as it is.
                var party = new List<PokemonCreature>
                {
                    new Charmander(9), // just below evolution threshold
                    new Squirtle(9),
                    new Bulbasaur(5)
                };

                // 2) Initial status: info + Speak() + attacks
                Console.WriteLine("\n-- Initial party status --");
                foreach (var mon in party)
                {
                    mon.PrintInfo();
                    mon.Speak();
                    mon.ListAttacks();
                    Console.WriteLine();
                }

                // 3) Trainer levels all Pokémon once.
                // RaiseLevel may return a new evolved Pokémon, so we must store the result.
                Console.WriteLine("\n-- Trainer levels all Pokémon --");
                for (int i = 0; i < party.Count; i++)
                {
                    var current = party[i];

                    Console.WriteLine($"\n[LEVEL UP] Processing {current.Name} ...");
                    // New RaiseLevel-version returns the (possibly evolved) Pokémon
                    var updated = current.RaiseLevel(1);

                    if (!ReferenceEquals(current, updated))
                    {
                        // Evolution has occurred – replace in the party list.
                        Console.WriteLine($"[EVOLUTION] {current.Name} has evolved into {updated.Name}!");
                    }

                    party[i] = updated;
                }

                // 4) After leveling: show new status (Speak + attacks)
                Console.WriteLine("\n-- Party after leveling (and possible evolutions) --");
                foreach (var mon in party)
                {
                    mon.PrintInfo();
                    mon.Speak();
                    mon.ListAttacks();
                    Console.WriteLine();
                }

                // 5) Demonstrate attacks: normal + legendary where available
                Console.WriteLine("\n-- Battle demo: attacks --");
                foreach (var mon in party)
                {
                    Console.WriteLine($"\n{mon.Name} attacks!");

                    // Always try first attack (index 0)
                    try
                    {
                        mon.UseAttackAt(0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ERROR] Could not use attack 0 for {mon.Name}: {ex.Message}");
                    }

                    // Try a possible legendary attack at index 2 (if it exists)
                    try
                    {
                        mon.UseAttackAt(2); // Charmeleon / Wartortle should have a legendary move here
                    }
                    catch
                    {
                        // It's fine if not all Pokémon have a third attack.
                    }
                }

                Console.WriteLine("\n=== Pokémon trainer simulation end ===");
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
        }
    }
}
