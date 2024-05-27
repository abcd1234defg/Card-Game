using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class mark : MonoBehaviour
{
    public GameObject shield, heal, burn;
    GameObject ts, th, tb;
    TextMeshProUGUI st, ht, bt;
    public GameObject manager;
    chain chain;
    bool canS, canH, canB;
    // Start is called before the first frame update
    void Start()
    {
        chain = manager.GetComponent<chain>();
        canH = canB = canS = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(chain.shield >=1)
        {
            if(canS)
            {
                ts = Instantiate(shield, transform);
                st = ts.GetComponentInChildren<TextMeshProUGUI>();
                canS = false;
            }
            st.text = chain.shield.ToString();
            
        }
        if (chain.shield == 0)
        {
            if(ts != null)
            {
                Destroy(ts);
                Destroy(st);
                canS = true;
                print("sajdnasd");
            }
            
        }


        if (chain.heal >= 1)
        {
            if (canH)
            {
                th = Instantiate(heal, transform);
                ht = th.GetComponentInChildren<TextMeshProUGUI>();
                canH = false;
            }
            ht.text = chain.heal.ToString();
           
        }
        if (chain.heal == 0)
        {
            if(th != null)
            {
                Destroy(th);
                Destroy(ht);
                canH = true;
            }
            
        }

        if (chain.eBurn >= 1)
        {
            if (canB)
            {
                tb = Instantiate(burn, transform);
                bt = tb.GetComponentInChildren<TextMeshProUGUI>();
                canB = false;
            }
            bt.text = chain.eBurn.ToString();
            
        }
        if (chain.eBurn == 0)
        {
            if(tb != null)
            {
                Destroy(tb);
                Destroy(bt);
                canB = true;
            }
            
        }

    }
}
