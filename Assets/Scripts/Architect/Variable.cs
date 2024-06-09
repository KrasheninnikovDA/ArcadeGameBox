/// класс - обертка для передачи параметров в качестве ссылки.
using System;
using UnityEngine;

[Serializable]
public sealed class Variable<T>
{
    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;
        }
    }

    [SerializeField] private T _value;

    public Variable(T value)
    {
        _value = value;
    }
}
