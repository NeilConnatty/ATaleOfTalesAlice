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
    private Card selected;

    private CardObject[] cardObjects;

    private int NUM_CARDS = 4;

    // these objects require renderer component
    public CardObject cardOne;
    public CardObject cardTwo;
    public CardObject cardThree;
    public CardObject cardFour;
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

        cardObjects = new CardObject[] {cardOne, cardTwo, cardThree, cardFour};
    }

    void Update ()
    {
        Card temp = head;
        int index = 0;
        while (temp != null) {
            cardObjects[index].gameObject.GetComponent<Renderer>().material = temp.cardType;
            temp = temp.next;
            index++;
        }
    }

    public void ResetAll ()
    {
        for (int i=0; i<NUM_CARDS; i++) {
            cardObjects[i].Reset ();
        }
    }

    public void determineSelected ()
    {
        Card temp = head;
        for (int i=0; i<NUM_CARDS; i++) {
            if (cardObjects[i].isSelected()) {
                selected = temp;
                break;
            }
            temp = temp.next;
        }
    }

    public void moveSelectedLeft ()
    {
        if (selected == null) {
            return;
        }
        if (selected.prev == null) {
            // TODO
            return;
        }
        if (selected.next == null) {
            // TODO
            return;
        }

        Card tempPrev = selected.prev;
        Card tempNext = selected.next;

        if (tempPrev == head) {
            head = selected;
        } else {
            tempPrev.prev.next = selected;
        }
        selected.next = tempPrev;
        selected.prev = tempPrev.prev;
        tempPrev.prev = selected;
        tempPrev.next = tempNext;
        tempNext.prev = tempPrev;

    }

    public void moveSelectedRight ()
    {
        if (selected == null) {
            return;
        }
        if (selected.prev == null) {
            // TODO
            return;
        }
        if (selected.next == null) {
            // TODO
            return;
        }

        Card tempPrev = selected.prev;
        Card tempNext = selected.next;

        if (tempNext.next != null) {
            tempNext.next.prev = selected;
        }
        selected.next = tempNext.next;
        selected.prev = tempNext;
        tempPrev.next = tempNext;
        tempNext.next = selected;
        tempNext.prev = tempPrev;

    }


}
