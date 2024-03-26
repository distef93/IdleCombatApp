// See https://aka.ms/new-console-template for more information
using IdleCombatApp.CharacterBase;

Console.WriteLine("Hello, Gamer!");

//Create Player Character
//TODO create funtionality for getting playter name from console
Player player = new Player(100, 3, 0, 0, "Player");
//Create first enemy
Enemy enemy1 = new Enemy(10, 1, 0, 0, "Enemy");
Battle battle = new Battle();

//initial fight
battle.ShowHitpoints(player, enemy1);
battle.StartBattle(player, enemy1);

//create new enemy
var previousEnemy = enemy1;
var currentEnemy = enemy1;
while (player.IsDead == false)
{
    currentEnemy = battle.CreateNextEnemy(previousEnemy);
    battle.ShowHitpoints(player,currentEnemy);
    battle.StartBattle(player, currentEnemy);
    previousEnemy = currentEnemy;

}




