using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalFactory : MainGame<TotalFactory>
{

    private TotalFactory() { }

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public Level GetLevelManager() {
        return Level.Instance();
    }

    public UI GetUIManager() {
        return UI.Instance();
    }
}
