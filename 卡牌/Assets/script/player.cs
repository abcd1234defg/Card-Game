using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public enum haveColor { fire, water, grass, none }
    public haveColor color;
    public string theColor;//用于记录这个位置的牌的颜色
    public gamemanager gamemanager;
    public GameObject manager;
    public bool canGoOn;
    public GameObject enemy;//对应位置的敌人
    public int ATK;
    public string single;
    public string cardName;
    public GameObject anim;
    bool canA;
    GameObject theA;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = null;
        canGoOn = true;
        manager = GameObject.Find("gamemanager");
        gamemanager = manager.GetComponent<gamemanager>();
        if (this.gameObject.name == ("player1"))
        {
            theColor = null;
        }
        if (this.gameObject.name == ("player2"))
        {
            theColor = "1";//这个1是占位用的
        }
        if (this.gameObject.name == ("player3"))
        {
            theColor = "1";
        }
        if (this.gameObject.name == ("player1"))
        {
            enemy = GameObject.Find("enemy1");
        }
        if (this.gameObject.name == ("player2"))
        {
            enemy = GameObject.Find("enemy2");
        }
        if (this.gameObject.name == ("player3"))
        {
            enemy = GameObject.Find("enemy3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (theColor == "fire")
        {
            //GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Image>().sprite = Resources.Load<Sprite>(cardName);
            GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }
        if (theColor == "water")
        {
            //GetComponent<SpriteRenderer>().color = Color.blue;
            GetComponent<Image>().sprite = Resources.Load<Sprite>(cardName);
            GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }
        if (theColor == "grass")
        {
            //GetComponent <SpriteRenderer>().color = Color.green;
            GetComponent<Image>().sprite = Resources.Load<Sprite>(cardName);
            GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }
        if (gamemanager.state == gamemanager.gamestate.playing)
        {
            compare();
        }
        if (gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if (gameObject.name == "player1")
            {
                theColor = null;
            }

            if (gameObject.name == "player2" || gameObject.name == "player3")
            {
                theColor = "1";
            }
            GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
            GetComponent<Image>().sprite = null;
            canGoOn = true;
            print("111");
        }
        if (gamemanager.state == gamemanager.gamestate.animation)
        {
            
            GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
            t = 2;


            if (canA == false)
            {
                theA = Instantiate(anim, transform);
                theA.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                canA = true;
                
            }
            t -= Time.deltaTime;
            if (t <= 0)
            {
                
            }
            


        }
        if (gamemanager.state == gamemanager.gamestate.chain1 || gamemanager.state == gamemanager.gamestate.chain2)
        {
            Destroy(theA);
            t = 1;
            canA = false;
            GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        }
    }

    void compare()
    {
        if (canGoOn == true)
        {
            if (theColor == "fire" && enemy.GetComponent<enemy>().color == "water")
            {
                gamemanager.lose++;
                print("1111");
                canGoOn = false;
            }
            if (theColor == "water" && enemy.GetComponent<enemy>().color == "grass")
            {
                gamemanager.lose++;
                print("1111");
                canGoOn = false;
            }
            if (theColor == "grass" && enemy.GetComponent<enemy>().color == "water")
            {
                gamemanager.win++;
                print("1111");
                canGoOn = false;
            }
            if (theColor == "fire" && enemy.GetComponent<enemy>().color == "grass")
            {
                gamemanager.win++;
                print("1111");
                canGoOn = false;
            }
            if (theColor == "water" && enemy.GetComponent<enemy>().color == "fire")
            {
                gamemanager.win++;
                print("1111");
                canGoOn = false;
            }
            if (theColor == "grass" && enemy.GetComponent<enemy>().color == "fire")
            {
                gamemanager.lose++;
                print("1111");
                canGoOn = false;
            }
        }
        
    }
}
