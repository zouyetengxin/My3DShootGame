using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject enemyPrefab;
	public float spawnTime = 3;		//生成周期
	private float timer = 0;		//计时器

	void Update(){
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			timer -= spawnTime;
			SpawnEnemy();
		}
	}

	void SpawnEnemy(){
		GameObject.Instantiate (enemyPrefab, transform.position, transform.rotation);
	}
}
