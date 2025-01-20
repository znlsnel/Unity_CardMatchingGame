using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Transform board;
    public GameObject card;
    public int idx = 0;
    public SpriteRenderer frontImage;

    // 카드에 번호와 이미지를 설정하는 함수
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Ikjun{idx}");
    }

    void Start()
    {
        // 16개의 카드에 대해 3개의 이미지 중 무작위로 선택하도록 수정
        int[] arr = new int[16];

        // 16개의 카드에 대해 3개 이미지 중 하나를 무작위로 배치
        for (int i = 0; i < 16; i++)
        {
            // 0~2 중 무작위 번호를 설정 (이미지 3개)
            arr[i] = Random.Range(0, 3);  // 0, 1, 2 중 하나
        }

        // 카드를 생성하고 이미지 설정
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card);
            go.transform.SetParent(board, false);  // 부모 설정 시 worldPositionStays=false

            // 카드 객체에 번호 설정
            go.GetComponent<Card>().Setting(arr[i]);
        }
    }
}
