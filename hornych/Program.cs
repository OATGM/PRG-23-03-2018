using System;

namespace CatAndMouse
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            
            Random rnd = new Random();
            Room room = new Room(20, 15, '*');
            
            Console.WriteLine("Welcome to Cat and Mouse game!");         



            // create cat and mouse on user's locations
            Console.WriteLine("Do you want to specify locations of cat and mouse? (y/n)");
            string locationsAnswer = Console.ReadLine().ToLower();

            Coordinates catPos = new Coordinates();
            Coordinates mousePos = new Coordinates();
            if (locationsAnswer == "y") {             
                do {
                    do {
                        Console.WriteLine("Enter x position of cat:");
                        catPos.x = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter y position of cat:");
                        catPos.y = int.Parse(Console.ReadLine());
                    } while (room.IsWall(catPos));

                    do {
                        Console.WriteLine("Enter x position of mouse:");
                        mousePos.x = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter y position of mouse:");
                        mousePos.y = int.Parse(Console.ReadLine());
                    } while (room.IsWall(mousePos));
                } while ((Math.Abs(catPos.x - mousePos.x) < 5) || (Math.Abs(catPos.y - mousePos.y) < 5));

            } else {
                catPos.x = rnd.Next(1, room.Width - 2); 
                catPos.y = rnd.Next(1, room.Height - 2);

                mousePos.x = rnd.Next(1, room.Width - 2); 
                mousePos.y = rnd.Next(1, room.Height - 2);
            }
            Cat cat = new Cat(catPos, room);
            Mouse mouse = new Mouse(mousePos, room);



            bool gameRunning = true;

            while (gameRunning) {
                Console.Clear();
                room.Draw();
                // cat.DrawWall();
                mouse.Draw();
                cat.Draw();
                Console.SetCursorPosition(0, room.Height + 1);
                Console.WriteLine("Score: {0}", score);

                // move cat
                Console.SetCursorPosition(0, room.Height + 2);
                Console.Write("Enter move for cat");
                ConsoleKey catMove = Console.ReadKey().Key;

                if (cat.Move(catMove))
                    score++;

                // move mouse
                Console.SetCursorPosition(0, room.Height + 2);
                Console.Write("Enter move for mouse");
                ConsoleKey mouseMove = Console.ReadKey().Key;

                mouse.Move(mouseMove);
                // mouse.MoveAuto(cat.Position);

                // check for end game
                if ((cat.Position.x == mouse.Position.x) && (cat.Position.y == mouse.Position.y)) {
                    gameRunning = false;
                    Console.Clear();
                    Console.SetCursorPosition(1, 1);
                    Console.Write("You won! Your score is {0}.", score);
                    Console.ReadKey();
                }
            }
        }
    }
}
