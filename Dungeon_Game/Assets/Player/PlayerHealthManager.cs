using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject HelthBar;
    public GameObject HealthBarUI;
    public Slider slider;
    public Slider sliderUI;
    private Camera playerCam;
    private float maxHealth;

    public float health;

    public GameObject gameLostmenu;

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
        sliderUI.value = health / maxHealth;
    }

    public void ReciveDamge(float damage)
    {
        health -= damage;
        UpdateHelthBar();
        if (health <= 0)
        {
            gameObject.transform.GetComponent<Animator>().SetBool("Death", true);
            gameObject.transform.parent.GetComponent<PlayerMovement>().enabled = false;
            Instantiate(gameLostmenu);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ReciveDamge(other.gameObject.transform.root.GetComponent<EnemyStats>().damage);
        }
        if (other.gameObject.tag == "EnemySpell")
        {
            ReciveDamge(other.gameObject.transform.root.GetComponent<SpellDamage>().Damage);
        }
    }
}
