using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public Image Icon;
    public gamemanager GM;
    public string owner;//Check the life from player or enemy.
    public TextMeshProUGUI Ugui;
    int life;
    public Sprite Win; // 胜利状态下的头像
    public Sprite Dead; // 似了的头像

    private void Update()
    {

        if (this.gameObject.tag == "Enemylife")
        {
            life = GM.enemylife;
            Ugui.text = "Life:" + " " + GM.enemylife.ToString();
        }
        else if (this.gameObject.tag == "Playerlife")
        {
            life = GM.playerlife;
            Ugui.text = "Life:" + " " + GM.playerlife.ToString();
        }
        if (life<=0) { Icon.sprite = Dead; }
        if (GM.canOver == true && Icon.sprite != Dead) { Icon.sprite = Win; }
    }
}
