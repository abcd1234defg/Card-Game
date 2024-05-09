using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMagic : MonoBehaviour
{
    public gamemanager gamemanager;
    public GameObject card;
    bool canCreate;
    // Start is called before the first frame update
    void Start()
    {
        canCreate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if(canCreate == true)
            {
                create();
                canCreate = false;
            }
   
        }
    }

    void create()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(card, transform);
        }
    }
}
