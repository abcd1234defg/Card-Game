using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Single : MonoBehaviour
{
    public GameObject GM;
    public GameObject thisSlot,enemySlot,otherEnemySlots1,otherEnemySlots2,friendSlots1,friendSlots2;
    public int ATK;
    public string single;
    public player PL;
    bool SingleButtom=true;
    public TextMeshProUGUI TextAtk;
    
    // Start is called before the first frame update
    void Start()
    {
        GM= GameObject.Find("gamemanager");
        PL = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PL.theColor == null) 
        { 
            TextAtk.text = " ";
        }
        if (PL.theColor !=null && PL.theColor != "1")
        {
            TextAtk.text = ATK.ToString();
        }        
        if (GM.GetComponent<gamemanager>().state == gamemanager.gamestate.beforeStart) { TextAtk.text = " "; }
        if (GM.GetComponent<gamemanager>().state ==gamemanager.gamestate.start)
        {
            ATK= PL.ATK;
            single= PL.single;
        }
        if (GM.GetComponent<gamemanager>().state == gamemanager.gamestate.singlePhase)
        {
            if (SingleButtom == true)
            {
                Effect();
                SingleButtom = false;
            }
        }
        if (GM.GetComponent<gamemanager>().state == gamemanager.gamestate.end) { SingleButtom = true; }
    }
    void Effect()
    {
        //斩击效果
        if (single == "Slash(Clone)") { print("Slash"); }
        //十字斩效果
        if (single == "DoubleAttack(Clone)")
        {
            print("DoubleAttack");
        }
        //牙突效果
        if (single == "Rush(Clone)") { print("Rush"); }
        //登龙剑效果
        if (single == "DragonSlash(Clone)")
        {
            print("DragonSlash");
            ATK += 1;
            friendSlots1.GetComponent<Single>().ATK += 1;
            friendSlots2.GetComponent<Single>().ATK += 1;
        }
        //锤击效果
        if (single == "SlashH(Clone)") { print("Crush"); }
        //盾击效果
        if (single == "ShieldAttack(Clone)")
        {
            print("ShieldAttack");
            enemySlot.GetComponent<enemy>().ATK -= 1;
        }
        //圣疗术效果
        if (single == "LayonHand(Clone)")
        {
            print("LayOnHand");
            GM.GetComponent<gamemanager>().playerlife += 2;
        }
        //神圣打击效果
        if (single == "DivineStrike(Clone)") 
        { 
            print("DivineStrike");
            enemySlot.GetComponent<enemy>().ATK -= 1;
            otherEnemySlots1.GetComponent<enemy>().ATK -= 1;
            otherEnemySlots2.GetComponent<enemy>().ATK -= 1;
        }
        //敲击效果
        if (single == "SlashF(Clone)") { print("Bonk"); }
        //护盾术效果
        if (single == "Shield(Clone)") 
        {
            print("Shield");
            enemySlot.GetComponent<enemy>().ATK = 0;
        }
        //巫术箭效果
        if (single == "WitchBolt(Clone)") 
        {
            print("WitchBolt");
            GM.GetComponent<gamemanager>().enemylife -= 2;
        }
        //火球术效果
        if (single == "FireBall(Clone)")
        {
            print("FireBall");
            GM.GetComponent<chain>().burn += 1;
        }

    }
}
