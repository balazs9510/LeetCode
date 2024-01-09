using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            var count = nums.Length;
            var middle = count / 2;
            TreeNode prev = null;
            for (var i = 0; i <= middle; i++)
            {
                var current = new TreeNode(nums[i]);
                if (prev != null) current.left = prev;

                prev = current;
            }
            var root = prev;
            prev = null;
            for (int i = count - 1; i > middle; i--)
            {
                var current = new TreeNode(nums[i]);
                if (prev != null) current.right = prev;
                prev = current;
            }
            root.right = prev;
            return root;
        }


        [Fact]
        public void MyTestMethod()
        {
            // Arrange
            var nums = new int[] { -10, -3, 0, 5, 9 };

            // Act
            var result = SortedArrayToBST(nums);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void MyTestMethod2()
        {
            // Arrange
            var nums = new int[] { -10 };

            // Act
            var result = SortedArrayToBST(nums);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void MyTestMethod3()
        {
            // Arrange
            var nums = new int[] { 1, 3 };

            // Act
            var result = SortedArrayToBST(nums);

            // Assert
            Assert.True(true);
        }
    }
}
