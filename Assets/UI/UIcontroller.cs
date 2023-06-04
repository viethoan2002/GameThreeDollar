using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public GameObject menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
    }
    public void BACK()
    {
        SceneManager.LoadScene("SceneMenu");
    }

    public void RESUME()
    {
        menu.SetActive(false);
    }
}
