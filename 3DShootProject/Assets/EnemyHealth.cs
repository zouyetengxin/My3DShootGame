using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private float HP = 100;
	private Animator anim;
	private NavMeshAgent agent;
	private CapsuleCollider capCollider;

	void Awake(){
		anim = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
		capCollider = this.GetComponent<CapsuleCollider> ();
	}
/*
	void UpDate(){
		if (this.HP <= 0) {
			transform.Translate (Vector3.down * Time.deltaTime * 0.5f);
			if(transform.position.y <= -3){
				DesBody();
			}
		}
	}
*/
	public void TakeDamage(float damage){
		if (this.HP <= 0)
						return;
		this.HP -= damage;
		if (this.HP <= 0) {
			Dead();
		}
	}

	void Dead(){
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		capCollider.enabled = false;

		Invoke ("DesBody", 3f);
	}

	void DesBody(){
		Destroy (this.gameObject);
	}
}
