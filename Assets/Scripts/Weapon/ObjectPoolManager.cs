using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private const int DEFAULT_POOL_COUNT = 5;
    private static ObjectPoolManager s_instance = default;
    private static Dictionary<string,List<PoolObject>> s_poolObjects = default;
    public static ObjectPoolManager Instance
    {
        get 
        {
            if (s_instance == null)
            {
                var obj = new GameObject("ObjectPool");
                var ins = obj.AddComponent<ObjectPoolManager>();
                s_instance = ins;
                s_poolObjects = new Dictionary<string, List<PoolObject>>();
            }
            return s_instance; 
        }
    }
    public void CreatePool(PoolObject poolObject,int createCount = DEFAULT_POOL_COUNT)
    {
        var poolObjects = new List<PoolObject>();
        for (int i = 0; i < createCount; i++)
        {
            var obj = Instantiate(poolObject,this.transform);
            obj.gameObject.SetActive(false);
            poolObjects.Add(obj);
        }
        s_poolObjects.Add(poolObject.ToString(), poolObjects);
    }
    public PoolObject Use(PoolObject useObject)
    {
        if (!s_poolObjects.ContainsKey(useObject.ToString())) 
        {
            CreatePool(useObject);
        }
        foreach (var poolObject in s_poolObjects[useObject.ToString()])
        {
            if (poolObject.gameObject.activeInHierarchy)
            {
                continue;
            }
            poolObject.gameObject.SetActive(true);
            return poolObject;
        }
        var obj = Instantiate(useObject, this.transform);
        s_poolObjects[useObject.ToString()].Add(obj);
        return obj;
    }
}
public abstract class PoolObject : MonoBehaviour
{
    public void SetPos(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        transform.forward = dir;
    }
}
