using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string FirstScene;

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(FirstScene);

    }
}
