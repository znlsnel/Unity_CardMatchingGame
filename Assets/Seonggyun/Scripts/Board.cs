using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // OrderBy

public class Board : MonoBehaviour
{
    public GameObject card; // card 프리팹

    // Board를 매니저처럼 사용
    // 카드 프리팹들의 정보를 가지고 있다
    public List<Sprite> spriteList;   // 카드를 미리 리스트에 추가한다
    private void Awake()
    {
        spriteList = new List<Sprite>();
    }
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();   // Linq

        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card, this.transform);  // Board의 자식으로 card 생성

            // 원점위치 조정을 위해 2.1f만큼 왼쪽, 3.0만큼 아래로 이동한다
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            go.transform.position = new Vector2(x, y);
            // go의 idx에 대입한다
            go.GetComponent<Cardd>().Setting(arr[i]);
        }
        GameManager.Instance.cardCount = arr.Length;
    }
}
