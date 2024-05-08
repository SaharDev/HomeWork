using System.Security.Permissions;
using System;

public enum Direction
{
    Up = ConsoleKey.UpArrow,
    Down = ConsoleKey.DownArrow,
    Left = ConsoleKey.LeftArrow,
    Right = ConsoleKey.RightArrow,
    InValidDirection = 0 // default value
}