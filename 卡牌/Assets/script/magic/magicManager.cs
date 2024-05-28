using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class magicManager : MonoBehaviour
{
    public GameObject num1, num2;
    public bool canSwap;//判断是否执行交换颜色
    public bool canTrans;//
    public bool canTransF, canTransW, canTransG;
    public bool canOdd, canEven;
    public bool canGoOn;//用来从magicEnd变成none
    public bool canClick;//用来判断是否可以按下魔法卡上的confirm按钮
    public bool canDouble;
    public gamemanager gamemanager;
    public GameObject thisCard;
    public number number1;
    public GameObject anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSwap)
        {
            swapPositions();
        }
        if(canTrans)
        {
            transColor();
        }
        if(canOdd)
        {
            oddC();
        }
        if (canEven)
        {
            evenC();
        }
        if(canDouble)
        {
            doubleD();
        }
    }
    public void Click()
    {
        if(num1 != null && num2 != null)
        {
            gamemanager.state3 = gamemanager.gamestate3.magicEnd;
        }
       
    }


    void swapPositions()//调换两个数字对应的颜色
    {
        if (gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
                if (num1 != null && num2 != null)
                {
                    num1.GetComponent<number>().empty = num1.GetComponent<number>().theColor;
                    num2.GetComponent<number>().empty = num2.GetComponent<number>().theColor;
                    canClick = true;
                }
        }
        if (gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
                num1.GetComponent<number>().theColor = num2.GetComponent<number>().empty;
                num2.GetComponent<number>().theColor = num1.GetComponent<number>().empty;
            if(canGoOn == true)
            {
                gamemanager.state3 = gamemanager.gamestate3.none;
                canGoOn = false;
            }
        }
        if (gamemanager.state3 == gamemanager.gamestate3.none)
        {
            num1 = null;
            num2 = null;
            canSwap = false;
            canClick = false;
        }
    }
    void transColor()//切换单一颜色
    {
        if(gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
            if(num1 != null)
            {
                
                number1 = num1.GetComponent<number>();
                if (canTransF)
                {
                    if ((number1.theColor == number.blockColor.grass && gamemanager.g > 1) || (number1.theColor == number.blockColor.water && gamemanager.w > 1))
                    {
                        canClick = true;
                    }
                    else
                        canClick = false;
                }
                if (canTransW)
                {
                    if ((number1.theColor == number.blockColor.fire && gamemanager.f > 1) || (number1.theColor == number.blockColor.grass && gamemanager.g > 1))
                    {
                        canClick = true;
                    }
                    else
                        canClick = false;
                    
                }
                if (canTransG)
                {
                    if ((number1.theColor == number.blockColor.fire && gamemanager.f > 1) || (number1.theColor == number.blockColor.water && gamemanager.w > 1))
                    {
                        canClick = true;
                    }
                    else
                        canClick = false;
                }
                
            }
            else
                canClick = false;
        }

        if(gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
            canClick=false;
            if (canTransF)
            {
                number number;
                number = num1.GetComponent<number>();
                number.theColor = number.blockColor.fire;
                canTransF = false;
            }
            if (canTransW)
            {
                number number;
                number = num1.GetComponent<number>();
                number.theColor = number.blockColor.water;
                canTransW = false;
            }
            if (canTransG)
            {
                number number;
                number = num1.GetComponent<number>();
                number.theColor = number.blockColor.grass;
                canTransG = false;
            }
            if (canGoOn == true)
            {
                gamemanager.state3 = gamemanager.gamestate3.none;
                canGoOn = false;
            }
        }
        if(gamemanager.state3 == gamemanager.gamestate3.none)
        {
            num1 = null;
            canTrans = false;
            canTransF = false;
            canTransG = false;
            canTransW = false;
        }

    }

    void oddC()
    {
        if(gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
            canClick = true;
        }
        if(gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
            gamemanager.canO = true;
            if(gamemanager.canE == true)
            {
                gamemanager.canE = false;
            }
            if(canGoOn == true)
            {
                gamemanager.state3 = gamemanager.gamestate3.none;
                canGoOn = false;
                canOdd = false;
                canClick = false;
            }
        }
        if (gamemanager.state3 == gamemanager.gamestate3.none)
        {
            canOdd = false;
          
        }

    }

    void evenC()
    {
        if (gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
            canClick = true;
        }
        if (gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
            gamemanager.canE = true;
            if(gamemanager.canO == true)
            {
                gamemanager.canO = false;
            }
            if (canGoOn == true)
            {
                gamemanager.state3 = gamemanager.gamestate3.none;
                canGoOn = false;
                canEven = false;
                canClick = false;
            }
        }
        if (gamemanager.state3 == gamemanager.gamestate3.none)
        {
            canEven = false;
        }
        
    }
    void doubleD()
    {
        if(gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
            canClick = true;
        }
        if(gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
            gamemanager.beiLv = 2;
            
            if (canGoOn == true)
            {
                anim.GetComponent<animation>().canC = true;
                gamemanager.state3 = gamemanager.gamestate3.none;
                canGoOn = false;
                canDouble = false;
                canClick = false;
            }
        }

    }
}
