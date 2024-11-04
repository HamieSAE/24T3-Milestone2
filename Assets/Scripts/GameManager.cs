using UnityEngine; /* Hamie Nouri - 04.11.2024 */
using System.Collections.Generic;

/*
 * The purpose of this GameManager script is to:
 *   - Find all target objects in the scene and retrieve their health points (HP).
 *   - Sort these HP values from highest to lowest using a bubble sort algorithm.
 *   - Provide access to this sorted list, allowing the PlayerController script to reference the sorted targets.
 */

public class GameManager : MonoBehaviour
{ 
    /*===============================> Declaration / Atributes <===========================================*/
    private Target[] targets;           // Array to hold all target objects
    private int[] hpValues;             // Array to store the HP values of the targets

    /*----------------------------------------> START () <-------------------------------------------------*/
    void Start()
    {
        targets = FindObjectsOfType<Target>();      // Find all targets in the scene

        hpValues = new int[targets.Length];         // Initialise hpValues array based on the number of targets

        for (int i = 0; i < targets.Length; i++)    // Gather the HP values from each target
        {
            hpValues[i] = targets[i].GetHealthPoints();
        }

        BubbleSort(hpValues);                       // Sort the HP values from highest to lowest using bubble sort

        for (int i = 0; i < hpValues.Length; i++)   // Print the sorted HP values for debugging
        {
            Debug.Log("Target " + (i + 1) + " HP: " + hpValues[i]);
        }
    }

    /*==========================================> Bubble Sort <==============================================*/

    void BubbleSort(int[] array)                    // Bubble sort algorithm to sort HP values in descending order
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] < array[j + 1])        // For descending order
                {
                    // Swap
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    /*-----------------------------------> Return for sorted HP <-------------------------------------------*/
    public int[] GetSortedHPValues()                // Get the sorted HP values (if needed by other scripts)
    {
        return hpValues;
    }
}
