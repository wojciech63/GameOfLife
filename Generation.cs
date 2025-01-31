using System;
using System.Text;

namespace GameOfLife
{
    class Generation
    {
        private Cell[,] cells;
        public int Rows { get; }
        public int Cols { get; }

        public Generation(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            cells = new Cell[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    cells[r, c] = new Cell(false);
                }
            }
        }

        public Generation(int rows, int cols, int numberOfLivingCells)
            : this(rows, cols)
        {
            Random rand = new Random();

            for (int i = 0; i < numberOfLivingCells; i++)
            {
                int r = rand.Next(rows);
                int c = rand.Next(cols);
                cells[r, c].IsAlive = true;
            }
        }

        public bool IsAlive(int row, int col)
        {
            return cells[row, col].IsAlive;
        }

        public Generation NextGeneration()
        {
            Generation next = new Generation(Rows, Cols);

            // Cell stays alive if they have 2 or 3 live neighbors
            // Dead cell becomes alive if they have 3 live neighbors
            // Otherwise death

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    bool currentAlive = IsAlive(r, c);
                    int aliveNeighbors = CountAliveNeighbors(r, c);

                    bool shouldLive = (currentAlive && (aliveNeighbors == 2 || aliveNeighbors == 3))
                                      || (!currentAlive && aliveNeighbors == 3);

                    next.cells[r, c].IsAlive = shouldLive;
                }
            }
            return next;
        }

        private int CountAliveNeighbors(int row, int col)
        {
            int count = 0;
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0)
                        continue;

                    int nr = row + dr;
                    int nc = col + dc;

                    if (nr >= 0 && nr < Rows && nc >= 0 && nc < Cols)
                    {
                        if (cells[nr, nc].IsAlive)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
