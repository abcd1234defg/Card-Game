using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCard : MonoBehaviour
{
    public bool isEmpty, a;//�����ж����λ����û�����ƣ����aò��û��ɶ��
    public gamemanager gamemanager;
    public int cardChoice;//�����������������
    public GameObject fireCard, waterCard, grassCard;//���ֹ�����
    public GameObject mouse;
    public bool remake;//����
    bool createC;
    int number;
    public int createNumber;
    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
        a = true;
        createNumber = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if(remake == false)
            {
                create();
                createNumber = 0;
                remake = true;
            }
        }
        if (gamemanager.state == gamemanager.gamestate.start)
        {
            
                print("asdasda");
            if(remake == false)
            {
                create();
                createNumber = 0;
                remake = true;
            }
        }
    }
    void create()
    {
        if (isEmpty == true)
        {
            for(int i = 0; i < createNumber; i++)
            {
                cardChoice = Random.Range(1, 4);
                if (cardChoice == 1)
                {

                    Instantiate(fireCard, transform);
                    cardChoice = 0;
                    isEmpty = false;


                }
               if (cardChoice == 2)
                {

                    Instantiate(waterCard, transform);

                    cardChoice = 0;
                    isEmpty = false;

                }
                if (cardChoice == 3)
                {

                    Instantiate(grassCard, transform);

                    cardChoice = 0;
                    isEmpty = false;

                }
                
            }
           

        }
    }

}
