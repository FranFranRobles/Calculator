using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculate
    {
        private Stack<String> operators = new Stack<String>();
        private Queue<String> output = new Queue<String>();
        private Stack<double> evalStack = new Stack<double>();
        private char[] operatorTokens = { '+', '-', '*', '/', '^', '%' }; //P-E-MD-AS
        private char[] mathTokens = { 'e', 'L', 'l', 'p', '(', ')' };
        public void parse(String text)
        {
            parseString(text);
        }
        public double evaluate()
        {
            return Evaluate();
        }
        private double Evaluate()
        {
            int outputSize = output.Count();

            while (output.Count() != 0)
            {
                if (checkIfOperator(output.Peek()))
                {
                    double secondNum = evalStack.Pop();
                    double firstNum = evalStack.Pop();
                    string operatr = output.Dequeue();
                    evalStack.Push(answer(firstNum, secondNum, operatr));
                }
                else
                {
                    evalStack.Push(Double.Parse(output.Dequeue()));
                }
            }
            return evalStack.Pop();
        }
        private enum OpNames { Add = 0, Sub, Mult, Divide, Pow, Mod };
        private double answer(double firstNum, double secondNum, string operatr)
        {
            double ans = 0.0;
            switch ((OpNames)Array.IndexOf(operatorTokens, operatr.ToCharArray()[0]))
            {
                case OpNames.Add:
                    ans = firstNum + secondNum;
                    break;
                case OpNames.Sub:
                    ans = firstNum - secondNum;
                    break;
                case OpNames.Mult:
                    ans = firstNum * secondNum;
                    break;
                case OpNames.Divide:
                    ans = firstNum / secondNum;
                    break;
                case OpNames.Pow:
                    ans = Math.Pow(firstNum, secondNum);
                    break;
                case OpNames.Mod:
                    ans = firstNum % secondNum;
                    break;
                default:
                    throw new InvalidOperationException("invalid token");
            }
            return ans;
        }

        private bool checkIfOperator(string token)
        {
            bool isOp = false;
            if (token.Count() == 1 && Array.IndexOf(operatorTokens, token.ToCharArray()[0]) != -1)
            {
                isOp = true;
            }
            return isOp;
        }

        private void parseString(String text)
        {
            for (int index = 0; index < text.Length; index++)
            {
                char token = text.ElementAt(index);
                if (Array.IndexOf(operatorTokens, token) != -1)//Current token is an operator
                {
                    operatorToken(token);
                }
                else if (Array.IndexOf(mathTokens, token) != -1)
                {
                    mathToken(token);
                }
                else //token is a number
                {
                    index = numToken(text, index);
                }
            }

            while (operators.Count() != 0)
            {
                output.Enqueue(operators.Pop());
            }


        }

        private void mathToken(char token)
        {
            //private char[] mathTokens = { 'e', 'L', 'l', 'p', '(', ')' };
            int pos = Array.IndexOf(mathTokens, token);
            if (pos == 0) // 'e' token
            {
                output.Enqueue(token.ToString());
            }
            else if (pos == 1)//'L' token L = log 
            {

            }
            else if (pos == 2) // 'l' token l = ln
            {

            }
            else if (pos == 3)// 'p' token p = pie
            {
                output.Enqueue(token.ToString());
            }
            else if (pos == 4) //  '(' token
            {
                operators.Push(token.ToString());
            }
            else if (pos == 5) // ')' token
            {
                while (operators.Peek() != "(")
                {
                    output.Enqueue(operators.Pop());
                }
                operators.Pop();
            }
        }

        /*
* function adds token to queue following pemdas
*/
        private void operatorToken(char token)
        {
            if (operators.Count() == 0) // no other operators
            {
                operators.Push(token.ToString());
            }
            else
            {
                while (checkPrecedence(token))// set new precedence
                {
                    output.Enqueue(operators.Pop());
                }
                operators.Push(token.ToString());
            }
        }

        /*
*captures the len of the number
*/
        private int numToken(string text, int index)
        {
            String temp = "";
            int j = index; // right most index
            while (j <= (text.Length - 1) && (Char.IsDigit(text.ElementAt(j)) || text.ElementAt(j) == '.'))
            {
                temp += text.ElementAt(j).ToString();
                j++;
            }
            output.Enqueue(temp);
            index = j - 1;// new  curr index
            return index;
        }

        ///<summary>
        /// Returns true if the operator at the top of the stack is a higher precedence
        /// than the operator that is passed in. else false;
        /// </summary>

        private bool checkPrecedence(char oper)
        {
            if (operators.Count == 0)
            {
                return false;
            }
            //We have to have char, only way to get it is by getting the char array
            char[] stackOp = operators.Peek().ToCharArray();

            int opPos = Array.IndexOf(operatorTokens, oper);
            //We only need the first element. There should never be more than one element. 
            int stackPos = Array.IndexOf(operatorTokens, stackOp[0]);

            if (opPos <= stackPos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Char[] tokenList
        {
            get { return operatorTokens; }
        }
        public Stack<String> symbolStack
        {
            get { return operators; }
        }
        public Queue<String> DigitQueue
        {
            get { return output; }
        }
    }
}
