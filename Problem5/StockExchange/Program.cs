using Microsoft.VisualBasic;

namespace se;

public class Transaction{
    public int TRADETIME; 
    public long VOLUME;
    public string SECBOARD="", SECCODE="", TRADENO="";
    public double PRICE, ACCRUEDINT, YIELD, VALUE; 
    public Transaction(string[] s){
        this.TRADENO = s[0];
        this.TRADETIME = Convert.ToInt32(s[1]);
        this.SECBOARD = s[2];
        this.SECCODE = s[3];
        this.PRICE = Convert.ToDouble(s[4].Replace(".",","));
        this.VOLUME = Convert.ToInt64(s[5]);
        this.ACCRUEDINT = Convert.ToDouble(s[6].Replace(".",","));
        this.YIELD = Convert.ToDouble(s[7].Replace(".",","));
        this.VALUE = Convert.ToDouble(s[8].Replace(".",","));        
    }

}

public class Share{
    public string code = "";
    public double OP, CP, volume;
    public int transactions;
    public double growth;
    public Share(string code, double OP, double CP, double volume, int transactions){
        this.code = code;
        this.volume = volume;
        this.transactions = transactions;
        this.OP = OP;
        this.CP = CP;
        this.growth = (CP-OP)*100/OP;
    }

}

public class Reader
{
    public static List<Transaction> Read(string fn){
        var L = new List<Transaction>();
        using var stream = new FileStream(fn, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(stream);
        var line = reader.ReadLine();
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            // Console.WriteLine(line);
            L.Add(new Transaction(line.Split ('\t')));
        }
        return L;
    }
}

public class Processing{
    public static List<Share> BestandWorst(List<Transaction> T, int n){
        var S = new List<Share>();
        var L = T.Where(s => (s.SECBOARD == "TQBR" || s.SECBOARD =="FQBR")); 
        var selected = L.GroupBy(s => s.SECCODE);
        foreach(var share in selected){
            var A = L.Where(s => s.SECCODE == share.Key);
            double OP = A.First().PRICE;
            double CP = A.Last().PRICE;
            double volume = A.Sum(s =>s.VOLUME);
            int transactions = A.Count();
            S.Add(new Share(share.Key, OP, CP, volume, transactions));         
        }
        S = S.OrderByDescending(s => s.growth).ToList();
        return S.Take(n).Concat(S.TakeLast(n).Reverse()).ToList();
    }




}

public class Program
{
    static public void Main()
    {
        var fn = "../../../../trades.txt";
        var L = Reader.Read(fn);
        int n = 10;
        var S = Processing.BestandWorst(L, n);

        Console.WriteLine("{0} best:", n);
        for(int i = 0; i < n; i++){
            var share = S[i];
            Console.WriteLine("{0}) {1} {2:N2}%. Volume = {3} and {4} transactions", i+1, share.code, share.growth, share.volume, share.transactions);
        }
        Console.WriteLine("{0} worst:", n);
        for(int i = n; i < 2*n; i++){
            var share = S[i];
            Console.WriteLine("{0}) {1} {2:N2}%. Volume = {3} and {4} transactions", i+1-n, share.code, share.growth, share.volume, share.transactions);
        }

    } 
}