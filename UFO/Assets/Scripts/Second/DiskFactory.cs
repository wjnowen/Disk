using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MainGame<DiskFactory>
{

    private DiskFactory() { }

    public static int POOL_SIZE = 15;
    private GameObject[] diskPool = new GameObject[POOL_SIZE];
    private GameObject firstAvailable;


    void Awake() {
        Init();
    }

    void Init() {
        for (int i = 0; i < POOL_SIZE; i++)
        {
            if (i == 0)
            {
                GameObject obj = Instantiate(MainCreate.Instance().disk);
                obj.SetActive(false);
                diskPool[i] = obj;
            
            else
            {
                diskPool[i].GetComponent<Disk>().poolIndex = i;
                if (i == 0) continue;
                diskPool[i - 1].GetComponent<Disk>().nextDisk = diskPool[i];
                }
        }
        diskPool[POOL_SIZE - 1].GetComponent<Disk>().nextDisk = null;
        firstAvailable = diskPool[0];
       
    }

    public GameObject Create(Vector3 position, Vector3 velocity, float lifeTime) {

        if (firstAvailable == null) firstAvailable = diskPool[0];

        Disk _Disk = firstAvailable.GetComponent<Disk>();
        _Disk.init(position, velocity, lifeTime);
        firstAvailable.SetActive(true);
        firstAvailable = _Disk.nextDisk;
        return(_Disk.gameObject);
    }

    public void Return(int _index) {
        diskPool[_index].GetComponent<Disk>().nextDisk = firstAvailable;
        diskPool[_index].SetActive(false);
        firstAvailable = diskPool[_index];
    }

    public void recycleDisk(GameObject disk)
    {
        int index = firstAvailable.index(x => x == disk);
            diskPool.Add(disk);
            firstAvailable.RemoveAt(index);
    }
}



