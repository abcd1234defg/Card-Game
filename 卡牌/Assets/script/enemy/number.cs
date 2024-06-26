using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class number : MonoBehaviour
{
    public string nums;//用来记录自己是啥数字
    public int num;//同上
    public enum blockColor { fire, water, grass};//用于决定这个物体对应的数字对应的颜色
    public blockColor theColor;
    public blockColor empty;
    gamemanager gamemanager;
    public GameObject manager;
    public magicManager magicManager;
    public GameObject shadow, theShadow;
    bool canPlus = true;
    // Start is called before the first frame update
    void Start()
    {
        
        nums = gameObject.name.ToString();//用来看自己是啥数字
        num = int.Parse(nums);//根据自己是啥数字去生成初始的颜色
        if(num < 5)
        {
            theColor = blockColor.water;
        }
        if (num < 9 && num >4)
        {
            theColor = blockColor.fire;
        }
        if (num < 13 && num > 8)
        {
            theColor = blockColor.grass;
        }
        manager = GameObject.Find("gamemanager");
        magicManager = manager.GetComponent<magicManager>();
        gamemanager = manager.GetComponent<gamemanager>();
        theShadow = GameObject.Instantiate(shadow, transform.position, Quaternion.identity,transform);
        shadow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(theColor == blockColor.water)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
           
        }
        if (theColor == blockColor.fire)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (theColor == blockColor.grass)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        if(gamemanager.state3 == gamemanager.gamestate3.none)
        {
            theShadow.SetActive(false);
        }
        if(gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
            while(canPlus == true)
            {
                if(theColor == blockColor.fire)
                {
                    gamemanager.f++;
                    canPlus = false;
                }
                if (theColor == blockColor.water)
                {
                    gamemanager.w++;
                    canPlus = false;
                }
                if (theColor == blockColor.grass)
                {
                    gamemanager.g++;
                    canPlus = false;
                }
            }
        }
        if(gamemanager.state3 == gamemanager.gamestate3.magicEnd)
        {
            canPlus = true;
        }
    }
    private void OnMouseDown()
    {
        if(gamemanager.state3 == gamemanager.gamestate3.magicStart)
        {
            if(magicManager.canSwap == true)
            {
                if (magicManager.num1 == null && magicManager.num2 != gameObject)
                {
                    magicManager.num1 = this.gameObject;


                    theShadow.SetActive(true);
                }
                else if (magicManager.num1 == gameObject)
                {
                    magicManager.num1 = null;
                    theShadow.SetActive(false);
                }
                else if (magicManager.num1 != gameObject && magicManager.num2 == null)
                {
                    magicManager.num2 = this.gameObject;


                    theShadow.SetActive(true);
                }
                else if (magicManager.num2 == gameObject)
                {
                    magicManager.num2 = null;
                    theShadow.SetActive(false);
                }
            }
            if(magicManager.canTrans)
            {
                if (magicManager.num1 == null)
                {
                    magicManager.num1 = this.gameObject;


                    theShadow.SetActive(true);
                }
                else if (magicManager.num1 == gameObject)
                {
                    magicManager.num1 = null;
                    theShadow.SetActive(false);
                }
            }
            
        }
        
    }
}
