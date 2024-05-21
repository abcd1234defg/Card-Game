using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class attackCard : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject manager;
    public gamemanager gamemanager;
    public GameObject card;
    public GameObject player1, player2, player3;
    public bool isChoose, isDraw;//判断这张牌有没有被选中
    bool choose;
    public GameObject position;//这张牌的生成位置，用来确认是card1-6中的哪个
    // Start is called before the first frame update
    private Color color;
    public TextMeshProUGUI text;
    createCard createCard;
    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("gamemanager");
        gamemanager = manager.GetComponent<gamemanager>();
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player3 = GameObject.Find("player3");
        isChoose = false;
        position = GameObject.Find("attack card area");
        createCard = position.GetComponent<createCard>();
        color = GetComponent<Image>().color;
        text.text = null;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.start)//回合弃牌阶段，把选中的手卡丢弃
        {
            if (isDraw == true)
            {
                print("asd");
                Destroy(gameObject);
            }
        }
        if (gamemanager.state == gamemanager.gamestate.playing)//回合出牌阶段的出牌将选中的牌删除
        {
            if (isChoose == true)
            {
                Destroy(gameObject);
            }

        }
    }
    void playerChoice()//按一二三号位的顺序填入玩家选中的牌
    {
        if (player1.GetComponent<player>().theColor == null)
        {
            player1.GetComponent<player>().theColor = gameObject.tag.ToString();
            card = player1;
            if(player2.GetComponent<player>().theColor == "1")
            {
                player2.GetComponent<player>().theColor = null;
            }
            text.text = ("1");
        }
        else if (player2.GetComponent<player>().theColor == null)
        {
            player2.GetComponent<player>().theColor = gameObject.tag.ToString();
            card = player2;
            if (player3.GetComponent<player>().theColor == "1")
            {
                player3.GetComponent<player>().theColor = null;
            }
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
        if(card != null)
        {
            card.GetComponent<SpriteRenderer>().color = Color.white;
            card.GetComponent<player>().theColor = null;
            card = null;
            text.text = null;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gamemanager.state == gamemanager.gamestate.beforeStart)//弃牌阶段
        {
            if (choose == false)
            {
                if (gamemanager.drawCard < 3)
                {
                    createCard.createNumber++;
                    isDraw = true;
                    print("color change");
                    color.a = 0.5f;
                    GetComponent<Image>().color = color;
                    gamemanager.drawCard++;
                    choose = true;
                }
            }
            else if (choose == true)
            {
                if (gamemanager.drawCard > 0)
                {
                    createCard.createNumber--;
                    color.a = 1f;
                    GetComponent<Image>().color = color;
                    gamemanager.drawCard--;
                    isDraw = false;
                    choose = false;
                }
            }
        }

        if (gamemanager.state == gamemanager.gamestate.start)//出牌阶段
        {
            if (isChoose == false)//出牌
            {
                if(gamemanager.canStart == false)
                {
                    createCard.createNumber++;
                    playerChoice();
                    if (this.gameObject.tag == "fire")
                    {
                       
                            gamemanager.fire++;
                    }

                    if (gameObject.tag == "water")
                    {
                        
                            gamemanager.water++;

                        
                    }

                    if (gameObject.tag == "grass")
                    {
                       
                            gamemanager.grass++;

                        
                    }
                    isChoose = true;
                }
            }
            else if (isChoose == true)//再次点击该牌取消出牌
            {
                createCard.createNumber--;
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
                isChoose = false;
            }
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1);
        spriteRenderer.sortingOrder = 0;


    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.localScale = new Vector3(1.5f, 1.5f);
        spriteRenderer.sortingOrder = 1;
    }
}
