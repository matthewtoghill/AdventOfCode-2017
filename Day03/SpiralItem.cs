using System;

namespace Day03
{
    public class SpiralItem
    {
        public enum SpiralDirection
        {
            Right,
            Up,
            Left,
            Down
        }

        public int Num { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public SpiralDirection Direction { get; set; }

        #region Constructors
        public SpiralItem(int lastNum, int increment, SpiralDirection lastDirection, int lastX, int lastY)
        {
            this.Num = lastNum + increment;
            this.Direction = GetNewDirection(lastDirection);
            this.X = GetX(lastX, increment);
            this.Y = GetY(lastY, increment);
        }

        public SpiralItem()
        {
        }
        #endregion

        public virtual bool IsBottomRightCorner()
        {
            return Num % 1 != 0 && Math.Sqrt(Num) % 2 == 0;
        }

        private SpiralDirection GetNewDirection(SpiralDirection lastDirection)
        {
            return lastDirection == SpiralDirection.Down ? SpiralDirection.Right : lastDirection + 1;
        }

        private int GetX(int lastX, int increment)
        {
            if (this.Direction == SpiralDirection.Right) return lastX + increment;
            if (this.Direction == SpiralDirection.Left) return lastX - increment;
            return lastX;
        }

        private int GetY(int lastY, int increment)
        {
            if (this.Direction == SpiralDirection.Up) return lastY + increment;
            if (this.Direction == SpiralDirection.Down) return lastY - increment;
            return lastY;
        }
    }
}
