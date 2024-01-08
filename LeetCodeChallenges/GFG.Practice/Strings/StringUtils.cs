namespace GFG.Practice.Strings;

public class StringUtils
{
    public static string Reverse(string str)
    {
        string newString = "";

        for (int i = str.Length - 1; i > -1; i--)
        {
            newString += str[i];
        }
        return newString;
    }

    public static string ReverseTwoPointer(string str)
    {
        int left = 0; int right = str.Length - 1;
        var array = str.ToCharArray();
        for (int i = 0; i < str.Length / 2; i++)
        {
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            left++;
            right--;
        }

        return string.Join("", array);
    }

    public static string ReverseRecursive(string str) => ReverseRecursive(str, 0, str.Length - 1);

    private static string ReverseRecursive(string str, int left, int right)
    {
        if (left >= right) return str;

        var array = str.ToCharArray();
        var temp = array[left];
        array[left] = array[right];
        array[right] = temp;

        return ReverseRecursive(string.Join("", array), left + 1, right - 1);
    }
}
