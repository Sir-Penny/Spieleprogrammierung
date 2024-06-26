using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporteEffect : MonoBehaviour
{
    private Coroutine effect;
    private int i=0;
    public string sceneName;
    public GameObject LoadScenen;
    public IEnumerator RunEffect()
    {
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            transform.GetChild(i).gameObject.SetActive(true);
            i++;
        }
        Time.timeScale = 0;
        GameObject go = Instantiate(LoadScenen);
        go.GetComponent<LoadNewStage>().sceneName = sceneName;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            effect = StartCoroutine(RunEffect());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(effect);
        }
    }
}
