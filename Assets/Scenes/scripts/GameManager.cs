using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[3];
    Transform parent;
    State s = new State();
    int player;
    bool h = false;
    public GameObject nWhite;
    public GameObject nBlack;
    public GameObject turn;
    public GameObject winningCond;
    public AudioSource firstPlayer;
    public AudioSource secondPlayer;
    public AudioSource gameover;

    void displayBoard()
    {
       foreach (Transform children in parent)
       {
           Destroy(children.gameObject);
        }
        for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				GameObject square;
				Vector2 position = new Vector2 (j, 7 - i);
				if (s.b.board [i, j] == -1) { // if square is black
					square = Instantiate (prefabs [2], parent);
					square.transform.position = position;
					square.name = i.ToString () + "," + j.ToString ();
					continue;
				}
				square = Instantiate (prefabs [s.b.board [i, j]], parent);
				square.transform.position = position;
				square.name = i.ToString () + "," + j.ToString ();
			}
		}
		nWhite.GetComponent<Text>().text =  s.b.nWhite().ToString();
		nBlack.GetComponent<Text>().text =   s.b.nBlack().ToString();
        turn.GetComponent<Text>().text =  s.turnn();
        winningCond.GetComponent<Text>().text = "winner : " + s.Winner();

      

    }
    // Use this for initialization
    void Start()
    {
        player = -1;
        parent = GameObject.Find("board").transform;
        displayBoard();
        //Move(s, player);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
	if (Input.GetMouseButtonDown(0) && s.possibleMoves ().Count != 0)
	{
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                string move = hit.collider.name;
                Coordinate m = new Coordinate(move);   
                    h = s.isPossible(m);
                    if(s.player == -1 && h == true ){
                        firstPlayer.Play();
                    }
                    if(s.player == 1 && h == true){
                        secondPlayer.Play();
                    } 
                    s = s.Place(m);
                    
                    displayBoard();
                    h = false;
                    yield return new WaitForSeconds(.1f);
                }
                  
            }
        else if(s.possibleMoves().Count == 0){
             s.player = -s.player;
        }
    
        gameover.Play();
        s.GameOver();


         
	}
      
    
    }

