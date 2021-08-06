using UnityEngine;
using System.Collections;
 
public class StairsScript : MonoBehaviour {
	
    // 接触判定用
    private bool isTouch;
	private BoxCollider2D groundCollider;
	
    // 階段
    public GameObject StairStep;
    private float StageSize = 0.8f;

	void Start ()
	{
		groundCollider = GetComponent<BoxCollider2D>();
	}
	
	void Update (){

        // 接触中はfalse、離れたらtrue
		if (isTouch) {
			groundCollider.enabled = false;
		}
        if (!isTouch) {
			groundCollider.enabled = true;
		}

	}
	
    // プレイヤーのトリガーが接触している間は接触判定をtrueに
	void OnTriggerStay2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			isTouch = true;
		}
	}
	
    // プレイヤーのトリガーが離れたら接触判定をfalseに
	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			isTouch = false;
		}
	}
}