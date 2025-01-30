namespace GameOfLife
{
    class Cell
    {
        public bool IsAlive { get; set; }

        public Cell(bool isAlive = false)
        {
            IsAlive = isAlive;
        }
    }
}
