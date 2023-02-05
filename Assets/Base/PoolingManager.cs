using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum NamePrefabPool
{
    None,
    RockNormal,
    RockFire,
    RockFreeze,
    RockStun,
    ZombieNormal,
    ZombieBig,
    ZombieSpeed,
    NormalBoom,
    FireBoom,
    FreezeBoom,
    StunBoom,
    Blood
}
[System.Serializable]
public enum PrefabPoolType
{
    VFX,
    GAMEOBJECT
}
[System.Serializable]
public class PoolingInfo
{
    public string name;
    public PrefabPoolType prefabType;
    public NamePrefabPool namePrefab;
    public GameObject prefab;
    public int countStartSpawn;
}

public class PoolingManager : SingletonMonoBehaviour<PoolingManager>
{
    [Header("VFX POOL OBJECTS")]
    public PoolingInfo[] vfxPoolingInfo;
    List<GameObject> listVFXPool = new List<GameObject>();

    [Header("GAMEOBJECT POOL")]
    public PoolingInfo[] gameObjectPoolingInfo;
    List<GameObject> listObjectPool = new List<GameObject>();

    private void Start()
    {
        StartSpawnObject();
    }

    private void OnValidate()
    {
        if(vfxPoolingInfo.Length > 0)
        {
            foreach (PoolingInfo pl in vfxPoolingInfo)
            {
                pl.name = pl.namePrefab.ToString();
            }
        }

        if(gameObjectPoolingInfo.Length > 0)
        {
            foreach (PoolingInfo pl in gameObjectPoolingInfo)
            {
                pl.name = pl.namePrefab.ToString();
            }
        }
    }

    public void StartSpawnObject()
    {
        foreach (PoolingInfo pooling in vfxPoolingInfo)
        {
            if (pooling.prefabType == PrefabPoolType.VFX)
            {
                for (int i = 0; i < pooling.countStartSpawn; i++)
                {
                    GameObject obj = Instantiate(pooling.prefab, transform);
                    obj.name = pooling.namePrefab.ToString();
                    obj.SetActive(false);
                    listVFXPool.Add(obj);
                }
            }
        }

        foreach (PoolingInfo pooling in gameObjectPoolingInfo)
        {
            if (pooling.prefabType == PrefabPoolType.GAMEOBJECT)
            {
                for (int i = 0; i < pooling.countStartSpawn; i++)
                {
                    GameObject obj = Instantiate(pooling.prefab, transform);
                    obj.name = pooling.namePrefab.ToString();
                    obj.SetActive(false);
                    listObjectPool.Add(obj);
                }
            }
        }
    }

    public GameObject GetVFX(NamePrefabPool name)
    {
        if (listVFXPool.Count > 0)
        {
            foreach (GameObject obj in listVFXPool)
            {
                if (!obj.activeSelf && obj.name == name.ToString())
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            for (int i = 0; i < vfxPoolingInfo.Length; i++)
            {
                if (name == vfxPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(vfxPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    listVFXPool.Add(vfx);
                    return vfx;
                }
            }
        }
        else
        {
            for (int i = 0; i < vfxPoolingInfo.Length; i++)
            {
                if (name == vfxPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(vfxPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    listVFXPool.Add(vfx);
                    return vfx;
                }
            }
        }

        return null;
    }
    public GameObject GetVFX(NamePrefabPool name, Vector3 position, Transform parent = null)
    {
        if (listVFXPool.Count > 0)
        {
            foreach (GameObject obj in listVFXPool)
            {
                if (!obj.activeSelf && obj.name == name.ToString())
                {
                    if (parent == null)
                    {
                        obj.transform.SetParent(transform);
                    }
                    else
                    {
                        obj.transform.SetParent(parent);
                    }
                    obj.transform.position = position;
                    obj.SetActive(true);
                    return obj;
                }
            }

            for (int i = 0; i < vfxPoolingInfo.Length; i++)
            {
                if (name == vfxPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(vfxPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    if (parent == null)
                    {
                        vfx.transform.SetParent(transform);
                    }
                    else
                    {
                        vfx.transform.SetParent(parent);
                    }
                    vfx.transform.position = position;
                    listVFXPool.Add(vfx);
                    return vfx;
                }
            }
        }
        else
        {
            for (int i = 0; i < vfxPoolingInfo.Length; i++)
            {
                if (name == vfxPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(vfxPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    if (parent == null)
                    {
                        vfx.transform.SetParent(transform);
                    }
                    else
                    {
                        vfx.transform.SetParent(parent);
                    }

                    vfx.transform.position = position;
                    listVFXPool.Add(vfx);
                    return vfx;
                }
            }
        }

        return null;
    }
    public GameObject GetObject(NamePrefabPool name, Vector3 position, Transform parent = null)
    {
        if (listObjectPool.Count > 0)
        {
            foreach (GameObject obj in listObjectPool)
            {
                if (!obj.activeSelf && obj.name == name.ToString())
                {
                    if (parent == null)
                    {
                        obj.transform.SetParent(transform);
                    }
                    else
                    {
                        obj.transform.SetParent(parent);
                    }
                    obj.transform.position = position;
                    obj.SetActive(true);
                    return obj;
                }
            }

            for (int i = 0; i < gameObjectPoolingInfo.Length; i++)
            {
                if (name == gameObjectPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(gameObjectPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    if (parent == null)
                    {
                        vfx.transform.SetParent(transform);
                    }
                    else
                    {
                        vfx.transform.SetParent(parent);
                    }

                    vfx.transform.position = position;
                    listObjectPool.Add(vfx);
                    return vfx;
                }
            }
        }
        else
        {
            for (int i = 0; i < gameObjectPoolingInfo.Length; i++)
            {
                if (name == gameObjectPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(gameObjectPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    if (parent == null)
                    {
                        vfx.transform.SetParent(transform);
                    }
                    else
                    {
                        vfx.transform.SetParent(parent);
                    }
                    vfx.transform.position = position;
                    listObjectPool.Add(vfx);
                    return vfx;
                }
            }
        }

        return null;
    }
    public GameObject GetObject(NamePrefabPool name)
    {
        if (listObjectPool.Count > 0)
        {
            foreach (GameObject obj in listObjectPool)
            {
                if (!obj.activeSelf && obj.name == name.ToString())
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            for (int i = 0; i < gameObjectPoolingInfo.Length; i++)
            {
                if (name == gameObjectPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(gameObjectPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    listObjectPool.Add(vfx);
                    return vfx;
                }
            }
        }
        else
        {
            for (int i = 0; i < gameObjectPoolingInfo.Length; i++)
            {
                if (name == gameObjectPoolingInfo[i].namePrefab)
                {
                    GameObject vfx = Instantiate(gameObjectPoolingInfo[i].prefab, transform);
                    vfx.name = name.ToString();
                    listObjectPool.Add(vfx);
                    return vfx;
                }
            }
        }

        return null;
    }
    public void DisableAllObject()
    {
        StopAllCoroutines();

        for (int i = listObjectPool.Count - 1; i >= 0; i--)
        {
            if (listObjectPool[i] == null)
            {
                listObjectPool.RemoveAt(i);
            }
        }

        for (int i = listVFXPool.Count - 1; i >= 0; i--)
        {
            if (listVFXPool[i] == null)
            {
                listVFXPool.RemoveAt(i);
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void DisableObjectWithTime(GameObject obj, float time)
    {
        StartCoroutine(TimeDisableObject(obj, time));
    }

    IEnumerator TimeDisableObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}
