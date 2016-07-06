using UnityEngine;
using System.Collections;
using System;

public class Card {
    public Card next;
    public Card prev;
    public Material suitMat;
    public string suit;
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

    public string[] suitSolution;

    void Awake ()
    {
        Card tempH = new Card {next = null, prev = null, suitMat = hearts, suit = "hearts"};
        Card tempC = new Card {next = null, prev = null, suitMat = clubs, suit = "clubs"};
        Card tempS = new Card {next = null, prev = null, suitMat = spades, suit = "spades"};
        Card tempD = new Card {next = null, prev = null, suitMat = diamonds, suit = "diamonds"};

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
            cardObjects[index].gameObject.GetComponent<Renderer>().material = temp.suitMat;
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
        Card tempPrev;
        Card tempNext;
        Card tempTail;

        if (selected == null) {
            return;
        }

        if (selected.prev == null) {
            tempTail = head;
            for (int i=0; i<NUM_CARDS-1; i++) {
                tempTail = tempTail.next;
            }
            tempNext = selected.next;

            tempTail.next = selected;
            selected.prev = tempTail;
            selected.next = null;
            tempNext.prev = null;
            head = tempNext;

            return;
        }

        if (selected.next == null) {
            tempPrev = selected.prev;

            tempPrev.prev.next = selected;
            selected.prev = tempPrev.prev;
            selected.next = tempPrev;
            tempPrev.prev = selected;
            tempPrev.next = null;

            return;
        }

        tempPrev = selected.prev;
        tempNext = selected.next;

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
        Card tempPrev;
        Card tempNext;
        Card tempHead;

        if (selected == null) {
            return;
        }

        if (selected.prev == null) {
            tempNext = selected.next;
            selected.next = tempNext.next;
            selected.prev = tempNext;
            tempNext.next.prev = selected;
            tempNext.next = selected;
            tempNext.prev = null;
            head = tempNext;

            return;
        }

        if (selected.next == null) {
            tempHead = head;
            tempPrev = selected.prev;

            tempPrev.next = null;
            selected.prev = null;
            selected.next = tempHead;
            tempHead.prev = selected;
            head = selected;

            return;
        }

        tempPrev = selected.prev;
        tempNext = selected.next;

        if (tempNext.next != null) {
            tempNext.next.prev = selected;
        }
        selected.next = tempNext.next;
        selected.prev = tempNext;
        tempPrev.next = tempNext;
        tempNext.next = selected;
        tempNext.prev = tempPrev;

    }

    public bool checkCorrectness ()
    {
        Card temp = head;
        for (int i=0; i<NUM_CARDS-1; i++) {
            if (!suitSolution[i].Equals(temp.suit, StringComparison.CurrentCultureIgnoreCase)) {
                return false;
            }
            temp = temp.next;
        }
        return true;
    }
}
