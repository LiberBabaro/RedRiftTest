using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Card : MonoBehaviour
{
    public int id;
    public int manaCost;
    public int attackPoints;
    public int healthPoints;
    public string cardName;
    public string cardDescription;

    public Card()
    {

    }

    public Card(int ID, int MP, int HP, int AP, string name, string description)
    {
        id = ID;
        manaCost = MP;
        healthPoints = HP;
        attackPoints = AP;
        cardName = name;
        cardDescription = description;
    }
}
