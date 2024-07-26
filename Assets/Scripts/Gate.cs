using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gate : MonoBehaviour
{
    [SerializeField] private Color color = Color.red;
    [SerializeField] private int value = 1;

    [SerializeField] private MathLogic.MathmaticalValue mathmaticalValue = MathLogic.MathmaticalValue.Random;
    [SerializeField] private string mathmaticalSymbol = string.Empty;

    [SerializeField] private GameObject gate = null;
    [SerializeField] private TMP_Text text = null;

    private void Start()
    {
        mathmaticalSymbol = MathLogic.GetMathmaticalSymbol(mathmaticalValue);
        text.text = mathmaticalSymbol + value;
        gate.GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnTriggerEnter(Collider collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log("Player Entered");

            GetComponent<BoxCollider>().enabled = false;
        }
    }

}
