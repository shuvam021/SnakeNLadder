using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeNLadder
{
    /// <summary>Snake and Ladder game.</summary>
    internal class Game
    {
        private static int _currentPosition = 0;
        private static int _currentPosition1 = 0;
        private static int _currentPosition2 = 0;
        private static int _finalPosition = 100;
        private const int _optionLadder = 1;
        private const int _optionNoPlay = 0;
        private const int _optionSanke = 2;
        private static bool _flag = false;
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
        private static int Play()
        {
            while(_currentPosition < _finalPosition)
            {
                int rollDice = random.Next(1, 7);
                int option = random.Next(0, 3);
                _currentPosition = UpdatePosition(option, _currentPosition, rollDice);
                if (option == _optionNoPlay || option == _optionSanke) break;
            }
            return _currentPosition;
        }

        private static void ResultDeclaration(int val1, int val2, int counter)
        {
            switch (val1.CompareTo(val2))
            {
                case 1:
                    Console.WriteLine($"Hooray!!! User1 won, after {counter} rounds of play");
                    break;
                case -1:
                    Console.WriteLine("Hooray!!! User2 won, after {counter} rounds of play");
                    break;
                case 0:
                default:
                    Console.WriteLine("Oooooooo, it is draw");
                    break;
            }
        }
        public static void Solution()
        {
            int counter = 0;
            while(true)
            {
                counter++;
                int position = Play();
                if (_flag == true)
                {
                    _currentPosition1 = position;
                    Console.WriteLine($"user1({_currentPosition1}) >> user2");
                }
                else
                {
                    _currentPosition2 = position;
                    Console.WriteLine($"user2({_currentPosition1}) >> user1");
                }
                _flag = _flag ? false : true;
                if (_currentPosition1 == 100 || _currentPosition2 == 100) break;
            }
            ResultDeclaration(_currentPosition1, _currentPosition2, counter);
        }
    }
}