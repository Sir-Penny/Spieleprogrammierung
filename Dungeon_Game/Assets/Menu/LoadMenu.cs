using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public GameObject LoadScenen;
    public void LoadMainMenu()
    {
        GameObject go = Instantiate(LoadScenen);
        go.GetComponent<LoadNewStage>().sceneName = "Menu";
        Destroy(GameObject.FindGameObjectWithTag("PlayerRoot"));
    }
}
