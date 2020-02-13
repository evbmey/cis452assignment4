using System;
using System.Collections;
using UnityEngine;

public static class Invoker 
{
    public static void InvokeRepeatedly(uint count, Action task)
    {
        for (uint i = count; i > 0; i--)
        {
            task();
        }
    }

    public static void InvokeRepeatedly<T>(uint count, Action<T> task, T param)
    {
        for (uint i = count; i > 0; i--)
        {
            task(param);
        }
    }

    public static void InvokeRepeatedly<T1, T2>(uint count, Action<T1, T2> task, T1 param1, T2 param2)
    {
        for (uint i = count; i > 0; i--)
        {
            task(param1, param2);
        }
    }

    public static IEnumerator InvokeWithDelay(float delay, Action task)
    {
        yield return new WaitForSeconds(delay);
        task();
    }

    public static IEnumerator InvokeWithDelay<T>(float delay, Action<T> task, T param)
    {
        yield return new WaitForSeconds(delay);
        task(param);
    }

    public static IEnumerator InvokeWithDelay<T1, T2>(float delay, Action<T1, T2> task, T1 param1, T2 param2)
    {
        yield return new WaitForSeconds(delay);
        task(param1, param2);
    }
}
