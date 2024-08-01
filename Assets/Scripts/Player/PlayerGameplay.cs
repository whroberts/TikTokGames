using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Player.Movement;
using Projectiles;
using Behavior;
using Unity.VisualScripting;

namespace Player
{
    public class PlayerGameplay : BehaviorBase
    {
        [Header("Duplicates")]
        [SerializeField] private GameObject duplicatePrefab = null;
        [SerializeField] private List<GameObject> duplicateGameObjects = new List<GameObject>();
        [SerializeField] private int currentDuplicates = 0;
        [SerializeField] private int minDuplicates = 0;
        [SerializeField] private int maxDuplicates = 250;

        private int previousDuplicates = 0;

        public void ChangeDuplicateCount(int value)
        {
            previousDuplicates = currentDuplicates;

            if (value >= maxDuplicates)
            {
                currentDuplicates = maxDuplicates;
            } 
            else if (value <= minDuplicates)
            {
                currentDuplicates = minDuplicates;
            }
            else
            {
                currentDuplicates = value;
            }

            Debug.Log("Prev: " + previousDuplicates);
            Debug.Log("Curr: " + currentDuplicates);

            AddDuplicates(currentDuplicates - previousDuplicates);
        }

        public int GetCurrentDuplicates()
        {
            if (currentDuplicates == 0)
            {
                return currentDuplicates + 1;
            }

            return currentDuplicates;
        }

        private void AddDuplicates(int toAdd)
        {
            for (int i = 0; i < toAdd; i++)
            {
                var duplicate = Instantiate(duplicatePrefab);
                duplicate.transform.parent = transform;



                duplicateGameObjects.Add(duplicate);
                Debug.Log("Adding " + toAdd + " Duplicates");
            }
        }
    }

}