﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCharacter : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
