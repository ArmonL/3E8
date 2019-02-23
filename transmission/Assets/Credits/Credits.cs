using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public Texture backgroundTexture;

    public Font font;


    private void OnGUI()
    {
        GUI.skin.font = font;

        GUIStyle l = GUI.skin.GetStyle("Label");
        l.alignment = TextAnchor.MiddleCenter;
        l.fontSize = 20;
        GUI.Label(new Rect(Screen.width * .25f, Screen.height * .01f, Screen.width * .5f, Screen.height * .5f), "Thanks For Playing!");

        GUI.Label(new Rect(Screen.width * .25f, Screen.height * .15f, Screen.width * .5f, Screen.height * .5f), "Design By:");

        GUI.Label(new Rect(Screen.width * .15f, Screen.height * .25f, Screen.width * .70f, Screen.height * .5f), "Joshua Prince & Armon Liaghat");

        GUI.Label(new Rect(Screen.width * .25f, Screen.height * .35f, Screen.width * .5f, Screen.height * .5f), "Art By:");

        GUI.Label(new Rect(Screen.width * .25f, Screen.height * .45f, Screen.width * .5f, Screen.height * .5f), "Corey 'curry' I");

    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync("PrePicMenu");
        }
    }

}