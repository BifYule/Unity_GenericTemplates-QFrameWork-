using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System.Linq;

public class GameManager : MonoSingleton<GameManager>, IController
{
    [SerializeField]
    private List<GameObject> _prefabs;

    //暂无加载设置，默认为单场景
    [HideInInspector]
    public string LoadSceneName = "";

    public Dictionary<string, GameObject> Prefabs { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DontDestroyOnLoad(this);
        }

        Prefabs = _prefabs.ToDictionary(prefab => prefab.name, prefab => prefab);
    }

    public void RemoveAllChildren(GameObject parent)
    {
        Transform transform;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            transform = parent.transform.GetChild(i);
            DestroyImmediate(transform.gameObject);
        }
    }

    public IArchitecture GetArchitecture()
    {
        throw new System.NotImplementedException();
    }
}
