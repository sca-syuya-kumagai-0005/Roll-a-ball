using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody rb;
    private int score = 0;
    [SerializeField]
    private Text scoretext;
    [SerializeField]
    private GameObject player;
    Vector3 StartPositon;
    Vector3  y;
    Vector3 playerposition;

    private bool flag;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();  
        Debug.Log(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!flag)
        {
            player.transform.position = WallManager.startpositon();
            playerposition = player.transform.position;
            flag=true;
        }
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);
        if (player.transform.position.y <= 0)
        {
            playerposition.y= 1.0f;
        }
        //var ‚ÍŒ^„˜_@‰E•Ó‚©‚çŒ^‚ðŽ©“®‚Å„‘ª‚µ‚Ä‚­‚ê‚é

        scoretext.text="Count:"+score.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Item.pickup"))
        {
            other.gameObject.SetActive(false);
            score+=1;
        }
        if(score>=5)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
