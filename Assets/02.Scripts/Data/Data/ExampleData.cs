﻿using System.ComponentModel;
using UnityEngine;

namespace act.data
{
    public class ExampleData
    {
        [Description("example_id")]
        public int ID;
        [Description("example_name")]
        public string name;
        [Description("example_desc")]
        public string desc;
    }
}

