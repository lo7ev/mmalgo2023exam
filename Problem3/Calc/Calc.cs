namespace calc;
public class Calculator
{
    private static Dictionary<char, int> operationPriority = new() {
        {'(', 0},
        {'+', 1},
        {'-', 1},
        {'*', 2},
        {'/', 2},
        {'m', 3}	//	Унарный минус
    };

    public static double Calc(string s)
    {
        Stack<double> stack = new();

        s = string.Join("", s.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        string postfix = SortStation(s);

        for (int i = 0; i < postfix.Length; i++)
        {
            char c = postfix[i];
            if (Char.IsDigit(c))
            {
                string number = ReadNumber(postfix, ref i);
                stack.Push(Convert.ToDouble(number));
            }
            else if (operationPriority.ContainsKey(c))
            {
                if (c == 'm')
                {
                    double last = 0.0;
                    if(stack.Count > 0 ){
                        last = stack.Pop();
                    }
                    stack.Push(Execute('-', 0, last));
                    continue;
                }
                            
                double first = 0.0;
                double second = 0.0;
                if(stack.Count > 0 ){
                        second = stack.Pop();
                }
                if(stack.Count > 0 ){
                        first = stack.Pop();
                }                            
                //	Получаем результат операции и заносим в стек
                stack.Push(Execute(c, first, second));
            }
        }
            
        return stack.Pop();
    }

    private static string ReadNumber(string s, ref int i)
    {
        string number = "";
        char c;
        for (; i < s.Length; i++)
        {
            c = s[i];
            if (Char.IsDigit(c) || c == ',' || c == '.'){
                number += c;
            } 
            else
            {
                i--;
                break;
            }
        }
        return number;
    }

    private static string SortStation(string s)
    {
        string postfix = "";
        Stack<char> stack = new();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            
            if (Char.IsDigit(c))
            {
                postfix += ReadNumber(s, ref i) + " ";
            }
            else if (c == '(')
            {
                    stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    postfix += stack.Pop();
                }
                stack.Pop();
            }
            else if (operationPriority.ContainsKey(c))
            {
                char op = c;
                //	Если унарный минус
                if (op == '-' && (i == 0 || (i > 1 && operationPriority.ContainsKey( s[i-1] ))))
               {
                    op = 'm';
               }
                        
                //	Заносим в выходную строку все операторы из стека, имеющие более высокий приоритет
                while (stack.Count > 0 && ( operationPriority[stack.Peek()] >= operationPriority[op]))
                        postfix += stack.Pop();
                stack.Push(op);
            }
        }
        foreach (char op in stack)
        {
            postfix += op;
        }

        return postfix;
    }

    private static double Execute(char op, double first, double second){
        switch(op){
        case '+':
             return first + second;
        case '-':
             return first - second;
        case '*':
             return first * second;
        case '/':
             return first / second;
        case '^':
             return Math.Pow(first, second);
        default:
            return 0;
        }
    } 

    
}