using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHUD : MonoBehaviour {

    [SerializeField]
    public CardDisplay[] Previews = new CardDisplay[2];

    public bool ActiveDisplay = false;//Flag to Toggle whether or not the Display is active 

    public Card[][] SampledArray = new Card[2][]; //[player][card]

    public int[] CurrCard = new int[2];

    public float[] hor = new float [2];
    public float[] ver = new float [2];



	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    /*void Update()
    {
        //when clickling on a button, run _______ to assign the values to the above panels
        //when moving left or right, , change the array number, and then run ________ again with the seleced card 

        hor[0] = Input.GetAxis("Horizontal");
        hor[1] = Input.GetAxis("Horizontal2");
        if (hor[0] != 0 && ActiveDisplay == true) { CardUpdate(hor[0] , 0); }
        if (hor[1] != 0 && ActiveDisplay == true) { CardUpdate(hor[1] , 1); }
        //CardUpdate goes through the CardDisplay's individual array of cards.
    }


    public void CardUpdate(float input, int player)
    {
        if (input > 0) CurrCard[player] = ((CurrCard[player] + 1) % SampledArray[player].Length);
        else if (input < 0) CurrCard[player] = ((CurrCard[player] + (SampledArray[player].Length - 1)) % SampledArray[player].Length);

        while (CardList[CurrCard] == null)
        {
            if (input > 0) CurrCard = ((CurrCard + 1) % CardList.Length);
            else if (input < 0) CurrCard = ((CurrCard + (CardList.Length - 1)) % CardList.Length);
        }

        CardShow();

    }

    public void CardArrayFill(string s, int player) //clicking a button will run this function with its own CardList, thereby giving it to the card display
    {
        //
        DisplayActive();
        //CardList = CardButtonList;
        CurrCard = 0;
        CardShow();

    }//Initializing the Upper Panel by pressing a Card Button

    public void CardArrayEmpty(int player)//when exiting a card array, just erase all texy and replace the artwork with out "NullArtwork" (just any placeholder sprite will work)
    {
        DisplayInactive();
        CardList = new Card[10];

        nameText.text = "";
        description.text = "";
        Artwork.sprite = NullArtwork;
        Element.text = "";
        ElementImage.sprite = NullArtwork;
    }

    public void CardShow(int player)
    {
        card = CardList[CurrCard];

        nameText.text = card.name;
        description.text = card.Description;
        Artwork.sprite = card.artwork;
        Element.text = card.element;
    }

    public static void DisplayActive()
    {
        ActiveDisplay = true;
    }

    public static void DisplayInactive()
    {
        ActiveDisplay = false;
    }
    */
}
