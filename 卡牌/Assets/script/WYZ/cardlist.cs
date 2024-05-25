using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cardlist : MonoBehaviour
{
    public TextAsset Database;
   public List<string> LeftCardlist = new List<string>();
    List<GameObject> Handcard = new List<GameObject>();
    string[] Carddata;
    string[]SwordCard = { "DoublieAttack", "Rush" ,"DragonSlash","Slash"};
    string[]ShieldCard = { "ShieldAttack", "LayonHand", "DivineStrike", "Slash" };
    string[]WitcherCard = { "WitchBolt", "Shield", "FireBall","Slash" };
    // Start is called before the first frame update
    void Start()
    {
        Carddata = Database.text.Split("\n");
        LeftCardlist = Carddata.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            removecard();
        }
    }

    void removecard()
    {
        int cardlimit = 6;
       while(transform.childCount < cardlimit)
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
       void getback()

        {
            
        }

    }
}
