/*Coding Challenge:

Write a command-line program in the language of your choice that will take operations on fractions as an input and produce a fractional result. 

Legal operators shall be *, /, +, - (multiply, divide, add, subtract)

Operands and operators shall be separated by one or more spaces

Mixed numbers will be represented by whole_numerator/denominator. e.g. "3_1/4"

Improper fractions and whole numbers are also allowed as operands 

Example run:

? 1 / 2 * 3_3 / 4

= 1_7 / 8

? 2_3 / 8 + 9 / 8

= 3_1 / 2
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace QuestCodeChallenge
{
    public class MathCalculation
    {
        public static bool CheckUserInputs(string inputStr)
        {
            bool pass = false;
            Regex reg = new Regex("^[0-9+*-/.]+$");
            if (inputStr!=null && inputStr.Trim().Length>0)
            {
                inputStr = inputStr.Replace(" ", "");
                if (inputStr.Contains('?'))
                {
                    inputStr = inputStr.Substring(inputStr.IndexOf('?')+1);
                }
                pass = reg.IsMatch(inputStr.Trim());
            }
            
            return pass;
        }
        public static decimal Calculate(string inputStr, out string errorMessage)
        {
            decimal result=0;
            decimal x =0, y = 0;
           
            decimal newItem= 0;
            Dictionary<char, int> operatorDict = new Dictionary<char, int>
            {
                {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2}
            };
            errorMessage = "";
            List<string> items = GetMathItems(inputStr);
            for (int i = operatorDict.Values.Max(); i >= operatorDict.Values.Min(); i--)
            {
                while (items.Count >= 3 && items.Any(s => s.Length == 1 && operatorDict.Where(p => p.Value == i).Select(p => p.Key).Contains(s[0])))
                {
                    int index = items.FindIndex(e => e.Length == 1 && operatorDict.Where(op => op.Value == i).Select(op => op.Key).Contains(e[0]));
                    try
                    {
                        x = Convert.ToDecimal(items[index - 1]);
                        y = Convert.ToDecimal(items[index + 1]);
                        switch (items[index][0])
                        {
                            case '+':
                                newItem = x + y;
                                break;
                            case '-':
                                newItem = x - y;
                                break;
                            case '*':
                                newItem = x * y;
                                break;
                            case '/':
                                newItem = x / y;
                                break;
                            default:
                                errorMessage = "Invalid operator";
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        errorMessage = e.Message;
                    }
                    items[index - 1] = newItem.ToString();
                    items.RemoveRange(index, 2);

                 }
            }
           if (items.Count>0)
            {
               decimal.TryParse(items[0], out result);
            }
            return result;
        }
        private static List<string> GetMathItems(string inputStr)
        {
            List<string> dataList = new List<string>();
            List<char> operators = new List<char> { '+', '-', '*', '/' };
            string tempString = "";
           
            inputStr = inputStr.Replace(" ", "").Replace("?","");
            char[] dataArray = inputStr.ToCharArray();
            for (int i=0; i<dataArray.Length; i++)
            {
                if (operators.Contains(dataArray[i]))
                {
                    if (tempString.Length>0)
                    {
                        dataList.Add(tempString);
                    }
                    dataList.Add(dataArray[i].ToString());
                    tempString = "";
                }
                else
                {
                    tempString += dataArray[i];
                    if (i==dataArray.Length-1)
                    {
                        dataList.Add(tempString);
                    }
                }
            }
            return dataList;

        }
    }
}
