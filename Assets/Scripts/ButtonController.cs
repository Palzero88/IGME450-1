using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
        {

            Application.Quit();

        }

    }

    public void LoadScene(int level)
    {

        SceneManager.LoadScene(level);

    }

    public void Exit()
    {

        Application.Quit();

    }

}
