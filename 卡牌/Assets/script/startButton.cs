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
        else if(gamemanager.state == gamemanager.gamestate.playing)
        {
            if (chain.canRun == true)
            {
                gamemanager.state = gamemanager.gamestate.chain;
            }
            else
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

}
