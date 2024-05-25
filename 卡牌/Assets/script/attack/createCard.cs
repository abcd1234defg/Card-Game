using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class createCard : MonoBehaviour
{
    public bool isEmpty, a;//用来判断这个位置有没有手牌，这个a貌似没有啥用
    public gamemanager gamemanager;
    public int cardChoice;//用于随机生成三种牌
    public GameObject fireCard, waterCard, grassCard;//三种攻击牌
    public GameObject mouse;
    public bool remake;//弃牌
    bool createC;
    int number;
    public int createNumber;

    public TextAsset Database;
    public List<string> LeftCardlist = new List<string>();
    List<GameObject> Handcard = new List<GameObject>();
    string[] Carddata;
    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
        a = true;
        createNumber = 6;
        Carddata = Database.text.Split("\n");
        LeftCardlist = Carddata.ToList();
    }


    // Update is called once per frame

    void Update()
    {
        if (gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if (remake == false)
            {
                create();
                createNumber = 0;
                remake = true;
            }
        }
        if (gamemanager.state == gamemanager.gamestate.start)
        {

            print("asdasda");
            if (remake == false)
            {
                create();
                createNumber = 0;
                remake = true;
            }
        }
    }
    void create()
    {
        while (transform.childCount < createNumber)
        {
            int randomIndex = Random.Range(0, LeftCardlist.Count);
            string selectedCard = LeftCardlist[randomIndex];

            string[] cardInfo = selectedCard.Split(',');
            string cardType = cardInfo[0].Trim();
            string cardName = cardInfo[1].Trim();

            GameObject cardObject = null;
            GameObject prefab = Resources.Load<GameObject>(cardName);
            cardObject = Instantiate(prefab, transform);

            if (cardObject != null)
            {
                Handcard.Add(cardObject);
            }

            LeftCardlist.Remove(selectedCard);

        }
        //if (isEmpty == true)
        //{
        //    for (int i = 0; i < createNumber; i++)
        //    {
        //        cardChoice = Random.Range(1, 4);
        //        if (cardChoice == 1)
        //        {

        //            Instantiate(fireCard, transform);
        //            cardChoice = 0;
        //            isEmpty = false;


        //        }
        //        if (cardChoice == 2)
        //        {

        //            Instantiate(waterCard, transform);

        //            cardChoice = 0;
        //            isEmpty = false;

        //        }
        //        if (cardChoice == 3)
        //        {
        //            Instantiate(grassCard, transform);

        //            cardChoice = 0;
        //            isEmpty = false;
        //        }
        //    }
        //}

    }

}
