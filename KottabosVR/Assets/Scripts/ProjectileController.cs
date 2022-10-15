using UnityEngine;


public class ProjectileController : MonoBehaviour
{
	private Rigidbody rb;
	private CupController cup;


	public void Start()
	{
		this.rb = this.GetComponent<Rigidbody>();
		this.cup = this.transform.parent.GetComponent<CupController>();
		this.rb.sleepThreshold = 0;
	}

	public void Update()
	{
		//Debug.DrawLine(this.transform.position, Vector3.zero, Color.red, 1.0f, false);
		//Debug.Log(this.transform.position);
	}

	public void Release()
	{
		this.rb.velocity += this.cup.Velocity;
		this.transform.SetParent(null);
	}
}
