using UnityEngine;


public class CupController : MonoBehaviour
{
	[Tooltip("The prefab to spawn when filling the cup.")]
	public ProjectileController fillPrefab;
	[Tooltip("The location to spawn the prefab.")]
	public Transform fillTransform;
	[Tooltip("The collider that follows this cup.")]
	public Collider meshCollider;
	[Tooltip("Speed at which to release the projectile.")]
	public float releaseSpeed;


	public Vector3 Velocity => this.velocity;

	private Vector3 velocity, prevVelocity;
	private Vector3 prevPos;
	private bool isFilled;
	private ProjectileController fillObject;

	public int shotsFired;


	/// <summary>
	/// Spawns the fill prefab.
	/// </summary>
	

	public void Start()
	{
		this.prevPos = this.transform.position;
		this.isFilled = false;
		shotsFired = 0;

	}

	public void FixedUpdate()
	{
		this.prevVelocity = this.velocity;
		Vector3 currentPos = this.transform.position;
		this.velocity = (currentPos - this.prevPos) / Time.deltaTime;
		this.prevPos = currentPos;
		if (this.velocity.magnitude >= this.releaseSpeed && !this.meshCollider.Raycast(new Ray(this.fillTransform.position, this.velocity.normalized), out _, 1f))
		{
			this.fillObject.Release();
			this.isFilled = false;
		}
	}

	public void Fill()
	{
		if (!this.isFilled)
		{
			this.isFilled = true;
			this.fillObject = Object.Instantiate(this.fillPrefab, this.fillTransform.position, this.fillTransform.rotation, this.transform);
		}
	}
}
