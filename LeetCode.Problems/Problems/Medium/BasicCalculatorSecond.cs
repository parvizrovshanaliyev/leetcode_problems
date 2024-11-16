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

    public int Calculate(string s)
    {
        s = RemoveSpaces(s); // Step 1: Remove spaces
        return Evaluate(s); // Step 2: Evaluate the expression
    }

    /*
     * Helper Function: RemoveSpaces
     * Removes all spaces from the input string.
     */
    private string RemoveSpaces(string s)
    {
        string result = "";
        foreach (char c in s)
        {
            if (c != ' ')
            {
                result += c;
            }
        }

        return result;
    }

    /*
     * Helper Function: Evaluate
     * Recursively evaluates a mathematical expression with parentheses, addition, subtraction,
     * multiplication, and division.
     */
    private int Evaluate(string s)
    {
        int result = 0;
        int currentNumber = 0;
        int sign = 1; // 1 for positive, -1 for negative
        int i = 0;
        char lastOperator = '+'; // Tracks the last operator for precedence
        int lastResult = 0; // Stores the intermediate result for multiplication/division

        while (i < s.Length)
        {
            char c = s[i];

            if (char.IsDigit(c))
            {
                // Build the current number
                currentNumber = 0;
                while (i < s.Length && char.IsDigit(s[i]))
                {
                    currentNumber = currentNumber * 10 + (s[i] - '0');
                    i++;
                }

                // Apply the last operator
                if (lastOperator == '*')
                {
                    lastResult *= currentNumber;
                }
                else if (lastOperator == '/')
                {
                    lastResult /= currentNumber;
                }
                else
                {
                    lastResult = sign * currentNumber;
                }

                continue; // Skip incrementing i as the loop already moved
            }
            else if (c == '+')
            {
                result += lastResult; // Add the last result to the total
                sign = 1;
                lastOperator = '+';
            }
            else if (c == '-')
            {
                result += lastResult; // Add the last result to the total
                sign = -1;
                lastOperator = '-';
            }
            else if (c == '*')
            {
                lastOperator = '*';
            }
            else if (c == '/')
            {
                lastOperator = '/';
            }
            else if (c == '(')
            {
                // Solve the sub-expression inside parentheses
                int start = i + 1; // Move to the character after '('
                int openBrackets = 1;

                // Find the matching closing parenthesis
                while (i + 1 < s.Length && openBrackets > 0)
                {
                    i++;
                    if (s[i] == '(') openBrackets++;
                    if (s[i] == ')') openBrackets--;
                }

                // Recursively evaluate the expression inside parentheses
                int subResult = Evaluate(s.Substring(start, i - start));
                if (lastOperator == '*')
                {
                    lastResult *= subResult;
                }
                else if (lastOperator == '/')
                {
                    lastResult /= subResult;
                }
                else
                {
                    lastResult = sign * subResult;
                }
            }

            // Move to the next character
            i++;
        }

        // Add the last processed result
        result += lastResult;
        return result;
    }
}