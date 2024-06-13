using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject HelthBar;
    public Slider slider;
    private Camera playerCam;
    private float maxHealth;

    public float health;

    private void Start()
    {
        playerCam = Camera.main;
        maxHealth = 100;
        slider.value = 100;
        HelthBar.transform.LookAt(playerCam.transform);
    }
    void Update()
    {
        HelthBar.transform.LookAt(playerCam.transform);
    }
    public void UpdateHelthBar()
    {
        slider.value = health / maxHealth;
    }

    public void ReciveDamge(float damage)
    {
        health -= damage;
        UpdateHelthBar();
        if (health <= 0)
        {
            Destroy(this.transform.root.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ReciveDamge(other.gameObject.transform.root.GetComponent<EnemyStats>().damage);
        }
    }
}
