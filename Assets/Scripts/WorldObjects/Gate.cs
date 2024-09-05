using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using CustomMath;
using Player;
using UnityEngine;

namespace Game.WorldObjects
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private Color color = Color.red;
        [SerializeField] private MathLogic.MathmaticalSymbol mathmaticalSymbol = MathLogic.MathmaticalSymbol.Random;
        [SerializeField] private string mathSymbol = string.Empty;
        [SerializeField] private int mathValue = -1;

        [SerializeField] private GameObject gate = null;
        [SerializeField] private TMP_Text text = null;

        private void Start()
        {
            var gateLogic = MathLogic.GetMathmaticalSymbol(mathmaticalSymbol);
            mathmaticalSymbol = gateLogic.Item1;
            mathSymbol = gateLogic.Item2;

            if (mathValue < 0)
                mathValue = gateLogic.Item3;

            text.text = mathSymbol + mathValue;
            gate.GetComponent<MeshRenderer>().material.color = color;
        }

        private void OnTriggerEnter(Collider collider)
        {
            PlayerGameplay player = collider.GetComponent<PlayerGameplay>();

            if (player != null)
            {
                Debug.Log("Player Entered");

                int newDuplicatesCount = SendDuplicates(player.GetCurrentDuplicates());
                Debug.Log("Sending " + newDuplicatesCount +" Duplicates");
                player.ChangeDuplicateCount(newDuplicatesCount);

                GetComponent<BoxCollider>().enabled = false;
                
                Destroy(gameObject, 2f);
            }
        }

        private int SendDuplicates(int currentDuplicates)
        {
            switch (mathmaticalSymbol)
            {
                case MathLogic.MathmaticalSymbol.Multi:
                    return currentDuplicates * mathValue;
                case MathLogic.MathmaticalSymbol.Div:
                    return currentDuplicates / mathValue;
                case MathLogic.MathmaticalSymbol.Add:
                    return currentDuplicates -1 + mathValue;
                case MathLogic.MathmaticalSymbol.Sub:
                    return currentDuplicates - mathValue;
            }

            Debug.LogError("Returning previous duplicateCount");
            return currentDuplicates;
        }
    }
}