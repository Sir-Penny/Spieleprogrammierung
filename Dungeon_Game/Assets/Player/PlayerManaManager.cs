using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaManager : MonoBehaviour
{
    public Slider sliderUI;
    private float maxMana;

    public float mana;
    public float regenerationAmmount;

    private void Start()
    {
        maxMana = mana;
        StartCoroutine(RegenrateMana());
    }
    public void UpdateManaBar()
    {
        sliderUI.value = mana / maxMana;
    }

    public bool TryUseMana(float ammount)
    {
        if (mana - ammount >= 0)
        {
            mana -= ammount;
            UpdateManaBar();
            return true;
        }else
        {
            return false;
        }

    }
    public IEnumerator RegenrateMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (mana < maxMana)
            {
                mana += regenerationAmmount;
                UpdateManaBar();
            }
        }
    }
}
