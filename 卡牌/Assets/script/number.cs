using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class number : MonoBehaviour
{
    public string color;//���ھ�����������Ӧ�����ֶ�Ӧ����ɫ
    public string nums;//������¼�Լ���ɶ����
    public int num;//ͬ��
    // Start is called before the first frame update
    void Start()
    {
        nums = gameObject.name.ToString();
        num = int.Parse(nums);
        if(num < 5)
        {
            color = "water";
        }
        if (num < 9 && num >4)
        {
            color = "fire";
        }
        if (num < 13 && num > 8)
        {
            color = "grass";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(color == "water")
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (color == "fire")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (color == "grass")
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

    }
}
