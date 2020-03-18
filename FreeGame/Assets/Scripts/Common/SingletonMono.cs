﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    /// <summary>
    /// 继承于monobehaviour的单例类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonMono<T> : MonoBehaviour where T:SingletonMono<T>
    {
        protected static T _instance = null;
        
        public static T instance
        {
            get
            {
                if(null == _instance)
                {
                    GameObject go = GameObject.Find("SingletonMono");
                    if(null == go)
                    {
                        go = new GameObject("SingletonMono");

                        DontDestroyOnLoad(go);
                    }

                    _instance = go.GetComponent<T>();

                    if(null == _instance)
                    {
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }

}
