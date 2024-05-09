using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public enum gamestate { beforeStart, start, magicTime, playing, end}//�ֱ��Ӧ���ƣ����ƣ��Է����ƣ������ĸ��׶�
    public enum gamestate2 { win, lose, draw}//ÿ�ֵ�ʤ��
    public gamestate state;
    public gamestate2 state2;
    public string choice;
    public int number1, number2, number3;
    public int fire, water, grass, enemyFire, enemyWater, enemyGrass;//��¼��Һ͵���ÿ����ɫ�����˶�����
    public bool canStart;
    public GameObject player1, player2, player3, enemy1, enemy2, enemy3;
    public int win, lose;//�����˶Ա�ʱӮ����Ĵ���
    public TextMesh text;
    public int drawCard;//���Ƶ�����
    public int enemylife = 10, playerlife = 10;
    public int playerDamage, enemyDamage;
    public int magicNum;
    bool canDamage;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == gamestate.start)
        {
            if(fire + water + grass == 3)//��Ұ�������ѡ��
            {
                canStart = true;
            }
            else
                canStart = false;
            canDamage = true;
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
                    enemylife -= playerDamage;
                    canDamage = false;
                    print("asdad");
                }
                if (state2 == gamestate2.lose)
                {
                    playerlife -= enemyDamage;
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
    public void enemy()//������ʮ������
    {
        if(state == gamestate.playing)
        {
            number1 = Random.Range(1, 13);
            number2 = Random.Range(1, 13);
            number3 = Random.Range(1, 13);
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
