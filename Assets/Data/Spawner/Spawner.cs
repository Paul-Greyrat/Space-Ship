using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : GreyMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform PrefabsObj = this.transform.Find("Prefabs");
        foreach(Transform prefab in PrefabsObj)
        {
            this.prefabs.Add(prefab);
        }
        this.Hideprefabs();
        Debug.Log(transform.name + ": Load Prefabs",gameObject);
    }

    protected virtual void Hideprefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform GetPrefabByName(String prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName) return prefab;
        }
        Debug.LogWarning("prefab not found:" + prefabName);
        return null;
    }
    public virtual Transform Spawn( String prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }
}
