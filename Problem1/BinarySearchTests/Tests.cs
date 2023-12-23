using binsearch;

namespace binsearch.tests;

public class BinarySearchTests
{
    public static void SuccessSearch()
    {
        int[] a = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]; 
        bool p = true;
        for(int i = 0; i < a.Length; i++) {
            int n = BinarySearch.Find<int>(a, Comparer<int>.Default, i);
            if(n!=i)
                p = false;  
        }

        if(p){
                Console.WriteLine("SuccessSearch test: passed");
            }else{
                Console.WriteLine("SuccessSearch test: failed");
            }

    }
    public static void SuccessSearchOddSize()
    {
        int[] a = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]; 
        bool p = true;
        for(int i = 0; i < a.Length; i++) {
            int n = BinarySearch.Find<int>(a, Comparer<int>.Default, i);
            if(n != i)
                p = false;
        }
        if(p){
                Console.WriteLine("SuccessSearchOddSize test: passed");
            }else{
                Console.WriteLine("SuccessSearchOddSize test: failed");
            }
    }

    public static void TestForFails() {
        int[] a = [0, 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13]; 
        int[] b = [-10,9,100];
        bool p = true;
        foreach(int value in b){
            int n = BinarySearch.Find<int>(a, Comparer<int>.Default, value);
            if(n != -1){
                p = false;
            }
            
        }
        if(p){
                Console.WriteLine("TestForFails test: passed");
            }else{
                Console.WriteLine("TestForFails test: failed");
            }
    }

    public static void EmptyArray()
    {
        int[] a = []; 
        bool p = true;
        try{
            BinarySearch.Find<int>(a, Comparer<int>.Default, 0);
        }catch{
            Console.WriteLine("EmptyArray test: passed");
            p = false;
        }
        if(p){
            Console.WriteLine("EmptyArray test: failed");
        }

    }
    public static void Similarelements()
    {
        int[] a = [1, 2, 3, 4, 4, 4, 4]; 
        int n = BinarySearch.Find<int>(a, Comparer<int>.Default, 4);
        if(a[n] == 4){
                Console.WriteLine("SimilarElements test: passed");
            }else{
                Console.WriteLine("SimilarElements test: failed");
            }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTests.SuccessSearch();
        BinarySearchTests.SuccessSearchOddSize();
        BinarySearchTests.TestForFails();
        BinarySearchTests.EmptyArray();
        BinarySearchTests.Similarelements();
    }
}