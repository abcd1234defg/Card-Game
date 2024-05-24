using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class magicCard : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public gamemanager gamemanager;
    public GameObject manager;
    public int a = 0;
    public bool isChoose;
    GameObject num1, num2;
    magicManager magicManager;
    private CanvasRenderer canvasRenderer;
    SpriteRenderer spriteRenderer;
    private Color color;
    public GameObject thisButton;
    GameObject creater;
    bool draw;//true表示这张牌会被弃掉
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("gamemanager");
        gamemanager = manager.GetComponent<gamemanager>();
        magicManager = manager.GetComponent<magicManager>();
        canvasRenderer = GetComponent<CanvasRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = GetComponent<Image>().color;
        creater = GameObject.Find("magic card area");
        thisButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            if(draw)
            {
                isChoose = false;
                GetComponent<Image>().color = color;
                Destroy(gameObject);
            }
            if (isChoose == true)
            {
                if(gameObject.name == "swapPosition(Clone)")
                {
                    magicManager.canSwap = true;
                    print("swap");
                }
                if(gameObject.name == "transFire(Clone)")
                {
                    magicManager.canTrans = true;
                    magicManager.canTransF = true;
                }
                if (gameObject.name == "transWater(Clone)")
                {
                    magicManager.canTrans = true;
                    magicManager.canTransW = true;
                }
                if (gameObject.name == "transGrass(Clone)")
                {
                    magicManager.canTrans = true;
                    magicManager.canTransG = true;
                }
                if(gameObject.name == "odd(Clone)")
                {
                    magicManager.canOdd = true;
                }
                if (gameObject.name == "even(Clone)")
                {
                    magicManager.canEven = true;
                }
                if(gameObject.name == "doubleDamage(Clone)")
                {
                    magicManager.canDouble = true;
                }
            }
        }
        if (gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
            if (isChoose == true)
            {
                isChoose = false;
                gamemanager.magicNum--;
                GetComponent<Image>().color = color;
                magicManager.canGoOn = true;
                Destroy(gameObject);
                creater.GetComponent<createMagic>().existNum--;
            }
        }

    }
  
    public void OnPointerClick(PointerEventData eventData)
    {
        if(gamemanager.state == gamemanager.gamestate.beforeStart)//弃牌阶段弃牌
        {
            if(isChoose == false)
            {
                isChoose = true;
                creater.GetComponent<createMagic>().draw = true;
                creater.GetComponent<createMagic>().existNum--;
                creater.GetComponent<createMagic>().drawNum++;
                GetComponent<Image>().color = new Vector4(1, 1, 1, 0.6f);
                draw = true;
            }
            else if(isChoose == true)
            {
                isChoose = false;
                creater.GetComponent<createMagic>().draw = false;
                creater.GetComponent<createMagic>().existNum++;
                creater.GetComponent<createMagic>().drawNum--;
                GetComponent<Image>().color = new Vector4(1, 1, 1, 1f);
                draw = false;
            }
        }
        if(gamemanager.state == gamemanager.gamestate.start)//出牌阶段出牌
        {
            if(gamemanager.state3 == gamemanager.gamestate3.none)
            {
                if (isChoose == false)
                {
                    isChoose = true;
                    gamemanager.magicNum++;
                    gamemanager.state3 = gamemanager.gamestate3.magicStart;
                    GetComponent<Image>().color = Color.gray;
                    thisButton.SetActive(true);
                }
            }
            else if(gamemanager.state3 == gamemanager.gamestate3.magicStart || gamemanager.state3 == gamemanager.gamestate3.magicEnd)
            {
                if(isChoose == true)
                {
                    isChoose = false;
                    gamemanager.magicNum--;
                    gamemanager.state3 = gamemanager.gamestate3.none;
                    GetComponent<Image>().color = color;
                    thisButton.SetActive(false);
                    magicManager.canClick = false;
                }
            }
           
        }
       
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
         transform.localScale = new Vector3(1, 1);
        spriteRenderer.sortingOrder = 0;
        Debug.Log("under");
        GetComponent<SortingGroup>().sortingOrder = 0;

    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
         transform.localScale = new Vector3(1.3f, 1.3f);
        spriteRenderer.sortingOrder = 1;
        Debug.Log("above");
        GetComponent<SortingGroup>().sortingOrder = 1;

    }
    public void clickB()
    {
        Debug.Log("Clicked outside");
        if (magicManager.canClick == true)
        {
            Debug.Log("Clicked inside");
            gamemanager.state3 = gamemanager.gamestate3.magicEnd;
        }
        
    }
}
