using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float HP = 100;
	public float smoothing = 5;

	private float CurrentHP;
	private Animator anim;
	private PlayerMove playerMove;
	private SkinnedMeshRenderer bodyRenderer;
	private PlayerShoot playerShoot;
	private UISlider uiSlider;
	private UILabel numHp;
	private HUDText text;

	void Awake(){
		CurrentHP = HP;
		anim = this.GetComponent<Animator> ();
		playerMove = this.GetComponent<PlayerMove> ();
		bodyRenderer = transform.Find ("Player").renderer as SkinnedMeshRenderer;
		playerShoot = this.GetComponentInChildren<PlayerShoot>();
		uiSlider = GameObject.Find ("HPBG").GetComponent<UISlider> ();
		numHp = GameObject.Find ("HP").GetComponent<UILabel> ();
		text = GameObject.Find ("Hud").GetComponent<HUDText> ();
	}

	void Update(){
		bodyRenderer.material.color = 
			Color.Lerp (bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
	}

	public void TakeDamage(float damage){

		if (CurrentHP <= 0)return;
		CurrentHP -= damage;
		uiSlider.value = (float)(CurrentHP / HP);
		numHp.text = CurrentHP + "/" + HP;
		text.Add (-damage, Color.red, 0.1f);
		bodyRenderer.material.color = Color.red;
		if (CurrentHP <= 0) {
			anim.SetBool("Dead",true);
			Dead();
		}
	}

	void Dead(){
		this.playerMove.enabled = false;
		this.playerShoot.enabled = false;
	}
}
