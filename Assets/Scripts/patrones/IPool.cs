using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPool<T>
{
    void Fill();

    T GetObject();

    void Recycle(T poolObject);
}