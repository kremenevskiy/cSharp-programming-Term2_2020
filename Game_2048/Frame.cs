using System;
using System.Collections.Generic;

namespace Game_2048
{
    public class Frame
    {
        private const int Size = 4;
        private int [,] _board = new int[Size, Size];
        private int score = 0;
        
        
        public void NewGame()
        {
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j < Size; ++j)
                    _board[i, j] = 0;

            generatePiece();
        }


        private void generatePiece()
        {
            Tuple<int, int> pos = generateUnoccupiedPosition();
            _board[pos.Item1, pos.Item2] = 2;
        }


        private void PrintUi()
        {
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                    if (_board[i, j] == 0)
                        Console.Write(".".PadLeft(8));
                    else
                        Console.Write(_board[i, j].ToString().PadLeft(8));
                Console.Write("\n");
            }
            
            Console.WriteLine($"\nScore: {score}");
            
            Console.WriteLine("\nPress - N: for Start New game\nPress - Q: for Quit\n");
        }


        private Tuple<int, int> generateUnoccupiedPosition()
        {
            int occupied = 1;
            Random random1 = new Random();
            Random random2 = new Random();
            int line;
            int column;
            
            while (true)
            {
                line = random1.Next() % 4;
                column = random2.Next() % 4;
                if (_board[line, column] == 0)
                    break;
            }
        
            return new Tuple<int, int>(line, column);
        }


        private bool MoveIsPossible(int line, int column, int nextLine, int nextColumn)
        {
            if (nextLine < 0 || nextColumn < 0 ||  nextLine >= 4 || nextColumn >= 4 ||
                (_board[line, column] != _board[nextLine, nextColumn] && _board[nextLine, nextColumn] != 0))
                return false;

            return true;
        }


        private void ApplyMove(ConsoleKeyInfo direction)
        {
            // convert key to int
            int conv_temp = 0;
            int startLine = 0, startColumn = 0, lineStep = 1, columnStep = 1;

            int[] dirLine = new int[4] {1, 0, -1, 0};
            int[] dirColumn = new int[4] {0, 1, 0, -1};

            if (direction.Key == ConsoleKey.UpArrow)
            {
                conv_temp = 2;
            }
            else if (direction.Key == ConsoleKey.DownArrow)
            {
                conv_temp = 0;
                startLine = 3;
                lineStep = -1;
            }
            else if (direction.Key == ConsoleKey.LeftArrow)
            {
                conv_temp = 3;
            }
            else if (direction.Key == ConsoleKey.RightArrow)
            {
                conv_temp = 1;
                startColumn = 3;
                columnStep = -1;
            }

            bool moveIsPos = false, canAddPiece = false;
            int scoreTemp = 0;
            do
            {
                moveIsPos = false;
                for (int i = startLine; i >= 0 && i < 4; i += lineStep)
                {
                    for (int j = startColumn; j >= 0 && j < 4; j += columnStep)
                    {
                        int nextI = i + dirLine[conv_temp];
                        int nextJ = j + dirColumn[conv_temp];
                        if (_board[i, j] > 0 && MoveIsPossible(i, j, nextI, nextJ))
                        {
                            if (_board[i, j] == _board[nextI, nextJ])
                            {
                                scoreTemp += _board[i, j] * 2;
                            }
                            _board[nextI, nextJ] += _board[i, j];
                            _board[i, j] = 0;
                            moveIsPos = canAddPiece = true;

                        }
                    }
                }
            } while (moveIsPos);

            if (canAddPiece)
            {
                generatePiece();
                score += scoreTemp;
            }

        }
        

        public void Start()
        {
            NewGame();
            
            while (true)
            {
                Console.Clear();
                PrintUi();
                ConsoleKeyInfo command =  Console.ReadKey();
            
                if (command.Key == ConsoleKey.N)
                    NewGame();
                else if (command.Key == ConsoleKey.Q)
                 break;
                else
                {
                    ApplyMove(command);
                }
                
            }
        }
    }
}