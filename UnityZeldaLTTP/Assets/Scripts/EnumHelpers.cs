using System.Collections;
using System.Collections.Generic;

public class EnumHelpers
{
    private static System.Random _randomizer = new System.Random();

    public static T RandomEnumValue<T>() {
        var v = System.Enum.GetValues(typeof(T));
        return (T)v.GetValue(_randomizer.Next(v.Length));
    }
}
