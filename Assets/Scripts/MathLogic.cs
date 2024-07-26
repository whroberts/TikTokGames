using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MathLogic
{
    public enum MathmaticalValue
    {
        Multi,
        Div,
        Add,
        Sub,
        Random
    }

    public static string GetMathmaticalSymbol(MathmaticalValue mathmaticalValue)
    {
        string symbol = string.Empty;

        switch (mathmaticalValue)
        {
            case MathmaticalValue.Multi:
                symbol = "*";
                break;
            case MathmaticalValue.Div:
                symbol = "/";
                break;
            case MathmaticalValue.Add:
                symbol = "+";
                break;
            case MathmaticalValue.Sub:
                symbol = "-";
                break;
            case MathmaticalValue.Random:
                int rand = Random.Range(0, 4);
                symbol = GetMathmaticalSymbol((MathmaticalValue)rand);
                break;
        }

        return symbol;
    }
}
