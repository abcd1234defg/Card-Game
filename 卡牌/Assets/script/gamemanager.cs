using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public enum gamestate { beforeStart, start, magicStart, magicEnd, playing, end}//分别对应弃牌，出牌，对方出牌，结算四个阶段
    public enum gamestate2 { win, lose, draw}//每局的胜负
    public enum gamestate3 { magicStart, magicEnd, none }
    public gamestate state;
    public gamestate2 state2;
    public gamestate3 state3;
    public int number1, number2, number3;
    public int fire, water, grass, enemyFire, enemyWater, enemyGrass;//记录玩家和电脑每种颜色各出了多少张
    public bool canStart;
    public GameObject player1, player2, player3, enemy1, enemy2, enemy3;
    public int win, lose;//跟敌人对比时赢和输的次数
    public TextMesh text;
    public int drawCard;//弃牌的数量
    public int enemylife = 10, playerlife = 10;
    public int playerDamage, enemyDamage;
    public int magicNum;
    bool canDamage;
    public TextMesh e1, e2, e3;
    magicManager magicManager;
    int[] odd = {1, 3, 5, 7, 9, 11};
    int[] even = { 2, 4, 6, 8, 10, 12 };
    public bool canO, canE;
    public int beiLv;//双方的伤害的倍率
    public int f,w,g;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player3 = GameObject.Find("player3");
        enemy1 = GameObject.Find("enemy1");
        enemy2 = GameObject.Find("enemy2");
        enemy3 = GameObject.Find("enemy3");
        Application.targetFrameRate = 60;
        state = gamestate.beforeStart;
        enemylife = 10; playerlife = 10;
        canDamage = true;
        state3 = gamestate3.none;
        magicManager = GetComponent<magicManager>();
        bool canE = true;
    
    }

    // Update is called once per frame
    void Update()
    {
        e1.text = number1.ToString();
        e2.text = number2.ToString();
        e3.text = number3.ToString();
        if(state == gamestate.beforeStart)
        {
            beiLv = 1;
        }
        if (state == gamestate.start)
        {
            if ((fire + water + grass == 3) && magicNum == 0)//玩家把三张牌选满
            {
                canStart = true;
            }
            else
                canStart = false;
            canDamage = true;
        }
        if(state3 == gamestate3.magicEnd)
        {
            f = w = g = 0;
        }
        if(state == gamestate.playing)
        {
            pDamage();
            eDamage();  
        }
        if(state == gamestate.end)
        {
          if(win > lose)
            {
                state2 = gamestate2.win;
                
            }
          if(win < lose)
            {
                state2 = gamestate2.lose;
                
            }
          if(win == lose)
            {
                state2 = gamestate2.draw;
                if(fire == 3 || water == 3 || grass == 3)
                {
                    if(enemyFire == enemyGrass && enemyWater == enemyGrass)
                    {
                        state2 = gamestate2.win;
                    }
                }
                if(fire == 1 && water == 1 && grass == 1)
                {
                    if(enemyFire == 3 || enemyWater == 3 || enemyGrass == 3)
                    {
                        state2 = gamestate2.lose;
                    }
                }
            }
          if(canDamage == true)
            {
                if (state2 == gamestate2.win)
                {
                    enemylife -= (playerDamage * beiLv);
                    canDamage = false;
                    print("asdad");
                }
                if (state2 == gamestate2.lose)
                {
                    playerlife -= (enemyDamage * beiLv);
                    canDamage = false;
                }
                if (state2 == gamestate2.draw)
                {
                    enemylife -= 1;
                    playerlife -= 1;
                    canDamage = false;
                }
            }
          
            drawCard = 0;
        }
        
        if(state == gamestate.beforeStart)
        {
            fire = 0;
            water = 0;
            grass = 0;
            enemyFire = 0;
            enemyGrass = 0;
            enemyWater = 0;
            number1 = 0;
            number2 = 0;
            number3 = 0;
            win = 0;
            lose = 0;
            canStart = false;
            canDamage = false;
        }
        text.text = state.ToString();
    }
    public void enemy()//骰三个十二面骰
    {
        if(state == gamestate.playing)
        {
            int randomIndex = Random.Range(1, odd.Length);
            int randomIndex2 = Random.Range(1, odd.Length);
            int randomIndex3 = Random.Range(1, odd.Length);

            if (canO)
            {
                number1 = odd[randomIndex];
               
                number2 = odd[randomIndex2];
                
                number3 = odd[randomIndex3];
                canO = false;
                print("odd");
            }
            else if (canE)
            {
                number1 = even[randomIndex];
                
                number2 = even[randomIndex2];
                
                number3 = even[randomIndex3];
                canE = false;
                print("even");
            }
            else if(canE == false && canO == false)
            {
                number1 = Random.Range(1, 13);
                number2 = Random.Range(1, 13);
                number3 = Random.Range(1, 13);
                print("both");
            }
      
        }
        
    }
    public void pDamage()
    {
        if(fire == 2 || water == 2 || grass == 2)
        {
            playerDamage = 2;
        }
        if(fire == 3 || water == 3 || grass == 3)
        {
            playerDamage = 3;
        }
    }
    public void eDamage()
    {
        if(enemyFire == 2 || enemyWater == 2 || enemyGrass == 2)
        {
            enemyDamage = 2;
        }
        if(enemyFire == 3 || enemyWater == 3 || grass == 3)
        {
            enemyDamage = 3;
        }
    }
}
