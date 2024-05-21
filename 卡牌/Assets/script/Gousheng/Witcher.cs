using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witcher : MonoBehaviour
{
    public string Single;//监测这张单卡的效果
    public int ATK;//攻击力
    public int rare;//稀有度
    attackCard attackCard;
    void Start()
    {
        rare = Random.Range(1, 11);
        if (rare <= 5) { Single = "Slash"; }//当出生点数是5以下时，生成“斩击”
        if (rare > 5 && rare < 8) { Single = "Shield"; }//当出生点数是6和7时，生成“护盾术”
        if (rare > 7 && rare < 10) { Single = "WitchBolt"; }//当出生点数是8和9时，生成“巫术箭”
        if (rare == 10) { Single = "FireBall"; }//当出生点数是10时，生成“火球术”
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
        if (Single == "Slash") { ATK = 1; }
        if (Single == "Shield") { ATK = 0; }
        if (Single == "WitchBolt") { ATK = 2; }
        if (Single == "FireBall") { ATK = 5; }
    }
}
