using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
    private int bananaCount=6;
    private bool addBanana;
    private bool remBanana;
    public Text countText;
    public GameObject banana;
    public Sprite halfNana;
    public Sprite fullNana;
    public Sprite blank;
    public Canvas canvas;
    Image m_Image;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

    void Start()
    {
        SetCountText();
        addBanana = false;
        remBanana = false;
        bananaCount = 6;
        SetBananas(bananaCount);
        Canvas.ForceUpdateCanvases();
    }

    void SetCountText()
    {
        countText.text = "Banana Meter: " + bananaCount.ToString();
    }

    void SetBananas(int bananas)
    {
        
        GameObject health;
        string bananaName = "BananaImage" + ((int)Mathf.Ceil(bananas / 2)).ToString();
        Debug.Log(bananaName);

        for (int i = 1; i<=(int)Mathf.Ceil(bananas/2);i++)
        {
            bananaName = "BananaImage" + i.ToString();
            health = GameObject.Find(bananaName);
            health.SetActive(true);
            m_Image = health.GetComponent<Image>();
            m_Image.sprite = fullNana;
            Canvas.ForceUpdateCanvases();
        }
        
        for (int i = 5; i > (int)Mathf.Ceil(bananas / 2)+1; i--)
        {
            bananaName = "BananaImage" + i.ToString();
            health = GameObject.Find(bananaName);
            m_Image = health.GetComponent<Image>();
            m_Image.sprite = blank;
            Canvas.ForceUpdateCanvases();
        }
        
            if (bananas%2==1)
        {
            bananaName = "BananaImage" + (((int)Mathf.Ceil(bananas / 2))+1).ToString();
            health = GameObject.Find(bananaName);
            health.SetActive(true);
            m_Image = health.GetComponent<Image>();
            m_Image.sprite = halfNana;
            Canvas.ForceUpdateCanvases();
        }
        Canvas.ForceUpdateCanvases();
    }

    private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
        
    }

    private void Update()
    {
        SetBananas(bananaCount);
        SetCountText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pick Up")
        {
            other.gameObject.SetActive(false);
            ++bananaCount;

            SetBananas(bananaCount);
            SetCountText();

            //string bananaName = "BananaImage" + bananaCount.ToString();
            //GameObject health = GameObject.Find(bananaName);


            /*
            if (bananaCount % 2 == 1) {

                bananaName = "BananaImage" + ((int)(bananaCount/2) + 1).ToString();
                
                health = GameObject.Find(bananaName);
                health.SetActive(true);
                m_Image = health.GetComponent<Image>();
                m_Image.sprite = halfNana;
                Canvas.ForceUpdateCanvases();
                SetCountText();
            }
            else {
                bananaName = "BananaImage" + ((int)(bananaCount / 2)).ToString();
                health = GameObject.Find(bananaName);
                health.SetActive(true);
                m_Image = health.GetComponent<Image>();
                m_Image.sprite = fullNana;
                Canvas.ForceUpdateCanvases();
                SetCountText();
            }
            */
        }else if (other.gameObject.tag == "Flying Enemy") {
            --bananaCount;

            SetBananas(bananaCount);
            SetCountText();

            Vector3 offset = new Vector3(1, 1, 0);
            other.transform.position = other.transform.position + offset; 

            //string bananaName = "BananaImage" + (bananaCount/2).ToString();
            //GameObject health = GameObject.Find(bananaName);

            /*
            if (((bananaCount) % 2) == 1)
            {
                //had a half banana in the last spot
                //remove the banana entirely
                bananaName = "BananaImage" + ((int)(bananaCount / 2) + 1).ToString();
                health = GameObject.Find(bananaName);
                health.SetActive(false);
                Canvas.ForceUpdateCanvases();
                SetCountText();
            }
            else
            {
                //had a whole banana in the last spot
                //put a half banana where the whole one was
                m_Image = health.GetComponent<Image>();
                m_Image.sprite = halfNana;
                Canvas.ForceUpdateCanvases();
                SetCountText();
            }
            */
        }
        else if (other.gameObject.tag == "Trigger Bee"){
            GameObject bee = GameObject.Find("Bee6");

        }
        Canvas.ForceUpdateCanvases();
        SetCountText();
    }


    public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
	}
}
