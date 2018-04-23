using System;
using System.Collections.Generic;

namespace CatAndMouse
{
    public class Room
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        List<Coordinates> wallBlocks;
        private char wallSymbol;

        public Room(int width, int height, char wallSymbol)
        {
            Width = width;
            Height = height;
            this.wallSymbol = wallSymbol;
            wallBlocks = new List<Coordinates>();
            FillBaseWallBlocks();
        }

        public void FillBaseWallBlocks()
        {
            for (int i = 0; i < Width; i++) {
                wallBlocks.Add(new Coordinates(i, 0));
                wallBlocks.Add(new Coordinates(i, (Height - 1)));
            }

            for (int i = 1; i < (Height - 1); i++) {
                wallBlocks.Add(new Coordinates(0, i));
                wallBlocks.Add(new Coordinates(Width - 1, i));
            }
        }

        public void Draw()
        {
            foreach (Coordinates pos in wallBlocks) {
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write(wallSymbol);
            }
        }

        public bool IsWall(Coordinates pos)
        {
            if (((pos.x == 0) || (pos.x > (Width - 1))) && ((pos.y == 0) || (pos.y >= (Height - 2))))
                return true;
            return false;
        }
    }
}