# What is a Shift-Reduce Parser?
A Shift-Reduce Parser is a type of bottom-up parser that builds the parse tree from the input starting from the bottom (input tokens) and works its way up to the start symbol.

# The Two Main Operations:
1.Shift:
This operation moves the next input token onto the stack.
The parser shifts one token from the input and places it on top of the stack.

2.Reduce:
This operation tries to replace a sequence of tokens on top of the stack with a non-terminal by using the grammar rules (reduction).
The parser looks at the stack and applies a grammar rule in reverse to simplify it.

# Step-by-Step Example of a Shift-Reduce Parser
Let's use a simple arithmetic grammar to illustrate how a Shift-Reduce Parser works.

# Grammar:
1. E → E + num
2. E → num

This grammar means:

- E is an expression.
- An expression can either be a number (num) or another expression followed by + num.

Input: "2 + 3"
We will parse the input "2 + 3" using shift and reduce operations.

# Initial Setup:
- Stack: Empty initially.
- Input: "2 + 3$" (we add $ at the end to mark the end of the input).
- Action: We’ll shift tokens onto the stack and reduce when the top of the stack matches a grammar rule.

# Step-by-Step Parsing Process:

# Step 1: Shift
- Input: "2 + 3$"
- Action: Shift the first token 2 onto the stack.
   - Stack: 2
   - Remaining Input: "+ 3$"

# Step 2: Reduce
- Stack: 2
- Action: Check if the top of the stack matches the right-hand side of any grammar rule. In this case, 2 is a num, and E → num is a rule we can use.
- Reduce by replacing 2 with E.
  - Stack: E
  - Remaining Input: "+ 3$"
 
# Step 3: Shift
- Stack: E
- Action: Shift the next token + onto the stack.
  - Stack: E +
  - Remaining Input: "3$"
 
# Step 4: Shift
- Stack: E +
- Action: Shift the next token 3 onto the stack.
  - Stack: E + 3
  - Remaining Input: "$"

# Step 5: Reduce
- Stack: E + 3
- Action: Now we check if we can apply a grammar rule. The stack has E + num, which matches the rule E → E + num.
- Reduce by replacing E + 3 with E.
  - Stack: E
  - Remaining Input: "$"


# Step 6: Finish
- Stack: E
- Remaining Input: "$"
- Action: The stack now contains E (the start symbol), and the input is $ (end of input), so the parsing is successful.

# Summary of the Example:
- Shift: Move tokens (2, +, 3) from the input onto the stack.
- Reduce: Whenever the top of the stack matches the right-hand side of a grammar rule, apply the rule and replace the tokens with the left-hand side of the rule (E).
- Final Result: The input is successfully reduced to E, meaning it follows the grammar.


# Key Takeaways:
1. Shift:
   - Move the next token from the input onto the stack.
2. Reduce:
   - Apply a grammar rule when the top of the stack matches the right-hand side of the rule.
3. Finish:
   - When the stack contains the start symbol and the input is fully consumed, the parser succeeds.



# Comparison with Top-Down Parsing:

- Top-Down Parsing: Starts from the start symbol and tries to match the input by expanding rules.
- Bottom-Up Parsing (Shift-Reduce): Starts from the input tokens and works backward by reducing the input to the start symbol.






