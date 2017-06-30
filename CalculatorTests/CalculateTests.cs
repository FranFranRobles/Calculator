using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// for future ref
//https://codeshare.io/21q7y0
// last run code metrics
 //calculator // 76  151 7   33  520
 //tests // 66  63  1   7   421


namespace Calculator.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void parseAdd()
        {
            Calculate calc = new Calculate();
            string add = "1+5";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual("1", nums.Dequeue(), "line 26");
            Assert.AreEqual("5", nums.Dequeue(), "line 27");
            Assert.AreEqual("+", nums.Dequeue(), "line 28");
            Assert.AreEqual(0, symbols.Count, "line 29");
        }
        [TestMethod()]
        public void parseSub()
        {
            Calculate calc = new Calculate();
            string sub = "1-5";
            calc.parse(sub);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual("1", nums.Dequeue(), "line 40");
            Assert.AreEqual("5", nums.Dequeue(), "line 41");
            Assert.AreEqual("-", nums.Dequeue(), "line 42");
            Assert.AreEqual(0, symbols.Count, "line 43");
        }
        [TestMethod()]
        public void parseMult()
        {
            Calculate calc = new Calculate();
            string mult = "1*5";
            calc.parse(mult);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual("1", nums.Dequeue(), "line 54");
            Assert.AreEqual("5", nums.Dequeue(), "line 55");
            Assert.AreEqual("*", nums.Dequeue(), "line 56");
            Assert.AreEqual(0, symbols.Count, "line 57");
        }
        [TestMethod()]
        public void parseDivide()
        {
            Calculate calc = new Calculate();
            string divide = "1/5";
            calc.parse(divide);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual("1", nums.Dequeue(), "line 68");
            Assert.AreEqual("5", nums.Dequeue(), "line 69");
            Assert.AreEqual("/", nums.Dequeue(), "line 70");
            Assert.AreEqual(0, symbols.Count, "line 71");
        }
        [TestMethod()]
        public void parseMod()
        {
            Calculate calc = new Calculate();
            string mod = "1%5";
            calc.parse(mod);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual("1", nums.Dequeue(), "line 82");
            Assert.AreEqual("5", nums.Dequeue(), "line 83");
            Assert.AreEqual("%", nums.Dequeue(), "line 84");
            Assert.AreEqual(0, symbols.Count, "line 85");
        }
        [TestMethod()]
        public void parsePow()
        {
            Calculate calc = new Calculate();
            string pow = "1^5";
            calc.parse(pow);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual("1", nums.Dequeue(), "line 96");
            Assert.AreEqual("5", nums.Dequeue(), "line 97");
            Assert.AreEqual("^", nums.Dequeue(), "line 98");
            Assert.AreEqual(0, symbols.Count, "line 99");
        }
        [TestMethod()]
        public void parseParenthesis()
        {
            Calculate calc = new Calculate();
            string add = "(1+5)";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsFalse(nums.Contains("("), "line 110");
            Assert.IsTrue(nums.Contains("+"), "line 111");
            Assert.IsFalse(nums.Contains(")"), "line 112");
            Assert.IsTrue(nums.Contains("1"), "Line 113");
            Assert.IsTrue(nums.Contains("5"), "line 114");
            Assert.AreEqual(0, symbols.Count, "line 115");
        }
        [TestMethod()]
        public void parseParenthesisAndMult()
        {
            Calculate calc = new Calculate();
            string add = "2+(1*5)";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsFalse(nums.Contains("("), "line 126");
            Assert.IsTrue(nums.Contains("+"), "line 127");
            Assert.IsTrue(nums.Contains("*"), "line 128");
            Assert.IsFalse(nums.Contains(")"), "line 129");
            Assert.IsTrue(nums.Contains("1"), "Line 130");
            Assert.IsTrue(nums.Contains("5"), "line 131");
            Assert.IsTrue(nums.Contains("2"), "line 132");
        }
        [TestMethod()]
        public void parseMultAndParenthesis()
        {
            Calculate calc = new Calculate();
            string add = "(2+1)*5";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsFalse(nums.Contains("("), "line 143");
            Assert.IsTrue(nums.Contains("+"), "line 144");
            Assert.IsTrue(nums.Contains("*"), "line 145");
            Assert.IsFalse(nums.Contains(")"), "line 146");
            Assert.IsTrue(nums.Contains("1"), "Line 147");
            Assert.IsTrue(nums.Contains("5"), "line 148");
            Assert.IsTrue(nums.Contains("2"), "line 149");
        }
        [TestMethod()]
        public void parseAddDec()
        {
            Calculate calc = new Calculate();
            string add = "1.1+5.1";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsTrue(nums.Contains("+"), "line 160");
            Assert.AreEqual(0, symbols.Count, "line 161");
            Assert.IsTrue(nums.Contains("1.1"), "Line 162");
            Assert.IsTrue(nums.Contains("5.1"), "line 163");
        }
        [TestMethod()]
        public void parseSubDec()
        {
            Calculate calc = new Calculate();
            string sub = "1.1-5.1";
            calc.parse(sub);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsTrue(nums.Contains("-"), "line 174");
            Assert.AreEqual(0, symbols.Count, "line 175");
            Assert.IsTrue(nums.Contains("1.1"), "Line 176");
            Assert.IsTrue(nums.Contains("5.1"), "line 177");
        }
        [TestMethod()]
        public void parseMultDec()
        {
            Calculate calc = new Calculate();
            string mult = "1.1*5.1";
            calc.parse(mult);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsTrue(nums.Contains("*"), "line 188");
            Assert.AreEqual(0, symbols.Count, "line 189");
            Assert.IsTrue(nums.Contains("1.1"), "Line 190");
            Assert.IsTrue(nums.Contains("5.1"), "line 191");
        }
        [TestMethod()] // start fixing code from right here
        public void parseDivideDec()
        {
            Calculate calc = new Calculate();
            string divide = "1.1/5.1";
            calc.parse(divide);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual(0, symbols.Count, "line 203");
            Assert.IsTrue(nums.Contains("/"), "line 204");
            Assert.IsTrue(nums.Contains("1.1"), "Line 205");
            Assert.IsTrue(nums.Contains("5.1"), "line 206");
        }
        [TestMethod()]
        public void parseModDec()
        {
            Calculate calc = new Calculate();
            string mod = "1.1%5.1";
            calc.parse(mod);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual(0, symbols.Count, "Line 217");
            Assert.IsTrue(nums.Contains("%"), "line 218");
            Assert.IsTrue(nums.Contains("1.1"), "Line 219");
            Assert.IsTrue(nums.Contains("5.1"), "line 220");
        }
        [TestMethod()]
        public void parsePowDec()
        {
            Calculate calc = new Calculate();
            string pow = "1.1^5.1";
            calc.parse(pow);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.AreEqual(0, symbols.Count, "Line 231 ");
            Assert.IsTrue(nums.Contains("^"), "line 232");
            Assert.IsTrue(nums.Contains("1.1"), "Line 233");
            Assert.IsTrue(nums.Contains("5.1"), "line 234");
        }
        [TestMethod()]
        public void parseParenthesisDec()
        {
            Calculate calc = new Calculate();
            string add = "(1.1+5.1)";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsFalse(nums.Contains("("), "line 245");
            Assert.IsTrue(nums.Contains("+"), "line 246");
            Assert.IsFalse(nums.Contains(")"), "line 247");
            Assert.IsTrue(nums.Contains("1.1"), "Line 248");
            Assert.IsTrue(nums.Contains("5.1"), "line 249");
            Assert.AreEqual(0, symbols.Count, " line 250");
        }
        [TestMethod()]
        public void parseParenthesisAndMultDec()
        {
            Calculate calc = new Calculate();
            string add = "2.1+(1.1*5.1)";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsFalse(nums.Contains("("), "line 261");
            Assert.IsTrue(nums.Contains("+"), "line 262");
            Assert.IsTrue(nums.Contains("*"), "line 263");
            Assert.IsFalse(nums.Contains(")"), "line 264");
            Assert.AreEqual(0, symbols.Count, " line 265");
            Assert.IsTrue(nums.Contains("1.1"), "Line 266");
            Assert.IsTrue(nums.Contains("5.1"), "line 267");
            Assert.IsTrue(nums.Contains("2.1"), "line 268");
        }
        [TestMethod()]
        public void parseMultAndParenthesisDec()
        {
            Calculate calc = new Calculate();
            string add = "(2.1+1.1)*5.1";
            calc.parse(add);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;

            Assert.IsFalse(nums.Contains("("), "line 279");
            Assert.IsTrue(nums.Contains("+"), "line 280");
            Assert.IsTrue(nums.Contains("*"), "line 281");
            Assert.IsFalse(nums.Contains(")"), "line 282");
            Assert.AreEqual(0, symbols.Count, "line 283");
            Assert.IsTrue(nums.Contains("1.1"), "Line 284");
            Assert.IsTrue(nums.Contains("5.1"), "line 285");
            Assert.IsTrue(nums.Contains("2.1"), "line 286");
        } //L = log, l = ln, p = pie
        [TestMethod()]
        public void parseLn()
        {
            Calculate calc = new Calculate();
            string ln = "l5";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 296");
            Assert.IsTrue(nums.Contains("l5"), "line 297");
        }
        [TestMethod()]
        public void parseLnAndOperate()
        {
            Calculate calc = new Calculate();
            string ln = "2+l5";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 298");
            Assert.IsTrue(nums.Contains("+"), "line 299");
            Assert.IsTrue(nums.Contains("l5"), "line 300");
            Assert.IsTrue(nums.Contains("2"), "line 301");
        }
        [TestMethod()]
        public void parseLog()
        {
            Calculate calc = new Calculate();
            string ln = "L5";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 319");
            Assert.IsTrue(nums.Contains("L5"), "line 320");
        }
        [TestMethod()]
        public void parseLogAndOperate()
        {
            Calculate calc = new Calculate();
            string ln = "2+L5";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 330");
            Assert.IsTrue(nums.Contains("+"), "line 331");
            Assert.IsTrue(nums.Contains("L5"), "line 332");
            Assert.IsTrue(nums.Contains("2"), "line 333");
        }
        [TestMethod()]
        public void parsePie()
        {
            Calculate calc = new Calculate();
            string ln = "p";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 342");
            Assert.IsTrue(nums.Contains("p"), "line 243");
        }
        [TestMethod()]
        public void parsePieAndOperate()
        {
            Calculate calc = new Calculate();
            string ln = "2+p";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 353");
            Assert.IsTrue(nums.Contains("+"), "line 354");
            Assert.IsTrue(nums.Contains("p"), "line 355");
            Assert.IsTrue(nums.Contains("2"), "line 356");
        }
        [TestMethod()]
        public void parseLnAndOperateDec()
        {
            Calculate calc = new Calculate();
            string ln = "2.1+l5.1";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 366");
            Assert.IsTrue(nums.Contains("+"), "line 367");
            Assert.IsTrue(nums.Contains("l5.1"), "line 368");
            Assert.IsTrue(nums.Contains("2.1"), "line 369");
        }
        [TestMethod()]
        public void parseLogDec()
        {
            Calculate calc = new Calculate();
            string ln = "L5.1";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 378");
            Assert.IsTrue(nums.Contains("L5.1"), "line 379");
        }
        [TestMethod()]
        public void parseLogAndOperateDec()
        {
            Calculate calc = new Calculate();
            string ln = "2.1+L5.1";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 389");
            Assert.IsTrue(nums.Contains("+"), "line 390");
            Assert.IsTrue(nums.Contains("L5.1"), "line 391");
            Assert.IsTrue(nums.Contains("2.1"), "line 392");
        }
        [TestMethod()]
        public void parsePieAndOperateDec()
        {
            Calculate calc = new Calculate();
            string ln = "2.1+p";
            calc.parse(ln);
            var nums = calc.DigitQueue;
            var symbols = calc.symbolStack;
            Assert.AreEqual(0, symbols.Count, "line 402");
            Assert.IsTrue(nums.Contains("+"), "line 403");
            Assert.IsTrue(nums.Contains("p"), "line 404");
            Assert.IsTrue(nums.Contains("2.1"), "line 405");
        }
        [TestMethod()]
        public void evalAdd()
        {
            Calculate calc = new Calculate();
            string add = "1+5";
            calc.parse(add);

            Assert.AreEqual(6, calc.evaluate(), " line 414");
        }
        [TestMethod()]
        public void evalSub()
        {
            Calculate calc = new Calculate();
            string sub = "1-5";
            calc.parse(sub);
            Assert.AreEqual(-4, calc.evaluate(), "line 422");
        }
        [TestMethod()]
        public void evalMult()
        {
            Calculate calc = new Calculate();
            string mult = "1*5";
            calc.parse(mult);
            Assert.AreEqual(5, calc.evaluate(), "line 430");
        }
        [TestMethod()]
        public void evalDivide()
        {
            Calculate calc = new Calculate();
            string divide = "1/5";
            calc.parse(divide);
            Assert.AreEqual(.2, calc.evaluate(), "line 438");
        }
        [TestMethod()]
        public void evalMod()
        {
            Calculate calc = new Calculate();
            string mod = "1%5";
            calc.parse(mod);
            Assert.AreEqual(1, calc.evaluate(), "line 446");
        }
        [TestMethod()]
        public void evalPow()
        {
            Calculate calc = new Calculate();
            string pow = "2^5";
            calc.parse(pow);
            Assert.AreEqual(32, calc.evaluate(), "line 454");
        }
        [TestMethod()]
        public void evalParenthesis()
        {
            Calculate calc = new Calculate();
            string add = "(1+5)";
            calc.parse(add);
            Assert.AreEqual(6, calc.evaluate(), "line 462");
        }
        [TestMethod()]
        public void evalParenthesisAndMult()
        {
            Calculate calc = new Calculate();
            string add = "2+(1*5)";
            calc.parse(add);
            Assert.AreEqual(7, calc.evaluate(), "line 470");
        }
        [TestMethod()]
        public void evalMultAndParenthesis()
        {
            Calculate calc = new Calculate();
            string add = "(2+1)*5";
            calc.parse(add);
            Assert.AreEqual(10, calc.evaluate(), "line 478");
        }
        [TestMethod()]
        public void evalAddDec()
        {
            Calculate calc = new Calculate();
            string add = "1.1+5.1";
            double val = 1.1 + 5.1;
            calc.parse(add);
            Assert.AreEqual(val, calc.evaluate(), "line 486");
        }
        [TestMethod()]
        public void evalSubDec()
        {
            Calculate calc = new Calculate();
            string sub = "1.1-5.1";
            double val = 1.1 - 5.1;
            calc.parse(sub);
            Assert.AreEqual(val, calc.evaluate(), "line 494");
        }
        [TestMethod()]
        public void evalMultDec()
        {
            Calculate calc = new Calculate();
            string mult = "1.1*5.1";
            calc.parse(mult);
            Assert.AreEqual(5.61, calc.evaluate(), "line 502");
        }
        [TestMethod()] // start fixing code from right here
        public void evalDivideDec()
        {
            Calculate calc = new Calculate();
            string divide = "2.5/.5";
            calc.parse(divide);
            Assert.AreEqual(5, calc.evaluate(), "line 510");
        }
        [TestMethod()]
        public void evalModDec()
        {
            Calculate calc = new Calculate();
            string mod = "1.1%5.1";
            double val = 1.1 % 5.1;
            calc.parse(mod);
            Assert.AreEqual(val, calc.evaluate(), "line 518");
        }
        [TestMethod()]
        public void evalPowDec()
        {
            Calculate calc = new Calculate();
            string pow = "6.25^1.5";
            calc.parse(pow);
            Assert.AreEqual(15.625, calc.evaluate(), "line 526");
        }
        [TestMethod()]
        public void evalParenthesisDec()
        {
            Calculate calc = new Calculate();
            string add = "(1.1+5.1)";
            double val = 1.1 + 5.1;
            calc.parse(add);
            Assert.AreEqual(val, calc.evaluate(), "line 534");
        }
        [TestMethod()]
        public void evalParenthesisAndMultDec()
        {
            Calculate calc = new Calculate();
            string add = "2.1+(1.1*5.1)";
            calc.parse(add);
            Assert.AreEqual(7.71, calc.evaluate(), "line 542");
        }
        [TestMethod()]
        public void evalMultAndParenthesisDec()
        {
            Calculate calc = new Calculate();
            string add = "(2.1+1.1)*5.1";
            calc.parse(add);
            Assert.AreEqual(16.32, calc.evaluate(), "line 550");
        }
        [TestMethod()]
        public void evalLn()
        {
            Calculate calc = new Calculate();
            string ln = "l5";
            calc.parse(ln);
            double val = Math.Round(Math.Log(10), 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 559");
        }
        [TestMethod()]
        public void evalLnAndOperate()
        {
            Calculate calc = new Calculate();
            string ln = "2+l5";
            calc.parse(ln);
            double val = Math.Round((2 + Math.Log(5)), 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 568");
        }
        [TestMethod()]
        public void evalLog()
        {
            Calculate calc = new Calculate();
            string ln = "L5";
            calc.parse(ln);
            double val = Math.Round(Math.Log10(5), 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 576");
        }
        [TestMethod()]
        public void evalLogAndOperate()
        {
            Calculate calc = new Calculate();
            string ln = "2+L5";
            calc.parse(ln);
            double val = Math.Round((2 + Math.Log10(5)), 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 585");
        }
        [TestMethod()]
        public void evalPie()
        {
            Calculate calc = new Calculate();
            string ln = "p";
            calc.parse(ln);
            Assert.AreEqual(Math.Round(Math.PI, 3), Math.Round(calc.evaluate(), 3), "line 592");
        }
        [TestMethod()]
        public void evalPieAndOperate()
        {
            Calculate calc = new Calculate();
            string ln = "2+p";
            calc.parse(ln);
            double val = Math.Round(2 + Math.PI, 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 600");
        }
        [TestMethod()]
        public void evalLnAndOperateDec()
        {
            Calculate calc = new Calculate();
            string ln = "2.1+l5.1";
            calc.parse(ln);
            double val = Math.Round(2.1 + Math.Log(5.1), 4);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 4), "line 609");
        }
        [TestMethod()]
        public void evalLogDec()
        {
            Calculate calc = new Calculate();
            string ln = "L5.1";
            calc.parse(ln);
            Assert.AreEqual(Math.Round(Math.Log10(5.1), 3), Math.Round(calc.evaluate(), 3), "line 616");
        }
        [TestMethod()]
        public void evalLogAndOperateDec()
        {
            Calculate calc = new Calculate();
            string ln = "2.1+L5.1";
            calc.parse(ln);
            double val = Math.Round(2.1 + Math.Log10(5.1), 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 625");
        }
        [TestMethod()]
        public void evalPieAndOperateDec()
        {
            Calculate calc = new Calculate();
            string ln = "2.1+p";
            calc.parse(ln);
            double val = Math.Round(2.1 + Math.PI, 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3), "line 634");
        }
        [TestMethod()]
        public void parseNatE()
        {
            Calculate calc = new Calculate();
            string e = "e";
            calc.parse(e);
            var nums = calc.DigitQueue;
            Assert.IsTrue(nums.Contains("e"), "line 651");
        }
        [TestMethod()]
        public void parseNatEAndAdd()
        {
            Calculate calc = new Calculate();
            string e = "e+2";
            calc.parse(e);
            var nums = calc.DigitQueue;
            Assert.IsTrue(nums.Contains("e"), "line 660");
            Assert.IsTrue(nums.Contains("+"), "line 661");
            Assert.IsTrue(nums.Contains("2"), "line 662");
        }
        [TestMethod()]
        public void parseNatEAndPow()
        {
            Calculate calc = new Calculate();
            string e = "e^2";
            calc.parse(e);
            var nums = calc.DigitQueue;
            Assert.IsTrue(nums.Contains("e"), "line 671");
            Assert.IsTrue(nums.Contains("^"), "line 672");
            Assert.IsTrue(nums.Contains("2"), "line 673");
        }
        [TestMethod()]
        public void evalNatE()
        {
            Calculate calc = new Calculate();
            string e = "e";
            calc.parse(e);
            double val = Math.Round(Math.E, 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3));
        }
        [TestMethod()]
        public void evalNatEAndAdd()
        {
            Calculate calc = new Calculate();
            string e = "e+2";
            calc.parse(e);
            double val = Math.Round(Math.E + 2, 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3));
        }
        [TestMethod()]
        public void evalNatEAndPow()
        {
            Calculate calc = new Calculate();
            string e = "e^2";
            calc.parse(e);
            double val = Math.Round(Math.Pow(Math.E, 2), 3);
            Assert.AreEqual(val, Math.Round(calc.evaluate(), 3));
        }

    }
}