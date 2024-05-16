using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        print("a=" + a);
        if(gamemanager.state == gamemanager.gamestate.start)
        {
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
        if(gamemanager.state == gamemanager.gamestate.start)
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
                }
            }
           
        }
       
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
         transform.localScale = new Vector3(1, 1);
        spriteRenderer.sortingOrder = 0;
        Debug.Log("under");


    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
         transform.localScale = new Vector3(1.5f, 1.5f);
        spriteRenderer.sortingOrder = 1;
        Debug.Log("above");
        

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
