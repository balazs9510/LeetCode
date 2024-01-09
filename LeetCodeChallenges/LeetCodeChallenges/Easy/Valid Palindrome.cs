using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Valid_Palindrome
    {
        public bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            s = s.ToLower();
            while (start <= end)
            {
                while (!char.IsLetterOrDigit(s[start])) { start++; if (start > s.Length - 1 || end < 0) return true; }
                while (!char.IsLetterOrDigit(s[end])) { end--; if (start > s.Length - 1 || end < 0) return true; }

                if (s[start] != s[end]) return false;
                start++;
                end--;
            }

            return true;
        }


        [Fact]
        public void MyTestMethod()
        {
            // Arrange
            var s = "A man, a plan, a canal: Panama";

            // Act
            var result = IsPalindrome(s);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MyTestMethod1()
        {
            // Arrange
            var s = "race a car";

            // Act
            var result = IsPalindrome(s);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void MyTestMethod2()
        {
            // Arrange
            var s = " ";

            // Act
            var result = IsPalindrome(s);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MyTestMethod3()
        {
            // Arrange
            var s = " a";

            // Act
            var result = IsPalindrome(s);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MyTestMethod4()
        {
            // Arrange
            var s = "";

            // Act
            var result = IsPalindrome(s);

            // Assert
            Assert.True(result);
        }
    }
}
