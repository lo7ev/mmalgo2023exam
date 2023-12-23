using csr;
namespace csr.test;

class CSRTest{
    public static void Test1(){
        
        var A = new CSRMatrix([1,2,3],[0,2,1],[0,2,3,3]);
        var B = new CSRMatrix([1,2,3],[0,2,2],[0,2,2,3]);
        var CC = new CSRMatrix([1,8],[0,2],[0,2,2,2]);
        var C = A.Multiply(B);

        if(C.val.SequenceEqual(CC.val) && C.col.SequenceEqual(CC.col) && C.row.SequenceEqual(CC.row)){
            Console.WriteLine("Test1: passed");
        }else{
            Console.WriteLine("Test1: failed");
        }
    } 
    public static void Test2(){

        var A = new CSRMatrix([1,2,3,4],[0,1,2,3],[0,1,2,3,4]);
        var B = new CSRMatrix([1,1,1,1],[3,1,2,0],[0,1,2,3,4]);
        var CC = new CSRMatrix([1,2,3,4],[3,1,2,0],[0,1,2,3,4]);
        var C = A.Multiply(B);

        if(C.val.SequenceEqual(CC.val) && C.col.SequenceEqual(CC.col) && C.row.SequenceEqual(CC.row)){
            Console.WriteLine("Test2: passed");
        }else{
            Console.WriteLine("Test2: failed");
        }
        
    }
    public static void Test3(){
        
        var A = new CSRMatrix([1,2,3,2],[0,4,2,4],[0,1,2,2,4,4]);
        var B = new CSRMatrix([2,3,3,1,1],[0,1,3,3,4],[0,1,1,3,3,5]);
        var CC = new CSRMatrix([2,2,2,9,11,2],[0,3,4,1,3,4],[0,1,3,3,6,6]);
        var C = A.Multiply(B);

        if(C.val.SequenceEqual(CC.val) && C.col.SequenceEqual(CC.col) && C.row.SequenceEqual(CC.row)){
            Console.WriteLine("Test3: passed");
        }else{
            Console.WriteLine("Test3: failed");
        }
    }
}

public class Program
{   static public void Main()
    {
        CSRTest.Test1();
        CSRTest.Test2();
        CSRTest.Test3();
    } 
}