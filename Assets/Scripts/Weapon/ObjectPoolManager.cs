using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
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
    public void CreatePool(PoolObject poolObject,int createCount)
    {
        var poolObjects = new List<PoolObject>();
        for (int i = 0; i < createCount; i++)
        {
            var obj = Instantiate(poolObject,this.transform);
            poolObjects.Add(obj);
        }
        s_poolObjects.Add(poolObject.ToString(), poolObjects);
    }
}
public abstract class PoolObject : MonoBehaviour
{

}
