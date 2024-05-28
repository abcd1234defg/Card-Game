using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
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
    public string imformation;
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
        text=transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.text = null;
        
        
 
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.start)
        {
            if (isDraw == true)
            {
                createCard.remake = false;
                Destroy(gameObject);
                createCard.LeftCardlist.Add(imformation);
                print("asd");
                
            }
        }
        if (gamemanager.state == gamemanager.gamestate.playing)
        {
            if (isChoose == true)
            {
                Destroy(gameObject);
                createCard.LeftCardlist.Add(imformation);
            }

        }
    }
    void playerChoice()//按一二三号位的顺序填入玩家选中的牌
    {
        if (player1.GetComponent<player>().theColor == null)
        {
            player1.GetComponent<player>().theColor = gameObject.tag.ToString();
            card = player1;
            string[] cn = gameObject.name.ToString().Split('(');
            card.GetComponent<player>().cardName = cn[0];
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
            string[] cn = gameObject.name.ToString().Split('(');
            card.GetComponent<player>().cardName = cn[0];
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
            string[] cn = gameObject.name.ToString().Split('(');
            card.GetComponent<player>().cardName = cn[0];
            text.text = ("3");
        }

    }

    void chehui()//再次点击撤回选中的牌
    {
        if(card != null)
        {
            card.GetComponent<Image>().color = new Vector4(1, 1,1,0);
            card.GetComponent<Image>().sprite = null;
            card.GetComponent<player>().theColor = null;
            card = null;
            text.text = null;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
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
                    if (gamemanager.canStart == false)
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
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1);
        GetComponent<SortingGroup>().sortingOrder = 0;
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.localScale = new Vector3(1.3f, 1.3f);
        GetComponent<SortingGroup>().sortingOrder = 1;
    }
}
