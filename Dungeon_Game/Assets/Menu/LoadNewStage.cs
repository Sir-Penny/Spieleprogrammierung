using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewStage : MonoBehaviour
{
    public string sceneName;
    private Scene currentscene;
    private Scene loading;
    private bool sceneLoaded;
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if(sceneLoaded && !currentscene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(loading);
            Destroy(this.gameObject);
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Loading")
        {
            loading = scene;
            SceneManager.UnloadSceneAsync(currentscene);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else if (scene.name == sceneName)
        {
            SceneManager.SetActiveScene(scene);
            sceneLoaded = true;
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
