using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Button : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadScene(0);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
