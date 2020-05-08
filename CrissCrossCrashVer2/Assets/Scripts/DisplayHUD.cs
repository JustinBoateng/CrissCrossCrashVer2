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

    [SerializeField]
    public GloveMovement[] Gloves = new GloveMovement[2];//Cursor References

    public static List<Card>[] SampledArray = new List<Card>[2]; 
    
    public static int[] CurrCard = new int[2];

    public static float[] hor = new float [2];
    public static float[] prevhor = new float [2];
    public static bool[] stickneutral = new bool[2];



    // Use this for initialization
    void Start () {
        for (int i = 0; i < Gloves.Length; i++)
        {
            //ActiveDisplay[i] = false;
            SampledArray[i] = new List<Card>();
            stickneutral[i] = true;
            //hor[i] = Input.GetAxis("Horizontal" + i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //when clickling on a button, run _______ to assign the values to the above panels
        //when moving left or right, , change the array number, and then run ________ again with the seleced card 
        //hor[0] = Input.GetAxis("Horizontal0");
        //hor[1] = Input.GetAxis("Horizontal1");

        for (int i = 0; i < Gloves.Length; i++)
        { hor[i] = Input.GetAxis("Horizontal"+i); }

        
        if (Input.GetAxis("Horizontal0") > 0) hor[0] = 1;
        if (Input.GetAxis("Horizontal0") < 0) hor[0] = -1;
        if (Input.GetAxis("Horizontal0") == 0) hor[0] = 0;

        if (Input.GetAxis("Horizontal1") > 0) hor[1] = 1;
        if (Input.GetAxis("Horizontal1") < 0) hor[1] = -1;
        if (Input.GetAxis("Horizontal1") == 0) hor[1] = 0;
        


        //glove navigation is handled in the glove class
        //while Card-in-the-HUD navigation is handled in this class

        //Debug.Log(hor[0]);

        if (hor[0] == 0) stickneutral[0] = true;                
        if (hor[1] == 0) stickneutral[1] = true;

        if ((hor[0] != 0) && ActiveDisplay[0] == true) { CardUpdate(hor[0] , 0); }
        if ((hor[1] != 0) && ActiveDisplay[1] == true) { CardUpdate(hor[1] , 1); }

        prevhor[0] = hor[0];
        prevhor[1] = hor[1];


        //if (Input.GetButtonDown("Horizontal") > true) { CardUpdate(1 ,0); }
        //if (Input.GetButtonDown("Left")) { CardUpdate(-1, 0); }

        //CardUpdate goes through the CardDisplay's individual array of cards.

        if (Input.GetButton("Cancel0")) CardArrayEmpty(0);
        if (Input.GetButton("Cancel1")) CardArrayEmpty(1);
    }


    public void CardUpdate(float input, int player)
    {
        if (stickneutral[player] == false) return; //if we're still leaning, exit immediately

        if (stickneutral[player] == true) stickneutral[player] = false; //if we pressed left or right the first time, take only that input and put up the flag disregarding any other input


        if (input > 0) CurrCard[player] = ((CurrCard[player] + 1) % SampledArray[player].Count);
        else if (input < 0) CurrCard[player] = ((CurrCard[player] + (SampledArray[player].Count - 1)) % SampledArray[player].Count);

        CardShow(player, SampledArray[player], CurrCard[player]);
    }

    public void CardArrayFill(string code, int player) //clicking a button will run this function with its own CardList, thereby giving it to the card display
    {
        //
        int i = 0;
        
        while (i < CE.getDatabaseLength())
        {
            if (code.ToLower().Contains(CE.CardDatabase[i].code.ToLower()))
            {
                
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

        Previews[player].nameText.text = c.cardname;
        Previews[player].description.text = c.Description;
        Previews[player].Artwork.GetComponentInChildren<Image>().sprite = c.artwork; 
        Previews[player].StatusImage.GetComponentInChildren<Image>().sprite = CE.StatusTranslate(c.element, c.status);
        
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

  
    public void DisplayActive(int player)
    {
        ActiveDisplay[player] = true;
        Gloves[player].gameObject.SetActive(false);
    }

    public void DisplayInactive(int player)
    {
        ActiveDisplay[player] = false;
        Gloves[player].gameObject.SetActive(true);
    }
    
}
