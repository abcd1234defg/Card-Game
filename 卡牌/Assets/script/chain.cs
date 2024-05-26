
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class chain : MonoBehaviour
{
    public gamemanager gamemanager;

    public bool canRun, canRun2;//让敌我双方的挂印机只挂一次
    bool canC, canC2;//用来让三水和二草只触发一次
    public int shield, heal, burn;//我方印记
    public int eShield, eHeal, eBurn;//敌方印记
    public GameObject p1, p2, p3, e1, e2, e3;//目前没用
    bool canGoOn, canGoOn2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.playing)//印记在playing阶段挂上去
        {
            canC = canC2 = true;
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(gamemanager.state == gamemanager.gamestate.chain1)//////////////////////////////3草
        {
            if(canRun == false)
            {
                if (gamemanager.grass == 3)
                {
                    threeGrass();
                    canRun = true;
                }
            }
            if(canRun2 == false)
            {
                if (gamemanager.enemyGrass == 3)
                {
                    ethreeGrass();
                    canRun2 = true;
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (gamemanager.state == gamemanager.gamestate.chain2)////////////////////2水
        {
            if (gamemanager.win > gamemanager.lose)
            {
                if(gamemanager.playerDamage >0)
                {
                    for (int i = 0; i < eShield; i = 0)
                    {
                        if (gamemanager.playerDamage >= 1)
                        {
                            gamemanager.playerDamage--;
                            eShield--;
                            print("shield");
                        }
                        if (gamemanager.playerDamage == 0)
                        {
                            break;
                        }
                    }
                   
                }
            }
            if (gamemanager.win < gamemanager.lose)
            {
                if(gamemanager.enemyDamage >0)
                {
                    for (int i = 0; i < shield; i = 0)
                    {
                        if (gamemanager.enemyDamage >= 1)
                        {
                            gamemanager.enemyDamage--;
                            shield--;
                            print("shield");
                        }
                        if (gamemanager.enemyDamage == 0)
                        {
                            break;
                        }
                    }
                }
            }
            gamemanager.state = gamemanager.gamestate.end;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (gamemanager.state == gamemanager.gamestate.end)/////////////////////////三水二草
        {
            if (canC)
            {
                for (int i = 0; i < burn; i++)
                {
                    gamemanager.enemylife--;
                }
                for (int j = 0; j < heal; j++)
                {
                    gamemanager.playerlife++;
                }
                canC = false;
                canRun = false;
            }
            if (canC2)
            {
                for (int i = 0; i < eBurn; i++)
                {
                    gamemanager.playerlife--;
                }
                for (int j = 0; j < eHeal; j++)
                {
                    gamemanager.enemylife++;
                }
                canC2 = false;
                canRun2 = false;
            }
        }
    }
    void twoWater()
    {
        shield += 2;
    }
    void threeWater()
    {
        heal++;
    }
    void twoGrass()
    {
        burn++;
    }
    void threeGrass()
    {
        if (gamemanager.state == gamemanager.gamestate.chain1)
        {
            if(canGoOn == false)
            {
                print(shield + heal + burn + eShield + eHeal + eBurn);
                gamemanager.enemylife -= (shield + heal + burn + eShield + eHeal + eBurn);
                shield = heal = burn = eShield = eHeal = eBurn = 0;
                canGoOn = true;
            }
         if(canGoOn)
            {
                gamemanager.state = gamemanager.gamestate.chain2;
                canGoOn = false;
            }
        }
    }
    void etwoWater()
    {
        eShield += 2;
    }
    void ethreeWater()
    {
        eHeal++;
    }
    void etwoGrass()
    {
        eBurn++;
    }
    void ethreeGrass()
    {
        if (gamemanager.state == gamemanager.gamestate.chain1)
        {
            if(canGoOn2 == false)
            {
                gamemanager.playerlife -= (shield + heal + burn + eShield + eHeal + eBurn);
                shield = heal = burn = eShield = eHeal = eBurn = 0;
                canGoOn2 = true;
            }         
            if(canGoOn2)
            {
                gamemanager.state = gamemanager.gamestate.chain2;
                canGoOn2 = false;
            }        
        }
    }
}
