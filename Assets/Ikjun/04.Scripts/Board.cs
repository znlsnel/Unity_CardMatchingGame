using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public Transform board;
    public GameObject card;
    public int idx = 0;
    public int cardCount = 0;

    

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();
        

        for (int i = 0; i < 16; i++)
        {
            
            GameObject go = Instantiate(card);
            go.transform.SetParent(board, false);
            go.GetComponent<Card>().Setting(arr[i]);

        }
        GameManager.Instance.cardCount = arr.Length;
    }

}