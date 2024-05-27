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
    float sTime, aTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        chain = manager.GetComponent<chain>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            sTime = 1;
            aTime = 2;
        }
        if (gamemanager.state == gamemanager.gamestate.singlePhase)
        {
            sTime -= Time.deltaTime;
            if(sTime <= 0)
            {
                gamemanager.state = gamemanager.gamestate.animation;
            }
            
        }
        if (gamemanager.state == gamemanager.gamestate.animation)
        {
            aTime -= Time.deltaTime;
            if(aTime <= 0)
            {
                if (gamemanager.grass == 3 || gamemanager.enemyGrass == 3)
                {
                    gamemanager.state = gamemanager.gamestate.chain1;//三草进一个state
                }
                else
                    gamemanager.state = gamemanager.gamestate.chain2;//二水进一个state

            }
            
        }
    }
    public void OnMouseDown()
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
            //creater.GetComponent<createCard>().remake = false;

        }
        else if(gamemanager.state == gamemanager.gamestate.gameover)
        {
            SceneManager.LoadScene(0);
        }
    }

}
