using UnityEngine;

public class ArrayBubbleSort : MonoBehaviour
{
    int[] numberArray = { 5, 3, 8, 4, 2 };

    void Start()
    {
        Debug.Log("Original Array: " + ArrayToString(numberArray));

        BubbleSortArray(numberArray);

        Debug.Log("Sorted Array: " + ArrayToString(numberArray));
    }

    void BubbleSortArray(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    string ArrayToString(int[] array)
    {
        return string.Join(", ", array);
    }
}

