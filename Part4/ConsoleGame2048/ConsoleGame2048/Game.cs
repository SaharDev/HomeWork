using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame2048
{
    public class Game
    {
        private Board board;
        private GameStatus status = GameStatus.Idle;
        private int points = 0;

        public int Points
        {
            get { return this.points; }
            protected set { this.points = value; }
        }

        public Board Board
        {
            get { return this.board;}
            protected set { this.board = value; }
        }

        public GameStatus Status
        {
            get { return this.status; }
            protected set { this.status = value; }
        }

        public Game()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.board = new Board();
        }

        public void Move(Direction direction)
        {
            if (this.status != GameStatus.Idle 
                || direction == Direction.InValidDirection)
                return;

            int res = this.board.Move(direction);

            this.points += res;
            this.UpdateGameStatus();
        }

        private void UpdateGameStatus()
        {
            if (this.board.ReachedGoal)
                this.status = GameStatus.Win;
            else if (this.board.FullBoard)
                this.status = GameStatus.Lose;
        }
    }
}
