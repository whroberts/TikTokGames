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
        [SerializeField] private float duplicateSpawnOffset = 1;
        [SerializeField] private int currentDuplicates = 0;
        [SerializeField] private int minDuplicates = 0;
        [SerializeField] private int maxDuplicates = 250;

        private int previousDuplicates = 0;

        private float currentSpawnOffset = 0;
        private List<Vector2> duplicateDirectionOffset;

        private void Start()
        {
            duplicateDirectionOffset = new List<Vector2>()
            {
                new Vector2(-duplicateSpawnOffset, 0),
                new Vector2(duplicateSpawnOffset, 0),
                new Vector2(0, -duplicateSpawnOffset),
                new Vector2(0, duplicateSpawnOffset)
            };

            currentSpawnOffset = duplicateSpawnOffset;
        }

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

            if (previousDuplicates > currentDuplicates)
            {
                DeleteDuplicates(previousDuplicates - currentDuplicates);
            }
            else
            {
                AddDuplicates(currentDuplicates - previousDuplicates);
            }
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
            Debug.Log("Adding " + toAdd + " Duplicates");
            int currentDirectionOffset = 0;
            for (int i = 1; i < toAdd + 1; i++)
            {
                var duplicate = Instantiate(duplicatePrefab);
                duplicate.name = "Duplicate: " + i;
                duplicate.transform.parent = transform;

                float xPos = transform.position.x + duplicateDirectionOffset[currentDirectionOffset].x;
                float zPos = transform.position.z + duplicateDirectionOffset[currentDirectionOffset].y;
                duplicate.transform.position = new Vector3(xPos, transform.position.y, zPos);
                duplicate.transform.rotation = transform.rotation;

                duplicateGameObjects.Add(duplicate);

                if (currentDuplicates % 4 == 0)
                {
                    currentSpawnOffset += duplicateSpawnOffset;

                    duplicateDirectionOffset.Clear();
                    duplicateDirectionOffset = new List<Vector2>()
                    {
                        new Vector2(-currentSpawnOffset, 0),
                        new Vector2(currentSpawnOffset, 0),
                        new Vector2(0, -currentSpawnOffset),
                        new Vector2(0, currentSpawnOffset)
                    };
                }

                if (currentDirectionOffset == 3)
                {
                    currentDirectionOffset = 0;
                }
                else
                {
                    currentDirectionOffset++;
                }

            }
        }

        private void DeleteDuplicates(int toRemove)
        {
            Debug.Log("Removing " + toRemove + " Duplicates");
            for (int i = previousDuplicates - 1; i > currentDuplicates - 1; i--)
            {
                Destroy(duplicateGameObjects[i]);
                duplicateGameObjects.RemoveAt(i);
                Debug.Log("I: " + i);
            }
        }
    }

}