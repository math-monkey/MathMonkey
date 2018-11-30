using System;
using UnityEngine;

public class TriangleHelper {

    public static readonly int[] availableTriangles = new int[] {0,1,2};

    public static bool HasDamage(BulletController.BulletType bulletType, int number) {
        return number == (int)bulletType;
    }
}

