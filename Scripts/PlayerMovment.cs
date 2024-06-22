using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public float jumpForce = 10f;
    public int poeni;
    public Rigidbody2D rb;
    public TextMeshProUGUI rezultatTekst;
    public TextMeshProUGUI gameoverPanelText;
    public GameObject gameOverPanel;
    public SpriteRenderer sr;
    public Color[] bojaLoptice;
    public string trenutnaBoja;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void OnTriggerEnter2D(Collider2D sudar)
    {
        if (sudar.tag == "promenaBoje")
        {
            SetRandomColor();
            Destroy(sudar.gameObject);
            return;
        }

        if (sudar.tag != trenutnaBoja && sudar.tag != "zvezdica")
        {
            Debug.Log("Game over");
            gameOverPanel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }

        if (sudar.tag == "zvezdica")
        {
            poeni++;
            rezultatTekst.text = poeni.ToString();
            gameoverPanelText.text = poeni.ToString();
            Destroy(sudar.gameObject);
        }
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                trenutnaBoja = "plava";
                sr.color = bojaLoptice[0];
                break;
            case 1:
                trenutnaBoja = "zuta";
                sr.color = bojaLoptice[1];
                break;
            case 2:
                trenutnaBoja = "roze";
                sr.color = bojaLoptice[2];
                break;
            case 3:
                trenutnaBoja = "ljubicasta";
                sr.color = bojaLoptice[3];
                break;
        }
    }
}
