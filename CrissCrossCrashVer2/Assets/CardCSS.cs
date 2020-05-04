using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CardCSS : MonoBehaviour {

    //[SerializeField]
    //public CardButton[] ArchetypeList = new CardButton[16]; //Size of the LIST of card buttons

    public List<Card> ArchetypeList = new List<Card>();

    //public GameObject[] Cursors = new GameObject[2];

    public CardCSS instance;

    public GameObject cardcellprefab;

    private int u = 0;


    /*private void Awake()
    {
        instance = this;
    }*/

    // Use this for initialization
    void Start() {

        foreach (Card card in ArchetypeList)
        {
            SpawnCardCell(card);
        }

        //initialize a certain function for every button using the "delegate" command
        //
        /*while (u <= ArchetypeList.Length - 1)
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
        }*/ 
        

	}
	
	// Update is called once per frame
	void Update () {
		//if(Cursor's raycast is over a CardButton type and the input given was "A")
        //run PopulatePanel(CardButton's.getcomponent.Name, CursorNumber);
	}

    public void SpawnCardCell(Card c)
    {
        GameObject cardcell = Instantiate(cardcellprefab, transform);


        cardcell.name = c.code;
        Image artwork = cardcell.transform.Find("Art").GetComponent<Image>();

        artwork.sprite = c.artwork;

        Vector2 pixelSize = new Vector2(artwork.sprite.texture.width, artwork.sprite.texture.height);
        Vector2 pixelPivot = artwork.sprite.pivot;
        Vector2 uiPivot = new Vector2 (pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);

        artwork.GetComponent<RectTransform>().pivot = uiPivot;
        artwork.GetComponent<RectTransform>().sizeDelta *= c.zoom;

        cardcell.transform.Find("Art").gameObject.name = c.code; //for some reason, the gloves detect the art and not the pictures holding the art...
                                                                 //fuck it, just rename the pictures. We just need to differenciate the icons from each other.
    }
}
