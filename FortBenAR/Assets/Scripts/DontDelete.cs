﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDelete : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
