using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public enum gamestate { beforeStart, start, playing, singlePhase,animation,chain1, chain2, end, gameover}//分别对应弃牌，出牌，对方出牌，结算四个阶段
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
    public int enemylife = 20, playerlife = 10;
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
    string over;//游戏结束告知输赢
    public bool canOver;
    public TextMeshProUGUI winOrLose;
    public TextMeshProUGUI chainText;
    GameObject image;
    Color color;
    public int doubleattack = 0;
    public bool c1 = true, c2 = true, c3 = true;
    GameObject tutorial;
    public string GameEnd;
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
        enemylife = 30; playerlife = 10;
        canDamage = true;
        state3 = gamestate3.none;
        magicManager = GetComponent<magicManager>();
        Application.targetFrameRate = 60;
        image = GameObject.Find("Image");
        color = image.GetComponent<Image>().color;
        tutorial = GameObject.Find("tutorial");
        GameEnd = "hold";
    }

    // Update is called once per frame
    void Update()
    {
    
        if(state == gamestate.beforeStart)
        {
            beiLv = 1;
            image.GetComponent<Image>().color = Vector4.zero;
            e1.text = null;
            e2.text = null;
            e3.text = null;
            if (c1)
            {
                tutorial.SetActive(true);
            }
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
            chainT();
            c1 = false;
            if (c2)
            {
                tutorial.SetActive(true);
            }
        }
        if(state3 == gamestate3.magicEnd)
        {
            f = w = g = 0;
        }
        if(state == gamestate.playing)
        {
 
            chainText.text = null;
            image.GetComponent<Image>().color = Vector4.zero;
            e1.text = number1.ToString();
            e2.text = number2.ToString();
            e3.text = number3.ToString();
            if (c3)
            {
                tutorial.SetActive(true);
            }
        }
        if (state == gamestate.chain1||state== gamestate.chain2) 
        {
            pDamage();
            eDamage();
        }
        if(state == gamestate.end)
        {

            if (win > lose)
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
                /*if(fire == 3 || water == 3 || grass == 3)
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
                }*/
            }
          if(canDamage == true)
            {
                if (state2 == gamestate2.win)
                {
                    enemylife -= ((playerDamage+doubleattack) * beiLv);
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
            doubleattack = 0;
        }
        text.text = state.ToString();
        //////////////////////////////////////////////////////////////////////////////////////
        if(state != gamestate.gameover)
        {
            if(playerlife <= 0)
            {
                canOver = true;
                over = "you lose";
                GameEnd = "PlayerLose";
                state = gamestate.gameover;
            }
            if (enemylife <= 0)
            {
                canOver = true;
                over = "you win";
                GameEnd = "PlayerWin";
                state = gamestate.gameover;
            }
        }
        if(state == gamestate.gameover)
        {
            winOrLose.text = over;
            if (GameEnd == "PlayerLose")
            {
                SceneManager.LoadScene("Lose");

            }
            if (GameEnd == "PlayerWin")
            {
                SceneManager.LoadScene("Win");

            }
        }
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
        if (fire == 2)
        {
            playerDamage = player1.GetComponent<Single>().ATK + player2.GetComponent<Single>().ATK + player3.GetComponent<Single>().ATK + 1;
        }
        if (fire == 3)
        {
            playerDamage = player1.GetComponent<Single>().ATK + player2.GetComponent<Single>().ATK + player3.GetComponent<Single>().ATK + 3;
        }
        if (water == 2 || water == 3 || grass == 2 || grass == 3)
        {
            playerDamage = player1.GetComponent<Single>().ATK + player2.GetComponent<Single>().ATK + player3.GetComponent<Single>().ATK;
        }
    }
    public void eDamage()
    {
        if (enemyFire == 2)
        {
            enemyDamage = enemy1.GetComponent<enemy>().ATK + enemy2.GetComponent<enemy>().ATK + enemy3.GetComponent<enemy>().ATK + 1;
        }
        if (enemyFire == 3)
        {
            enemyDamage = enemy1.GetComponent<enemy>().ATK + enemy2.GetComponent<enemy>().ATK + enemy3.GetComponent<enemy>().ATK + 3;
        }
        if (enemyWater == 2 || enemyWater == 3 || enemyGrass == 2 || enemyGrass == 3)
        {
            enemyDamage = enemy1.GetComponent<enemy>().ATK + enemy2.GetComponent<enemy>().ATK + enemy3.GetComponent<enemy>().ATK;
        }
    }

    void chainT()
    {
        if(state3 == gamestate3.magicStart)
        {
            image.GetComponent<Image>().color = color;
            if(magicManager.canSwap)
            {
                chainText.text = "Exchange: Swap two enemy's attack tendency.";
            }
            if(magicManager.canTransF)
            {
                chainText.text = "Let't NTR: Turn an enemy's attack tendency into minotaur.";
            }
            if (magicManager.canTransW)
            {
                chainText.text = "Slime Time: Turn an enemy's attack tendency into slime.";
            }
            if (magicManager.canTransG)
            {
                chainText.text = "Goblin Party: Turn an enemy's attack tendency into goblin.";
            }
            if (magicManager.canOdd)
            {
                chainText.text = "Odd!!: Enemy can only roll out odd number during this turn.";
            }
            if (magicManager.canEven)
            {
                chainText.text = "Even!!: Enemy can only roll out even number during this turn.";
            }
            if (magicManager.canDouble)
            {
                chainText.text = "True Hero Potion: During this turn, the damage X2.";
            }

        }
        else
        {
            if (water == 2)
            {
                chainText.text = "Chain Effect: Give yourself up to 2 defend marks, each marks can decrease enemy 1 damage per turn.";
                image.GetComponent<Image>().color = color;
            }
            if (water == 3)
            {
                chainText.text = "Chain Effect: Give yourself up to 1 heal mark, each marks healing 1 life per turn";
                image.GetComponent<Image>().color = color;
            }
            if (grass == 2)
            {
                chainText.text = "Chain Effect: Give enemy up to 1 burn mark, each marks will make 1 damage per turn";
                image.GetComponent<Image>().color = color;
            }
            if (grass == 3)
            {
                chainText.text = "Chain Effect: Clean all the marks from the borad, each marks you clean can give your enemy 1 damage.";
                image.GetComponent<Image>().color = color;
            }
            if (fire == 2)
            {
                chainText.text = "Chain Effect: If you win, the total damage +1 until end of this turn.";
                image.GetComponent<Image>().color = color;
            }
            if (fire == 3)
            {
                chainText.text = "Chain Effect: If you win, the total damage +3 until end of this turn.";
                image.GetComponent<Image>().color = color;
            }
            if (fire <= 1 && water <= 1 && grass <= 1)
            {
                chainText.text = null;
                image.GetComponent<Image>().color = Vector4.zero;
            }

        }

    }
}
