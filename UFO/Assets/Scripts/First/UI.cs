using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MainGame<UI> {

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
