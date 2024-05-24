using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public gamemanager gamemanager;
    public string color;
    public int fire, water, grass;//目前没用
    public bool canGoOn;
    public GameObject Num;//十二个数字中这张牌对应的数字
    public number number;
    public int ATK;
    // Start is called before the first frame update
    void Start()
    {
        canGoOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            ATK = 1;
        }
        if(gamemanager.state == gamemanager.gamestate.playing)
        {
            if (transform.position.x < 0)
            {
                enemy1();
            }
            if (transform.position.x == 0)
            {
                enemy2();
            }
            if (transform.position.x > 0)
            {
                enemy3();
            }
        }
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            color = null;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            canGoOn = true;
        }
    }
    void enemy1()//一号位的牌
    {
        if (canGoOn == true)
        {
            Num = GameObject.Find(gamemanager.number1.ToString());
            number = Num.GetComponent<number>();
            if(Num != null)
            {
                chufa();
            }
            
        }
        
    }
    void enemy2()//二号位的牌
    {
        if (canGoOn == true)
        {
            Num = GameObject.Find(gamemanager.number2.ToString());
            number = Num.GetComponent<number>();
            if (Num != null)
            {
                chufa();
            }

        }

    }
    void enemy3()//三号位的牌
    {
        if (canGoOn == true)
        {
            Num = GameObject.Find(gamemanager.number3.ToString());
            number = Num.GetComponent<number>();
            if (Num != null)
            {
                chufa();
            }

        }

    }
    void chufa()
    {
        if (number.theColor == number.blockColor.water)
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            color = "water";
            gamemanager.enemyWater++;
            canGoOn = false;

        }
        if (number.theColor == number.blockColor.fire)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            color = "fire";
            gamemanager.enemyFire++;
            canGoOn = false;

        }
        if (number.theColor == number.blockColor.grass)
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
            color = "grass";
            gamemanager.enemyGrass++;
            canGoOn = false;

        }
    }


    /*if (gamemanager.number1 > 0 && gamemanager.number1 <= 4)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                color = "water";
                gamemanager.enemyWater++;
                canGoOn = false;
            }
            if (gamemanager.number1 > 4 && gamemanager.number1 <= 8)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                color = "fire";
                gamemanager.enemyFire++;
                canGoOn = false;
            }
            if (gamemanager.number1 > 8 && gamemanager.number1 <= 12)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                color = "grass";
                gamemanager.enemyGrass++;
                canGoOn = false;
            }*/
}
