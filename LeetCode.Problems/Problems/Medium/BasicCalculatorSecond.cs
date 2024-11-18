using Xunit;

namespace LeetCode.Problems.Problems.Medium;

/// <summary>
/// Problem: 227. Basic Calculator II
///
/// Tags: Math, String
/// Difficulty: Medium
/// URL: https://leetcode.com/problems/basic-calculator-ii/
/// Given a string s which represents an expression, evaluate this expression and return its value. 
///
/// The integer division should truncate toward zero.
///
///     You may assume that the given expression is always valid. All intermediate results will be in the range of [-231, 231 - 1].
///
///     Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().
///
///  
///
/// Example 1:
///
/// Input: s = "3+2*2"
/// Output: 7
/// Example 2:
///
/// Input: s = " 3/2 "
/// Output: 1
/// Example 3:
///
/// Input: s = " 3+5 / 2 "
/// Output: 5
///
/// Constraints:
///
/// 1 <= s.length <= 3 * 105
/// s consists of integers and operators ('+', '-', '*', '/') separated by some number of spaces.
///     s represents a valid expression.
///     All the integers in the expression are non-negative integers in the range [0, 231 - 1].
///     The answer is guaranteed to fit in a 32-bit integer.
/// </summary>
public class BasicCalculatorSecond
{
    /*
     * TASK DESCRIPTION:
     * Write a program to evaluate a mathematical string expression containing:
     * - Non-negative integers
     * - Addition (`+`), subtraction (`-`), multiplication (`*`), division (`/`)
     * - Parentheses (`(`, `)`)
     * - Spaces (which should be ignored)
     *
     * The program must handle:
     * 1. Operator precedence: Multiplication (`*`) and Division (`/`) take precedence over Addition (`+`) and Subtraction (`-`).
     * 2. Parentheses: Expressions inside parentheses are evaluated first.
     *
     * CONSTRAINTS:
     * - The input is guaranteed to be a valid mathematical expression.
     * - No division by zero occurs in the input.
     */

    /*
     * EXPLANATION:
     * 1. Remove all spaces from the input string for easier processing.
     * 2. Evaluate the expression using the following logic:
     *    - If a number is encountered, process it based on the last operator.
     *    - If `+` or `-` is encountered, store the last result and change the sign.
     *    - If `*` or `/` is encountered, perform the operation immediately on the last number.
     *    - If `(` is encountered, solve the sub-expression recursively.
     * 3. At the end of the string, add any remaining number to the final result.
     *
     * EXAMPLES:
     * Example 1:
     *   Input:  "2 + 3 * 4"
     *   Output: 14
     *   Explanation: Multiplication is performed before addition.
     *
     * Example 2:
     *   Input:  "10 / 2 + 3"
     *   Output: 8
     *   Explanation: Division is performed before addition.
     *
     * Example 3:
     *   Input:  "(2 + 3) * 4"
     *   Output: 20
     *   Explanation: Parentheses are evaluated first.
     */

    public int CalculateWithStack(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        Stack<int> stack = new Stack<int>();
        int num = 0;
        char sign = '+';
        int n = s.Length;

        for (int i = 0; i < n; i++)
        {
            char ch = s[i];

            if (char.IsDigit(ch))
            {
                num = num * 10 + (ch - '0');
            }

            if ((!char.IsDigit(ch) && ch != ' ') || i == n - 1)
            {
                switch (sign)
                {
                    case '+':
                        stack.Push(num);
                        break;
                    case '-':
                        stack.Push(-num);
                        break;
                    case '*':
                        stack.Push(stack.Pop() * num);
                        break;
                    case '/':
                        stack.Push(stack.Pop() / num);
                        break;
                }

                sign = ch;
                num = 0;
            }
        }

        int result = 0;
        while (stack.Count > 0)
        {
            result += stack.Pop();
        }

        return result;
    }
    
    public int CalculateWithoutStack(string s)
    {
        int index = 0; // Declare index as a local variable
        return Evaluate(s.Replace(" ", ""), ref index);
    }

    private int Evaluate(string s, ref int index)
    {
        int result = 0;
        int lastNumber = 0;
        int num = 0;
        char sign = '+';

        while (index < s.Length)
        {
            char ch = s[index++];

            if (char.IsDigit(ch))
            {
                num = num * 10 + (ch - '0');
            }

            if (ch == '(')
            {
                // Recursively evaluate the expression within parentheses
                num = Evaluate(s, ref index);
            }

            if (!char.IsDigit(ch) || index == s.Length || ch == ')')
            {
                if (sign == '+')
                {
                    result += lastNumber;
                    lastNumber = num;
                }
                else if (sign == '-')
                {
                    result += lastNumber;
                    lastNumber = -num;
                }
                else if (sign == '*')
                {
                    lastNumber *= num;
                }
                else if (sign == '/')
                {
                    lastNumber /= num; // Use integer division
                }

                if (ch == ')')
                    break;

                sign = ch;
                num = 0;
            }
        }

        return result + lastNumber;
    }

}