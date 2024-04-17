using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPOOL : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public GameObject prefab;
        public int count;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject> ();
            for (int i = 0; i < pool.count; i++) 
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive (false);
                objectsPool.Enqueue (obj);
            }
            poolDictionary.Add (pool.tag, objectsPool);
        }
    }

    public GameObject SpawnFromPool(string tag) 
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject obj = poolDictionary[tag].Dequeue ();
        poolDictionary[tag].Enqueue (obj);
        return obj;
    }


}
