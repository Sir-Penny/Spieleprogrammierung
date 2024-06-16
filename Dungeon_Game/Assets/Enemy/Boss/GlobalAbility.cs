using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAbility : MonoBehaviour
{
    public Transform leftRow;
    public Transform rightRow;
    public Transform topRow;
    public Transform bottomRow;
    public void Activate()
    {
        List<int> randomNumbers = GenerateRandomNumbers(4, 0, 7);
        foreach (int number in randomNumbers)
        {
            leftRow.GetChild(number).GetComponent<FlameThrower>().ActivateFlaemThrowerEffect();
            rightRow.GetChild(number).GetComponent<FlameThrower>().ActivateFlaemThrowerEffect();
        }
        randomNumbers = GenerateRandomNumbers(4, 0, 7);
        foreach (int number in randomNumbers)
        {
            topRow.GetChild(number).GetComponent<FlameThrower>().ActivateFlaemThrowerEffect();
            bottomRow.GetChild(number).GetComponent<FlameThrower>().ActivateFlaemThrowerEffect();
        }
    }

    List<int> GenerateRandomNumbers(int count, int minValue, int maxValue)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        while (uniqueNumbers.Count < count)
        {
            int randomNumber = Random.Range(minValue, maxValue);
            uniqueNumbers.Add(randomNumber);
        }

        return new List<int>(uniqueNumbers);
    }
}
