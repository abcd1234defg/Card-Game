using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rightclick : MonoBehaviour,IPointerEnterHandler,IPointerDownHandler,IPointerUpHandler
{
    createCard createCard;
    public TextAsset CardInformation;
    public GameObject info, my, eneimg;
    string[] Cardinf;
    public TextMeshProUGUI infotext;
    public Sprite F, G, W;
    string cardName, cardDescription;
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("Information");
        if (info != null )
        {
            my = info.transform.GetChild(2).gameObject;
            eneimg = info.transform.GetChild(1).gameObject;
            infotext = info.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        // Cardinf = weak.text.Split("\n");
        
        //if (CardInformation != null)
        //{
        //    // 将文本内容分割成行
        //   string[] cardInfoLines = CardInformation.text.Split('\n');

        //    // 解析每一行数据
        //    foreach (string lines in cardInfoLines)
        //    {
        //        string[] parts = lines.Split(',');  // 使用冒号分割每行数据
        //        {
        //            string cardkind = parts[0].Trim();
        //            string cardName = parts[1].Trim();
        //            string cardDescription = parts[2].Trim();
        //            string[] clearname = gameObject.name.Split('(');

        //        if (cardName == clearname[0])
        //        {
        //            infotext.text = cardDescription; // Display matching card description
        //            break; // Exit the loop after finding a match
        //        }

        //            // 假设你想在infotext上显示信息
        //            infotext.text = $"{cardDescription}";
        //        }
        //    }
        //}

    }

    // Update is called once per frame
    void Update()
    {


    }
    
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tag == "fire")
        {
            my.GetComponent<Image>().sprite = F;
            eneimg.GetComponent<Image>().sprite = G;
        }

        if (tag == "grass")
        {
            my.GetComponent<Image>().sprite = G;
            eneimg.GetComponent<Image>().sprite = W;
        }
        if (tag == "water")
        {
            my.GetComponent<Image>().sprite = W;
            eneimg.GetComponent<Image>().sprite = F;
        }
        if (CardInformation != null)
        {
            // 将文本内容分割成行
            string[] cardInfoLines = CardInformation.text.Split('\n');

            // 解析每一行数据
            foreach (string lines in cardInfoLines)
            {
                string[] parts = lines.Split(',');  // 使用冒号分割每行数据
                {
                    string cardkind = parts[0].Trim();
                    string cardName = parts[1].Trim();
                    string cardDescription = parts[2].Trim();
                    string[] clearname = gameObject.name.Split('(');

                    if (cardName == clearname[0])
                    {
                        infotext.text = cardDescription; // Display matching card description
                        break; // Exit the loop after finding a match
                    }

                    // 假设你想在infotext上显示信息
                    infotext.text = $"{cardDescription}";
                }
            }
        }


    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += 200;
            newPosition.y += 140;

            info.GetComponent<RectTransform>().position = newPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            info.GetComponent<RectTransform>().position = new Vector3(-1184, -145, 0);
        }
    }

}
    

