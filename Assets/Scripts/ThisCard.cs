using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    private string url = "https://picsum.photos/200/150";

    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;

    public GameObject CardImage;

    public int manaCost;
    public Text manaCostObject;

    public int attackPoints;
    public Text attackPointsObject;

    public int healthPoints;
    public Text healthPointsObject;

    public string cardName;
    public Text cardNameObject;

    public string cardDescription;
    public Text cardDescriptionObject;

    private Quaternion cardRotation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadImage(url));
        thisCard[0] = CardDataBase.cardList[thisId];


        id = thisCard[0].id;
        manaCost = thisCard[0].manaCost;
        attackPoints = thisCard[0].attackPoints;
        healthPoints = thisCard[0].healthPoints;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;

        manaCostObject.text = "" + manaCost.ToString();
        attackPointsObject.text = "" + attackPoints.ToString();
        healthPointsObject.text = "" + healthPoints.ToString();
        cardNameObject.text = "" + cardName;
        cardDescriptionObject.text = "" + cardDescription;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        Texture2D texture = null;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

            CardImage.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }


    void OnMouseEnter()
    {
        gameObject.transform.localScale *= 2;
        gameObject.transform.position -= new Vector3(0, 0, 5);
        cardRotation = gameObject.transform.rotation;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.layer += 1;
    }
    void OnMouseExit()
    {
        gameObject.transform.localScale /= 2;
        gameObject.transform.position += new Vector3(0, 0, 5);
        gameObject.transform.rotation = cardRotation;
        gameObject.layer -= 1;
    }
}
