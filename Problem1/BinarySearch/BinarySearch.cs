namespace binsearch;
public class BinarySearch
{
    public static int Find<T>(T[] array, IComparer<T> comparer, T element)
    {
        if(array.Length==0)
        {
            throw new EmptyArrayException();
        }
        int left = 0;
        int right = array.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (comparer.Compare(array[mid], element) == 0)
                return mid;
            else if (comparer.Compare(array[mid], element) < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}