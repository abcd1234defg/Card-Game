using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class magicCard : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler
{
    public gamemanager gamemanager;
    public GameObject manager;
    public int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("gamemanager");
        gamemanager = manager.GetComponent<gamemanager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print("a=" + a);
    }
  
    public void OnPointerClick(PointerEventData eventData)
    {
        a += 1;
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
       
    }
}
