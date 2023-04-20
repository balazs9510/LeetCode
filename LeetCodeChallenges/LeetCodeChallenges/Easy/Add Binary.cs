using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Add_Binary
    {

        public static string AddBinary(string a, string b)
        {
            var sb = new StringBuilder();

            int aIterator = a.Length - 1;
            int bIterator = b.Length - 1;

            bool remaining = false;
            while (aIterator > -1 && bIterator > -1)
            {
                var aC = a[aIterator] == '0' ? 0 : 1;
                var bC = b[bIterator] == '0' ? 0 : 1;
                var cC = aC + bC;
                if (remaining)
                    cC++;
                switch (cC)
                {
                    case 0: sb.Append('0'); remaining = false; break;
                    case 1: sb.Append("1"); remaining = false; break;
                    case 2: sb.Append("0"); remaining = true; break;
                    case 3: sb.Append("1"); remaining = true; break;
                }
                aIterator--;
                bIterator--;
            }

            for (int i = aIterator; i > -1; i--)
            {
                var aC = a[i] == '0' ? 0 : 1;
                var cC = (int)aC;
                if (remaining)
                    cC++;
                switch (cC)
                {
                    case 0: sb.Append('0'); remaining = false; break;
                    case 1: sb.Append("1"); remaining = false; break;
                    case 2: sb.Append("0"); remaining = true; break;
                }
            }
            for (int i = bIterator; i > -1; i--)
            {
                var bC = b[i] == '0' ? 0 : 1;
                var cC = (int)bC;
                if (remaining)
                    cC++;
                switch (cC)
                {
                    case 0: sb.Append('0'); remaining = false; break;
                    case 1: sb.Append("1"); remaining = false; break;
                    case 2: sb.Append("0"); remaining = true; break;
                }
            }

            if (remaining)
                sb.Append("1");

            return string.Join("", sb.ToString().Reverse());
        }

        [Theory]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        [InlineData("1111", "0", "1111")]
        public void AddBinaryTests(string a, string b, string expected)
        {
            // Arrance & Act
            var res = AddBinary(a, b);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
