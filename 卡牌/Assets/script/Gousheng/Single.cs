using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single : MonoBehaviour
{
    public GameObject GM;
    public GameObject thisSlot,enemySlot,otherEnemySlots1,otherEnemySlots2,friendSlots1,friendSlots2;
    public int ATK;
    public string single;
    public player PL;
    bool SingleButtom=true;
    // Start is called before the first frame update
    void Start()
    {
        GM= GameObject.Find("gamemanager");
        PL = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.GetComponent<gamemanager>().state ==gamemanager.gamestate.start)
        {
            ATK= PL.ATK;
            single= PL.single;
        }
        else if (GM.GetComponent<gamemanager>().state == gamemanager.gamestate.singlePhase)
        {
            if (SingleButtom == true)
            {
                Effect();
                SingleButtom = false;
            }
        }
        else if (GM.GetComponent<gamemanager>().state == gamemanager.gamestate.end) { SingleButtom = true; }
    }
    void Effect()
    {
        //斩击效果
        if (single == "Slash") { print("Slash"); }
        //十字斩效果
        else if (single == "DoubleAttack")
        {
            print("DoubleAttack");
        }
        //牙突效果
        else if (single == "Rush") { print("Rush"); }
        //登龙剑效果
        else if (single == "DragonSlash")
        {
            print("DragonSlash");
            ATK += 1;
            friendSlots1.GetComponent<Single>().ATK += 1;
            friendSlots2.GetComponent<Single>().ATK += 1;
        }
        //锤击效果
        else if (single == "Crush") { print("Crush"); }
        //盾击效果
        else if (single == "ShieldAttack")
        {
            print("ShieldAttack");
            enemySlot.GetComponent<enemy>().ATK -= 1;
        }
        //圣疗术效果
        else if (single == "LayOnHand")
        {
            print("LayOnHand");
            GM.GetComponent<gamemanager>().playerlife += 2;
        }
        //神圣打击效果
        else if (single == "DivineStrike") 
        { 
            print("DivineStrike");
            enemySlot.GetComponent<enemy>().ATK -= 1;
            otherEnemySlots1.GetComponent<enemy>().ATK -= 1;
            otherEnemySlots2.GetComponent<enemy>().ATK -= 1;
        }
        //敲击效果
        else if (single == "Bonk") { print("Bonk"); }
        //护盾术效果
        else if (single == "Shield") 
        {
            print("Shield");
            enemySlot.GetComponent<enemy>().ATK = 0;
        }
        //巫术箭效果
        else if (single == "WitchBolt") 
        {
            print("WitchBolt");
            GM.GetComponent<gamemanager>().enemylife -= 2;
        }
        //火球术效果
        else if (single == "FireBall") { print("FireBall"); }


    }
}
