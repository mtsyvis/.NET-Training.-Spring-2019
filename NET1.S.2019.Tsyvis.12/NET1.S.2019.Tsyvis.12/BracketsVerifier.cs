using System;
using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._12
{
    /// <summary>
    /// Provide verification in string.
    /// </summary>
    public static class BracketsVerifier
    {
        /// <summary>
        /// Checks the string for the matching brackets.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>True if string is matched;otherwise - false. And false if string don't have brackets.</returns>
        /// <exception cref="ArgumentNullException">string is null</exception>
        public static bool AreBracketsCorrectlySpaced(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException($"string is null {nameof(str)}");
            }

            var stack = new Stack<char>();

            foreach (var symbol in str)
            {
                if (symbol == '(' || symbol == '[' || symbol == '{')
                {
                    stack.Push(symbol);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }

                char top;
                switch (symbol)
                {
                    case ')':
                        top = stack.Peek();
                        stack.Pop();
                        if (top == '{' || top == '[')
                        {
                            return false;
                        }

                        break;

                    case ']':
                        top = stack.Peek();
                        stack.Pop();
                        if (top == '{' || top == '(')
                        {
                            return false;
                        }

                        break;

                    case '}':
                        top = stack.Peek();
                        stack.Pop();
                        if (top == '[' || top == '(')
                        {
                            return false;
                        }

                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}