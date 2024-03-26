using IdleCombatApp.CharacterBase;

namespace IdleCombatApp.CharacterBase
{
    public interface IStats
    {
        int Hitpoints { get; set; }
        int Power { get; set; }
        int Armor { get; set; }
        int Regen { get; set; }
        string? Name { get; set; }
        bool IsDead { get; set; }
    }
    public class Base : IStats
    {
        public int Hitpoints { get; set; }
        public int Power { get; set; }
        public int Armor { get; set; }
        public int Regen { get; set; }
        public string? Name { get; set; }
        public bool IsDead { get; set; }
        public void Attack(Base attacker, Base reciever)
        {
            var damage = attacker.Power - reciever.Armor;
            if (damage > 0)
            {
                reciever.Hitpoints -= damage;
                Console.WriteLine($"{attacker.Name} hit {reciever.Name} for {damage} damage");
                
            }
            if (reciever.Hitpoints <= 0)
            {
                reciever.IsDead = true;
                Console.WriteLine($"{reciever.Name} is dead!");
            }
        }
    }
    public class Player : Base
    {
        public Player(int hp, int Power, int Armor, int Regen, string Name)
        {
            this.Hitpoints = hp;
            this.Power = Power;
            this.Armor = Armor;
            this.Regen = Regen;
            this.Name = Name;
            this.IsDead = false;
        }
        public string caracterName = "";

    }
}
public class Enemy : Base
{
    public Enemy(int hp, int Power, int Armor, int Regen, string Name)
    {
        this.Hitpoints = hp;
        this.Power = Power;
        this.Armor = Armor;
        this.Regen = Regen;
        this.Name = Name;
        this.IsDead = false;
    }
    public List<String>? items;
}

public class Battle : Base
{
    public void ShowHitpoints(Player player, Enemy enemy)
    {
        Console.WriteLine("Player Hp: " + player.Hitpoints);
        Console.WriteLine("Enemy Hp: " + enemy.Hitpoints);

    }
    public void StartBattle(Player player, Enemy enemy)
    {
        ShowHitpoints(player, enemy);
        Console.WriteLine("What would you like to do? Press 1 to attack, 2 to run");
        var s = Console.ReadLine();
        if (s != "1")
        {
            StartBattle(player, enemy);
        }
        else
        {
            while (player.Hitpoints > 0 && enemy.Hitpoints > 0)
            {
                ShowHitpoints(player, enemy);
                Attack(player, enemy);
                if (enemy.IsDead)
                {
                    continue;
                }
                else
                {
                    ShowHitpoints(player, enemy);
                    Attack(enemy, player);
                }
            }
        }
    }
}
