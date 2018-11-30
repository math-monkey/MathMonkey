using System;
using UnityEngine;

public class TriangleHelper {

    public static readonly int[] availableTriangles = new int[] {0,1,2};

    public static bool HasDamage(BulletController.BulletType bulletType, int number) {
        switch (bulletType) {
            case BulletController.BulletType.EVEN:
                Debug.Log("number: " + number + "   bulletType: " + bulletType);
                return number == (int) bulletType;
            case BulletController.BulletType.DIVISIBLE_3:
                Debug.Log("number: " + number + "   bulletType: " + bulletType);
                return number == (int) bulletType;
            case BulletController.BulletType.PRIME:
                 Debug.Log("number: " + number + "   bulletType: " + bulletType);
                 return number == (int) bulletType;
            default:
                 return false;
        }
    }
}
