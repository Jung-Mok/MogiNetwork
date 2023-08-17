using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MogiNetwork.Util
{
    //public class Atomic<T>
    //{
    //    private T _value;

    //    public Atomic(T initialValue)
    //    {
    //        _value = initialValue;
    //    }

    //    public T Value
    //    {
    //        get => _value;
    //        set => Interlocked.Exchange(ref _value, value);
    //    }

    //    public static Atomic<T> operator +(Atomic<T> atomic, T value)
    //    {
    //        T originalValue, newValue;
    //        do
    //        {
    //            originalValue = atomic.Value;
    //            newValue = PerformOperation(originalValue, value);
    //        } while (Interlocked.CompareExchange(ref atomic._value, newValue, originalValue) != originalValue);

    //        return atomic;
    //    }

    //    // 이 메서드에서 실제 연산을 수행합니다.
    //    private static T PerformOperation(T originalValue, T value)
    //    {
    //        if (typeof(T) == typeof(int))
    //        {
    //            return (T)(object)(((int)(object)originalValue) + ((int)(object)value));
    //        }
    //        else if (typeof(T) == typeof(long))
    //        {
    //            return (T)(object)(((long)(object)originalValue) + ((long)(object)value));
    //        }
    //        // 다른 타입의 경우에도 필요한 연산을 추가하세요.

    //        throw new NotSupportedException("Unsupported type for atomic operation.");
    //    }
    //}

}
