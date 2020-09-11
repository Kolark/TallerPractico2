using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpritePool : MonoBehaviour, IPool<Image>
{

    RectTransform rectTransform;
    private static SpritePool instance;
    public static SpritePool Instance { get => instance; }

    [SerializeField]
    Image pooleable;

    private List<Image> imgs = new List<Image>();
    public List<Image> Imgs { get => imgs; }

    public int PoolSize;
    public void initpool()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        rectTransform = GetComponent<RectTransform>();
        PoolSize = 8;
        Fill();
    }

    public void Fill()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            imgs.Add(Instantiate(pooleable, this.transform));
        }
    }

    public Image GetObject()
    {
        Image _img = imgs[0];
        imgs.RemoveAt(0);
        return _img;
    }

    public void Recycle(Image poolObject)
    {
        imgs.Add(poolObject);
        poolObject.GetComponent<RectTransform>().SetParent(rectTransform, false);
    }
}
