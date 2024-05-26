using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScence : MonoBehaviour
{
    public GameObject start, quit;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.Find("Start");
        quit = GameObject.Find("Quit");

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == start)
        {
            Invoke("LoadScene", 0.5f);
            

        }
        if (gameObject == quit)
        {
            Application.Quit();
        }

    }
    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadCardlist()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Start");
    }


}
