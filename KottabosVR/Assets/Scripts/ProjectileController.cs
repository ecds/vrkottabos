using UnityEngine;


public class ProjectileController : MonoBehaviour
{
	[Tooltip("How long the projectile should remain alive after being thrown.")]
	public float lifeSpan;
	[Tooltip("How long the projectile collider should remain disabled after being thrown.")]
	public float clipTime;

	private Rigidbody rb;
	private CupController cup;
	private bool seperated;
	new private SphereCollider collider;


	public void Awake()
	{
		this.rb = this.GetComponent<Rigidbody>();
		this.cup = this.transform.parent.GetComponent<CupController>();
		this.rb.sleepThreshold = 0;
		this.seperated = false;
		this.collider = this.GetComponent<SphereCollider>();
		this.collider.enabled = false;
	}

	public void Update()
	{

		if (this.seperated)
		{
			this.lifeSpan -= Time.deltaTime;
			if (this.lifeSpan <= 0)
			{
				if(this.GetComponent<ProjectileScore>().hitSomething == false)
				{
                    
					Score.misses += 1;//if for some reason the projectile disappears without touching anything, not even terrain, it counts as a miss
                    //Debug.Log("MISAPPEAR hits: " + Score.hits + " misses: " + Score.misses);
                }

				Object.Destroy(this.gameObject);
			}
			this.clipTime -= Time.deltaTime;
			if (!this.collider.enabled && this.clipTime <= 0)
			{
				this.collider.enabled = true;
			}
		}
		Debug.DrawLine(this.transform.position, Vector3.zero, Color.red, 1.0f, false);
		//Debug.Log(this.transform.position);
	}

	public void Release()
	{
		this.transform.SetParent(null);
		this.seperated = true;
	}
}
