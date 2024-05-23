using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public gamemanager gamemanager;
    public GameObject creater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(gamemanager.state == gamemanager.gamestate.start)
        {

            if(gamemanager.canStart == true)
            {
                    gamemanager.state = gamemanager.gamestate.playing;
                    gamemanager.enemy();               
            }
        }
        /////////////////////////////////////////
       
        ///////////////////////////////////////////
        else if(gamemanager.state == gamemanager.gamestate.playing)
        {
            gamemanager.state = gamemanager.gamestate.singlePhase;
        }
        else if (gamemanager.state == gamemanager.gamestate.singlePhase)
        {
            gamemanager.state = gamemanager.gamestate.end;
        }
        else if(gamemanager.state == gamemanager.gamestate.end)
        {
            gamemanager.state=gamemanager.gamestate.beforeStart;
            creater.GetComponent<createCard>().isEmpty = true;
            creater.GetComponent<createCard>().remake = false;
        }
        else if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            gamemanager.state = gamemanager.gamestate.start;
            creater.GetComponent<createCard>().isEmpty = true;
            creater.GetComponent<createCard>().remake = false;

        }
    }
    /*   gamemanager.fire = 0;
            gamemanager.water = 0;
            gamemanager.grass = 0;
            gamemanager.enemyFire = 0;
            gamemanager.enemyGrass = 0;
            gamemanager.enemyWater = 0;
            gamemanager.number1 = 0;
            gamemanager.number2 = 0;
            gamemanager.number3 = 0;
            gamemanager.win = 0;
            gamemanager.lose = 0;
            gamemanager.abc = 0;*/
}
