using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using Color = UnityEngine.Color;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fire : MonoBehaviour, IPointerClickHandler //, IPointerUpHandler, IPointerEnterHandler
{
    public GameObject manager;
    public gamemanager gamemanager;
    public GameObject card;
    public GameObject player1, player2, player3;
    public bool isChoose;//判断这张牌有没有被选中
    public GameObject position;//这张牌的生成位置，用来确认是card1-6中的哪个
    // Start is called before the first frame update
    private Color color;
    public TextMesh text;
    
    void Start()
    {
        manager = GameObject.Find("gamemanager");
        gamemanager = manager.GetComponent<gamemanager>();
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player3 = GameObject.Find("player3");
        isChoose = false;
        if(this.transform.position.x == -5)
        {
            position = GameObject.Find("card1");
        }
        if (this.transform.position.x == -3)
        {
            position = GameObject.Find("card2");
        }
        if (this.transform.position.x == -1)
        {
            position = GameObject.Find("card3");
        }
        if (this.transform.position.x == 1)
        {
            position = GameObject.Find("card4");
        }
        if (this.transform.position.x == 3)
        {
            position = GameObject.Find("card5");
        }
        if (this.transform.position.x == 5)
        {
            position = GameObject.Find("card6");
        }
        if(position.GetComponent<cardPosition>().remake == true)
        {
            position.GetComponent<cardPosition>().remake = false;
        }

        color = GetComponent<SpriteRenderer>().color;
        text.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            if(position.GetComponent<cardPosition>().remake == true)
            {
                print("asd");
                Destroy(gameObject);
            }
        }
        if(gamemanager.state == gamemanager.gamestate.playing)
        {
            if(isChoose == true)
            {
                Destroy(gameObject);
            }
            
        }
    }
    private void OnMouseDown()
    {
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if(position.GetComponent<cardPosition>().remake == false)
            {
                if(gamemanager.drawCard <3)
                {
                    position.GetComponent<cardPosition>().isEmpty = true;
                    position.GetComponent<cardPosition>().remake = true;

                    print("color change");
                    color.a = 0.5f;
                    GetComponent<SpriteRenderer>().color = color;
                    // GetComponent<SpriteRenderer>().color = new Vector4(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 125);
                    gamemanager.drawCard++;
                }
            }
            else if(position.GetComponent<cardPosition>().remake == true)
            {
                if(gamemanager.drawCard > 0)
                {
                    position.GetComponent<cardPosition>().isEmpty = false;
                    position.GetComponent<cardPosition>().remake = false;
                    color.a = 1f;
                    GetComponent<SpriteRenderer>().color = color;
                    gamemanager.drawCard--;
                }
            }
        }

        if (gamemanager.state == gamemanager.gamestate.start)
        {
            if (isChoose == false)
            {
                playerChoice();
                if (this.gameObject.tag == "fire")
                {
                    if (gamemanager.canStart == false)
                    {
                        gamemanager.fire++;

                    }
                    gamemanager.choice = "fire";
                }

                if (gameObject.tag == "water")
                {
                    if (gamemanager.canStart == false)
                    {
                        gamemanager.water++;

                    }
                }

                if (gameObject.tag == "grass")
                {
                    if (gamemanager.canStart == false)
                    {
                        gamemanager.grass++;

                    }
                }
                isChoose = true;
                position.GetComponent<cardPosition>().isEmpty = true;
            }
            else if(isChoose == true)
            {
                if (this.gameObject.tag == "fire")
                {
                        gamemanager.fire--;
                }

                if (gameObject.tag == "water")
                {
                        gamemanager.water--;
                }

                if (gameObject.tag == "grass")
                {
                        gamemanager.grass--;
                }
                chehui();
                isChoose=false;
                position.GetComponent<cardPosition>().isEmpty = false;
            }
        }
        
     
    
    }
    void playerChoice()//按一二三号位的顺序填入玩家选中的牌
    {
        if (player1.GetComponent<player>().theColor == null)
        {
            player1.GetComponent<player>().theColor = gameObject.tag.ToString();
            card = player1;
            player2.GetComponent<player>().theColor = null;
            text.text = ("1");
        }
        else if (player2.GetComponent<player>().theColor == null)
        {
            player2.GetComponent<player>().theColor = gameObject.tag.ToString();
            card = player2;
            player3.GetComponent<player>().theColor = null;
            text.text = ("2");
        }
        else if (player3.GetComponent<player>().theColor == null)
        {
            player3.GetComponent<player>().theColor = gameObject.tag.ToString();
            card = player3;
            text.text = ("3");
        }

    }

    void chehui()//再次点击撤回选中的牌
    {
        card.GetComponent<SpriteRenderer>().color = Color.white;
        card.GetComponent<player>().theColor = null;
        card = null;
        text.text = null;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
