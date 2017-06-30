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
        private enum OpNames { Add = 0, Sub, Mult, Divide, Pow, Mod };
        private enum mathNames { E = 0,Ln,Log,Pie};
        /// <summary>
        /// function  parses given string for later use and evaluation
        /// </summary>
        /// <param name="text">string to parse</param>
        public void parse(String text)
        {
            parseString(text);
        }
        /// <summary>
        /// function does the sumation of the parsed string
        /// </summary>
        /// <returns>returns the total of the all given operations</returns>
        public double evaluate()
        {
            return Evaluate();
        }
        /// <summary>
        /// function does the sumation of the parsed string
        /// </summary>
        /// <returns>returns the total of the all given operations</returns>
        private double Evaluate()
        {
            int outputSize = output.Count();
            char[] mathsymbol = { 'e', 'l', 'L', 'p' };
            int mathIndex = 0;
            while (output.Count() != 0)
            {
                mathIndex = Array.IndexOf(mathsymbol, output.Peek()[0]);
                if (checkIfOperator(output.Peek()))
                {
                    double secondNum = evalStack.Pop();
                    double firstNum = evalStack.Pop();
                    string operatr = output.Dequeue();
                    evalStack.Push(answer(firstNum, secondNum, operatr));
                }
                else if (mathIndex != -1) // if math symbol
                {
                    convert(output.Dequeue(),mathIndex);
                }
                else
                {
                    evalStack.Push(Double.Parse(output.Dequeue()));
                }
            }
            return evalStack.Pop();
        }
        /// <summary>
        /// function converts the given token to the correct math symbol
        /// </summary>
        /// <param name="token">the obj to parse</param>
        /// <param name="operation">the given operation to do</param>
        private void convert(string token,int operation)
        {
            double tempNum = 0.0;
            switch ((mathNames)operation)
            {
                case mathNames.E:
                    evalStack.Push(Math.E);
                    break;
                case mathNames.Ln:
                    tempNum = Double.Parse((token.Substring(1, token.Count() - 1)));
                    evalStack.Push(Math.Log(tempNum));
                    break;
                case mathNames.Log:
                    tempNum = Double.Parse((token.Substring(1, token.Count() - 1)));
                    evalStack.Push(Math.Log10(tempNum));
                    break;
                case mathNames.Pie:
                    evalStack.Push(Math.PI);
                    break;
                default:
                    throw new FormatException("invalid token");
            }
        }
        /// <summary>
        /// function sums two numbers using the given math operator symbol
        /// </summary>
        /// <param name="firstNum">number to evaluate</param>
        /// <param name="secondNum">number to evaluate</param>
        /// <param name="operatr">math operator symbol</param>
        /// <returns></returns>
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
        /// <summary>
        /// functions checks if the current token is a math operator symbol
        /// </summary>
        /// <param name="token"> current item to check</param>
        /// <returns>returns true if token is a math operator</returns>
        private bool checkIfOperator(string token)
        {
            bool isOp = false;
            if (token.Count() == 1 && Array.IndexOf(operatorTokens, token.ToCharArray()[0]) != -1)
            {
                isOp = true;
            }
            return isOp;
        }
        /// <summary>
        /// function parses a given string into a postfix notation queue for later use for
        /// later calculation
        /// <remarks>when finished the parsed string follows pemdas</remarks>
        /// </summary>
        /// <param name="text"></param>
        private void parseString(String text)
        {
            char token;
            int mathTokenIndex = 0;
            for (int index = 0; index < text.Length; index++)
            {
                token = text.ElementAt(index);
                mathTokenIndex = Array.IndexOf(mathTokens, token);
                if (Array.IndexOf(operatorTokens, token) != -1)//Current token is an operator
                {
                    operatorToken(token);
                }
                else if (mathTokenIndex != -1)
                {
                    if (mathTokenIndex != 1 && mathTokenIndex != 2)
                    {
                        mathToken(token);
                    }
                    else
                    {
                        string logType = text[index] == 'L' ? "L" : "l";
                        string tempNum = logToken(text, ref index);
                        output.Enqueue(logType + tempNum);
                    }
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
        /// <summary>
        ///  Function  parses the token to a valid format
        /// </summary>
        /// <param name="token">current math token</param>
        private void mathToken(char token)
        {
            int pos = Array.IndexOf(mathTokens, token);
            if (pos == 0) // 'e' token
            {
                output.Enqueue(token.ToString());
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
        /// <summary>
        /// function parses current token to valid log format
        /// </summary>
        /// <param name="token"> string to parse</param>
        /// <param name="index">location on string</param>
        /// <returns> string </returns>
        private string logToken(string token, ref int index)
        {
            string temp = "";
            int j = ++index; // right most index
            while (j <= (token.Length - 1) && (Char.IsDigit(token.ElementAt(j)) || token.ElementAt(j) == '.'))
            {
                temp += token.ElementAt(j).ToString();
                j++;
            }
            index = j - 1;// new  curr index
            return temp;
        }
        /// <summary>
        ///  function adds current token to queue follow pemdas
        /// </summary>
        /// <param name="token"></param>
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
        ///<sumary>
        ///parses a number token to valid format
        ///</summary>
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
        /// <summary>
        /// returns a stack of any math operator left in the stack
        /// </summary>
        public Stack<String> symbolStack
        {
            get { return operators; }
        }
        /// <summary>
        ///  returns an ordered queue of math operations following pemdas 
        /// </summary>
        public Queue<String> DigitQueue
        {
            get { return output; }
        }
    }
}
