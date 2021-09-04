using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public ResourcePrefab TreePrefab, RockPrefab, IronPrefab, BushPrefab;
    public Vector2 MapMin, MapMax;

    // Start is called before the first frame update
    void Start()
    {
        PlaceResource(10, TreePrefab);
        PlaceResource(10, RockPrefab);
        PlaceResource(10, IronPrefab);
        PlaceResource(10, BushPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        CheckResource(TreePrefab);
        CheckResource(RockPrefab);
        CheckResource(IronPrefab);
        CheckResource(BushPrefab);
    }

    private void CheckResource(ResourcePrefab resource)
    {
        if(resource.SpawnRate + resource.lastSpawn < Time.fixedTime)
        {
            PlaceResource(1, resource);
        }
    }

    private void PlaceResource(int count, ResourcePrefab resource)
    {
        resource.lastSpawn = Time.fixedTime;
        int placedCount = 0;
        while(placedCount < count)
        {
            float x = Random.Range(MapMin.x, MapMax.x);
            float y = Random.Range(MapMin.y, MapMax.y);

            GameObject[] resources = GameObject.FindGameObjectsWithTag(resource.ResourceTag);
            bool goodPlacement = true;
            foreach(GameObject res in resources)
            {
                if (Vector2.Distance(res.transform.position, new Vector2(x, y)) < resource.ResourceRadius) goodPlacement = false;
            }

            if (goodPlacement)
            {
                GameObject res = Instantiate(resource.Prefab, new Vector3(x, y, y), Quaternion.identity);
                res.tag = resource.ResourceTag;
                res.GetComponent<Resources>().SetPosition(x, y, y);
                placedCount += 1;
            }
        }
    }

}

[System.Serializable]
public class ResourcePrefab
{
    public GameObject Prefab;
    public string ResourceTag;
    public int ResourceCount = 10;
    public float ResourceRadius = 10;
    public float SpawnRate = 10; //one every 10 seconds
    public float lastSpawn = Mathf.NegativeInfinity;
}
