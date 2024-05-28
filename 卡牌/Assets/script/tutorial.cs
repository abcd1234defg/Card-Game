using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public gamemanager gamemanager;
    public TextMeshProUGUI text;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if(gamemanager.c1)
            {
                gameObject.SetActive(true);
                text.text = "Now it's the discard phase. You can discard up to three attack cards (cards on the left) and " +
                "all magic cards in your hand (cards on the right). The discarded cards will be replenished afterward." +
                " Click the 'next' button to proceed to the next phase.";
            }
            
        }

        if(gamemanager.state == gamemanager.gamestate.start)
        {
           
            if(gamemanager.c2)
            {
                gameObject.SetActive(true);
                text.text = "It is now the play phase. You need to play exactly three attack cards and any number of magic cards. You can right-click" +
               " on an attack card to view its information. Different quantities of the same type of attack card will give you different chain effects." +
               " Click the 'next' button to proceed to the next phase.";
            }
           

        }
        if(gamemanager.state == gamemanager.gamestate.playing)
        {
            
            if(gamemanager.c3)
            {
                gameObject.SetActive(true);
                text.text = "Now, let's explain the settlement rules: Based on the outcome of each of the three sets of cards from both sides, the side that wins" +
               " more sets is the winner. The winner will deal damage to the loser equal to the sum of the values of the three cards." +
               " Click the 'next' button to proceed to the next phase.";
            }
           
        }
        if(gamemanager.state == gamemanager.gamestate.singlePhase)
        {
            gameObject.SetActive(false);
        
            text.text = null;
        }

        
    }
    public void delete()
    {
        gameObject.SetActive(false);
        text.text = null;
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            gamemanager.c1 = false;
        }
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            gamemanager.c2 = false;
        }
        if(gamemanager.state == gamemanager.gamestate.playing)
        {
            gamemanager.c3 = false;
        }
    }

}
