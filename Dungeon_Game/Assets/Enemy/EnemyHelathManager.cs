using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHelathManager : MonoBehaviour
{
    public GameObject HelthBar;
    public Slider slider;
    public EnemyStats enemyStats;
    private Camera playerCam;
    private float maxHealth;

    private void Awake()
    {
        playerCam = Camera.main;
        maxHealth = enemyStats.Health;
        slider.value = enemyStats.Health;
        HelthBar.transform.LookAt(playerCam.transform);
    }
    private void Update()
    {
        HelthBar.transform.LookAt(playerCam.transform);
    }

    public void UpdateHelthBar()
    {
        slider.value = enemyStats.Health/maxHealth;
    }

    public void ReciveDamge(float damage)
    {
        enemyStats.Health -= damage;
        UpdateHelthBar();
        if (enemyStats.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spell")
        {
            ReciveDamge(other.gameObject.GetComponent<Spell>().damageAmount);
            Destroy(other.gameObject);
        }
    }
}
