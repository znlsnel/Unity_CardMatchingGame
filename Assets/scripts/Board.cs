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

	StartCoroutine(SpawnCard(arr));
    }


        IEnumerator SpawnCard(int[] arr)
        {
		List<Card> cards = new List<Card>();
		for (int i = 0; i < arr.Length; i++)
		{
			GameObject go = Instantiate(card);
			go.transform.SetParent(board, false);

			float x = (i % 4) * 1.4f - 2.1f;
			float y = (i / 4) * 1.5f - 4.0f;

			if (cardNum == CardNumber.easy)
				y = (i / 4) * 1.6f - 2.5f;

			else if (cardNum == CardNumber.normal)
				y = (i / 4) * 1.6f - 3.0f;

			Card cd = go.GetComponent<Card>();
			cards.Add(cd);

			go.transform.position = new Vector2(0, -5);
			go.GetComponent<Card>().Setting(arr[i], new Vector2(x, y));

			yield return new WaitForSeconds(0.1f);
		}

		yield return new WaitForSeconds(0.5f);
		foreach (Card cd in cards)
			cd.StartCard();  

		
		GameManager.Instance.cardCount = arr.Length;

		yield return new WaitForSeconds(2.0f);
		GameManager.Instance.StartTimer();
	}



}
