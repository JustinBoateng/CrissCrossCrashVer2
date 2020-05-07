using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHUD : MonoBehaviour {

    [SerializeField]
    public CardDisplay[] Previews = new CardDisplay[2];

    [SerializeField]
    public CardEncyclopedia CE;

    public static bool[] ActiveDisplay = new bool[2];//Flag to Toggle whether or not the Display is active     
    public static bool[] stickneutral = new bool[2];


    public static List<Card>[] SampledArray = new List<Card>[2]; 
    
    public static int[] CurrCard = new int[2];

    public static float[] hor = new float [2];
    public static float[] ver = new float [2];



	// Use this for initialization
	void Start () {
        for (int i = 0; i < ActiveDisplay.Length; i++) ActiveDisplay[i] = false;
        SampledArray[0] = new List<Card>();
        SampledArray[1] = new List<Card>();
        stickneutral[0] = false;
        stickneutral[1] = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when clickling on a button, run _______ to assign the values to the above panels
        //when moving left or right, , change the array number, and then run ________ again with the seleced card 

        hor[0] = Input.GetAxis("Horizontal");
        hor[1] = Input.GetAxis("Horizontal2");

        if (hor[0] == 0) stickneutral[0] = false;
        if (hor[1] == 0) stickneutral[1] = false;

        if (hor[0] != 0 && ActiveDisplay[0] == true) { CardUpdate(hor[0] , 0); }
        if (hor[1] != 0 && ActiveDisplay[1] == true) { CardUpdate(hor[1] , 1); }

        //if (Input.GetButtonDown("Horizontal") > true) { CardUpdate(1 ,0); }
        //if (Input.GetButtonDown("Left")) { CardUpdate(-1, 0); }

        //CardUpdate goes through the CardDisplay's individual array of cards.

        if (Input.GetButton("Cancel")) CardArrayEmpty(0);

    }


    public void CardUpdate(float input, int player)
    {
        if (stickneutral[player] == true) return;

        if (stickneutral[player] == false) stickneutral[player] = true;


        if (input > 0) CurrCard[player] = ((CurrCard[player] + 1) % SampledArray[player].Count);
        else if (input < 0) CurrCard[player] = ((CurrCard[player] + (SampledArray[player].Count - 1)) % SampledArray[player].Count);

        CardShow(player, SampledArray[player], CurrCard[player]);
    }

    public void CardArrayFill(string code, int player) //clicking a button will run this function with its own CardList, thereby giving it to the card display
    {
        //
        int i = 0;
        Debug.Log("i is " + i);
        Debug.Log("CardDatabase Length is " + CE.getDatabaseLength());
        Debug.Log("CardArrayFill, Entering While Loop with " + code);

        while (i < CE.getDatabaseLength())
        {
            Debug.Log("CardArrayFill, Checking card #" + i);
            if (code.ToLower().Contains(CE.CardDatabase[i].code.ToLower()))
            {
                Debug.Log("Player: " + player);
                Debug.Log("Code: " + code.ToLower() + ", Current EncyCard: " + CE.CardDatabase[i].code.ToLower());
                Debug.Log("Sample Array length of player " + player + ": " + SampledArray[player].Count());
                SampledArray[player].Add(CE.CardDatabase[i]);

            }
            i++;
        }//The player's Card Array should be filled now   

        DisplayActive(player);
        CardShow(player, SampledArray[player], 0);

    }//Initializing the Upper Panel by pressing a Card Button

    public void CardShow(int player, List<Card> CL, int CardPosition)
    {
        Card c = CL[CardPosition];

        Previews[player].nameText.text = c.name;
        Previews[player].description.text = c.Description;
        Previews[player].Artwork.GetComponentInChildren<Image>().sprite = c.artwork; 
        Previews[player].StatusImage.GetComponentInChildren<Image>().sprite = c.getStatus(c.element, c.status);
        
    }

    public void CardArrayEmpty(int player)//when exiting a card array, just erase all texy and replace the artwork with out "NullArtwork" (just any placeholder sprite will work)
    {
        DisplayInactive(player);
        SampledArray[player] = new List<Card>();
        CurrCard[player] = 0;

        Previews[player].nameText.text = "";
        Previews[player].description.text = "";
        Previews[player].Artwork.GetComponentInChildren<Image>().sprite = CE.Icons[0];
        Previews[player].StatusImage.GetComponentInChildren<Image>().sprite = CE.Icons[0];
    }

  
    public static void DisplayActive(int player)
    {
        ActiveDisplay[player] = true;
    }

    public static void DisplayInactive(int player)
    {
        ActiveDisplay[player] = false;
    }
    
}
