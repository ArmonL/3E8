///Main Menu
///Attached to Main Camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Texture backgroundTexture;

    public Font font;

    public static int highScore = 0, lastScore = -1;


    private void OnGUI()
    {
        GUI.skin.font = font;
        //Display our Background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUIStyle l = GUI.skin.GetStyle("Label");
        l.alignment = TextAnchor.MiddleCenter;
        l.fontSize = 50;
        GUI.Label(new Rect(Screen.width * .25f, Screen.height * .20f, Screen.width * .5f, Screen.height * .1f), "3e8");

        l.fontSize = 32;
        if (lastScore > -1)
        {
            GUI.Label(new Rect(Screen.width * .05f, Screen.height * .30f, Screen.width * .9f, Screen.height * .1f), "You made it " + lastScore + "km!");
            GUI.Label(new Rect(Screen.width * .05f, Screen.height * .35f, Screen.width * .9f, Screen.height * .1f), "High Score: " + highScore + "km");
        }

        //Displays our buttons
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .45f, Screen.width * .5f, Screen.height * .1f), "Play Game"))
        {
            SceneManager.LoadSceneAsync("scene");
        }

        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .60f, Screen.width * .5f, Screen.height * .1f), "Credits"))
        {
            SceneManager.LoadSceneAsync("Credits");
        }

        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .75f, Screen.width * .5f, Screen.height * .1f), "Exit"))
        {
            Application.Quit();
        }
    }

}

