using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceController : MonoBehaviour
{
    public int Hp = 5;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;

    public bool flash = false;

    public float MovingSpeed = 2.0f;    //앨리스가 좌우로 움직이는 속도
    public bool inputLeft = false;
    public bool inputRight = false;     //좌우이동 터치버튼 입력 확인
    public Vector2 speed_vec;   //앨리스가 좌우로 움직이는 속도 벡터

    public int move_method = 1;         //1일 때 정상 방향으로 이동, -1일 때 좌우 반전

    Rigidbody2D rigid;

    public SpriteRenderer spriteRenderer;
    public GameObject unBeatTimePanel;
    public bool isUnBeatTime = false;

    public AudioSource audioCollision;
    public AudioSource audioItem;

    /****************************************************************************/

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        MoveBtControl ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MoveBtControl>();
        ui.Init();
    }

    //벽과 장애물 충돌 처리 함수
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUnBeatTime)
            return;

        if (collision.CompareTag("Item"))
        {//아이템 먹었을 때 오디오 처리
            audioItem.time = 0;
            audioItem.Play();
            isUnBeatTime = false;
            return;
        }

        else if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {//tag가 Enemy인 오브젝트와 충돌했을 경우에
            audioCollision.time = 0;
            audioCollision.Play();
            Hp--;
            RemoveHeart();      //하트 한개씩 제거하는 함수
            isUnBeatTime = true;
            StartCoroutine(UnBeatTime());       //무적시간 코루틴 함수를 시작한다
        }

    }

    //플래시 충돌 처리
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (isUnBeatTime)
            return;

        if (collision.name == "IMG_0453" && (flash == false))
        {
            flash = true;
            Hp--;
            RemoveHeart();      //하트 한개씩 제거하는 함수
            isUnBeatTime = true;
            StartCoroutine(UnBeatTime());       //무적시간 코루틴 함수를 시작한다
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "IMG_0453")
            flash = false;
    }

    // Update is called once per frame
    void Update()
    {

        //앨리스 좌우 이동
        if (!inputLeft && !inputRight)
            speed_vec.x = 0;
        else if (inputLeft)
        {
            if (move_method == 1)
                speed_vec.x = -MovingSpeed;
            else
                speed_vec.x = MovingSpeed;
        }
        else if (inputRight)
        {
            if (move_method == 1)
                speed_vec.x = MovingSpeed;
            else
                speed_vec.x = -MovingSpeed;
        }

        rigid.velocity = speed_vec;

        //앨리스의 좌우 이동범위 제한
        float xMinClamp = Mathf.Clamp(this.transform.position.x, -2.2f, 2.2f);
        transform.position = new Vector3(xMinClamp, transform.position.y, transform.position.z);
    }

    //무적시간 코루틴 함수
    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime < 3)
                unBeatTimePanel.SetActive(true);
            else
                unBeatTimePanel.SetActive(false);

            if (countTime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 100);

            yield return new WaitForSeconds(0.1f);

            countTime++;
        }

        spriteRenderer.color = new Color32(255, 255, 255, 255);     //앨리스 색깔 원상복귀
        isUnBeatTime = false;
        yield return null;
    }

    void RemoveHeart()
    {
        if (Hp == 4)
            Destroy(Heart1);
        if (Hp == 3)
            Destroy(Heart2);
        if (Hp == 2)
            Destroy(Heart3);
        if (Hp == 1)
            Destroy(Heart4);
        if (Hp == 0)
        {
                        Destroy(Heart5);
            Debug.Log("게임오버");
            //            Die();
        }
    }


    void Die()
    {
        Time.timeScale = 0;
        NormalUIController.instance.ShowGameOver();
    }

}