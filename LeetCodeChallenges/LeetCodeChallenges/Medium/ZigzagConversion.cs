namespace LeetCodeChallenges.Medium
{
    public partial class MediumSolution
    {
        public string ZigZagConvert(string s, int numRows)
        {
            if (numRows == 1) return s;
            string result = "";
            int diagonalLetterCount = numRows - 2;
            int itemsInZag = numRows + diagonalLetterCount;
            int colCount = s.Length / itemsInZag + 1;
            for (int i = 0; i < numRows; i++)
            {
                if (i == 0 || i == numRows - 1)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        // items in cols
                        int index = i + j * itemsInZag;
                        if (index < s.Length)
                            result += s[index];
                    }
                }
                else
                {
                    int maxItemCount = colCount * 2;
                    for (int j = 0; j < maxItemCount; j++)
                    {

                        int index;
                        if (j % 2 == 0)
                        {
                            // items in cols
                            index = i + (j / 2) * itemsInZag;
                        }
                        else
                        {
                            // diagonal items
                            index = (itemsInZag - i) + (j / 2) * (itemsInZag);
                        }
                        if (index < s.Length)
                            result += s[index];
                    }
                }
            }
            return result;
        }

        public static void ZigZagConvertTests()
        {
            WriteTestToConsole("PAHNAPLSIIGYIR", Instance.ZigZagConvert("PAYPALISHIRING", 3));
            WriteTestToConsole("PINALSIGYAHRPI", Instance.ZigZagConvert("PAYPALISHIRING", 4));
            WriteTestToConsole("PHASIYIRPLIGAN", Instance.ZigZagConvert("PAYPALISHIRING", 5));
            WriteTestToConsole("PYAAPL", Instance.ZigZagConvert("PAYPAL", 2));
            WriteTestToConsole("PAYPAL", Instance.ZigZagConvert("PAYPAL", 1));
            WriteTestToConsole("PAYPAL", Instance.ZigZagConvert("PAYPAL", 100));
        }
    }
}
