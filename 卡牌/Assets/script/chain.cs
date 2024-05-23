using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class chain : MonoBehaviour
{
    public gamemanager gamemanager;
    enum owner { player, enemy };
    owner o;
    enum marking { shield, burn, heal }
    marking mark1, mark2, mark3;
    public bool canRun, canRun2;
    public int shield, heal, burn;
    int eShield, eHeal, eBurn;
    public GameObject p1, p2, p3, e1, e2, e3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.playing)
        {
            if (canRun == false)
            {
                if (gamemanager.water == 2)
                {
                    twoWater();
                    canRun = true;
                }
                if (gamemanager.water == 3)
                {
                    threeWater();
                    canRun = true;
                }
                if (gamemanager.grass == 2)
                {
                    twoGrass();
                    canRun = true;
                }
            }
            if (canRun2 == false)
            {
                if (gamemanager.enemyWater == 2)
                {
                    etwoWater();
                    canRun2 = true;
                }
                if (gamemanager.enemyWater == 3)
                {
                    ethreeWater();
                    canRun2 = true;
                }
                if (gamemanager.enemyGrass == 2)
                {
                    etwoGrass();
                    canRun2 = true;
                }
            }


        }
        if (gamemanager.state == gamemanager.gamestate.chain)
        {
            if (gamemanager.win > gamemanager.lose)
            {

                for (int i = 0; i < eShield; i++)
                {
                    if (gamemanager.playerDamage >= 2)
                    {
                        gamemanager.playerDamage -= 2;
                        eShield--;
                    }
                }
            }
            if (gamemanager.win < gamemanager.lose)
            {

                for (int i = 0; i < shield; i++)
                {
                    if (gamemanager.enemyDamage >= 2)
                    {
                        gamemanager.enemyDamage -= 2;
                        shield--;
                    }
                }
            }
            canRun = false;
            canRun2 = false;
            if (canRun == false || canRun2 == false)
            {
                gamemanager.state = gamemanager.gamestate.end;
                canRun = true;
                canRun2 = true;
            }
        }
        if (gamemanager.state == gamemanager.gamestate.end)
        {
            if (canRun)
            {
                for (int i = 0; i < burn; i++)
                {
                    gamemanager.enemylife--;
                }
                for (int j = 0; j < heal; j++)
                {
                    gamemanager.playerlife++;
                }
                canRun = false;
            }
            if (canRun2)
            {
                for (int i = 0; i < eBurn; i++)
                {
                    gamemanager.playerlife--;
                }
                for (int j = 0; j < eHeal; j++)
                {
                    gamemanager.enemylife++;
                }
                canRun2 = false;
            }
        }
    }
    void twoWater()
    {
        shield++;
    }
    void threeWater()
    {
        heal++;
    }
    void twoGrass()
    {
        burn++;
    }
    void etwoWater()
    {
        eShield++;
    }
    void ethreeWater()
    {
        eHeal++;
    }
    void etwoGrass()
    {
        eBurn++;
    }
}
