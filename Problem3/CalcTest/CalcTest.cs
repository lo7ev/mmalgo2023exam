using calc;
namespace calc.test;
public class CalcTest{
    public static void Count(){
        string expression = "15/(7-(1+1))*3-(2+(1+1))*15/(7-(200+1))*3-(2+(1+1))*(15/(7-(1+1))*3-(2+(1+1))+15/(7-(1+1))*3-(2+(1+1)))";
        double t = Calculator.Calc(expression);
        double p = -2917.0/97;
        if(Math.Abs(t-p) < 1e-10 ){
             Console.WriteLine("Count test: passed");
        }else{
            Console.WriteLine("Count test: failed");
        }

    }
    public static void Fails(){
        string expression = "(2+5))";
        double t = 0;
        bool p = true;
        try{
            t = Calculator.Calc(expression);
        }catch(InvalidOperationException e){
            Console.WriteLine("Fails test (missing bracket): passed. " + e.Message);
            p = false;
        }
        if(p)
            Console.WriteLine("Fails test: failed");
    }
}

public class Program
{
    static public void Main()
    {
        CalcTest.Count();
        CalcTest.Fails();   
    } 
}