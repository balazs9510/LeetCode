using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTRec(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBSTRec(int[] nums, int left, int right)
        {
            if (left > right) return null;

            var middle = left + (right - left) / 2;
            var newNode = new TreeNode(nums[middle]);
            newNode.left = SortedArrayToBSTRec(nums, left, middle - 1);
            newNode.right = SortedArrayToBSTRec(nums, middle + 1, right);

            return newNode;
        }

        [Fact]
        public void SortedArrayToBSTTest1()
        {
            // Arrange
            var nums = new int[] { -10, -3, 0, 5, 9 };
            var expected = new TreeNode(0,
                    new TreeNode(-3, new TreeNode(-10)),
                    new TreeNode(9, new TreeNode(5)));
            // Act
            var result = SortedArrayToBST(nums);

            // Assert
            AssertUtils.AssertBinaryTreeEqual(expected, result);
        }

        [Fact]
        public void SortedArrayToBSTTest2()
        {
            // Arrange
            var nums = new int[] { -10 };

            // Act
            var result = SortedArrayToBST(nums);

            // Assert
            AssertUtils.AssertBinaryTreeEqual(new TreeNode(-10), result);
        }

        [Fact]
        public void SortedArrayToBSTTest3()
        {
            // Arrange
            var nums = new int[] { 1, 3 };

            // Act
            var result = SortedArrayToBST(nums);

            // Assert
            AssertUtils.AssertBinaryTreeEqual(new TreeNode(3, new TreeNode(1)), result);
        }
    }
}
