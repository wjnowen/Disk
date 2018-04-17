using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDisk : MainGame<HitDisk> {

    private HitDisk() { }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isCollider = Physics.Raycast(ray, out hit);
            if (isCollider)
            {

                if (hit.transform.tag == "Disk")
                {
                    hit.transform.GetComponent<Disk>().DestroyItSelf();
                }
            }
        }

    }

}
