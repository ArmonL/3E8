using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalManager : MonoBehaviour {

    public enum TransmissionType
    {
        UP, RIGHT, DOWN, LEFT
    }

    public GameObject signal;

    GameObject[] currentTransmission = new GameObject[Enum.GetValues(typeof(TransmissionType)).Length];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (TransmissionType t in Enum.GetValues(typeof(TransmissionType)))
        {
            if (Input.GetButtonDown(t.ToString()))
            {
                currentTransmission[(int)t] = GameObject.Instantiate(signal, this.transform);
                currentTransmission[(int)t].GetComponent<Image>().color = getSignalColor(t);
                currentTransmission[(int)t].GetComponent<Signal>().top = -0.01f;
                currentTransmission[(int)t].GetComponent<Signal>().type = t;
            }


            if (currentTransmission[(int)t] != null)
            {
                //RectTransform transf = currentTransmission[(int)t].GetComponent<RectTransform>();
                //transf.offsetMin = new Vector2(transf.offsetMin.x, 0);

                Signal s = currentTransmission[(int)t].GetComponent<Signal>();

                if (s != null)
                    s.bottom = -0.02f;
            }
            

            if (Input.GetButtonUp(t.ToString()))
            {
                currentTransmission[(int)t] = null;
            }
        }
    }

    Color getSignalColor(TransmissionType type)
    {
        switch(type)
        {
            case TransmissionType.UP: return new Color(1, 0.4f, 0.4f);
            case TransmissionType.DOWN: return new Color(0.4f, 1f, 0.4f);
            case TransmissionType.LEFT: return new Color(0.4f, 0.4f, 1f);
            case TransmissionType.RIGHT: return new Color(1, 0.4f, 1f);

            default: return new Color(1, 1, 1);
        }
    }
}
