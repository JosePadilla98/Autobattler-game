namespace AutobattlerOld.Grid
{
    public enum Column
    {
        FRONT,
        BACK,
        NONE
    }

    public enum Side
    {
        LEFT,
        RIGHT
    }

    public enum Height
    {
        UP,
        CENTER,
        DOWN
    }

    public struct Position
    {
        public int heigh;
        public Column column;
        public Side side;

        public Position(int heigh, Column column, Side side)
        {
            this.heigh = heigh;
            this.column = column;
            this.side = side;
        }
    }
}
