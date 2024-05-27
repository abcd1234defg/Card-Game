using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemy : MonoBehaviour
{
    public gamemanager gamemanager;
    public string color;
    public int fire, water, grass;//目前没用
    public bool canGoOn;
    public GameObject Num;//十二个数字中这张牌对应的数字
    public number number;
    public int ATK;
    public GameObject anim;
    bool canA,atkcheck;
    GameObject theA;
    public TextMeshProUGUI TextAtk;
    // Start is called before the first frame update
    void Start()
    {
        canGoOn = true;
        atkcheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (color == null)
        {
            TextAtk.text = " ";
        }
        if (color != null &&color != "1")
        {
            TextAtk.text = ATK.ToString();
        }
        if (gamemanager.GetComponent<gamemanager>().state == gamemanager.gamestate.beforeStart) { TextAtk.text = " "; }


        if (gamemanager.state!= gamemanager.gamestate.beforeStart && atkcheck == false) { atkcheck = true; }
        if (gamemanager.state == gamemanager.gamestate.beforeStart&&atkcheck==true)
        {
            float randomValue = Random.value;

            // 根据概率分配攻击力
            if (randomValue < 2f / 3f) // 2/3 的概率
            {
                ATK = 1;
                atkcheck = false;
            }
            else // 剩余的 1/3 概率
            {
                ATK = 2;
                atkcheck = false;
            }
        }
        if (gamemanager.state == gamemanager.gamestate.playing)
        {
            if (gameObject.name == ("enemy1"))
            {
                enemy1();
                
            }
            if (gameObject.name == ("enemy2"))
            {
                enemy2();
            }
            if (gameObject.name == ("enemy3"))
            {
                enemy3();
            }
        }
        if (gamemanager.state == gamemanager.gamestate.animation)
        {
            GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
           
            if (canA == false)
            {

                theA = Instantiate(anim, transform);
                theA.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                
                canA = true;
            }
        }
        if (gamemanager.state == gamemanager.gamestate.end)
        {
            Destroy(theA);
            canA = false;
            GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }
        if (gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            Destroy(theA);
            color = null;
            this.GetComponent<Image>().color = new Vector4(1,1, 1, 0);
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
            this.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("slm");
            color = "water";
            gamemanager.enemyWater++;
            canGoOn = false;

        }
        if (number.theColor == number.blockColor.fire)
        {
            this.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("ntrb4");
            color = "fire";
            gamemanager.enemyFire++;
            canGoOn = false;

        }
        if (number.theColor == number.blockColor.grass)
        {
            this.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("lvp");
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
