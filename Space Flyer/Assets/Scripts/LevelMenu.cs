using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartLvl1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void StartLvl2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void StartLvl3()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
