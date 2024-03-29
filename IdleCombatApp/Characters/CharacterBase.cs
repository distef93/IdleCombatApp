using IdleCombatApp.CharacterBase;
using IdleCombatApp.Items;
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
        public int BaseMaxHitpoints {  get; set; }
        public int MaxHitpoints { get; set; }
        public int CurrentHitpoints { get; set; }
        public int BasePower {  get; set; }
        public int Power { get; set; }
        public int BaseArmor {  get; set; }
        public int Armor { get; set; }
        public int BaseRegen {  get; set; }
        public int Regen { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public Helmet? EquipedHelmet { get; set; }
        public Body? EquipedBody { get; set; }
        public Weapon? EquipedWeapon { get; set; }
    }
    public class Player : Base
    {
        public int experience { get; set; }
        public List<ItemBase> Items { get; set; }
        public Player(int BaseMaxHitpoints, int BasePower, int BaseArmor, int BaseRegen, string Name)
        {
            this.BaseMaxHitpoints = BaseMaxHitpoints;
            this.CurrentHitpoints = BaseMaxHitpoints;
            this.BasePower = BasePower;
            this.Power = BasePower;
            this.BaseArmor = BaseArmor;
            this.Armor = BaseArmor;
            this.BaseRegen = BaseRegen;
            this.Regen = BaseRegen;
            this.Name = Name;
            this.IsDead = false;
            this.experience = 0;
        }
        public void Attack(Enemy enemy)
        {
            var damage = Power - enemy.Armor;
            if(damage > 0)
            {
                enemy.CurrentHitpoints -= damage;
                Console.WriteLine($"{Name} hit {enemy.Name} for {damage} damage");
            }
            if (enemy.CurrentHitpoints <= 0)
            {
                enemy.IsDead = true;
                Console.WriteLine($"{enemy.Name} is dead!");
            }
        }
    }
}
public class Enemy : Base
{
    public int Level { get; set; }
    public Enemy(int MaxHitpoints, int Power, int Armor, int Regen, string Name, int Level)
    {
        this.MaxHitpoints = MaxHitpoints;
        this.CurrentHitpoints = MaxHitpoints;
        this.Power = Power;
        this.Armor = Armor;
        this.Regen = Regen;
        this.Name = Name;
        this.IsDead = false;
        this.Level = Level;
    }

    public void Attack(Player player)
    {
        var damage = Power - player.Armor;
        if (damage > 0)
        {
            player.CurrentHitpoints -= damage;
            Console.WriteLine($"{Name} hit {player.Name} for {damage} damage");
        }
        if (player.CurrentHitpoints <= 0)
        {
            player.IsDead = true;
            Console.WriteLine($"{player.Name} is dead!");
        }
    }
}

public class Battle : Base
{
    //show hitpoints and assign item stats to player
    public void ShowHitpoints(Player player, Enemy enemy)
    {
        Console.WriteLine($"{player.Name} Hp: {player.CurrentHitpoints}");
        Console.WriteLine($"{enemy.Name} Hp: {enemy.CurrentHitpoints}");

    }

    public void StartBattle(Player player, Enemy enemy)
    {
        CheckItems(player);
        Console.WriteLine("What would you like to do? Press 1 to attack, 2 to run");
        var s = Console.ReadLine();
        if (s != "1")
        {
            StartBattle(player, enemy);
        }
        else
        {
            while(!enemy.IsDead && !player.IsDead) 
            {
                ShowHitpoints(player, enemy);
                player.Attack(enemy);
                if(!enemy.IsDead)
                {
                    ShowHitpoints(player, enemy);
                    enemy.Attack(player);
                }
                else
                {
                    player.experience += 1;
                    if(player.experience == 2)
                    {
                        LevelUp(player);
                    }
                }
            }
        }
    }
    
    //method for creating a monster
    public Enemy CreateNextEnemy(Enemy previousEnemy)
    {
        int increment = 2;
        Enemy enemy = new Enemy((previousEnemy.MaxHitpoints * increment), (previousEnemy.Power * increment), (previousEnemy.Armor * increment), (previousEnemy.Regen * increment),(previousEnemy.Name + "Next"),(previousEnemy.Level + 1));
        return enemy;
    }

    public void CheckItems(Player player)
    {
        var totalHitpoonts = player.EquipedHelmet.Hitpoints + player.EquipedBody.Hitpoints + player.EquipedWeapon.Hitpoints;
        var totalArmor = player.EquipedWeapon.Armor + player.EquipedBody.Armor + player.EquipedWeapon.Armor;
        var totalPower = player.EquipedHelmet.Power + player.EquipedBody.Power + player.EquipedWeapon.Power;
        var totalRegen = player.EquipedHelmet.Regen + player.EquipedBody.Regen + player.EquipedWeapon.Regen;

        player.MaxHitpoints = player.BaseMaxHitpoints + totalHitpoonts;
        player.Armor = player.BaseArmor + totalArmor;
        player.Power = player.BasePower + totalPower;
        player.Regen = player.Regen + totalRegen;

        player.CurrentHitpoints = player.MaxHitpoints;
    }

    public void LevelUp(Player player)
    {
        player.experience = 0;
        player.BasePower *= 2;
        player.BaseMaxHitpoints *= 2;
        player.CurrentHitpoints = player.BaseMaxHitpoints;
        Console.WriteLine($"{player.Name} has leveled up!");
        CheckItems(player);
    }
}
