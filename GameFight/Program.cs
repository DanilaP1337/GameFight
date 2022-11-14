using System;
using GameFight.Fighters;

namespace GameFight;

class Program
{
    static void Main(string[] args)
    {
        PrintMenu();
    }
    // меню
    static void PrintMenu()
    {
        // метод создает главное меню
        Console.Clear(); 
        Console.WriteLine("БОЙЦОВСКИЙ КЛУБ\n");
        Console.WriteLine("1 - Начать игру");
        Console.WriteLine("2 - Правила");
        Console.WriteLine("3 - Выйти из игры");
        string option = Console.ReadLine();

        if (option == "1")
        {
            Game game = new Game();
            game.StartGame();
        }
        if(option == "2")
            PrintRules();

        if(option == "3")
            Environment.Exit(0); // условие, при котором бексонечный цикл будет завершаться

        PrintMenu();    // рекурсия 
    }
        
    static void PrintRules() // метод выводит правила игры
    {
        Console.Clear();
        Console.WriteLine("Правила игры");
        Console.WriteLine(new Warrior());
        Console.WriteLine(new Dodger());
        Console.WriteLine(new Mage());
        Console.ReadLine();
    }
}