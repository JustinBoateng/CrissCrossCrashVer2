using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardButton : Button {

    [SerializeField]
    public Card[] CardList = new Card[10]; //[C/C/C/C/C/C/CM/CM/S/B] //holding a list of the cards to send to the CardDisplay
    
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    //onClick send that cardbutton's cardlist to the CYC panel	
	}
}
