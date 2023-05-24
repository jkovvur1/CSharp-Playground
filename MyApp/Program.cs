// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

        // Basic Console

        Console.Title = "SkyNet";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hey! what's your name?");
        String? userName =  Console.ReadLine();
        Console.WriteLine("Hi! " + userName + ", Nice to Meet You");
        Console.ReadKey();


        // Working with Variables

        double num1;
        double num2;

        Console.Write("Input a number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Input a 2nd number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        double result = num1 * num2;
        Console.WriteLine("The Result is " + result);

        Console.ReadKey();

        // Conditions

        Console.WriteLine("Tickets are $5, please insert cash!!");
        int cash = Convert.ToInt32(Console.ReadLine());

        if(cash < 5){
            Console.WriteLine("That is not Enough Money!");

        }
        else if(cash == 5){
            Console.WriteLine("Here is your ticket!");
        }
        else{
            Console.WriteLine("Here is your ticket and the remaining change $" + (cash-5));
        }

        Console.WriteLine("Input a number between 1 & 5");
        int num = Convert.ToInt32(Console.ReadLine());

        switch(num){
            case 1:
                Console.WriteLine("One");
                break;
            case 2:
                Console.WriteLine("Two");
                break;
            case 3:
                Console.WriteLine("Three");
                break;
            case 4:
                Console.WriteLine("Four");
                break;
            case 5:
                Console.WriteLine("Five");
                break;
            default:
                Console.WriteLine("Default");
                break;
        }

        // Loops

        for(int i=0;i<=10;i++){
            double num = Math.Pow(2,i);
            Console.WriteLine(num);
        }

        Random numberGen = new Random();

        int roll1 = 0;
        int roll2 = -1;
        int attempts = 0;

        Console.WriteLine("Press enter to roll the dies");

        while(roll1 != roll2){
            Console.ReadKey();
            roll1 = numberGen.Next(1,7);
            roll2 = numberGen.Next(1,7);
            Console.WriteLine("Roll 1:" + roll1);
            Console.WriteLine("Roll 2:" + roll2);
            attempts++;
        }
        Console.WriteLine("It took you " + attempts + " attempts to roll two of a kind!");

        // Arrays

        string[] kpop ={
        "lisa",
        "rose",
        "jenny",
        "jisoo"
        };

        for(int i=0;i<kpop.Length;i++){
            Console.WriteLine(kpop[i]);
        }


        string?[] movies = new string[4];

        Console.WriteLine("Enter 4 movies:");

        for(int i=0;i<movies.Length;i++){
            movies[i] = Console.ReadLine();
        }

        Console.WriteLine("Sorted Movies: \n");

        Array.Sort(movies);

        for(int i=0;i<movies.Length;i++){
           Console.WriteLine(movies[i]);
        }

        // Lists

        List<string> shoppingList = new List<string>();

        shoppingList.Add("Coke");
        shoppingList.Add("Chicken");
        shoppingList.Add("Salad");
        shoppingList.Add("Chocolates");


        for(int i=0;i<shoppingList.Count;i++){
            Console.WriteLine(shoppingList[i]);
        }

        Console.WriteLine("---------");
        shoppingList.Remove("Chocolates");

        for(int i=0;i<shoppingList.Count;i++){
            Console.WriteLine(shoppingList[i]);
        }

        // Methods

        void MeetAlien(){
            Random numberGen = new Random();
            string name = "x-" + numberGen.Next(10, 9999);
            int age = numberGen.Next(10, 500);

            Console.WriteLine("Hi!, I'm "+ name);
            Console.WriteLine("My Age is " + age);
        }

        MeetAlien();
        Console.WriteLine("---------");
        MeetAlien();

        int Square(int num){
            int result = num * num;
            return result;
        }

        Console.WriteLine(Square(5));
        Console.WriteLine("---------");
        Console.WriteLine(Square(6));


        // Classes

        Cat cat1 = new Cat("Lisa", 6);

        cat1.Meow();
        
        }
    }
}

class Cat{
    public string name;
    public int age;

    public Cat(string _name, int _age){
        name = _name;
        age = _age;
    }
    public void Meow(){
        Console.WriteLine(name + " says Meow!");
    }
}