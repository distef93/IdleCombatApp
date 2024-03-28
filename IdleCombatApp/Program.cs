// See https://aka.ms/new-console-template for more information
using IdleCombatApp.CharacterBase;
using IdleCombatApp.Items;

Console.WriteLine("Hello, Gamer!");

//Create Player Character
//TODO create funtionality for getting playter name from console
Player player = new Player(100, 3, 0, 0, "Player");
//Create first enemy
Enemy enemy1 = new Enemy(10, 1, 0, 0, "Enemy", 1000);
Battle battle = new Battle();
player.EquipedHelmet = new Helmet(1, 1000, 0, 0, 0);
player.EquipedBody = new Body(1, 1000, 0, 0, 0);
player.EquipedWeapon = new Weapon(1, 1000, 0, 0, 0);

//initial fight
battle.ShowHitpoints(player, enemy1);
battle.StartBattle(player, enemy1);

//This code will spawn a new monster when the previous one dies until the player dies
var previousEnemy = enemy1;
var currentEnemy = enemy1;
while (player.IsDead == false)
{
    currentEnemy = battle.CreateNextEnemy(previousEnemy);
    battle.ShowHitpoints(player,currentEnemy);
    battle.StartBattle(player, currentEnemy);
    previousEnemy = currentEnemy;
}




