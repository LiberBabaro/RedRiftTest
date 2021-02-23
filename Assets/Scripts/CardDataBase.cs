using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();

    void Awake()
    {
        cardList.Add(new Card(0, 4, 4, 4, "0", "asdas dasd 0"));
        cardList.Add(new Card(1, 2, 5, 3, "1", "asdas dasd 1"));
        cardList.Add(new Card(2, 3, 2, 3, "2", "asdas dasd 2"));
        cardList.Add(new Card(3, 1, 2, 1, "3", "asdas dasd 3"));
        cardList.Add(new Card(4, 6, 8, 8, "4", "asdas dasd 4"));
    }
}
