Code Smells Identified:
1.The Register method in the Speaker class is excessively long and contains nested conditionals, indicating a possible issue with complexity and readability.
2.The Speaker class seems to handle multiple responsibilities, such as speaker registration and validation, violating the Single Responsibility Principle.

Problems with the Speaker Class:
1.The Speaker class attempts to handle too many responsibilities, leading to code that is difficult to maintain and understand.
2.Complex conditional logic within the Register method makes it hard to follow and prone to errors.

Clean Code Principles Violated:
1.Single Responsibility Principle (SRP) is violated as the Speaker class handles multiple tasks.
2.The code complexity violates the Keep It Simple, Stupid (KISS) principle.

Refactoring Techniques Used:
1.Extract Method: Used to break down complex logic into smaller, more manageable methods.
2.Simplify Conditional Expressions: Simplified complex conditional logic to improve readability.
3.Remove Code Duplication: Eliminated redundant code and reduced code duplication where possible.