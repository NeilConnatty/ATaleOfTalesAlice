using UnityEngine;
using System.Collections;

public class Card {
    public Card next;
    public Card prev;
    public Material cardType;
}

public class CardLock : MonoBehaviour
{
    private Card head;
    private Card tail;

    private GameObject[] cardObjects;

    // these objects require renderer component
    public GameObject cardOne;
    public GameObject cardTwo;
    public GameObject cardThree;
    public GameObject cardFour;
    // four different suits
    public Material hearts;
    public Material clubs;
    public Material spades;
    public Material diamonds;

    void Awake ()
    {
        Card tempH = new Card {next = null, prev = null, cardType = hearts};
        Card tempC = new Card {next = null, prev = null, cardType = clubs};
        Card tempS = new Card {next = null, prev = null, cardType = spades};
        Card tempD = new Card {next = null, prev = null, cardType = diamonds};

        head = tempH;
        tempH.next = tempC;
        tempC.prev = tempH;
        tempC.next = tempS;
        tempS.prev = tempC;
        tempS.next = tempD;
        tempD.prev = tempS;

        cardObjects = new GameObject[] {cardOne, cardTwo, cardThree, cardFour};
    }

    void Update ()
    {
        Card temp = head;
        int index = 0;
        while (temp != null)
        {
            cardObjects[index].GetComponent<Renderer>().material = temp.cardType;
            temp = temp.next;
            index++;
        }
    }


}
