using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour
{

    public static Card[] CardList = new Card[10];
    public static Card card;
    public static int CurrCard = 0;
    public static bool ActiveDisplay = false;

    [SerializeField]
    public Text nameText;
    [SerializeField]
    public Text description;
    [SerializeField]
    public Image Artwork;
    [SerializeField]
    public Sprite NullArtwork;
    public Text Element;
    [SerializeField]
    public Image ElementImage;

    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //when clickling on a button, run _______ to assign the values to the above panels
        //when moving left or right, , change the array number, and then run ________ again with the seleced card 
        float Horizontal = Input.GetAxis("Horizontal");
        if (Horizontal != 0 && ActiveDisplay == true) {CardUpdate(Horizontal);}

    }


    public void CardUpdate(float input)
    {
        if (input > 0) CurrCard = ((CurrCard + 1) % CardList.Length);
        else if (input < 0) CurrCard = ((CurrCard + (CardList.Length-1)) % CardList.Length);

        /*while (CardList[CurrCard] == null)
        {
            if (input > 0) CurrCard = ((CurrCard + 1) % CardList.Length);
            else if (input < 0) CurrCard = ((CurrCard + (CardList.Length - 1)) % CardList.Length);
        }*/

        CardShow();

    }

    public void CardArrayFill (Card[] CardButtonList) //clicking a button will run this function with its own CardList, thereby giving it to the card display
    {
        DisplayActive();
        CardList = CardButtonList;
        CurrCard = 0;
        CardShow();

    }//Initializing the Upper Panel by pressing a Card Button

    public void CardArrayEmpty()//when exiting a card array, just erase all texy and replace the artwork with out "NullArtwork" (just any placeholder sprite will work)
    {
        DisplayInactive();
        CardList = new Card[10];

        nameText.text = "";
        description.text = "";
        Artwork.sprite = NullArtwork;
        Element.text = "";
        ElementImage.sprite = NullArtwork;
    }

    public void CardShow()
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
}
