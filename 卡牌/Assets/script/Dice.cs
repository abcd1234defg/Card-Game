using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public gamemanager gamemanager;
    public GameObject diceA;
    GameObject theDice;
    bool canBorn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 0);
        }
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            if(canBorn)
            {
                theDice = Instantiate(diceA, transform.position, Quaternion.identity);
                canBorn = false;
            }
    
        }
        if(gamemanager.state == gamemanager.gamestate.playing)
        {
            Destroy(theDice);
            GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
            canBorn=true;
        }
    }
}
