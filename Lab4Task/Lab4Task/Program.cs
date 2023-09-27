using System;
using System.IO;
using System.Text;

class Lexer
{
    private StreamReader reader;
    private char currentChar;
    private StringBuilder buffer1 = new StringBuilder();
    private StringBuilder buffer2 = new StringBuilder();
    private bool usingBuffer1 = true;

    public Lexer(string filePath)
    {
        reader = new StreamReader(filePath);
        Advance();
    }

    // Switch between buffers
    private void SwitchBuffers()
    {
        if (usingBuffer1)
        {
            usingBuffer1 = false;
            buffer1.Clear();
        }
        else
        {
            usingBuffer1 = true;
            buffer2.Clear();
        }
    }

    // Get the current character
    private char Peek()
    {
        return currentChar;
    }

    // Consume the current character and advance to the next one
    private void Advance()
    {
        int nextChar = reader.Read();
        currentChar = (nextChar == -1) ? '\0' : (char)nextChar;
    }

    // Add the current character to the current buffer
    private void AddToBuffer(char c)
    {
        if (usingBuffer1)
            buffer1.Append(c);
        else
            buffer2.Append(c);
    }

    // Get the content of the active buffer
    private string GetActiveBuffer()
    {
        return usingBuffer1 ? buffer1.ToString() : buffer2.ToString();
    }

    // Lexical analysis logic
    public Token GetNextToken()
    {
        while (true)
        {
            if (Peek() == '\0') // End of input
            {
                reader.Close();
                return new Token(TokenType.EOF, "");
            }
            else if (Char.IsWhiteSpace(Peek()))
            {
                // Skip whitespace characters
                Advance();
            }
            else if (Char.IsLetter(Peek()))
            {
                // Handle identifiers
                while (Char.IsLetterOrDigit(Peek()))
                {
                    AddToBuffer(Peek());
                    Advance();
                }
                return new Token(TokenType.Identifier, GetActiveBuffer());
            }
            else
            {
                // Handle other tokens (operators, symbols, etc.)
                AddToBuffer(Peek());
                Advance();
                return new Token(TokenType.Unknown, GetActiveBuffer());
            }
        }
    }
}

enum TokenType
{
    EOF,
    Identifier,
    Unknown
}

class Token
{
    public TokenType Type { get; private set; }
    public string Value { get; private set; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Type}: {Value}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "sample.txt"; // Replace with the path to your source code file
        Lexer lexer = new Lexer(filePath);

        Token token;
        do
        {
            token = lexer.GetNextToken();
            Console.WriteLine(token);
        } while (token.Type != TokenType.EOF);
    }
}
