using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RoundData { 
    public float Speed;
    public float random;
};

public class MainCreate : MainGame<MainCreate>
{

    private MainCreate() { }

  

    public static int roundNumber = 20;
    public RoundData[] Round = new RoundData[roundNumber];
    public static int countNumber = 3;
    private float time;
    private float nexttime;
    [SerializeField] private int roundIndex;
    [SerializeField] private int countIndex;
    public GameObject disk;
    public Transform lunchPosition;

    void Awake() {
        _instance = this;
        time = 0; nexttime = 0; roundIndex = 0; countIndex = 0;
        DiskFactory ini = DiskFactory.Instance(); 
    }

    void Update() {
        time += Time.deltaTime;

        if (nexttime == 0) {
            nexttime = Round[roundIndex].Speed + Random.Range(-Round[roundIndex].random, Round[roundIndex].random);
        }

        if (time < nexttime) return;
        countIndex++;
        CreateDisk();
        time -= nexttime;
        nexttime = 0;
        if (countIndex < countNumber) return;
        countIndex = 0; roundIndex++;
    }



    void CreateDisk() {


        Vector3 _position = lunchPosition.position + new Vector3(Random.Range(-2,2), Random.Range(-2,2), Random.Range(-2, 2));
        Vector3 _velocity = new Vector3(-1f, Random.Range(-0.125f, 0.125f), 0);
        GameObject obj = DiskProductor.Instance().Create(_position, _velocity, 15f);
    }

    public int GetRoundIndex() {
        return roundIndex;
    }
}

