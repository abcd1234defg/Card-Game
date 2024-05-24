using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startButton : MonoBehaviour
{
    public gamemanager gamemanager;
    public GameObject creater;
    public GameObject manager;
    chain chain;
    // Start is called before the first frame update
    void Start()
    {
        chain = manager.GetComponent<chain>();
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
        //

        else if(gamemanager.state == gamemanager.gamestate.playing)
        {
                gamemanager.state = gamemanager.gamestate.singlePhase;
        }
        else if (gamemanager.state == gamemanager.gamestate.singlePhase)
        {
            if (gamemanager.grass == 3 || gamemanager.enemyGrass == 3)
            {
                gamemanager.state = gamemanager.gamestate.chain1;//三草进一个state
            }
            else
                gamemanager.state = gamemanager.gamestate.chain2;//二水进一个state
        }
            

        else if(gamemanager.state == gamemanager.gamestate.end)
        {
            if(gamemanager.canOver)
            {
                gamemanager.state = gamemanager.gamestate.gameover;
            }
            else
            {
                gamemanager.state = gamemanager.gamestate.beforeStart;
                creater.GetComponent<createCard>().isEmpty = true;
                creater.GetComponent<createCard>().remake = false;
            }

        }
        else if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            gamemanager.state = gamemanager.gamestate.start;
            creater.GetComponent<createCard>().isEmpty = true;
            creater.GetComponent<createCard>().remake = false;

        }
        else if(gamemanager.state == gamemanager.gamestate.gameover)
        {
            SceneManager.LoadScene(0);
        }
    }

}
