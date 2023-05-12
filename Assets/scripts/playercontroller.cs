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
    Vector3 forwardDir;
    Vector3 rightDir;

    [SerializeField]
    Camera mainCamera;

    private string str="q";

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
        Debug.Log(str);
        Key();
        
        if (!flag)
        {
            player.transform.position = WallManager.startpositon();
            playerposition = player.transform.position;
            flag=true;
        }
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 tmpPosition=player.transform.position;
        //rb.AddForce(movement * speed * Time.deltaTime);
        if(str=="w"||str=="s")
        { 
            var forwardDir = mainCamera.transform.forward;
            Dir(str);
            rb.AddForce(forwardDir * speed * Time.deltaTime);
        }
        if(str=="a"||str=="d")
        { 
        var rightDir = mainCamera.transform.right;
        Dir(str);
        rb.AddForce(rightDir*speed*Time.deltaTime);
        }

        if (player.transform.position.y <= 0)
        {
            tmpPosition.y = 1.0f;
        }
        player.transform.position=new Vector3(player.transform.position.x,tmpPosition.y,player.transform.position.z);

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
        //if(score>=5)
        //{
        //    SceneManager.LoadScene("Clear");
        //}
    }

    private void Dir(string str)
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S))
        {
            if(speed>0)
            {
                speed*=-1;
            }
        }
        if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.D))
        {
            if(speed<0)
            {
                speed*=-1;
            }
        }
    }

    private void Key()
    {
        if (Input.GetKey(KeyCode.W))
        {
            str = "w";
        }
        else if (Input.GetKey(KeyCode.A))
        {
            str="a";
        }
        else if(Input.GetKey(KeyCode.S))
        {
            str="s";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            str = "d";
        }
        else
        {
            str="n";
        }
    }
}
