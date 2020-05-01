using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour {

    public Card card;

    public Text nameText;
    public Text description;
    public Image artwork;
    public Text Element;
    public Text Description;


    // Use this for initialization
    void Start () {
        nameText.text = card.name;
        description.text = card.Description;
        artwork.sprite = card.artwork;
        Element.text = card.element;
        Description.text = card.Description;

	}
	
	// Update is called once per frame
	void Update () {
		//when clickling on a button, run _______ to assign the values to the above panels
        //when moving left or right, , change the array number, and then run ________ again with the seleced card 
	}
}
