using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MainGame<UIController>{

    private UIController() { }
    private UIController action;
    void OnGUI() {
        GUI.Label(new Rect(50, 50, 100, 20), "Round:" + (MainCreate.Instance().GetRoundIndex()+1));
        GUI.Button(new Rect(20, 80, 100, 40), "Begin");
        GUI.Button(new Rect(20, 130, 100, 40), "Restart");
        if (GUI.Button(new Rect(20, 130, 100, 40), "Restart"))
        {
            Application.LoadLevel(Application.loadedLevelName);
            
        }
    }

}
