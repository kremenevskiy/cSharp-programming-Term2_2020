using System;
using System.Collections.Generic;

namespace Game_2048
{
    public class Frame
    {
        private const int Size = 4;
        private int [,] _board = new int[Size, Size];
        private int _score = 0;
        
        
        private void NewGame()
        {
            for (int i = 0; i < Size; ++i)
                for (int j = 0; j < Size; ++j)
                    _board[i, j] = 0;
            
            _score = 0;
            
            GeneratePiece();
        }


        private void GeneratePiece()
        {
            Tuple<int, int> pos = GenerateUnoccupiedPosition();
            Random randomFour = new Random();
            int numFour = randomFour.Next(9);
            if (numFour == 4)
                _board[pos.Item1, pos.Item2] = 4;
            else
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
                Console.Write("\n\n");
            }
            
            Console.WriteLine($"Score: {_score}\n");
            Console.WriteLine("Press - N: for Start New game\nPress - Q: for Quit\n");
        }


        private Tuple<int, int> GenerateUnoccupiedPosition()
        {
            Random random = new Random();
            int line;
            int column;
            
            while (true)
            {
                line = random.Next() % 4;
                column = random.Next() % 4;
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
            int convTemp = 0;
            int startLine = 0, startColumn = 0, lineStep = 1, columnStep = 1;

            int[] dirLine = new int[4] {1, 0, -1, 0};
            int[] dirColumn = new int[4] {0, 1, 0, -1};

            if (direction.Key == ConsoleKey.UpArrow)
            {
                convTemp = 2;
            }
            else if (direction.Key == ConsoleKey.DownArrow)
            {
                convTemp = 0;
                startLine = 3;
                lineStep = -1;
            }
            else if (direction.Key == ConsoleKey.LeftArrow)
            {
                convTemp = 3;
            }
            else if (direction.Key == ConsoleKey.RightArrow)
            {
                convTemp = 1;
                startColumn = 3;
                columnStep = -1;
            }

            bool moveIsPos, canAddPiece = false;
            int scoreTemp = 0;
            
            do
            {
                moveIsPos = false;
                for (int i = startLine; i >= 0 && i < 4; i += lineStep)
                {
                    for (int j = startColumn; j >= 0 && j < 4; j += columnStep)
                    {
                        int nextI = i + dirLine[convTemp];
                        int nextJ = j + dirColumn[convTemp];
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
                GeneratePiece();
                _score += scoreTemp;
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
                    ApplyMove(command);
            }
        }
    }
}