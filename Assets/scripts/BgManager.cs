using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{
    public Board boardsc;
    public GameObject[] bgImages;
    public Transform bgManager;

    // Start is called before the first frame update
    void Start()
    {
        
        switch (boardsc.cardNum)
        {
            case Board.CardNumber.easy:
                CreateImage(0);
                Debug.Log("esay");
                break;
            case Board.CardNumber.normal:
                CreateImage(1);
                Debug.Log("normal");
                break;
            case Board.CardNumber.Hard:
                CreateImage(2);
                Debug.Log("Hard");
                break;
        }
            
        
    }
    void CreateImage(int index)
    {
        if (index >=0 && index < bgImages.Length && bgImages[index] != null)
        {
            Instantiate(bgImages[index], bgManager.position, Quaternion.identity, bgManager);
            Debug.Log("careate");
        }
    }

   
}
