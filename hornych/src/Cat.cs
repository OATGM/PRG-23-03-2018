using System;
using System.Collections.Generic;

namespace CatAndMouse
{
    public class Cat : Animal
    {
        // List<Coordinates> catWall;

        public Cat(Coordinates startingPosition, Room room) : base(startingPosition, 'O', room)
        {
            // catWall = new List<Coordinates>();
        }

        // protected override bool MoveLeft()
        // {
        //     Coordinates prevPosition = GetPrevPosition();

        //     if (base.MoveLeft()) {
        //         catWall.Add(prevPosition);
        //         return true;
        //     }
        //     return false;
        // }

        // protected override bool MoveRight()
        // {
        //     Coordinates prevPosition = GetPrevPosition();

        //     if (base.MoveRight()) {
        //         catWall.Add(prevPosition);
        //         return true;
        //     }
        //     return false;
        // }

        // protected override bool MoveUp()
        // {
        //     Coordinates prevPosition = GetPrevPosition();
        //     if (base.MoveUp()) {
        //         catWall.Add(prevPosition);
        //         return true;
        //     }
        //     return false;
        // }

        // protected override bool MoveDown()
        // {
        //     Coordinates prevPosition = GetPrevPosition();
        //     if (base.MoveDown()) {
        //         catWall.Add(prevPosition);
        //         return true;
        //     }
        //     return false;
        // }

        private Coordinates GetPrevPosition()
        {
            Coordinates prevPosition = new Coordinates();
            prevPosition.x = Position.x;
            prevPosition.y = Position.y;

            return prevPosition;
        }

        // public void DrawWall()
        // {
        //     foreach (Coordinates pos in catWall) {
        //         Console.SetCursorPosition(pos.x, pos.y);
        //         Console.Write('.');
        //     }
        // }
    }
}