﻿// See https://aka.ms/new-console-template for more information
using System;

class DiceSimulator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");

        Console.Write("How many dice rolls would you like to simulate? ");
        int numRolls = Convert.ToInt32(Console.ReadLine());

        DiceRoller diceRoller = new DiceRoller();

        int[] results = diceRoller.SimulateDiceRolls(numRolls);

        PrintHistogram(results, numRolls);

        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    static void PrintHistogram(int[] results, int totalRolls)
    {
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {totalRolls}.");

        for (int i = 2; i <= 12; i++)
        {
            int percentage = results[i] * 100 / totalRolls;
            Console.WriteLine($"{i}: {new string('*', percentage)}");
        }
    }
}

class DiceRoller
{
    public int[] SimulateDiceRolls(int numRolls)
    {
        Random random = new Random();
        int[] results = new int[13];

        for (int i = 0; i < numRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            results[sum]++;
        }

        return results;
    }
}

