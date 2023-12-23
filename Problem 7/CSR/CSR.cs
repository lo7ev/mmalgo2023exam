using System.Runtime.CompilerServices;

namespace csr;
public class CSRMatrix{

    public int[] val, col, row;
    public int n;

    public CSRMatrix(int[] val, int[] col, int[] row){
        this.val = val;
        this.col = col;
        this.row = row;
        n = row.Length - 1;
    }

    public void PrintMatrix(){
        int count = 0;
        int r = 1;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                int e = 0;
                if(count < val.Length){
                    if(r-1 == i){
                        if (j == col[count]){
                            e = val[count];
                            count++;
                        }
                    }
                    while(count==row[r]){
                        if(r<n)
                            r+=1;
                        else
                            break;    
                    }
                }
                Console.Write(e.ToString()+" ");
            }
            Console.WriteLine("");
        }
    }
    public void Print(){
        Console.WriteLine("values [{0}]", string.Join(", ", val));
        Console.WriteLine("col index [{0}]", string.Join(", ", col));
        Console.WriteLine("rows [{0}]", string.Join(", ", row));
    }

    public CSRMatrix Multiply(CSRMatrix B){

        var newvals = new List<int>();
        var newcols = new List<int>();
        int[] newrows = new int[n+1];
        newrows[0]=0;

        int count = 0;
        
        //tranform csr to csc
        int[] Btval = new int[B.val.Length];
        int[] Btcol = new int[B.val.Length];
        int[] Btrow = new int[B.n+1];

        int[] cnt = new int[n];
        for (int k = 0; k < B.val.Length; k++)
        {
            int col = B.col[k];
            cnt[col] += 1;
        }

        for (int i = 1; i < n + 1; i++)
        {
            Btrow[i] = Btrow[i - 1] + cnt[i - 1];
        }

        for (int row = 0; row < B.n; row++)
        {
            for (int j = B.row[row]; j < B.row[row + 1]; j++)
            {
                int col = B.col[j];
                int dest = Btrow[col];
                Btcol[dest] = row;
                Btval[dest] = B.val[j];
                Btrow[col] += 1;
            }
        }

        for(int i=B.n; i>0; i--){
            Btrow[i]=Btrow[i-1];
        }
        Btrow[0]=0;
        
        // Multiply CSR by CSC
        for(int i = 1; i < n+1; i++){
            for(int j = 1; j < n+1; j++){
                
                var elA = row[i]-row[i-1];
                var elB = Btrow[j]-Btrow[j-1];
                int istart = row[i-1];
                int iend = istart + elA;
                int jstart = Btrow[j-1];
                int jend = jstart + elB;
                int p = 0;
            
                for(int k = istart; k < iend; k++){
                    for(int l = jstart; l < jend; l++){
                        if(col[k]==Btcol[l]){
                            p += val[k]*Btval[l];
                        }
                    }
                }
                if(p!=0){
                    newvals.Add(p);
                    newcols.Add(j-1);
                    count++;
                }
                
            }
            newrows[i] = count;
        }    
        return new CSRMatrix(newvals.ToArray(), newcols.ToArray(), newrows.ToArray());    
    }
}