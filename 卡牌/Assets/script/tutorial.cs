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
                text.text = "This phase is the preparation phase. During this phase, you can choose to discard and redraw up to three cards, or you can choose to reset your magic cards. Click NEXT to proceed to the next phase of the game.";
            }
            
        }

        if(gamemanager.state == gamemanager.gamestate.start)
        {
           
            if(gamemanager.c2)
            {
                gameObject.SetActive(true);
                text.text = "This phase is the main phase. During this phase, you must choose three cards from your hand to play, right-click on a card to check these effects and counter relationships. You can also choose to use the magic cards on the right side. When you select two or more cards of the same type, different chain effects will be triggered. Click NEXT to proceed to the next phase of the game.";
            }
           

        }
        if(gamemanager.state == gamemanager.gamestate.playing)
        {
            
            if(gamemanager.c3)
            {
                gameObject.SetActive(true);
                text.text = "This phase will enter the battle phase. During this phase, the victory or defeat between each pair of opposing cards will be determined. The side with more advantageous counter relationships will win. After winning, each card's attack power will be used to deal damage to the opponent. Don't worry, you can still resolve your chain effects. Click NEXT to enter the battle.";
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
