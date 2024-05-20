using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    void OnEnter(T t);
    void OnExcute(T t);
    void OnExit(T t);
}
