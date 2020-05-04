using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardEncyclopedia : MonoBehaviour {


    public CardDisplay[] UpperDisplay = new CardDisplay[2];

    [SerializeField]
    public CardCSS CardButtons;

    public Card[] CardDatabase = new Card[55];

	// Use this for initialization
	void Start () {
        /*for (int i = 0; i < CardButtons.ArchetypeList.Length; i++)
        {
            CardButtons.ArchetypeList[i].GetComponent<Button>().
        }*/
	
	}
	
	// Update is called once per frame
	void Update () {

        List<Card> Blank = new List<Card>();

        //Blank.
    }


    //scrap the Cards on buttons idea. Unity might not be able to handle that. Takes a full minute just to start up...
    //rather
    //have a Card Encyclopedia for the game to refer to
    //When a button is pressed, have it call a function to fill the CardDisplay's CardArray with cards from the CardEncyclopedia
    //give the function a CODE in its parameter to search the CardEncyclopedia with, and each card a code to be called with, just like in the last version
    //the function will scroll the encyclopedia and make an List<Cards> to send to the CardDisplay
    //List<Card>Blank = new List<Card
    //Blank.add(Cards that match the code)
    //return Blank.toArray to the CardDisplay



    /*public static void fillButtonwithCards(string Code, int buttonspot, Card[] ButtonsCards)// have the 1P vs 2P button activate this function
    {
        int i = 0;//go through the list of cards until the ButtonCards are full, or until you got through the entire list of the encyclopedia
        
        //note the keyword given, Ex: 

    }//initialize the buttons with cards from the Card Database */
}
