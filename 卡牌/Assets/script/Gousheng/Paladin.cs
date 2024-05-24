using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : MonoBehaviour
{
    public string Single;//监测这张单卡的效果
    public int ATK;//攻击力
    public int rare;//稀有度
    attackCard attackCard;
    void Start()
    {
        rare = Random.Range(1, 11);
        if (rare <= 5) { Single = "Crush"; }//当出生点数是5以下时，生成“锤击”
        if (rare > 5 && rare < 8) { Single = "ShieldAttack"; }//当出生点数是6和7时，生成“盾击”
        if (rare > 7 && rare < 10) { Single = "LayOnHand"; }//当出生点数是8和9时，生成“圣疗”
        if (rare == 10) { Single = "DivineStrike"; }//当出生点数是10时，生成“神圣打击”
        Cardeffect();
        attackCard = GetComponent<attackCard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCard.isChoose)
        {
            attackCard.card.GetComponent<player>().ATK = ATK;
            attackCard.card.GetComponent<player>().single = Single;
        }
    }

    void Cardeffect()
    {
        if (Single == "Crush") { ATK = 1; }
        if (Single == "ShieldAttack") { ATK = 2; }
        if (Single == "LayOnHand") { ATK = 0; }
        if (Single == "DivineStrike") { ATK = 2; }
    }
}
