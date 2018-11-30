using System;
public class NumberHelper {

	public static readonly int[] availableNumbers = new int[] {
		4, 5, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17, 19, 20, 21, 22, 23, 26, 27, 28, 29, 31
	};

	public static bool IsEven(int number) {
		return number % 2 == 0;
	}

	public static bool IsDivisible3(int number) {
		return number % 3 == 0;
	}

	public static bool IsPrime(int number) {
		if (number == 1) return false;

		for (int i = 2; i <= (int) Math.Floor(Math.Sqrt(number)); i++) {
			if (number % i == 0) {
				return false;
			}
		}
		return true;
	}

	public static bool HasDamage(BulletController.BulletType bulletType, int number) {
		switch (bulletType) {
			case BulletController.BulletType.EVEN:
				return IsEven(number);
			case BulletController.BulletType.DIVISIBLE_3:
				return IsDivisible3(number);
			case BulletController.BulletType.PRIME:
				return IsPrime(number);
			default:
				return false;
		}
	}
}
