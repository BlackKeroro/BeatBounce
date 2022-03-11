using UnityEngine;
using System.Collections;

public class IntroCut : MonoBehaviour {

	public Material capMaterial;

	public float maxDistance;

	public GameObject Slash;

	public GameObject Wall;
	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){


        
		}
		
	

	public void OnStart()
	{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
	{

		GameObject victim = hit.collider.gameObject;

		GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

		if (!pieces[1].GetComponent<Rigidbody>())
			pieces[1].AddComponent<Rigidbody>();

		Destroy(pieces[1], 1);

		  Instantiate(Slash);

			Wall.AddComponent<Rigidbody>();

	}
}

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

}
