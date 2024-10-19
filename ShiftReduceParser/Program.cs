namespace ShiftReduceParser
{
    internal class Program
    {
        // Define grammar rules
        static readonly string[] grammar = { "E -> E + num", "E -> num" };

        // Stack for shift-reduce parsing
        static Stack<string> stack = new Stack<string>();

        // Input tokens (e.g., "num + num $")
        static string[] inputTokens;
        static int inputIndex = 0;
        static void Main(string[] args)
        {
            // Example input: "num + num"
            inputTokens = new string[] { "num", "+", "num", "$" }; // "$" marks the end of input
            inputIndex = 0;

            // Start parsing
            if (ShiftReduce())
            {
                Console.WriteLine("Input successfully parsed!");
            }
            else
            {
                Console.WriteLine("Input parsing failed.");
            }
        }
        // Main shift-reduce function
        static bool ShiftReduce()
        {
            while (inputIndex < inputTokens.Length)
            {
                // Shift: Push the next input token onto the stack
                string lookahead = inputTokens[inputIndex];
                Console.WriteLine($"Shifting: {lookahead}");
                stack.Push(lookahead);
                inputIndex++;

                // Try to reduce the stack
                if (!TryReduce())
                {
                    return false;
                }

                // If the stack is reduced to "E" and input is fully consumed, we succeed
                if (stack.Count == 1 && stack.Peek() == "E" && inputTokens[inputIndex] == "$")
                {
                    return true; // Successfully parsed
                }
            }
            return false; // Parsing failed if input is not fully reduced
        }

        // Function to try reducing the stack using grammar rules
        static bool TryReduce()
        {
            bool reduced = false;
            while (true)
            {
                // Check if we can apply a reduction based on the top of the stack
                string top = string.Join(" ", stack.ToArray());

                // Check the rules in reverse order (since stack operates in reverse)
                if (top.StartsWith("num")) // Rule: E -> num
                {
                    Console.WriteLine("Reducing: E -> num");
                    stack.Pop(); // Pop "num"
                    stack.Push("E"); // Push "E"
                    reduced = true;
                }
                else if (top.StartsWith("E + num")) // Rule: E -> E + num
                {
                    Console.WriteLine("Reducing: E -> E + num");
                    stack.Pop(); // Pop "num"
                    stack.Pop(); // Pop "+"
                    stack.Pop(); // Pop "E"
                    stack.Push("E"); // Push "E"
                    reduced = true;
                }
                else
                {
                    break; // No more reductions possible
                }
            }
            return reduced; // Return whether a reduction was applied
        }
    }
}
