namespace GFG.Practice.Arrays
{
    public class ArrayUtils
    {
        public static T[] Reverse<T>(T[] array)
        {
            //T[] result = new T[array.Length];
            //for (int i = array.Length - 1; i >= 0; i--)
            //{
            //    result[(array.Length - 1) - i] = array[i];
            //}

            //return result;

            int start = 0; int end = array.Length - 1;
            while (start < end)
            {
                T temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }

            return array;
        }
    }
}
