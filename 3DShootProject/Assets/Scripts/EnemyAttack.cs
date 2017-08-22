using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public  float attack = 5;	//攻击力
	private float timer;		//计时器
	private EnemyHealth health;
	public float attackTime = 1;//攻击频率

	void Start(){
		timer = attackTime;
		health = this.GetComponent<EnemyHealth> ();
	}

	public void OnTriggerStay(Collider col){
		if (col.tag == Tags.player && health.HP > 0) {
			timer += Time.deltaTime;
			if(timer >= attackTime){
				timer -= attackTime;
				col.GetComponent<PlayerHealth>().TakeDamage(attack);
			}
		}
	}
}
