using System;
using System.Threading;

namespace ConsoleGame2048
{
    internal class GameConsole
    {
        protected Game game;
        private readonly int TARGET_LENGHT = (int)Math.Log10(Board.TARGET) + 1;

        public GameConsole()
        {
            this.Initialize();
            this.Start();
            Console.ReadKey(true);
            // Waiting for key press before closing the game.
        }

        public void Initialize()
        {
            this.game = new Game();
        }

        private void Start()
        {
            while (this.game.Status == GameStatus.Idle)
            {
                this.Periodic();
            }


            // Drammatic Ending...
            this.Render(); // Last Render to Realize was happend...
            Thread.Sleep(2000);

            // Ending of the game
            switch (this.game.Status)
            {
                case GameStatus.Lose:
                    this.LoseEnding();
                    return;
                case GameStatus.Win:
                    this.WinEnding();
                    return;
            }
        }

        private void Periodic()
        {
            this.Render();
            this.Input();
        }

        private void Input()
        {
            ConsoleKey key;
            Direction direction;

            do
            {
                Console.WriteLine("Waiting for input!");
                key = Console.ReadKey(true).Key;
                direction = this.DirectionValidation((Direction)key);

            } while (direction == Direction.InValidDirection);

            Console.WriteLine("Key was inputed: " + (Direction)direction);

            this.game.Move(direction);
        }

        private void Render()
        {
            Console.Clear();
            string numString;

            for (int i = 0; i < this.game.Board.Data.GetLength(0); i++)
            {
                this.PrintBorderLine();
                Console.Write("|");

                for (int j = 0; j < this.game.Board.Data.GetLength(1); j++)
                {
                    numString = this.NumToBlockLenghtString(this.game.Board.Data[i, j], this.TARGET_LENGHT);
                    Console.Write(numString + "|");
                }
                Console.WriteLine();
            }
            this.PrintBorderLine();
            Console.WriteLine($"\nPoints: {this.game.Points}");
        }

        /// <summary>
        /// Converts an int into a length specified string with spaces 
        /// equally speaded around it.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="length"></param>
        /// <retrun>String of the number with spaces to achive the length.</retrun>
        private string NumToBlockLenghtString(int num, int length)
        {
            string currentBlockString = num != 0 ? num.ToString() : "";
            // If the number is equal to 0,
            // It will generate an empty string in that length.
            bool leftOrRight = false; // helping variable for changing the space placement.

            while (currentBlockString.Length < length)
            {
                if (leftOrRight)
                    currentBlockString += " ";
                else
                    currentBlockString = " " + currentBlockString;
                leftOrRight = !leftOrRight;
            }

            return currentBlockString;
        }

        private void PrintBorderLine()
        {
            Console.Write("+");
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < this.TARGET_LENGHT; j++)
                    Console.Write("-");
                Console.Write("+");
            }
            Console.WriteLine();
        }

        private void LoseEnding()
        {
            Console.Clear();
            string text = " _        _______  _______  _______  _______          \r\n( \\      (  ___  )(  ____ \\(  ____ \\(  ____ )         \r\n| (      | (   ) || (    \\/| (    \\/| (    )|         \r\n| |      | |   | || (_____ | (__    | (____)|         \r\n| |      | |   | |(_____  )|  __)   |     __)         \r\n| |      | |   | |      ) || (      | (\\ (            \r\n| (____/\\| (___) |/\\____) || (____/\\| ) \\ \\__ _  _  _ \r\n(_______/(_______)\\_______)(_______/|/   \\__/(_)(_)(_)\r\n                                                      \n";
            int[,] sound =
                new int[,] { { 800, 300 }, { 600, 400},
                { 400, 500}, { 200, 600} };
            Console.WriteLine("You lost... Maybe next time!");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(text.Substring(i * text.Length / 4, text.Length / 4));
                Console.Beep(sound[i, 0], sound[i, 1]);
            }
        }

        private void WinEnding()
        {
            Console.Clear();
            string text = "         _________ _        _        _______  _______                                                                     \r\n|\\     /|\\__   __/( (    /|( (    /|(  ____ \\(  ____ )                                                                    \r\n| )   ( |   ) (   |  \\  ( ||  \\  ( || (    \\/| (    )|                                                                    \r\n| | _ | |   | |   |   \\ | ||   \\ | || (__    | (____)|                                                                    \r\n| |( )| |   | |   | (\\ \\) || (\\ \\) ||  __)   |     __)                                                                    \r\n| || || |   | |   | | \\   || | \\   || (      | (\\ (                                                                       \r\n| () () |___) (___| )  \\  || )  \\  || (____/\\| ) \\ \\__                                                                    \r\n(_______)\\_______/|/    )_)|/    )_)(_______/|/   \\__/                                                                    \r\n                                                                                                                          \r\n         _________ _        _        _______  _______                                                                     \r\n|\\     /|\\__   __/( (    /|( (    /|(  ____ \\(  ____ )                                                                    \r\n| )   ( |   ) (   |  \\  ( ||  \\  ( || (    \\/| (    )|                                                                    \r\n| | _ | |   | |   |   \\ | ||   \\ | || (__    | (____)|                                                                    \r\n| |( )| |   | |   | (\\ \\) || (\\ \\) ||  __)   |     __)                                                                    \r\n| || || |   | |   | | \\   || | \\   || (      | (\\ (                                                                       \r\n| () () |___) (___| )  \\  || )  \\  || (____/\\| ) \\ \\__                                                                    \r\n(_______)\\_______/|/    )_)|/    )_)(_______/|/   \\__/                                                                    \r\n                                                                                                                          \r\n _______          _________ _______  _        _______  _          ______  _________ _        _        _______  _______  _ \r\n(  ____ \\|\\     /|\\__   __/(  ____ \\| \\    /\\(  ____ \\( (    /|  (  __  \\ \\__   __/( (    /|( (    /|(  ____ \\(  ____ )( )\r\n| (    \\/| )   ( |   ) (   | (    \\/|  \\  / /| (    \\/|  \\  ( |  | (  \\  )   ) (   |  \\  ( ||  \\  ( || (    \\/| (    )|| |\r\n| |      | (___) |   | |   | |      |  (_/ / | (__    |   \\ | |  | |   ) |   | |   |   \\ | ||   \\ | || (__    | (____)|| |\r\n| |      |  ___  |   | |   | |      |   _ (  |  __)   | (\\ \\) |  | |   | |   | |   | (\\ \\) || (\\ \\) ||  __)   |     __)| |\r\n| |      | (   ) |   | |   | |      |  ( \\ \\ | (      | | \\   |  | |   ) |   | |   | | \\   || | \\   || (      | (\\ (   (_)\r\n| (____/\\| )   ( |___) (___| (____/\\|  /  \\ \\| (____/\\| )  \\  |  | (__/  )___) (___| )  \\  || )  \\  || (____/\\| ) \\ \\__ _ \r\n(_______/|/     \\|\\_______/(_______/|_/    \\/(_______/|/    )_)  (______/ \\_______/|/    )_)|/    )_)(_______/|/   \\__/(_)\r\n                                                                                                                          ";
            int[,] sound =
                new int[,] { { 523, 200 }, { 587, 200 },
                         { 659, 200 }, { 784, 200 }, { 1046, 400 } };
            Console.WriteLine($"Congratulations! You've won! With {this.game.Points} points!");
            for (int i = 0; i < sound.GetLength(0); i++)
            {
                Console.Write(text.Substring(i * text.Length / sound.GetLength(0), text.Length / sound.GetLength(0)));
                Console.Beep(sound[i, 0], sound[i, 1]);
            }
        }

        /// <summary>
        /// Validates that the key casted correctly into the enum Direction.
        /// </summary>
        /// <param name="direction">Pre-validated Diretion enum.</param>
        /// <returns>The fully corrent Direction enum.</returns>
        private Direction DirectionValidation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Up;
                case Direction.Down:
                    return Direction.Down;
                case Direction.Left:
                    return Direction.Left;
                case Direction.Right:
                    return Direction.Right;
                default:
                    return Direction.InValidDirection;
            }
        }
    }
}
