using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Scenario
{
    public string name;
    public string author;
    public List<GenericObject> objects;
    public Dictionary<string, int> ratings;
}
