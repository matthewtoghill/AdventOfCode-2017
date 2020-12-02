namespace Day03
{
    public class SpecialSpiralItem : SpiralItem
    {
        #region Constructors
        public SpecialSpiralItem()
        {
        }

        public SpecialSpiralItem(SpiralDirection lastDirection, int sidePos, int lastX, int lastY)
        {
            this.Direction = GetDirection(lastDirection, sidePos);
            this.X = GetX(lastX);
            this.Y = GetY(lastY);
        }
        #endregion


        private SpiralDirection GetDirection(SpiralDirection lastDirection, int sidePos)
        {
            if (sidePos == 1)
            {
                return lastDirection == SpiralDirection.Down ? SpiralDirection.Right : lastDirection + 1;
            }
            return lastDirection;
        }

        private int GetX(int lastX)
        {
            if (this.Direction == SpiralDirection.Right) return lastX + 1;
            if (this.Direction == SpiralDirection.Left) return lastX - 1;
            return lastX;
        }

        private int GetY(int lastY)
        {
            if (this.Direction == SpiralDirection.Up) return lastY + 1;
            if (this.Direction == SpiralDirection.Down) return lastY - 1;
            return lastY;
        }

    }
}
