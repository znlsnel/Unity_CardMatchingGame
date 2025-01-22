using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBtn : MonoBehaviour
{
    public string sceneName;

    public void onClickIntroBtn()
    {
        SceneManager.LoadScene(sceneName);
    }
}
