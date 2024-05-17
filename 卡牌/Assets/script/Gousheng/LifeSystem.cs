using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public gamemanager GM;
    public string owner;//Check the life from player or enemy.
    public TextMeshProUGUI Ugui;

    private void Update()
    {
        if (this.gameObject.tag == "Enemylife") { Ugui.text = "EnemyLife:" + " " + GM.enemylife.ToString(); }
        else if (this.gameObject.tag == "Playerlife") { Ugui.text = "PlayerLife:" + " " + GM.playerlife.ToString(); }
    }
}
