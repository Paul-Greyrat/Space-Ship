using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : GreyMonoBehaviour
{
    [SerializeField] protected Transform hodler;
    [SerializeField] protected int spawndCount = 0;
    public int SpawndCount { get => this.spawndCount; }
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolOjbs;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHoder();
    }

    protected virtual void LoadHoder()
    {
        if (this.hodler != null) return;
        this.hodler = transform.Find("Hodler");
        Debug.Log(transform.name + ":Load Hodler", gameObject);

    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform PrefabsObj = this.transform.Find("Prefabs");
        foreach (Transform prefab in PrefabsObj)
        {
            this.prefabs.Add(prefab);
        }
        this.Hideprefabs();
        Debug.Log(transform.name + ": Load Prefabs", gameObject);
    }

    protected virtual void Hideprefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform GetPrefabByName(String prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        Debug.LogWarning("prefab not found:" + prefabName);
        return null;
    }
    public virtual Transform Spawn(String prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetOjbFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.hodler;
        this.spawndCount++;
        return newPrefab;
    }
    
    public virtual Transform GetOjbFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolOjbs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolOjbs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform Obj)
    {
        this.poolOjbs.Add(Obj);
        Obj.gameObject.SetActive(false);
        this.spawndCount--;
    }

    public virtual Transform RandomPrefab()
    {
        int rand = UnityEngine.Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

}
