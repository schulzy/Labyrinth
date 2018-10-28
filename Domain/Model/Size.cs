namespace Domain.Model
{
    internal struct Size
    {
        public int Row;
        public int Column;

        public static Size GetEmptySize()
        {
            var emptySize = new Size
            {
                Column = 0,
                Row = 0
            };

            return emptySize;
        }

        public Size(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}