using UnityEngine; /* Hamie Nouri - 04.11.2024 */
using System.Collections.Generic;

/*
 * The purpose of this GameManager script is to:
 *   - Find all target objects in the scene and retrieve their health points (Targets).
 *   - Sort these HP values from highest to lowest using a bubble sort algorithm.
 *   - Provide access to this sorted list, allowing the PlayerController script to reference the sorted targets.
 */

public class GameManager : MonoBehaviour
{ 
    /*===============================> Declaration / Atributes <===========================================*/
    private Target[] targets;           // Array to hold all target objects

    /*----------------------------------------> START-> Awake () <-------------------------------------------------*/
    void Awake()
    {
        targets = FindObjectsOfType<Target>();      // Find all targets in the scene

        BubbleSort();                       // Sort the HP values from highest to lowest using bubble sort
    }

    /*==========================================> Bubble Sort <==============================================*/
    void BubbleSort()                    // Bubble sort algorithm to sort HP values in descending order
    {
        int n = targets.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (targets[j].GetHealthPoints() < targets[j + 1].GetHealthPoints())
                {
                    Target tempTarget = targets[j];
                    targets[j] = targets[j + 1];
                    targets[j + 1] = tempTarget;
                }
            }
        }
    }

    /*-----------------------------------> Return for sorted HP <-------------------------------------------*/
    public Target[] GetSortedTargets()                // Get the sorted HP values (if needed by other scripts)
    {
        return targets;
    }
}