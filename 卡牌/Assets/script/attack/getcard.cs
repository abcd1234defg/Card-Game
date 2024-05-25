using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class getcard : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab for the card
    public Transform cardListPanel; // Parent transform where the cards will be instantiated
    public List<int> numberList = new List<int>();
    public int R, SR, SSR, UR,tot;

    void Start()
    {
        UR = 1;
        SSR = 2;
        SR = 2;
        R = 5;
        GenerateCardList();
        if (cardPrefab != null)
        {
            tot = R+UR+SR+SSR;
            numberList.Add(tot);

        }
      
    }
    private void Update()
    {
        
    }

    void GenerateCardList()
    {
        //foreach (var card in cards)
        //{
        //    GameObject newCard = Instantiate(cardPrefab, cardListPanel);
        //    //newCard.transform.Find("TitleText").GetComponent<Text>().text = card.title;
        //   // newCard.transform.Find("DescriptionText").GetComponent<Text>().text = card.description;
        //}
    }
}
