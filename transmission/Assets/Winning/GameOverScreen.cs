using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Texture backgroundTexture;

    public Font font;


    private void OnGUI()
    {
        GUI.skin.font = font;
        //Display our Background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUIStyle l = GUI.skin.GetStyle("Label");
        l.alignment = TextAnchor.MiddleCenter;
        l.fontSize = 30;
        GUI.Label(new Rect(Screen.width * .25f, Screen.height * .55f, Screen.width * .5f, Screen.height * .5f), "You saw the cow right?");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("PrePicMenu");
        }
    }
}
