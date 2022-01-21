using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeNLadder
{
    /// <summary>Snake and Ladder game.</summary>
    internal class Game
    {
        private static int _currentPosition = 0;
        private static Random random = new Random();
        /// <summary>Use this Game class with only this method.</summary>
        public static void Play()
        {
            int rollDice = random.Next(1, 7);
            Console.WriteLine($"You are at: {_currentPosition}");
            Console.WriteLine($"You got: {rollDice}");
        }
    }
}
