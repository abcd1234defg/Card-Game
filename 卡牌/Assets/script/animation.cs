using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public gamemanager gamemanager;
    public GameObject manager;
    magicManager magicManager;
    public GameObject potion;
    public GameObject theP;
    public bool canC;
    // Start is called before the first frame update
    void Start()
    {
        magicManager = manager.GetComponent<magicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            if(gamemanager.state3 == gamemanager.gamestate3.magicEnd)
            {
                if(magicManager.canDouble)
                {
                    if(canC)
                    {
                        theP = Instantiate(potion, transform);
                        canC = false;
                    }
                    
                }
            }
        }
        if(gamemanager.state == gamemanager.gamestate.beforeStart)
        {
            if(theP != null)
            {
                Destroy(theP);
                
            }
        }
    }
}
