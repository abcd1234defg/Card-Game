using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class attackCard : MonoBehaviour, IPointerClickHandler
{
    public GameObject manager;
    public gamemanager gamemanager;
    public GameObject card;
    public GameObject player1, player2, player3;
    public bool isChoose, isDraw;//�ж���������û�б�ѡ��
    bool choose;
    public GameObject position;//�����Ƶ�����λ�ã�����ȷ����card1-6�е��ĸ�
    // Start is called before the first frame update
    private Color color;
    public TextMeshProUGUI text;
    createCard createCard;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.start)
        {
            if (isDraw == true)
            {
                print("asd");
                Destroy(gameObject);
            }
        }
        if (gamemanager.state == gamemanager.gamestate.playing)
        {
            if (isChoose == true)
            {
                Destroy(gameObject);
            }

        }
    }
    void playerChoice()//��һ������λ��˳���������ѡ�е���
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

    void chehui()//�ٴε������ѡ�е���
    {
        card.GetComponent<SpriteRenderer>().color = Color.white;
        card.GetComponent<player>().theColor = null;
        card = null;
        text.text = null;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gamemanager.state == gamemanager.gamestate.beforeStart)
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

        if (gamemanager.state == gamemanager.gamestate.start)
        {
            if (isChoose == false)
            {
                createCard.createNumber++;
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
            
            }
            else if (isChoose == true)
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
