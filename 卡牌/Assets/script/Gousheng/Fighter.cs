using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public string Single;//监测这张单卡的效果
    public int ATK;//攻击力
    int rare;//稀有度
    void Start()
    {
        rare = Random.Range(0, 10);
        if (rare <= 5) { Single = "Slash"; }//当出生点数是5以下时，生成“斩击”
        if (rare >5&& rare < 7) { Single = "DoubleAttack"; }//当出生点数是6和7时，生成“二连斩”
        if (rare > 7 && rare < 10) { Single = "Rush"; }//当出生点数是8和9时，生成“牙突”
        if (rare ==10) { Single = "DragonSlash"; }//当出生点数是10时，生成“登龙剑”
        Cardeffect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Cardeffect()
    {
        if (Single == "Slash") { ATK = 1; }
        if (Single == "DoubleAttack") { ATK = 2; }
        if (Single == "Rush") { ATK = 3; }
        if (Single == "DragonSlash") { ATK = 4; }
    }
}
