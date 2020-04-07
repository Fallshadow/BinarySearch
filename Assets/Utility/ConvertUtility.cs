using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace act.utility
{
    public static class ConvertUtility
    {
        public static string ConvertEnumToString<T>(T Ttype)
        {
            string tempS = Enum.Parse(typeof(T), Ttype.ToString()).ToString();
            return tempS;
        }
    }
}
