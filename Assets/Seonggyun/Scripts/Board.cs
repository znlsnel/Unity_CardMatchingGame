using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // OrderBy

public class Board : MonoBehaviour
{
    public GameObject card; // card ������

    // Board�� �Ŵ���ó�� ���
    // ī�� �����յ��� ������ ������ �ִ�
    public List<Sprite> spriteList;   // ī�带 �̸� ����Ʈ�� �߰��Ѵ�
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
            GameObject go = Instantiate(card, this.transform);  // Board�� �ڽ����� card ����

            // ������ġ ������ ���� 2.1f��ŭ ����, 3.0��ŭ �Ʒ��� �̵��Ѵ�
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            go.transform.position = new Vector2(x, y);
            // go�� idx�� �����Ѵ�
            go.GetComponent<Cardd>().Setting(arr[i]);
        }
        GameManager.Instance.cardCount = arr.Length;
    }
}
