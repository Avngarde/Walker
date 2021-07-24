using System;

namespace Walker
{
    class Program
    {
        static void printGrid(char[,] grid)
        {
            Console.Clear();
            for (int y = 0; y <= 4; y++)
            {
                for (int x = 0; x <= 4; x++)
                {
                    Console.Write(grid[x, y]);
                }

                Console.WriteLine();
            } 
        }

        static char[,] createGrid(int x, int y) {
            char[,] grid = new char[x, y];
            for (int gridYIdx = 0; gridYIdx < y; gridYIdx++) {
                for (int gridXIdx = 0; gridXIdx < x; gridXIdx++) {
                    grid[gridXIdx, gridYIdx] = '.';
                }
            }

            return grid;
        }

        static char[,] redrawGrid(char[,] grid, int currentX, int currentY, char changedParam, string ascOrDesc)
        {
            grid[currentX, currentY] = '.';

            switch (changedParam)
            {
                case 'x':
                    if (ascOrDesc == "asc")
                    {
                        grid[currentX + 1, currentY] = '@';
                    }

                    if (ascOrDesc == "desc")
                    {
                        grid[currentX - 1, currentY] = '@';
                    }
                    break;

                case 'y':
                    if (ascOrDesc == "asc")
                    {
                        grid[currentX, currentY + 1] = '@';
                    }

                    if (ascOrDesc == "desc")
                    {
                        grid[currentX, currentY - 1] = '@';
                    }
                    break;
            }


            return grid;
        }

        static void Main()
        {         
            char[,] grid = new char[5, 5] {
                {'@', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.'},
                {'.', '.', '.', '.', '.'},
            };
            int playerX = 0;
            int playerY = 0;

            while (true)
            {
                printGrid(grid);
                Console.WriteLine(playerX + " " + playerY);

                ConsoleKeyInfo newMovement = Console.ReadKey(true);
                switch (newMovement.KeyChar)
                {
                    case 'w':
                        if (playerY > 0)
                        {
                            grid = redrawGrid(grid, playerX, playerY, 'y', "desc");
                            playerY -= 1;
                        }
                        break;

                    case 'a':
                        if (playerX > 0)
                        {
                            grid = redrawGrid(grid, playerX, playerY, 'x', "desc");
                            playerX -= 1;
                        }
                        break;

                    case 's':
                        if (playerY < 4)
                        {
                            grid = redrawGrid(grid, playerX, playerY, 'y', "asc");
                            playerY += 1;
                        }
                        break;

                    case 'd':
                        if (playerX < 4)
                        {
                            grid = redrawGrid(grid, playerX, playerY, 'x', "asc");
                            playerX += 1;
                        }
                        break;
                }
            }
        }
    }
} 
