using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public Transform board;
    public GameObject card;
    public int idx = 0;
    public int cardCount = 0;

    public enum CardNumber
    {
        easy = 6,
        normal = 8,
        Hard = 10
    }

    [SerializeField]
    public CardNumber cardNum = CardNumber.normal;

    void Start()
    {
        int cardTypeCount = (int)cardNum;

        int[] arr = new int[cardTypeCount * 2]; //CardNumber 곱하기 2 ex)Hard면 20
        for (int i = 0; i < cardTypeCount; i++)
        {
            arr[i] = i;
            arr[cardTypeCount + i] = i;
        }

        arr = arr.OrderBy(x => Random.Range(0f, arr.Length)).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            GameObject go = Instantiate(card);
            go.transform.SetParent(board, false);

            float x = (i % 4) * 1.4f - 2.1f;
            if (cardNum == CardNumber.Hard) //난이도 별 카드 간격 조정 
            {
                float y = (i / 4) * 1.5f - 4.0f;
                go.transform.position = new Vector2(x, y);

            } else if(cardNum == CardNumber.easy)
            {
                float y = (i / 4) * 1.6f - 2.5f;
                go.transform.position = new Vector2(x, y);
            } else
            {
                float y = (i / 4) * 1.6f - 3.0f;
                go.transform.position = new Vector2(x, y);
            }
            

            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
