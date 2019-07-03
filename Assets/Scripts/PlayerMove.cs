using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	float score = 0;
	float life = 3;
	public float spawnX,spawnY;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float move;

	public AudioClip WinLevel;
	
	
	// Use this for initialization
	void Start () {
		spawnX = transform.position.x;
		spawnY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis ("Horizontal");

	}

	void Update(){
		if (grounded &&(Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {

			GetComponent<Rigidbody2D>().AddForce (new Vector2(0f,jumpForce));
			grounded = false;
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		if(life == 0)
		{
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}


	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "VoidZone"||(col.gameObject.name == "saw")){
						life = life - 1;
						transform.position = new Vector3(spawnX,spawnY,transform.position.z);
						//Application.LoadLevel (Application.loadedLevel);
			}	
		if (col.gameObject.tag == "star") {
						score++;
						Destroy (col.gameObject);
				}
		if (col.gameObject.name == "EndLevel") {
			if (score == 2) {
				GetComponent<AudioSource>().PlayOneShot(WinLevel);
				System.Threading.Thread.Sleep(3000);
				Application.LoadLevel ("level2");
			}
				}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		grounded = true;
		if(col.gameObject.tag == "enemy")
		{
			life = life - 1;
			transform.position = new Vector3(spawnX,spawnY,transform.position.z);
		}
	}
	
	void OnGUI(){
	GUI.Box (new Rect (0, 0, 100, 50), "Stars: " + score + '\n' + "Life: " + life);
	}
		
}