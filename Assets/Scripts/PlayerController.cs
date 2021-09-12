using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public float speed = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObj;
		
	private int count;
	private Rigidbody rb;
	
	private float movementX;
	private float movementY;
    // Start is called before the first frame update
    void Start()
    {
		count = 0;
        rb = GetComponent<Rigidbody>();
		SetCountText();
		winTextObj.SetActive(false);
    }
	
	void SetCountText(){
		countText.text = "Count: " + count.ToString();
		if(count>=7){
			winTextObj.SetActive(true);
		}
	}

	void OnMove(InputValue movementValue){
		Vector2 movementVector = movementValue.Get<Vector2>();
		
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	
	void FixedUpdate(){
		Vector3 movement = new Vector3(movementX,0.0f,movementY);
		rb.AddForce(movement * speed);
	}
	
	private void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("PickUp")){
			count++;
			other.gameObject.SetActive(false);
			SetCountText();
		}
	}
}
