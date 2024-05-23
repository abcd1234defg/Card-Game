using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cardlist : MonoBehaviour
{
    public TextAsset Database;
    public int URlimit,SRlimit,SSRlimit,Rlimit ;
    List<string> LeftCardlist = new List<string>();
    List<GameObject> Handcard = new List<GameObject>();
    string[] Carddata;
    string[]SwordCard = { "lianzhan", "yatu" ,"denglong","huikan"};
    string[]ShieldCard = { "dunji", "shengliao", "shensheng", "chui" };
    string[]WitcherCard = { "wushujian", "mofafeidan", "hudunshu", "huoqiushu" };
    // Start is called before the first frame update
    void Start()
    {
        Carddata = Database.text.Split("\n");
        LeftCardlist.Add("a");
    }

    // Update is called once per frame
    void Update()
    {
        LeftCardlist = Carddata.ToList();

    }
    void getcard()
    {
        foreach (var row in Carddata)
        {
            string[] rowarray = row.Split(",");
        if (Carddata[0] == "Sword")
        { 

        }
        if (Carddata[0] == "Shield")
        {

        }
        if (Carddata[0] == "Witcher")
        {

        }
        }
       
    }
}
