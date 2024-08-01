using System;
using UnityEngine;

namespace CustomMath
{
    [System.Serializable]
    public class MathLogic
    {
        public enum MathmaticalSymbol
        {
            Multi,
            Div,
            Add,
            Sub,
            Random
        }

        public static Tuple<MathmaticalSymbol, string, int> GetMathmaticalSymbol(MathmaticalSymbol mathmaticalSymbol)
        {
            string symbol = string.Empty;
            int value = 1;

            if (mathmaticalSymbol == MathmaticalSymbol.Random)
            {
                mathmaticalSymbol = (MathmaticalSymbol)UnityEngine.Random.Range(0, 4);
            }


            switch (mathmaticalSymbol)
            {
                case MathmaticalSymbol.Multi:
                    symbol = "x";
                    value = UnityEngine.Random.Range(1, 5);
                    break;
                case MathmaticalSymbol.Div:
                    symbol = "/";
                    value = UnityEngine.Random.Range(1, 5);
                    break;
                case MathmaticalSymbol.Add:
                    symbol = "+";
                    value = UnityEngine.Random.Range(10, 20);
                    break;
                case MathmaticalSymbol.Sub:
                    symbol = "-";
                    value = UnityEngine.Random.Range(10, 20);
                    break;
                case MathmaticalSymbol.Random:
                    Debug.LogError("Mathmatical Symbol cannot be random");
                    break;
            }

            return Tuple.Create(mathmaticalSymbol, symbol, value);
        }
    }
}
