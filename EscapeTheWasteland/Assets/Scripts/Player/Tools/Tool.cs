using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    protected int _level;

    public int Level { get => _level; set => _level = value; }

    public virtual void Upgrade()
    {
        Level++;
    }

}
