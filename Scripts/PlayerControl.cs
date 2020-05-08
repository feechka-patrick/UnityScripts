using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControl : MonoBehaviour
{

	public float speed = 1.5f;

	public Transform head;

	public float sensitivity = 5f; // чувствительность мыши
	public float headMinY = -40f; // ограничение угла для головы
	public float headMaxY = 40f;

	public KeyCode runButton = KeyCode.LeftShift; // клавиша для бега
	public float runForce = 10; // ускорение

	private Vector3 direction;
	private float h, v;
	private int layerMask;
	private Rigidbody body;
	private float rotationY;

	void Start()
	{
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
		//layerMask = 1 << gameObject.layer | 1 << 2;
		//layerMask = ~layerMask;
	}

	void FixedUpdate()
	{
		body.AddForce(direction * speed, ForceMode.VelocityChange);

		// Ограничение скорости, иначе объект будет постоянно ускоряться
		if (Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
		}
		if (Mathf.Abs(body.velocity.z) > speed)
		{
			body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
		}
	}

	void Update()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		// управление головой (камерой)
		float rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		rotationY += Input.GetAxis("Mouse Y") * sensitivity;
		rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
		head.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

		// вектор направления движения
		direction = new Vector3(h, 0, v);
		direction = head.TransformDirection(direction);
		direction = new Vector3(direction.x, 0, direction.z);

		
	}

}