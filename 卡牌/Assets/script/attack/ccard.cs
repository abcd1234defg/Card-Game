using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccard : MonoBehaviour
{
    public List<int> numbers = new List<int>(); // 存储数字的列表
    public List<GameObject> numberGameObjects = new List<GameObject>(); // 存储数字对应的游戏对象的列表
    public GameObject prefab; // 预制件，用于实例化每个数字的游戏对象
    public int R, SR, SSR, UR, tot;


    void Start()
    {
        UR = 1;
        SSR = 2;
        SR = 2;
        R = 5;
        if (prefab != null)
        {
            tot = R + UR + SR + SSR;
            numbers.Add(tot);
        }
        // 实例化数字对应的游戏对象，并添加到列表中
        for (int i = 0; i < numbers.Count; i++)
        {
            GameObject newGameObject = Instantiate(prefab);
            newGameObject.transform.position = new Vector3(i * 2, 0, 0);
            newGameObject.name = numbers[i].ToString();
            numberGameObjects.Add(newGameObject);
        }
    }

    void Update()
    {
        // 检查每个数字对应的游戏对象是否存在，如果存在则减少数字
        for (int i = 0; i < numberGameObjects.Count; i++)
        {
            if (numberGameObjects[i] != null)
            {
                // 从数字列表中删除一个数字
                numbers.RemoveAt(i);
                // 销毁游戏对象
                Destroy(numberGameObjects[i]);
                // 从游戏对象列表中删除游戏对象
                numberGameObjects.RemoveAt(i);
                // 退出循环，只处理一个游戏对象
                break;
            }
        }
    }
}
