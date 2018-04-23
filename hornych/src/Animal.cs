using System;

namespace CatAndMouse
{
    public class Coordinates
    {
        public int x;
        public int y;

        public Coordinates()
        {}

        public Coordinates(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Animal
    {
        public Coordinates Position { get; private set; }
        public char AnimalSymbol { get; private set; }

        protected Room room;

        public Animal(Coordinates startingPosition, char animalSymbol, Room room)
        {
            Position = startingPosition;
            AnimalSymbol = animalSymbol;
            this.room = room;
        } 

        public virtual bool Move(ConsoleKey key)
        {
            switch (key) {
                case ConsoleKey.A: return MoveLeft(); 
                case ConsoleKey.D: return MoveRight();
                case ConsoleKey.W: return MoveUp();
                case ConsoleKey.S: return MoveDown();
                case ConsoleKey.Q: return MoveLeftUp();
                case ConsoleKey.E: return MoveRightUp();
                case ConsoleKey.Y: return MoveLeftDown();
                case ConsoleKey.X: return MoveRightDown();
            }

            return false;
        }

        protected virtual bool MoveLeft()
        {
            // if ((Position.x - 1) != 0) {
            //     Position.x -= 1;
            //     return true;
            // }
            Position.x -= 1;
            if (Position.x == 0)
                Position.x = room.Width - 2;
            return true;
        }

        protected virtual bool MoveRight()
        {
            // if ((Position.x + 2) != room.Width) {
            //     Position.x += 1;
            //     return true;
            // }
            Position.x += 1;
            if (Position.x == (room.Width - 1))
                Position.x = 1;
            return true;
        }

        protected virtual bool MoveUp()
        {
            // if ((Position.y - 1) != 0) {
            //     Position.y -= 1;
            //     return true;
            // }

            Position.y -= 1;
            if (Position.y == 0)
                Position.y = room.Height - 2;
            return true;
        }

        protected virtual bool MoveDown()
        {
            // if ((Position.y + 2) != room.Height) {
            //     Position.y += 1;
            //     return true;
            // }
            Position.y += 1;
            if (Position.y == (room.Height - 1))
                Position.y = 1;
            return true;
        }

        public virtual bool MoveLeftUp()
        {
            bool res0 = MoveLeft();
            bool res1 = MoveUp();
            return (res0 || res1);
        }

        public virtual bool MoveLeftDown()
        {
            bool res0 = MoveLeft();
            bool res1 = MoveDown();
            return (res0 || res1);
        }

        public virtual bool MoveRightUp()
        {
            bool res0 = MoveRight();
            bool res1 = MoveUp();
            return (res0 || res1);
        }

        public virtual bool MoveRightDown()
        {
            bool res0 = MoveRight();
            bool res1 = MoveDown();
            return (res0 || res1);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write(AnimalSymbol);
        }

        
    }
}