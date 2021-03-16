using System;
using System.Collections.Generic;

namespace AD
{
    public static class BracketChecker
    {

        /// <summary>
        ///    Run over all characters in a string, push all '(' characters
        ///    found on a stack. When ')' is found, it shoud match a '(' on
        ///    the stack, which is then popped.
        ///
        ///    If ')' is found when no '(' is on the stack, this method will
        ///    terminate prematurely, no further inspection is needed.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Returns True if all '(' are matched by ')'.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets(string s)
        {
            if (s.Length == 0) return true;

            IMyStack<string> myStack = DSBuilder.CreateMyStack();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                myStack.Push(s.Substring(i, 1));
            }

            int leftBrackets = 0;
            int rightBrackets = 0;

            while (!myStack.IsEmpty())
            {
                string i = myStack.Pop();
                if (i == "(") leftBrackets++;
                if (i == ")") rightBrackets++;

                if (rightBrackets > leftBrackets) return false;
            }

            return leftBrackets == rightBrackets;
        }


        /// <summary>
        ///    Run over all characters in a string, when an opening bracket is
        ///    found the closing counterpart from closeChar is pushed on a Stack
        ///    When an closing bracket is found, it should match the top character
        ///    from this stack.
        ///    
        ///    This method will terminate prematurely if a wrong or missmatched
        ///    closing bracket is found and no further inspection is needed.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Returns True if all opening brackets are matched by
        /// it's correct counterpart in a correct order.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets2(string s)
        {
            if (s.Length == 0) return true;

            IMyStack<char> MyStack = new MyStack<char>();
            Dictionary<char, char> BracketPairs = new Dictionary<char, char>()
            {
                { '{', '}'},
                { '(', ')'},
                { '[', ']'},
            };

            try
            {
                foreach (char c in s)
                {
                    if (BracketPairs.ContainsKey(c))
                    {
                        MyStack.Push(c);
                    }
                    else
                    {
                        // check if the character is one of the 'closing' brackets

                        if (BracketPairs.ContainsValue(c))
                        {
                            // check if the closing bracket matches the 'latest' 'opening' bracket
                            if (c == BracketPairs[MyStack.Top()])
                            {
                                MyStack.Pop();
                            }
                            else
                                // if not, its an unbalanced string
                                return false;
                        } else 
                            continue;
                    }
                }
            }
            catch
            {
                return false;
            }


            return MyStack.IsEmpty();
        }
    }

    class BracketCheckerInvalidInputException : Exception
    {
    }

}
