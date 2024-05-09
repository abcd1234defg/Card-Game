using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cardPosition : MonoBehaviour
{
    public bool isEmpty, a;//用来判断这个位置有没有手牌，这个a貌似没有啥用
    public gamemanager gamemanager;
    public int cardChoice;//用于随机生成三种牌
    public GameObject fireCard, waterCard, grassCard;//三种攻击牌
    public GameObject mouse;
    public bool remake;//弃牌
   
    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
        a = true;
     
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
          if(remake == false)
            {
                create();
            }
            
        }
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            if(remake == true)
            {
                print("asdasda");
                create();
            }
        }
        
    }

    void create()
    {
        if(isEmpty == true)
        {
            cardChoice = Random.Range(1, 4);
            if (cardChoice == 1)
            {
  
                    Instantiate(fireCard, transform.position, Quaternion.identity);
                    cardChoice = 0;
                    isEmpty = false;
                
                
            }
            else if (cardChoice == 2)
            {
    
                    Instantiate(waterCard, transform.position, Quaternion.identity);
                
                    cardChoice = 0;
                    isEmpty = false;
                
            }
            else if (cardChoice == 3)
            {

                   Instantiate(grassCard, transform.position, Quaternion.identity);
         
                    cardChoice = 0;
                    isEmpty = false;
                
            }
            
        }
    }

    /*private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (gamemanager.state == gamemanager.gamestate.start)
            {

                if (isEmpty == false)
                {
                    isEmpty = true;
                }
            }
        }
        print("aaa");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == ("mouse"))
        {
            
        }
       
    }*/
}
