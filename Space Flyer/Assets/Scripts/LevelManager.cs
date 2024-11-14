using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void PLayLvl1Again()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void PLayLvl2Again()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void PLayLvl3Again()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void ReturnLvlSelection()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
