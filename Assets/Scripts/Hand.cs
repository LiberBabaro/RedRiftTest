using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public int currentId;

    public List<ThisCard> Cards;

    private ThisCard currentCard;
    public Text numberText;

    public float animationTime = 1.5f;

    private float desiredNumber;
    private float initialNumber;
    private float currentNumber;

    public void ChangeAttribute()
    {
        desiredNumber = 0;
        currentCard = Cards[currentId];
        desiredNumber += RandomChange.RandomizeValue();
        switch (RandomChange.RandomizeAttribute())
        {
            case 0:
                currentNumber = currentCard.manaCost;
                desiredNumber += currentCard.manaCost;
                numberText = currentCard.manaCostObject;
                currentCard.manaCost = (int)desiredNumber;
                break;
            case 1:
                currentNumber = currentCard.attackPoints;
                desiredNumber += currentCard.attackPoints;
                numberText = currentCard.attackPointsObject;
                currentCard.attackPoints = (int)desiredNumber;
                break;
            default:
                currentNumber = currentCard.healthPoints;
                desiredNumber += currentCard.healthPoints;
                numberText = currentCard.healthPointsObject;
                currentCard.healthPoints = (int)desiredNumber;
                break;
        }
        initialNumber = currentNumber;

        currentId++;
        if (currentId == Cards.Count)
            currentId = 0;
    }

    public void Update()
    {
        if (currentNumber != desiredNumber)
        {
            if (initialNumber < desiredNumber)
            {
                currentNumber += (animationTime * Time.deltaTime) * (desiredNumber - initialNumber);
                if (currentNumber >= desiredNumber)
                    currentNumber = desiredNumber;
            }
            else
            {
                currentNumber -= (animationTime * Time.deltaTime) * (initialNumber - desiredNumber);
                if (currentNumber <= desiredNumber)
                    currentNumber = desiredNumber;
            }
            numberText.text = ((int)currentNumber).ToString();
        }
    }
}
