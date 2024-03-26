// See https://aka.ms/new-console-template for more information
using IdleCombatApp.CharacterBase;

Console.WriteLine("Hello, Gamer!");

//Create Player Character
//TODO create funtionality for getting playter name from console
Player player = new Player(10, 3, 0, 0, "Player");
//Create first enemy
Enemy enemy1 = new Enemy(10, 1, 0, 0, "Enemy");
Battle battle = new Battle();

//create new enemy
//provide method for creating incemenentally stronger monsters when previous one is defeated.



battle.StartBattle(player,enemy1);



