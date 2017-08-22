using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public  float HP = 100;
	private Animator anim;
	private NavMeshAgent agent;
	private EnemyMove enemyMove;
	private CapsuleCollider capCollider;
	private ParticleSystem particleSystem;
	private EnemyAttack enemyAttack;

	public AudioClip dealthClip;

	void Awake(){
		anim = this.GetComponent<Animator> ();
		agent = this.GetComponent<NavMeshAgent> ();
		enemyMove = this.GetComponent<EnemyMove> ();
		capCollider = this.GetComponent<CapsuleCollider> ();
		particleSystem = this.GetComponentInChildren<ParticleSystem> ();
		enemyAttack = this.GetComponent<EnemyAttack> ();
	}

	void Update(){
		if (this.HP <= 0) {
			transform.Translate (Vector3.down * Time.deltaTime * 0.5f);
			if(transform.position.y <= -1.5){
				DesBody();
			}
		}
	}

	public void TakeDamage(float damage,Vector3 hitPoint){
		if (this.HP <= 0)return;
		audio.Play ();
		particleSystem.transform.position = hitPoint;
		particleSystem.Play ();
		this.HP -= damage;
		if (this.HP <= 0) {
			Dead();
		}
	}

	void Dead(){
		anim.SetBool ("Dead", true);
		agent.enabled = false;
		enemyMove.enabled = false;
		capCollider.enabled = false;
		enemyAttack.enabled = false;
		AudioSource.PlayClipAtPoint (dealthClip, transform.position, 0.5f);
	}

	void DesBody(){
		Destroy (this.gameObject);
	}
}
