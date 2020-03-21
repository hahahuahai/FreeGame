using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeGame
{
    /// <summary>
    /// 普通单例类，非继承于monobehaviour
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonNoMono<T> where T : class, new()
    {
        protected static T _instance = null;

        public static T Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

        protected SingletonNoMono()
        {
            if (null != _instance)
            {
                Debug.LogError("This " + (typeof(T)).ToString() + "Singleton Instance is not null!!!");
            }
            Init();
        }

        public virtual void Init()
        {

        }
    }

}
