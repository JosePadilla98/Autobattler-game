using System;
using JetBrains.Annotations;

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
        UP = 0,
        CENTER = 1,
        DOWN = 2
    }

    public struct Position
    {
        public Height heigh;
        public Column column;
        public Side side;

        public Position(Height heigh, Column column, Side side)
        {
            this.heigh = heigh;
            this.column = column;
            this.side = side;
        }

        public Position(int heigh, Column column, Side side)
        {
            this.heigh = HeightFromNumber(heigh);
            this.column = column;
            this.side = side;
        }

        private static Height HeightFromNumber(int heightNumber)
        {
            if (Enum.IsDefined(typeof(Height), heightNumber))
            {
                return (Height)heightNumber;
            }

            throw new Exception("Invalid height");
        }
    }
}
