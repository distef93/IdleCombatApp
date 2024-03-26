using IdleCombatApp.CharacterBase;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace IdleCombatApp.CharacterBase
{
    public interface IStats
    {
        int MaxHitpoints { get; set; }
        int CurrentHitpoints { get; set; }
        int Power { get; set; }
        int Armor { get; set; }
        int Regen { get; set; }
        string Name { get; set; }
        bool IsDead { get; set; }
    }
    public class Base : IStats
    {
        public int MaxHitpoints { get; set; }
        public int CurrentHitpoints { get; set; }
        public int Power { get; set; }
        public int Armor { get; set; }
        public int Regen { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public void Attack(Base attacker, Base reciever)
        {
            var damage = attacker.Power - reciever.Armor;
            if (damage > 0)
            {
                reciever.CurrentHitpoints -= damage;
                Console.WriteLine($"{attacker.Name} hit {reciever.Name} for {damage} damage");
                
            }
            if (reciever.CurrentHitpoints <= 0)
            {
                reciever.IsDead = true;
                Console.WriteLine($"{reciever.Name} is dead!");
            }
        }
    }
    public class Player : Base
    {
        public Player(int MaxHitpoints, int Power, int Armor, int Regen, string Name)
        {
            this.MaxHitpoints = MaxHitpoints;
            this.CurrentHitpoints = MaxHitpoints;
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
    public Enemy(int MaxHitpoints, int Power, int Armor, int Regen, string Name)
    {
        this.MaxHitpoints = MaxHitpoints;
        this.CurrentHitpoints = MaxHitpoints;
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
        Console.WriteLine("Player Hp: " + player.CurrentHitpoints);
        Console.WriteLine("Enemy Hp: " + enemy.CurrentHitpoints);

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
            while (player.CurrentHitpoints > 0 && enemy.CurrentHitpoints > 0)
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
    
    //method for creating a monster
    public Enemy CreateNextEnemy(Enemy previousEnemy)
    {
        int increment = 2;
        Enemy enemy = new Enemy((previousEnemy.MaxHitpoints * increment), (previousEnemy.Power * increment), (previousEnemy.Armor * increment), (previousEnemy.Regen * increment),(previousEnemy.Name + "Next"));
        return enemy;
    }
}
