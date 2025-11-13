namespace Pokemon.Domain.Species
{
    internal class Charmeleon : FirePokemon
    {


        public Charmeleon() : base("Charmeleon", 1)
        {

            var fireKick = new Attack("Fire Kick", ElementType.Fire, 15);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 10);


            AddAttack(fireKick);

            AddAttack(flameBurst);
        }

        public Charmeleon(int level) : base("Charmeleon", level)
        {

            var fireKick = new Attack("Fire Kick", ElementType.Fire, 15);
            var flameBurst = new Attack("Flame Burst", ElementType.Fire, 10);


            AddAttack(fireKick);

            AddAttack(flameBurst);
        }

    }
}