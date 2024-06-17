using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Destroy(GameObject.FindGameObjectWithTag("PlayerRoot"));
    }
}
