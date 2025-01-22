using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBtn : MonoBehaviour
{
    public Object scene;

    public void onClickIntroBtn()
    {
        SceneManager.LoadScene(scene.name);
    }
}
