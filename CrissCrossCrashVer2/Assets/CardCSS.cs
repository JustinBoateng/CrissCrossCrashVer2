using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CardCSS : MonoBehaviour {

    [SerializeField]
    public CardButton[] ArchetypeList = new CardButton[16]; //Size of the LIST of card buttons

    private int u = 0;

    // Use this for initialization
    void Start() {

        //initialize a certain function for every button using the "delegate" command
        //
        while (u <= ArchetypeList.Length - 1)
        {
            Button CB = ArchetypeList[u].GetComponent<Button>();

            CB.onClick.AddListener(new UnityAction(delegate ()
            {   
                //Identify which Cursor clicked the button
                //the cursor SHOULD have the reference to their respective card display

                // = ArchetypeList[u].CardList

                //add to each button the functions you want it to do
                //you want to send the CardButton's Card list to the PanelDisplay's CardList
                //...but first, you'll need the player cursor to act as a bridge between the button and the respective card display
            }));

            u++;
        }
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
