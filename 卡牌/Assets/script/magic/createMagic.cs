using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMagic : MonoBehaviour
{
    public gamemanager gamemanager;
    public GameObject Swap, tF, tW, tG, odd, even, doubleD;
    bool canCreate;
    public int createNum, maxNum, existNum, drawNum;
    int choice;
    public bool draw;
   
    // Start is called before the first frame update
    void Start()
    {
        canCreate = true;
        createNum = 2;
        maxNum = 4;
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
        if(gamemanager.state == gamemanager.gamestate.start)
        {
            if(draw == true)
            {
                createNum = drawNum;
                create();
                draw = false;
            }
        }
        if(gamemanager.state == gamemanager.gamestate.end)
        {
            drawNum = 0;
            if(maxNum - existNum > 2)
            {
                createNum = 2;
            }
            else
                createNum = maxNum - existNum;

            canCreate = true;
        }
        
    }

    void create()
    {
        for (int i = 0; i < createNum; i++)
        {
            choice = Random.Range(1, 8);
            if(choice == 1)
            {
                Instantiate(Swap, transform);
                existNum++;
            }
            if (choice == 2)
            {
                Instantiate(tF, transform);
                existNum++;
            }
            if (choice == 3)
            {
                Instantiate(tW, transform);
                existNum++;
            }
            if (choice == 4)
            {
                Instantiate(tG, transform);
                existNum++;
            }
            if(choice == 5)
            {
                Instantiate(odd, transform);
                existNum++;
            }
            if (choice == 6)
            {
                Instantiate(even, transform);
                existNum++;
            }
            if (choice == 7)
            {
                Instantiate(doubleD, transform);
                existNum++;
            }
        }
    }
}
