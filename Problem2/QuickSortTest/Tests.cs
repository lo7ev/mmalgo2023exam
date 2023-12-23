using quicksort;
using System;

namespace quicksort.test;

//custom int comparer with counter
public class IntComp : IComparer<int>
{
    private int numberOfcalls = 0;
    public IntComp(){
        numberOfcalls = 0;
    }
    public int NCalls()
    {
        return numberOfcalls;
    }
    public int Compare(int a, int b)
    {
        numberOfcalls += 1;
        if (a > b)
            return 1;
        else if (a < b)
            return -1;
        else
            return 0;
    }
}

public class QuickSortTests
{
    public static void SimpleSort()
    {
        System.Random rnd = new System.Random();
        int[] a = [.. Enumerable.Range(1, 100).OrderBy(r => rnd.Next())];
        int[] b = (int [])a.Clone();
        var comparer = new IntComp();
        var comparer_lib = new IntComp();

        
        QuickSort.Sort<int>(a, comparer, 0, a.Length - 1);
        Array.Sort(b, comparer_lib);
        bool p = Enumerable.SequenceEqual(a,b);
        
        if(p){
            Console.WriteLine("SimpleSort test: passed");
            Console.WriteLine("Comprassions. my: {0}. Default quicksort: {1}", comparer.NCalls(), comparer_lib.NCalls());
        }else{
            Console.WriteLine("SimpleSort test: failed");
        }
    }
    public static void Sorted()
    {
        int[] a = Enumerable.Range(1, 100).ToArray();;
        int[] b = (int [])a.Clone();
        var comparer = new IntComp();
        var comparer_lib = new IntComp();
        
        QuickSort.Sort<int>(a, comparer, 0, a.Length - 1);
        Array.Sort(b, comparer_lib);

        bool p = Enumerable.SequenceEqual(a,b);
        if(p){
            Console.WriteLine("SortedArray test: passed");
            Console.WriteLine("Comprassions. my: {0}. Default quicksort: {1}", comparer.NCalls(), comparer_lib.NCalls());
        }else{
            Console.WriteLine("SortedArray test: failed");
        }
    }
    public static void SameNumbers()
    {
        int[] a = new int[100];
        for(int i=0; i<33; i++)
            a[i] = 0;
        for(int i=33; i<66; i++)
            a[i] = 1;
        for(int i=66; i<100; i++)
            a[i] = 2;
        int[] b = (int [])a.Clone();
        var comparer = new IntComp();
        var comparer_lib = new IntComp();
        
        QuickSort.Sort<int>(a, comparer, 0, a.Length - 1);
        Array.Sort(b, comparer_lib);

        bool p =Enumerable.SequenceEqual(a,b);
        if(p){
            Console.WriteLine("SameNumbers test: passed");
            Console.WriteLine("Comprassions. my: {0}. Default quicksort: {1}", comparer.NCalls(), comparer_lib.NCalls());
        }else{
            Console.WriteLine("SameNumber test: failed"); 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QuickSortTests.SimpleSort();
        QuickSortTests.Sorted();
        QuickSortTests.SameNumbers();
        

    }
}