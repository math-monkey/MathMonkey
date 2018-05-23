using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float degsBySec;
	public float bulletSpeed;
	public Sprite spEven;
	public Sprite spDiv3;
	public Sprite spPrime;
    public BulletType bulletType { get; set; }
    public AudioClip throwAudio;

	public enum BulletType {
		EVEN, DIVISIBLE_3, PRIME,
	};

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();

		var direction = Vector2.left;
		if (transform.localRotation.z.Equals(0)) {
			direction = Vector2.right;
			degsBySec *= -1;
		}

		// Set Bullet Type
		var banana = transform.Find("banana");
		SetType(banana.GetComponent<SpriteRenderer>().sprite);

		rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(throwAudio, transform.position, 1f);
	}

	// Update is called once per frame
	void Update() {
		transform.Rotate(0, 0, degsBySec * Time.deltaTime);
	}

	void SetType(Sprite sprite) {
		if (sprite == spEven) {
			bulletType = BulletType.EVEN;
		} else if (sprite == spDiv3) {
			bulletType = BulletType.DIVISIBLE_3;
		} else if (sprite == spPrime) {
			bulletType = BulletType.PRIME;
		}
	}

	public void RemoveForce() {
		rb.velocity = Vector2.zero;
	}

	public Sprite GetSprite(BulletType type) {
		switch (type) {
			case BulletType.EVEN:
				return spEven;
			case BulletType.DIVISIBLE_3:
				return spDiv3;
			case BulletType.PRIME:
				return spPrime;
			default:
				return null;
		}
	}
}
