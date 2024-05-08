using System;
using System.Collections.Generic;
using System.Drawing;

public class Board
{
    private int[,] data = new int[4, 4];
    private Random rnd = new Random();

    private const int BASE_BLOCK = 2; 
    public static readonly int TARGET = (int)Math.Pow(BASE_BLOCK, 11); // 11
    
    private bool reachedTarget = false;
    private bool gameOver = false;

    public int[,] Data { get => data; protected set => data = value; }
    public bool ReachedGoal { get => reachedTarget; protected set => reachedTarget = value; }
    public bool FullBoard { get => gameOver; protected set => gameOver = value; }

    public Board()
    {
        this.data.Initialize();
        this.Initialize();
    }

    public void Initialize()
    {
        Random rnd = new Random();
        this.PlaceBlocks(2);
    }

    /// <summary>
    /// Moving all the blocks to the specified direction.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns>Points gained.</returns>
    public int Move(Direction direction)
    {

        int points = 0;
        switch (direction)
        {
            case Direction.Left:
                points += this.MoveLeft();
                break;
            case Direction.Right:
                points += this.MoveRight();
                break;
            case Direction.Up:
                points += this.MoveUp();
                break;
            case Direction.Down:
                points += this.MoveDown();
                break;
        }

        this.PlaceBlocks(1);

        if (!this.CanMove()) 
            this.gameOver = true;
        return points;
    }

    private void GoalReachedUpdate(int pointsAdded)
    {
        if (pointsAdded == TARGET)
            this.reachedTarget = true;
    }

    /// <summary>
    /// Moving the blocks to the left direction.
    /// If checkMode is true, no block is actually moving, 
    /// it only checks if blocks can move.
    /// </summary>
    /// <param name="checkMode"></param>
    /// <returns>Points gained, if check mode: -1 is Can Move, -2 Can't Move</returns>
    private int MoveLeft(bool checkMode = false)
    {
        int help, movingNum, limit;
        int points = 0; // Points counter

        for (int i = 0; i < this.data.GetLength(0); i++)
        {
            limit = 0;
            for (int j = 0; j < this.data.GetLength(1); j++)
            {
                help = j;

                if (this.data[i, help] == 0)
                    continue;

                movingNum = this.data[i, help];

                while (help > limit)
                {
                    if (this.data[i, help - 1] == movingNum)
                    {
                        if (checkMode)
                            return -1;
                        this.data[i, help - 1] = movingNum * 2;
                        this.GoalReachedUpdate(movingNum * 2);

                        this.data[i, help] = 0;
                        points += this.data[i, help - 1];
                        limit = help;
                        help = -1; // Breaks the loop
                    }
                    else if (this.data[i, help - 1] == 0)
                    {
                        if (checkMode)
                            return -1;
                        this.data[i, help - 1] = movingNum;
                        this.data[i, help] = 0;
                        help--;
                    }
                    else
                    {
                        limit = help;
                        help = -1;
                    }
                }

            }
        }
        if (checkMode)
            return -2;

        return points;
    }

    /// <summary>
    /// Moving the blocks to the right direction.
    /// If checkMode is true, no block is actually moving, 
    /// it only checks if blocks can move.
    /// </summary>
    /// <param name="checkMode"></param>
    /// <returns>Points gained, if check mode: -1 is Can Move, -2 Can't Move</returns>
    private int MoveRight(bool checkMode = false)
    {
        int help, movingNum, limit;
        int points = 0; // Points counter

        for (int i = 0; i < this.data.GetLength(0); i++)
        {
            limit = this.data.GetLength(1) - 1;
            for (int j = this.data.GetLength(1) - 1; j >= 0; j--)
            {
                help = j;

                if (this.data[i, help] == 0)
                    continue;

                movingNum = this.data[i, help];

                while (help < limit)
                {
                    if (this.data[i, help + 1] == movingNum)
                    {
                        if (checkMode)
                            return -1;

                        this.data[i, help + 1] = movingNum * 2;
                        this.GoalReachedUpdate(movingNum * 2);

                        this.data[i, help] = 0;
                        points += this.data[i, help + 1];
                        limit = help;
                        // Stops the help pointer from reaching allready done points.
                        help = 5; // Breaks the loop
                    }
                    else if (this.data[i, help + 1] == 0)
                    {
                        if (checkMode)
                            return -1;

                        this.data[i, help + 1] = movingNum;
                        this.data[i, help] = 0;
                        help++;
                    }
                    else
                    {
                        limit = help;
                        // Stops the help pointer from reaching allready done points.
                        help = 5; // break the loop
                    }

                }

            }
        }

        if (checkMode)
            return -2;

        return points;
    }

    /// <summary>
    /// Moving the blocks to the up direction.
    /// If checkMode is true, no block is actually moving, 
    /// it only checks if blocks can move.
    /// </summary>
    /// <param name="checkMode"></param>
    /// <returns>Points gained, if check mode: -1 is Can Move, -2 Can't Move</returns>
    private int MoveUp(bool checkMode = false)
    {
        int help, movingNum, limit;
        int points = 0; // Points counter

        for (int i = 0; i < this.data.GetLength(1); i++)
        {
            limit = 0;
            for (int j = 0; j < this.data.GetLength(0); j++)
            {
                help = j;

                if (this.data[help, i] == 0)
                    continue;

                movingNum = this.data[help, i];

                while (help > limit)
                {
                    if (this.data[help - 1, i] == movingNum)
                    {
                        if (checkMode)
                            return -1;

                        this.data[help - 1, i] = movingNum * 2;
                        this.GoalReachedUpdate(movingNum * 2);

                        this.data[help, i] = 0;
                        points += this.data[help - 1, i];
                        limit = help;
                        help = -1; // Breaks the loop
                    }
                    else if (this.data[help - 1, i] == 0)
                    {
                        if (checkMode)
                            return -1;

                        this.data[help - 1, i] = movingNum;
                        this.data[help, i] = 0;
                        help--;
                    }
                    else
                    {
                        limit = help;
                        help = -1;
                    }
                }

            }
        }

        if (checkMode)
            return -2;

        return points;
    }

    /// <summary>
    /// Moving the blocks to the down direction.
    /// If checkMode is true, no block is actually moving, 
    /// it only checks if blocks can move.
    /// </summary>
    /// <param name="checkMode"></param>
    /// <returns>Points gained, if check mode: -1 is Can Move, -2 Can't Move</returns>
    private int MoveDown(bool checkMode = false)
    {
        int help, movingNum, limit;
        int points = 0; // Points counter

        for (int i = 0; i < this.data.GetLength(1); i++)
        {
            limit = this.data.GetLength(0) - 1;
            for (int j = this.data.GetLength(0) - 1; j >= 0; j--)
            {
                help = j;

                if (this.data[help, i] == 0)
                    continue;

                movingNum = this.data[help, i];

                while (help < limit)
                {
                    if (this.data[help + 1, i] == movingNum)
                    {
                        if (checkMode)
                            return -1;

                        this.data[help + 1, i] = movingNum * 2;
                        this.GoalReachedUpdate(movingNum * 2);

                        this.data[help, i] = 0;
                        points += this.data[help + 1, i];
                        limit = help;
                        // Stops the help pointer from reaching allready done points.
                        help = 5; // Breaks the loop
                    }
                    else if (this.data[help + 1, i] == 0)
                    {
                        if (checkMode)
                            return -1;

                        this.data[help + 1, i] = movingNum;
                        this.data[help, i] = 0;
                        help++;
                    }
                    else
                    {
                        limit = help;
                        // Stops the help pointer from reaching allready done points.
                        help = 5; // break the loop
                    }

                }

            }
        }

        if (checkMode)
            return -2;

        return points;
    }

    private List<Point> AvailableBlocks()
    {
        List<Point> available = new List<Point>();
        // list of available (x, y)'s 

        for (int i = 0; i < this.data.GetLength(0); i++)
        {
            for (int j = 0; j < this.data.GetLength(1); j++)
            {
                if (this.data[i, j] == 0)
                {
                    available.Add(new Point(i, j));
                }
            }
        }
        return available;
    }

    /// <summary>
    /// Checks if in a full board, there is a way to move. 
    /// This function ment to check is the game is over.
    /// </summary>
    /// <returns>If there is a way to move in the board.</returns>
    private bool CanMove()
    {
        if (this.MoveUp(true) == -1 ||
            this.MoveDown(true)  == -1 ||
            this.MoveRight(true) == -1 ||
            this.MoveLeft(true) == -1)
            return true;
        return false;
    }

    private bool PlaceBlocks(int numOfBlocks)
    {
        List<Point> available = this.AvailableBlocks();
        // list of available (x, y)'s 

        if (available.Count < numOfBlocks)
            return false; // Operation failed, not enough blocks available.

        int currentNum;

        for (int i = 0; i < numOfBlocks; i++)
        {
            currentNum = this.rnd.Next(0, available.Count);
            this.data[available[currentNum].X, available[currentNum].Y]
                = (this.rnd.Next(BASE_BLOCK / 2, BASE_BLOCK + 1)) * 2;
            available.RemoveAt(currentNum);
            // Places in random available places random number (2/4).
        }

        return true; // Operation succeeded
    }
}
