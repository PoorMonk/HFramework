using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HFramework
{
    public interface IPool<T>
    {
        T Spawn();
        bool Despawn(T obj);
    }

    public abstract class Pool<T> : IPool<T>
    {
        public int CurCount
        {
            get { return _cacheStack.Count; }
        }

        protected Stack<T> _cacheStack = new Stack<T>();
        protected IObjectFactory<T> _objFactory;
        protected int _maxCount = 5;

        public abstract bool Despawn(T obj);

        public T Spawn()
        {
            return CurCount == 0 ? _objFactory.Create() : _cacheStack.Pop();
        }
    }

    public interface IObjectFactory<T>
    {
        T Create();
    }

    public class CustomObjFactory<T> : IObjectFactory<T>
    {
        protected Func<T> _factoryMethod;

        public CustomObjFactory(Func<T> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        public T Create()
        {
            return _factoryMethod();
        }
    }

    public class SimpleObjectPool<T> : Pool<T>
    {
        readonly Action<T> _resetMethod;

        public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null, int initCount = 0)
        {
            _objFactory = new CustomObjFactory<T>(factoryMethod);
            _resetMethod = resetMethod;
            int count = initCount > _maxCount ? _maxCount : initCount;
            for (int i = 0; i < count; i++)
            {
                _cacheStack.Push(_objFactory.Create());
            }
        }

        public override bool Despawn(T obj)
        {
            _resetMethod?.Invoke(obj);
            _cacheStack.Push(obj);
            return true;
        }
    }
}

