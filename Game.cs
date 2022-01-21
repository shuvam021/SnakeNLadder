using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeNLadder
{
    /// <summary>Snake and Ladder game.</summary>
    internal class Game
    {
        private static int _currentPosition = 0;
        private static int _finalPosition = 100;
        private const int _optionNoPlay = 0;
        private const int _optionLadder = 1;
        private const int _optionSanke = 2;
        private static Random random = new Random();

        /// <summary>Updates the current position based on option.</summary>
        /// <param name="option">snake(2)/ladder(1)/no_paly(0)</param>
        /// <param name="position">Current position</param>
        /// <param name="roll">expected values are 1-6</param>
        private static int UpdatePosition(int option, int position, int roll)
        {
            switch (option)
            {
                case _optionLadder:
                    if (position + roll > 100) position += 0;
                    else position += roll;
                    break;
                case _optionSanke:
                    if (position - roll < 0) position = 0;
                    else position -= roll;
                    break;
            }
            return position;
        }
        /// <summary>Use this Game class with only this method.</summary>
        public static void Play()
        {
            while(_currentPosition < _finalPosition)
            {
                int rollDice = random.Next(1, 7);
                int option = random.Next(0, 3);
                _currentPosition = UpdatePosition(option, _currentPosition, rollDice);
                Console.WriteLine($"You got: {option}/{rollDice} and Position is at: {_currentPosition}");
            }
            Console.WriteLine("Hooray!!!");
        }
    }
}