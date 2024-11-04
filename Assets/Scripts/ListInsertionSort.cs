using System.Collections.Generic;
using UnityEngine;

public class ListInsertionSort : MonoBehaviour
{
    List<int> numberList = new List<int> { 7, 1, 9, 6, 0 };

    void Start()
    {
        Debug.Log("Original List: " + ListToString(numberList));

        InsertionSortList(numberList);

        Debug.Log("Sorted List: " + ListToString(numberList));
    }

    void InsertionSortList(List<int> list)
    {
        int n = list.Count;
        for (int i = 1; i < n; i++)
        {
            int key = list[i];
            int j = i - 1;

            while (j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j = j - 1;
            }
            list[j + 1] = key;
        }
    }

    string ListToString(List<int> list)
    {
        return string.Join(", ", list);
    }
}
