using System;

namespace CatAndMouse
{
    public class Mouse : Animal
    {
        public Mouse(Coordinates startingPosition, Room room) : base(startingPosition, 'X', room)
        {}

        public void MoveAuto(Coordinates catPosition)
        {
            int xDif = Position.x - catPosition.x;
            int yDif = Position.y - catPosition.y;

            if (Math.Abs(xDif) < Math.Abs(yDif)) {
                int move = Math.Sign(xDif);
                if (move == 1)
                    MoveRight();
                else 
                    MoveLeft();
            } else {
                int move = Math.Sign(yDif);
                if (move == 1)
                    MoveDown();
                else 
                    MoveUp();
            }
        }
    }
}