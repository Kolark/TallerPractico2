using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPool<T> : MonoBehaviour where T: MonoBehaviour
{
    RectTransform rectTransform;
    private static AbstractPool<T> instance;
    public static AbstractPool<T> Instance { get => instance; }

    [SerializeField]
    T pooleable;

    private List<T> objs = new List<T>();
    private List<T> Objs { get => objs; }

    public int poolSize;
    public void InitPool()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        rectTransform = GetComponent<RectTransform>();
        Fill();
    }

    public void Fill()
    {
        for (int i = 0; i < poolSize; i++)
        {
            objs.Add(Instantiate<T>(pooleable,rectTransform));
        }
    }

    public T GetObject()
    {
        T obj = objs[0];
        objs.RemoveAt(0);
        return obj;
    }

    public void Recycle(T poolObject)
    {
        objs.Add(poolObject);
        poolObject.GetComponent<RectTransform>().SetParent(rectTransform, false);
    }
}
