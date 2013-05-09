using System;

namespace KingSurvival
{
    class Game
    {
        private static char[,] board;

        private readonly int[] pawnRows =
        {
            0,
            0,
            0,
            0
        };

        private readonly int[] pawnCols =
        {
            0,
            2,
            4,
            6
        };
        //TODO kingRow And kingCol should be constants?
        private int kingRow = 7;

        private int kingCol = 3;

        private readonly char whiteCell = '+';

        private readonly char blackCell = '-';

        private readonly int[] deltaRow =
        {
            -1,
            +1,
            +1,
            -1
        }; //UR, DR, DL, UL

        private readonly int[] deltaCol =
        {
            +1,
            +1,
            -1,
            -1
        };


        // TODO this method needs refactoring 
        public Game()
        {
            board = new char[8, 8];
            InitializeBoard();
        }

        // TODO can be separated to several methods
        public void InitializeBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        board[row, col] = whiteCell;
                    }
                    else
                    {
                        board[row, col] = blackCell;
                    }
                }
            }

            board[pawnRows[0], pawnCols[0]] = 'A';

            board[pawnRows[1], pawnCols[1]] = 'B';

            board[pawnRows[2], pawnCols[2]] = 'C';

            board[pawnRows[3], pawnCols[3]] = 'D';

            board[kingRow, kingCol] = 'K';
        }
        //TODO needs refactoring
        public bool MoveKingIfPossible(string command)
        {
            if (command.Length != 3)
            {
                return false;
            }
            string commandToLower = command.ToLower();
            int indexOfChange = -1;
            // TODO check default return value
            switch (commandToLower)
            {
                case "kur":
                    {
                        indexOfChange = 0;
                    }
                    break;
                case "kdr":
                    {
                        indexOfChange = 1;
                    }
                    break;
                case "kdl":
                    {
                        indexOfChange = 2;
                    }
                    break;
                case "kul":
                    {
                        indexOfChange = 3;
                    }
                    break;
                default:
                    return false;
            }
            int kingNewRow = kingRow + deltaRow[indexOfChange];
            int kingNewCol = kingCol + deltaCol[indexOfChange];
            if (IsCellObstacle(kingNewRow, kingNewCol))
            {
                board[kingRow, kingCol] = board[kingNewRow, kingNewCol];
                board[kingNewRow, kingNewCol] = 'K';
                kingRow = kingNewRow;

                kingCol = kingNewCol;

                return true;
            }
            return false;
        }

        // TODO refactor into several methods
        public bool MovePawnIfPossible(string command)
        {
            if (command.Length != 3)
            {
                return false;
            }

            int indexOfChange = -1;

            string commandToLower = command.ToLower();
            switch (commandToLower)
            {
                case "adr":
                case "bdr":
                case "cdr":
                case "ddr":
                    {
                        indexOfChange = 1;
                    }
                    break;
                case "adl":
                case "bdl":
                case "cdl":
                case "ddl":
                    {
                        indexOfChange = 2;
                    }
                    break;
                default:
                    return false;
            }

            int pawnIndex = -1;
            switch (command[0])
            {
                case 'a':
                case 'A':
                    {
                        pawnIndex = 0;
                    }
                    break;
                case 'b':
                case 'B':
                    {
                        pawnIndex = 1;
                    }
                    break;
                case 'c':
                case 'C':
                    {
                        pawnIndex = 2;
                    }
                    break;
                case 'd':
                case 'D':
                    {
                        pawnIndex = 3;
                    }
                    break;
            }

            int pawnNewRow = pawnRows[pawnIndex] + deltaRow[indexOfChange];
            int pawnNewCol = pawnCols[pawnIndex] + deltaCol[indexOfChange];

            if (IsCellObstacle(pawnNewRow, pawnNewCol))
            {
                board[pawnRows[pawnIndex], pawnCols[pawnIndex]] = board[pawnNewRow, pawnNewCol];
                board[pawnNewRow, pawnNewCol] = command.ToUpper()[0];
                pawnRows[pawnIndex] = pawnNewRow;
                pawnCols[pawnIndex] = pawnNewCol;

                return true;
            }

            return false;
        }

        public bool KingWon()
        {
            if (kingRow == 0) //check if king is on the first row
            {
                return true;
            }

            for (int i = 0; i < board.GetLength(0); i += 2) // check if all powns are on the last row
            {
                if (board[board.GetLength(1) - 1, i] == whiteCell || board[board.GetLength(1) - 1, i] == blackCell)
                {
                    return false;
                }
            }
            return true;
        }

        // TODO reduce coupling of this method
        private bool IsCellOnBoard(int row, int col)
        {
            if (row < 0 || row > board.GetLength(0) - 1 || col < 0 || col > board.GetLength(1) - 1)
            {
                return false;
            }
            
            return true;
        }

        // TODO reduce coupling of this method
        private bool IsCellObstacle(int row, int col)
        {
            if (IsCellOnBoard(row, col))
            {
                if (board[row, col] == whiteCell || board[row, col] == blackCell)
                {
                    return true;
                }
            }

            return false;
        }

        public bool KingLost()
        {
            if (!IsCellObstacle(kingRow + 1, kingCol + 1) && !IsCellObstacle(kingRow + 1, kingCol - 1) &&
                !IsCellObstacle(kingRow - 1, kingCol + 1) && !IsCellObstacle(kingRow - 1, kingCol - 1))
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            Game game = new Game();

            int kingMovesCount = 0;
            bool isKingsTurn = true;

            while (true)
            {
                if (game.KingWon())
                {
                    Console.WriteLine("King won in {0} turns", kingMovesCount); break;
                }
                else if (game.KingLost())
                {
                    Console.WriteLine("King lost in {0} turns", kingMovesCount);
                    break;
                }
                else
                {
                    Console.WriteLine();
                    ConsoleManager.PrintBoard(board);
                    if (isKingsTurn)
                    {
                        bool kingMoved = false;
                        while (!kingMoved)
                        {
                            Console.Write("King's turn: ");
                            string command = Console.ReadLine();
                            kingMoved = game.MoveKingIfPossible(command);
                            if (!kingMoved)
                            {
                                Console.WriteLine("Illegal move!");
                            }
                        }
                        isKingsTurn = false;
                        kingMovesCount++;
                    }
                    else
                    {
                        bool pawnMoved = false;
                        while (!pawnMoved)
                        {
                            Console.Write("Pawn's turn: ");
                            string command = Console.ReadLine();
                            pawnMoved = game.MovePawnIfPossible(command);
                            if (!pawnMoved)
                            {
                                Console.WriteLine("Illegal move!");
                            }
                        }
                        isKingsTurn = true;
                    }
                }
            }
        }
    }
}