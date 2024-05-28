using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG : MonoBehaviour
{
    public GameObject dao,BKG,board;
    // Start is called before the first frame update
    void Start()
    {
        board.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("anim",0.95f);
    }
    void anim()
    {
        dao.SetActive(true);
        Invoke("close", 0.3f);

    }
    void close()
    {
        dao.SetActive(false);
        BKG.SetActive(false);
        board.SetActive(true);
    }
}
