﻿using System.Collections;
using System.Runtime.CompilerServices;
Array finalArray = { };
ArrayList States = new ArrayList();
Stack<String> Stack = new Stack<String>();
String Parser;
String[] Col = { "begin" ,"(",")","{","int","a","b",
"c","=","5","10","0",";","if",">","print",
    "else","$","}","+","end","Program","DecS","AssS",
    "IffS","PriS","Var","Const" };
#region Bottom Up Parser
States.Add("Program_begin ( ) { DecS Decs Decs AssS IffS } end");

States.Add("DecS_int Var = Const ;");
States.Add("AssS_Var = Var + Var ;");
States.Add("IffS_if ( Var > Var ) { PriS } else { PriS }");
States.Add("PriS_print Var ;");
States.Add("Var_a");
States.Add("Var_b");
States.Add("Var_c");
States.Add("Const_5");
States.Add("Const_10");
States.Add("Const_0");
Stack.Push("0");
finalArray.Add("$");
int pointer = 0;
#region ParseTable
var dict = new Dictionary<string, Dictionary<String,
object>>();
dict.Add("0", new Dictionary<String, object>()
 {
 { "begin", "S2" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "1" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("1", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "Accept" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("2", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "S3" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
{ "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("3", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "S4" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("4", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "S5" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
{ "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("5", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "S13" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "6" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("6", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "S13" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
{ "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "7" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("7", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "S13" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "8" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("8", new Dictionary<String, object>()
 {
 { "begin", "" },
{ "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "9" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "18" },
 { "Const", "" }
 });
dict.Add("9", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "S24" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
{ "IffS", "10" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("10", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "S11" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("11", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
{ "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "S12" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("12", new Dictionary<String, object>()
 {
 { "begin", "R1" },
 { "(", "R1" },
 { ")", "R1" },
 { "{", "R1" },
 { "int", "R1" },
 { "a", "R1" },
 { "b", "R1" },
 { "c", "R1" },
 { "=", "R1" },
 { "5", "R1" },
 { "10", "R1" },
 { "0", "R1" },
 { ";", "R1" },
 { "if", "R1" },
 { ">", "R1" },
 { "print", "R1" },
 { "else", "R1" },
 { "$", "R1" },
 { "}", "R1" },
 { "+", "R1" },
 { "end", "R1" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("13", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
{ "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "14" },
 { "Const", ""
}
 });
dict.Add("14", new Dictionary
<String, object>()

{
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "S15" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 {
"else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "2" },
 { "IffS", "1" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", ""
}
 });
dict.Add("15", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "S41" },
 { "10", "S43" },
 { "0", "S45" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "16" }
 });
dict.Add("16", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "S17" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
{ "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("17", new Dictionary<String, object>()
 {
 { "begin", "R2" },
 { "(", "R2" },
 { ")", "R2" },
 { "{", "R2" },
 { "int", "R2" },
 { "a", "R2" },
 { "b", "R2" },
 { "c", "R2" },
 { "=", "R2" },
 { "5", "R2" },
 { "10", "R2" },
 { "0", "R2" },
 { ";", "R2" },
 { "if", "R2" },
 { ">", "R2" },
 { "print", "R2" },
 { "else", "R2" },
 { "$", "R2" },
 { "}", "R2" },
 { "+", "R2" },
 { "end", "R2" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("18", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "S19" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
{ "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("19", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "20" },
 { "Const", "" }
 });
dict.Add("20", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
{ "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "S21" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", ""
}
 });
dict.Add("21", new Dictionary
<String, object>()

{
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "22" },
 { "Const", ""
}
});
dict.Add("22", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "S23" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("23", new Dictionary<String, object>()
 {
 { "begin", "R3" },
 { "(", "R3" },
 { ")", "R3" },
 { "{", "R3" },
 { "int", "R3" },
 { "a", "R3" },
 { "b", "R3" },
 { "c", "R3" },
 { "=", "R3" },
 { "5", "R3" },
 { "10", "R3" },
 { "0", "R3" },
 { ";", "R3" },
 { "if", "R3" },
 { ">", "R3" },
 { "print", "R3" },
 { "else", "R3" },
 { "$", "R3" },
 { "}", "R3" },
 { "+", "R3" },
{ "end", "R3" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("24", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "S25" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("25", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
{ ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "26" },
 { "Const", "" }
 });

dict.Add("26", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "S27" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("27", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
{ "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "28" },
 { "Const", "" }
 });
dict.Add("28", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "S29" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "2" },
 { "IffS", "1" },
 { "PriS", "" },
{ "Var", "" },
 { "Const", "" }
 });
dict.Add("29", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "S30" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "2" },
 { "IffS", "1" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("30", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "S37" },
 { "else", "" },
 { "$", "" },
{ "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "31" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("31", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "S32" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("32", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
{ "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "S33" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("33", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "S34" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("34", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
{ ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "S37" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "35" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("35", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "S36" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "2" },
 { "IffS", "1" },
{ "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("36", new Dictionary<String, object>()
 {
 { "begin", "R4" },
 { "(", "R4" },
 { ")", "R4" },
 { "{", "R4" },
 { "int", "R4" },
 { "a", "R4" },
 { "b", "R4" },
 { "c", "R4" },
 { "=", "R4" },
 { "5", "R4" },
 { "10", "R4" },
 { "0", "R4" },
 { ";", "R4" },
 { "if", "R4" },
 { ">", "R4" },
 { "print", "R4" },
 { "else", "R4" },
 { "$", "R4" },
 { "}", "R4" },
 { "+", "R4" },
 { "end", "R4" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("37", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "S40" },
 { "b", "S42" },
 { "c", "S44" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
{ "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "38" },
 { "Const", "" }
 });
dict.Add("38", new Dictionary<String, object>()
 {
 { "begin", "" },
 { "(", "" },
 { ")", "" },
 { "{", "" },
 { "int", "" },
 { "a", "" },
 { "b", "" },
 { "c", "" },
 { "=", "" },
 { "5", "" },
 { "10", "" },
 { "0", "" },
 { ";", "S39" },
 { "if", "" },
 { ">", "" },
 { "print", "" },
 { "else", "" },
 { "$", "" },
 { "}", "" },
 { "+", "" },
 { "end", "" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("39", new Dictionary<String, object>()
 {
 { "begin", "R5" },
 { "(", "R5" },
 { ")", "R5" },
 { "{", "R5" },
 { "int", "R5" },
 { "a", "R5" },
 { "b", "R5" },
 { "c", "R5" },
 { "=", "R5" },
{ "5", "R5" },
 { "10", "R5" },
 { "0", "R5" },
 { ";", "R5" },
 { "if", "R5" },
 { ">", "R5" },
 { "print", "R5" },
 { "else", "R5" },
 { "$", "R5" },
 { "}", "R5" },
 { "+", "R5" },
 { "end", "R5" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("40", new Dictionary<String, object>()
 {
 { "begin", "R6" },
 { "(", "R6" },
 { ")", "R6" },
 { "{", "R6" },
 { "int", "R6" },
 { "a", "R6" },
 { "b", "R6" },
 { "c", "R6" },
 { "=", "R6" },
 { "5", "R6" },
 { "10", "R6" },
 { "0", "R6" },
 { ";", "R6" },
 { "if", "R6" },
 { ">", "R6" },
 { "print", "R6" },
 { "else", "R6" },
 { "$", "R6" },
 { "}", "R6" },
 { "+", "R6" },
 { "end", "R6" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });

dict.Add("41", new Dictionary<String, object>()
{
{ "begin", "R9" },
 { "(", "R9" },
 { ")", "R9" },
 { "{", "R9" },
 { "int", "R9" },
 { "a", "R9" },
 { "b", "R9" },
 { "c", "R9" },
 { "=", "R9" },
 { "5", "R9" },
 { "10", "R9" },
 { "0", "R9" },
 { ";", "R9" },
 { "if", "R9" },
 { ">", "R9" },
 { "print", "R9" },
 { "else", "R9" },
 { "$", "R9" },
 { "}", "R9" },
 { "+", "R9" },
 { "end", "R9" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("42", new Dictionary<String, object>()
 {
 { "begin", "R7" },
 { "(", "R7" },
 { ")", "R7" },
 { "{", "R7" },
 { "int", "R7" },
 { "a", "R7" },
 { "b", "R7" },
 { "c", "R7" },
 { "=", "R7" },
 { "5", "R7" },
 { "10", "R7" },
 { "0", "R7" },
 { ";", "R7" },
 { "if", "R7" },
 { ">", "R7" },
 { "print", "R7" },
 { "else", "R7" },
 { "$", "R7" },
 { "}", "R7" },
 { "+", "R7" },
 { "end", "R7" },
 { "Program", "" },
 { "DecS", "" },
{ "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("43", new Dictionary<String, object>()
 {
 { "begin", "R10" },
 { "(", "R10" },
 { ")", "R10" },
 { "{", "R10" },
 { "int", "R10" },
 { "a", "R10" },
 { "b", "R10" },
 { "c", "R10" },
 { "=", "R10" },
 { "5", "R10" },
 { "10", "R10" },
 { "0", "R10" },
 { ";", "R10" },
 { "if", "R10" },
 { ">", "R10" },
 { "print", "R10" },
 { "else", "R10" },
 { "$", "R10" },
 { "}", "R10" },
 { "+", "R10" },
 { "end", "R10" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("44", new Dictionary<String, object>()
 {
 { "begin", "R8" },
 { "(", "R8" },
 { ")", "R8" },
 { "{", "R8" },
 { "int", "R8" },
 { "a", "R8" },
 { "b", "R8" },
 { "c", "R8" },
 { "=", "R8" },
 { "5", "R8" },
 { "10", "R8" },
 { "0", "R8" },
 { ";", "R8" },
 { "if", "R8" },
 { ">", "R8" },
{ "print", "R8" },
 { "else", "R8" },
 { "$", "R8" },
 { "}", "R8" },
 { "+", "R8" },
 { "end", "R8" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
dict.Add("45", new Dictionary<String, object>()
 {
 { "begin", "R11" },
 { "(", "R11" },
 { ")", "R11" },
 { "{", "R11" },
 { "int", "R11" },
 { "a", "R11" },
 { "b", "R11" },
 { "c", "R11" },
 { "=", "R11" },
 { "5", "R11" },
 { "10", "R11" },
 { "0", "R11" },
 { ";", "R11" },
 { "if", "R11" },
 { ">", "R11" },
 { "print", "R11" },
 { "else", "R11" },
 { "$", "R11" },
 { "}", "R11" },
 { "+", "R11" },
 { "end", "R11" },
 { "Program", "" },
 { "DecS", "" },
 { "AssS", "" },
 { "IffS", "" },
 { "PriS", "" },
 { "Var", "" },
 { "Const", "" }
 });
#endregion
while (true)
{
    if (!Col.Contains(finalArray[pointer]))
    {
        Output.AppendText("Unable to Parse Unknown Input");
        break;
    }
    Parser = dict[Stack.Peek() + ""][finalArray[pointer] + ""] + "";
    if (Parser.Contains("S"))
    {
        Stack.Push(finalArray[pointer] + "");
        Parser = Parser.TrimStart('S');
        Stack.Push(Parser);
        pointer++;
        Print_Stack();
    }
    if (Parser.Contains("R"))
    {
        Parser = Parser.TrimStart('R');
        String get = States[Convert.ToInt32(Parser) - 1] +
        "";
        String[] Splitted = get.Split('_');
        String[] Final_ = Splitted[1].Split(' ');
        int test = Final_.Length;
        for (int i = 0; i < test * 2; i++)
        { Stack.Pop(); }
        String row = Stack.Peek() + "";
        Stack.Push(Splitted[0]);
        Stack.Push(dict[row][Stack.Peek()] + "");
        Print_Stack();
    }
    if (Parser.Contains("Accept"))
    {
        Output.AppendText("Parsed");
        break;
    }
    if (Parser.Equals(""))
    {
        Output.AppendText("Unable to Parse");
        break;
    }
}
finalArray.Remove("$");
finalArray.Remove("begin");
#endregion
