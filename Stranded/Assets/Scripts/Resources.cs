using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{

    public int HitCount = 3;
    public int DropMinHit = 0, DropMaxHit = 2;
    public float BreakBonus = 3; // add one
    // Start is called before the first frame update
    void Awake()
    {
        SetPosition(transform.position.x, transform.position.y, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition (Vector3 position)
    {
        transform.position = position;
    }

    public void SetPosition(float x, float y, float z)
    {
        SetPosition(new Vector3(x, y, z));
    }

    public void ResourceHit()
    {
        if(HitCount > 0)
        {
            HitCount -= 1;
            caculateDrops();
        }

        if (HitCount <= 0)
        {

        }
    }
    //Caculate the drop value and some equations
    private void caculateDrops()
    {
        int ranDrop = Random.Range(DropMinHit, DropMaxHit + 1);
        if (HitCount == 0)
            ranDrop += 1;
            ranDrop = (int)(ranDrop * BreakBonus);
    }

    private void dropItems(int dropCount)
    {

    }

    private void destroyResource()
    {
        Destroy(gameObject);
    }
}
