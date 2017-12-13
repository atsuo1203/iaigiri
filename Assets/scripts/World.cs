using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour {
	private float now;
	private float battleTime;
	private float enemyTime = 30f;
	private bool isTime;
	private bool isWin;
	private bool isLose;
	private GameObject atsumori;

	void Start(){
		battleTime = (Random.value + 0.1f) * 500;
		atsumori = GameObject.Find ("Atsumori");
		atsumori.SetActive (false);
	}

	void Update()
	{
		now++;
		if (isBattleStart()) {
			atsumori.SetActive (true);
			if (Input.GetMouseButtonDown (0)) {
				print ("いあいぎり！");
				isWin = true;
			}
			if (isEnemyAttack()) {
				isLose = true;
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				print ("フライング！");
				isLose = true;
			}
		}

		if (isWin) { SceneManager.LoadScene ("win");}
		if (isLose) { SceneManager.LoadScene ("lose");}
	}

	bool isBattleStart()
	{
		return (now > battleTime);
	}

	bool isEnemyAttack()
	{
		return (now - battleTime > enemyTime);
	}
}