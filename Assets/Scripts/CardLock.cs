using UnityEngine;
using System.Collections;
using System;

public class Card {
    public Card next;
    public Card prev;
    public Material suitMat;
    public Material selectedMat;
    public bool selected;
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
    // the materials with highlight for if card is selected
    public Material hearts_highlight;
    public Material clubs_highlight;
    public Material spades_highlight;
    public Material diamonds_highlight;

    public string[] suitSolution;

    void Awake ()
    {
        Card tempH = new Card {next = null, prev = null, suitMat = hearts,
            selectedMat = hearts_highlight, selected = false, suit = "hearts"};
        Card tempC = new Card {next = null, prev = null, suitMat = clubs,
            selectedMat = clubs_highlight, selected = false, suit = "clubs"};
        Card tempS = new Card {next = null, prev = null, suitMat = spades,
            selectedMat = spades_highlight, selected = false, suit = "spades"};
        Card tempD = new Card {next = null, prev = null, suitMat = diamonds,
            selectedMat = diamonds_highlight, selected = false, suit = "diamonds"};

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
            if (temp.selected) {
                cardObjects[index].gameObject.GetComponent<Renderer>().material = temp.selectedMat;
            } else {
                cardObjects[index].gameObject.GetComponent<Renderer>().material = temp.suitMat;
            }
            temp = temp.next;
            index++;
        }
    }

    // Reset all cards so they are no longer selected
    public void ResetAll ()
    {
        Card temp = head;
        for (int i=0; i<NUM_CARDS; i++) {
            temp.selected = false;
            cardObjects[i].Reset ();
            temp = temp.next;
        }
    }

    public void determineSelected ()
    {
        Card temp = head;
        for (int i=0; i<NUM_CARDS; i++) {
            if (cardObjects[i].isSelected()) {
                selected = temp;
                temp.selected = true;
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
