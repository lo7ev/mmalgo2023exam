namespace quicksort;

public class QuickSort
{
    private static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    public static void Sort<T>(T[] a, IComparer<T> comparer, int lo, int hi)
    {
        if(a.Length==0)
        {
            throw new Exception("NOthing to sort.");
        }
        while (lo < hi)
        {
            int i = lo, j = (lo + hi) / 2, k = hi;
            T p;
            // Выбор опорного как медиана из трех
            if (comparer.Compare(a[k], a[i])<0)
                Swap<T>(ref a[k], ref a[i]);
            if (comparer.Compare(a[j], a[i])<0)
                Swap<T>(ref a[j], ref a[i]);
            if (comparer.Compare(a[k], a[j])<0)
                Swap<T>(ref a[k], ref a[j]);
            p = a[j];
            i--;
            k++;
            while (true)
            {
                while (comparer.Compare(a[++i],p)<0) ;
                while (comparer.Compare(a[--k], p)>0) ;
                if (i >= k)
                    break;
                Swap(ref a[i], ref a[k]);
            }
            //трехчастное разбиение
            i = k++;
            while (i > lo && comparer.Compare(a[i], p)==0)
                i--;
            while (k < hi && comparer.Compare(a[k], p)==0)
                k++;
            // Один рекурентный вызов вместо двух
            int ll, rr;
            if((i - lo) <= (hi - k)){
                ll = lo;
                rr = i;
                i = hi;
            } else {
                ll = k;
                rr = hi;
                k = lo;
            }
            QuickSort.Sort<T>(a, comparer, ll, rr);
            lo = k;
            hi = i;
        }
    }
}
