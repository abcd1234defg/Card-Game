using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class eMark : MonoBehaviour
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
        if (chain.eShield >= 1)
        {
            if (canS)
            {
                ts = Instantiate(shield, transform);
                st = ts.GetComponentInChildren<TextMeshProUGUI>();
                canS = false;
            }
            st.text = chain.eShield.ToString();

        }
        if (chain.eShield == 0)
        {
            if (ts != null)
            {
                Destroy(ts);
                Destroy(st);
                canS = true;
                print("sajdnasd");
            }

        }


        if (chain.eHeal >= 1)
        {
            if (canH)
            {
                th = Instantiate(heal, transform);
                ht = th.GetComponentInChildren<TextMeshProUGUI>();
                canH = false;
            }
            ht.text = chain.eHeal.ToString();

        }
        if (chain.eHeal == 0)
        {
            if (th != null)
            {
                Destroy(th);
                Destroy(ht);
                canH = true;
            }

        }

        if (chain.burn >= 1)
        {
            if (canB)
            {
                tb = Instantiate(burn, transform);
                bt = tb.GetComponentInChildren<TextMeshProUGUI>();
                canB = false;
            }
            bt.text = chain.burn.ToString();

        }
        if (chain.burn == 0)
        {
            if (tb != null)
            {
                Destroy(tb);
                Destroy(bt);
                canB = true;
            }

        }

    }
}
