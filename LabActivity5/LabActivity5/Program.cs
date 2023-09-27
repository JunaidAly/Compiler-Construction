using System;
using System.Collections.Generic;

public class Symbol
{
    public string Name { get; }
    public string DataType { get; }
    // Add other attributes as needed

    public Symbol(string name, string dataType)
    {
        Name = name;
        DataType = dataType;
    }
}

public class SymbolTable
{
    private const int TableSize = 100; // Adjust the table size as needed
    private List<Symbol>[] table;

    public SymbolTable()
    {
        table = new List<Symbol>[TableSize];
        for (int i = 0; i < TableSize; i++)
        {
            table[i] = new List<Symbol>();
        }
    }

    // Define a hash function to map symbol names to table indices
    private int Hash(string name)
    {
        int hash = 0;
        foreach (char c in name)
        {
            hash += (int)c;
        }
        return hash % TableSize;
    }

    // Add a symbol to the symbol table
    public void AddSymbol(Symbol symbol)
    {
        int index = Hash(symbol.Name);
        table[index].Add(symbol);
    }

    // Retrieve a symbol from the symbol table by name
    public Symbol GetSymbol(string name)
    {
        int index = Hash(name);
        foreach (Symbol symbol in table[index])
        {
            if (symbol.Name == name)
            {
                return symbol;
            }
        }
        return null; // Symbol not found
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SymbolTable symbolTable = new SymbolTable();

        // Add symbols to the symbol table
        symbolTable.AddSymbol(new Symbol("x", "int"));
        symbolTable.AddSymbol(new Symbol("y", "float"));
        symbolTable.AddSymbol(new Symbol("z", "string"));

        // Retrieve symbols from the symbol table
        Symbol symbolX = symbolTable.GetSymbol("x");
        if (symbolX != null)
        {
            Console.WriteLine($"Symbol Name: {symbolX.Name}, Data Type: {symbolX.DataType}");
        }
        else
        {
            Console.WriteLine("Symbol not found.");
        }
    }
}

