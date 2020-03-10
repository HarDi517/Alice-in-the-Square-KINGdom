using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_3 : MonoBehaviour
{
    //이 스크립트
    public static ObjectPool_3 objectPool;

    //장애물들의 부모(맵 이동 관리)
    public GameObject Obstacles;

    //장애물 생성용 프리펩
    public GameObject neonPrefab;
    public GameObject vaseLPrefab;
    public GameObject vaseRPrefab;
    public GameObject catLPrefab;
    public GameObject catRPrefab;
    public GameObject birdLPrefab;
    public GameObject birdRPrefab;
    public GameObject clockLPrefab;
    public GameObject clockRPrefab;
    public GameObject cupLPrefab;
    public GameObject cupRPrefab;
    /*--------------------------------------고정 장애물 프리펩-------*/

    public GameObject flipItemPrefab;
    /*--------------------------------------동적 장애물 프리펩-------*/


    public GameObject teapotLPrefab;
    public GameObject teapotRPrefab;
    public GameObject fakeItemPrefab;
    /*--------------------------------------일회용 장애물 프리펩-------*/

    //장애물 구조체
    public struct Obstacle
    {
        public GameObject obj;
        public string name;
        public int count;

        public Obstacle(GameObject _obj, string _name, int _count)
        {
            this.obj = _obj;
            this.name = _name;
            this.count = _count;
        }
    };

    //장애물 오브젝트 생성
    public Obstacle Neon = new Obstacle(null, "neon", 0);
    public Obstacle VaseL = new Obstacle(null, "vaseL", 0), VaseR = new Obstacle(null, "vaseR", 0);
    public Obstacle CatL1 = new Obstacle(null, "catL1", 0), CatL2 = new Obstacle(null, "catL2", 0), CatR = new Obstacle(null, "catR", 0);
    public Obstacle BirdL1 = new Obstacle(null, "birdL1", 0), BirdL2 = new Obstacle(null, "birdL2", 0), BirdR = new Obstacle(null, "birdR", 0);
    public Obstacle ClockL = new Obstacle(null, "clockL", 0), ClockR = new Obstacle(null, "clockR", 0);
    public Obstacle CupL = new Obstacle(null, "cupL", 0), CupR = new Obstacle(null, "cupR", 0);

    public int flipItemNum = 9;
    public Obstacle[] FlipItem = new Obstacle[9];

    public GameObject teapotL;
    public GameObject teapotR;
    public GameObject[] fakeItem = new GameObject[9];


    void Awake()
    {
        if (ObjectPool_3.objectPool == null)
            ObjectPool_3.objectPool = this;

        Generate();
        GenerateFlipItem();
        GenerateSingle();
    }

    //구조체 장애물 오브젝트(재활용 O) 생성
    void Generate()
    {
        Neon.obj = Instantiate(neonPrefab, neonPrefab.transform.position, neonPrefab.transform.rotation);
        Neon.obj.transform.SetParent(Obstacles.transform);

        VaseL.obj = Instantiate(vaseLPrefab, vaseLPrefab.transform.position, vaseLPrefab.transform.rotation);
        VaseL.obj.transform.SetParent(Obstacles.transform);
        VaseR.obj = Instantiate(vaseRPrefab, vaseRPrefab.transform.position, vaseRPrefab.transform.rotation);
        VaseR.obj.transform.SetParent(Obstacles.transform);

        CatL1.obj = Instantiate(catLPrefab, catLPrefab.transform.position, catLPrefab.transform.rotation);
        CatL1.obj.transform.SetParent(Obstacles.transform);
        CatL2.obj = Instantiate(catLPrefab, catLPrefab.transform.position, catLPrefab.transform.rotation);
        CatL2.obj.transform.SetParent(Obstacles.transform);
        CatR.obj = Instantiate(catRPrefab, catRPrefab.transform.position, catRPrefab.transform.rotation);
        CatR.obj.transform.SetParent(Obstacles.transform);

        BirdL1.obj = Instantiate(birdLPrefab, birdLPrefab.transform.position, birdLPrefab.transform.rotation);
        BirdL1.obj.transform.SetParent(Obstacles.transform);
        BirdL2.obj = Instantiate(birdLPrefab, birdLPrefab.transform.position, birdLPrefab.transform.rotation);
        BirdL2.obj.transform.SetParent(Obstacles.transform);
        BirdR.obj = Instantiate(birdRPrefab, birdRPrefab.transform.position, birdRPrefab.transform.rotation);
        BirdR.obj.transform.SetParent(Obstacles.transform);

        ClockL.obj = Instantiate(clockLPrefab, clockLPrefab.transform.position, clockLPrefab.transform.rotation);
        ClockL.obj.transform.SetParent(Obstacles.transform);
        ClockR.obj = Instantiate(clockRPrefab, clockRPrefab.transform.position, clockRPrefab.transform.rotation);
        ClockR.obj.transform.SetParent(Obstacles.transform);
        
        CupL.obj = Instantiate(cupLPrefab, cupLPrefab.transform.position, cupLPrefab.transform.rotation);
        CupL.obj.transform.SetParent(Obstacles.transform);
        CupR.obj = Instantiate(cupRPrefab, cupRPrefab.transform.position, cupRPrefab.transform.rotation);
        CupR.obj.transform.SetParent(Obstacles.transform);

    }

    void GenerateFlipItem()
    {
        for(int i = 0; i < flipItemNum; i++)
        {
            FlipItem[i].obj = GameObject.Instantiate(flipItemPrefab, Obstacles.transform);
            FlipItem[i].obj.transform.localPosition += new Vector3(0.5f * i, 0, 0);
        }
        FlipItem[0].name = "flipItem";
        FlipItem[0].count = 0;
    }

    //단일 장애물 오브젝트(재활용 X) 생성
    void GenerateSingle()
    {
        teapotL = GameObject.Instantiate(teapotLPrefab, teapotLPrefab.transform.position, teapotLPrefab.transform.rotation) as GameObject;
        teapotL.transform.SetParent(Obstacles.transform);
        teapotR = GameObject.Instantiate(teapotRPrefab, teapotRPrefab.transform.position, teapotRPrefab.transform.rotation) as GameObject;
        teapotR.transform.SetParent(Obstacles.transform);

        for (int i = 0; i < flipItemNum; i++)
        {
            fakeItem[i] = Instantiate(fakeItemPrefab, Obstacles.transform);
            fakeItem[i].transform.localPosition += new Vector3(0.5f * i, 0, 0);
        }
    }

    //장애물 이름 찾기 함수
    public string getName(GameObject thisObj)
    {
        string thisName = null;

        if (Neon.obj == thisObj)
            thisName = Neon.name;
        else if (VaseL.obj == thisObj)
            thisName = VaseL.name;
        else if (VaseR.obj == thisObj)
            thisName = VaseR.name;
        else if (CatL1.obj == thisObj)
            thisName = CatL1.name;
        else if (CatL2.obj == thisObj)
            thisName = CatL2.name;
        else if (CatR.obj == thisObj)
            thisName = CatR.name;
        else if (BirdL1.obj == thisObj)
            thisName = BirdL1.name;
        else if (BirdL2.obj == thisObj)
            thisName = BirdL2.name;
        else if (BirdR.obj == thisObj)
            thisName = BirdR.name;
        else if (ClockL.obj == thisObj)
            thisName = ClockL.name;
        else if (ClockR.obj == thisObj)
            thisName = ClockR.name;
        else if (CupL.obj == thisObj)
            thisName = CupL.name;
        else if (CupR.obj == thisObj)
            thisName = CupR.name;
        else if (FlipItem[0].obj == thisObj)
            thisName = FlipItem[0].name;
        else
            thisName = null;

        return thisName;
    }

    //재활용 장애물 이동 함수
    public void MoveObj()
    {
        switch (Neon.count)
        {
            case 1:
                Neon.obj.transform.localPosition = new Vector3(-0.71f, -54.2f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, -43.911f);
                break;
            case 2:
                Neon.obj.transform.localPosition = new Vector3(1.75f, -88.27f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, 15.858f);
                break;
            case 3:
                Neon.obj.transform.localPosition = new Vector3(-1.27f, -119.27f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, -68.979f);
                break;
            case 4:
                Neon.obj.transform.localPosition = new Vector3(0.87f, -150.39f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, 50.065f);
                break;
            case 5:
                Neon.obj.transform.localPosition = new Vector3(1.58f, -228.79f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, 24.78f);
                break;
            case 6:
                Neon.obj.transform.localPosition = new Vector3(-0.84f, -267.63f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, -43.133f);
                break;
            case 7:
                Neon.obj.transform.localPosition = new Vector3(1.33f, -310.59f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, 26.925f);
                break;
            case 8:
                Neon.obj.transform.localPosition = new Vector3(-1.02f, -326.9f, neonPrefab.transform.position.z);
                Neon.obj.transform.rotation = Quaternion.Euler(0, 0, -43.133f);
                break;
            case 9:
                Destroy(Neon.obj);
                break;
        }
        
        switch (VaseL.count)
        {
            case 1:
                VaseL.obj.transform.localPosition = new Vector3(vaseLPrefab.transform.position.x, -62f, vaseLPrefab.transform.position.z);
                break;
            case 2:
                VaseL.obj.transform.localPosition = new Vector3(vaseLPrefab.transform.position.x, -133f, vaseLPrefab.transform.position.z);
                break;
            case 3:
                VaseL.obj.transform.localPosition = new Vector3(vaseLPrefab.transform.position.x, -167f, vaseLPrefab.transform.position.z);
                break;
            case 4:
                VaseL.obj.transform.localPosition = new Vector3(vaseLPrefab.transform.position.x, -233f, vaseLPrefab.transform.position.z);
                break;
            case 5:
                Destroy(VaseL.obj);
                break;
        }

        switch (VaseR.count)
        {
            case 1:
                VaseR.obj.transform.localPosition = new Vector3(1.74f, -94.4f, vaseRPrefab.transform.position.z);
                break;
            case 2:
                VaseR.obj.transform.localPosition = new Vector3(1.53f, -203.7f, vaseRPrefab.transform.position.z);
                break;
            case 3:
                VaseR.obj.transform.localPosition = new Vector3(1.92f, -264.49f, vaseRPrefab.transform.position.z);
                break;
            case 4:
                Destroy(VaseR.obj);
                break;
        }

        switch (CatL1.count)
        {
            case 1:
                CatL2.obj.transform.localPosition = new Vector3(-1.1f, -71.1f, catLPrefab.transform.position.z);
                CatL2.obj.transform.rotation = Quaternion.Euler(0, 0, 61.442f);
            break;
            case 2:
                CatL1.obj.transform.localPosition = new Vector3(-1.36f, -83.39f, catLPrefab.transform.position.z);
                CatL1.obj.transform.rotation = Quaternion.Euler(0, 0, 111.617f);
            break;
            case 3:
                CatL2.obj.transform.localPosition = new Vector3(0.79f, -113.91f, catLPrefab.transform.position.z);
                CatL2.obj.transform.rotation = Quaternion.Euler(0, 0, 180f);
                break;
            case 4:
                CatL1.obj.transform.localPosition = new Vector3(-1.17f, -189.07f, catLPrefab.transform.position.z);
                break;
            case 5:
                CatL2.obj.transform.localPosition = new Vector3(-1.11f, -206.75f, catLPrefab.transform.position.z);
                CatL2.obj.transform.rotation = Quaternion.Euler(0, 0, 111.617f);
                break;
            case 6:
                CatL1.obj.transform.localPosition = new Vector3(0.63f, -243.9f, catLPrefab.transform.position.z);
                CatL1.obj.transform.rotation = Quaternion.Euler(0, 0, 180f);
                break;
            case 7:
                CatL2.obj.transform.localPosition = new Vector3(-1.65f, -252.2f, catLPrefab.transform.position.z);
                break;
            case 8:
                CatL1.obj.transform.localPosition = new Vector3(-1.03f, -279.17f, catLPrefab.transform.position.z);
                CatL1.obj.transform.rotation = Quaternion.Euler(0, 0, 111.617f);
                break;
            case 9:
                CatL2.obj.transform.localPosition = new Vector3(-1.03f, -299.7f, catLPrefab.transform.position.z);
                CatL2.obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 10:
                Destroy(CatL1.obj);
                break;
            case 11:
                Destroy(CatL2.obj);
                break;
        }

        switch (CatR.count)
        {
            case 1:
                CatR.obj.transform.localPosition = new Vector3(0.74f, -107.52f, catRPrefab.transform.position.z);
                CatR.obj.transform.rotation = Quaternion.Euler(0, 0, 180f);
                break;
            case 2:
                CatR.obj.transform.localPosition = new Vector3(1.13f, -139.55f, catRPrefab.transform.position.z);
                CatR.obj.transform.rotation = Quaternion.Euler(0, 0, 116.955f);
                break;
            case 3:
                CatR.obj.transform.localPosition = new Vector3(-0.99f, -306.01f, catRPrefab.transform.position.z);
                CatR.obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 4:
                Destroy(CatR.obj);
                break;
        }

        switch (BirdL1.count)
        {
            case 1:
                BirdL2.obj.transform.localPosition = new Vector3(-1f, -50.87f, birdLPrefab.transform.position.z);
                BirdL2.obj.transform.rotation = Quaternion.Euler(0, 0, 90f);
                break;
            case 2:
                BirdL1.obj.transform.localPosition = new Vector3(1.22f, -79.36f, birdLPrefab.transform.position.z);
                BirdL1.obj.transform.rotation = Quaternion.Euler(0, 0, 63.93f);
                break;
            case 3:
                BirdL2.obj.transform.localPosition = new Vector3(-0.95f, -99.6f, birdLPrefab.transform.position.z);
                BirdL2.obj.transform.rotation = Quaternion.Euler(0, 0, 81.6f);
                break;
            case 4:
                BirdL1.obj.transform.localPosition = new Vector3(-1.06f, -143.81f, birdLPrefab.transform.position.z);
                BirdL1.obj.transform.rotation = Quaternion.Euler(0, 0, 81.6f);
                break;
            case 5:
                BirdL2.obj.transform.localPosition = new Vector3(-1.02f, -171.19f, birdLPrefab.transform.position.z);
                break;
            case 6:
                BirdL1.obj.transform.localPosition = new Vector3(-1f, -179.87f, birdLPrefab.transform.position.z);
                break;
            case 7:
                BirdL2.obj.transform.localPosition = new Vector3(0.85f, -219.8f, birdLPrefab.transform.position.z);
                break;
            case 8:
                BirdL1.obj.transform.localPosition = new Vector3(-1.35f, -239.2f, birdLPrefab.transform.position.z);
                BirdL1.obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 9:
                BirdL2.obj.transform.localPosition = new Vector3(-1.35f, -302.86f, birdLPrefab.transform.position.z);
                BirdL2.obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 10:
                BirdL1.obj.transform.localPosition = new Vector3(0.95f, -320.86f, birdLPrefab.transform.position.z);
                BirdL1.obj.transform.rotation = Quaternion.Euler(0, 0, 82.831f);
                break;
            case 11:
                Destroy(BirdL2.obj);
                break;
            case 12:
                Destroy(BirdL1.obj);
                break;
        }

        switch (BirdR.count)
        {
            case 1:
                BirdR.obj.transform.localPosition = new Vector3(1.09f, -175.58f, birdRPrefab.transform.position.z);
                BirdR.obj.transform.rotation = Quaternion.Euler(0, 0, -83.519f);
                break;
            case 2:
                BirdR.obj.transform.localPosition = new Vector3(1f, -257.9f, birdRPrefab.transform.position.z);
                break;
            case 3:
                BirdR.obj.transform.localPosition = new Vector3(1f, -284.2f, birdRPrefab.transform.position.z);
                break;
            case 4:
                Destroy(BirdR.obj);
                break;
        }

        switch (ClockL.count)
        {
            case 1:
                ClockL.obj.transform.localPosition = new Vector3(clockLPrefab.transform.position.x, -156.4f, clockLPrefab.transform.position.z);
                break;
            case 2:
                ClockL.obj.transform.localPosition = new Vector3(clockLPrefab.transform.position.x, -215f, clockLPrefab.transform.position.z);
                break;
            case 3:
                ClockL.obj.transform.localPosition = new Vector3(clockLPrefab.transform.position.x, -263.1f, clockLPrefab.transform.position.z);
                break;
            case 4:
                ClockL.obj.transform.localPosition = new Vector3(clockLPrefab.transform.position.x, -289.9f, clockLPrefab.transform.position.z);
                break;
            case 5:
                ClockL.obj.transform.localPosition = new Vector3(clockLPrefab.transform.position.x, -316.4f, clockLPrefab.transform.position.z);
                break;
            case 6:
                Destroy(ClockL.obj);
                break;
        }

        switch (ClockR.count)
        {
            case 1:
                ClockR.obj.transform.localPosition = new Vector3(clockRPrefab.transform.position.x, -76.2f, clockRPrefab.transform.position.z);
                break;
            case 2:
                ClockR.obj.transform.localPosition = new Vector3(clockRPrefab.transform.position.x, -129.2f, clockRPrefab.transform.position.z);
                break;
            case 3:
                ClockR.obj.transform.localPosition = new Vector3(clockRPrefab.transform.position.x, -185f, clockRPrefab.transform.position.z);
                break;
            case 4:
                Destroy(ClockR.obj);
                break;
        }

        switch (CupL.count)
        {
            case 1:
                CupL.obj.transform.localPosition = new Vector3(cupLPrefab.transform.position.x, -92.8f, cupLPrefab.transform.position.z);
                break;
            case 2:
                CupL.obj.transform.localPosition = new Vector3(cupLPrefab.transform.position.x, -199.8f, cupLPrefab.transform.position.z);
                break;
            case 3:
                CupL.obj.transform.localPosition = new Vector3(cupLPrefab.transform.position.x, -269.7f, cupLPrefab.transform.position.z);
                break;
            case 4:
                CupL.obj.transform.localPosition = new Vector3(cupLPrefab.transform.position.x, -295.7f, cupLPrefab.transform.position.z);
                break;
            case 5:
                CupL.obj.transform.localPosition = new Vector3(cupLPrefab.transform.position.x, -324.55f, cupLPrefab.transform.position.z);
                break;
            case 6:
                Destroy(CupL.obj);
                break;
        }

        switch (CupR.count)
        {
            case 1:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -103.6f, cupRPrefab.transform.position.z);
                break;
            case 2:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -135.6f, cupRPrefab.transform.position.z);
                break;
            case 3:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -163.3f, cupRPrefab.transform.position.z);
                break;
            case 4:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -196.6f, cupRPrefab.transform.position.z);
                break;
            case 5:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -211.2f, cupRPrefab.transform.position.z);
                break;
            case 6:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -235.6f, cupRPrefab.transform.position.z);
                break;
            case 7:
                CupR.obj.transform.localPosition = new Vector3(cupRPrefab.transform.position.x, -293.7f, cupRPrefab.transform.position.z);
                break;
            case 8:
                Destroy(CupR.obj);
                break;
        }



    }

    public void MoveFlipItem()
    {
        switch (FlipItem[0].count)
        {
            case 1:
                for (int i = 0; i < flipItemNum; i++)
                {
                    FlipItem[i].obj.transform.localPosition += new Vector3(0, -22.8f, 0);
                    FlipItem[i].obj.GetComponent<SpriteRenderer>().enabled = true;
                    FlipItem[i].obj.GetComponent<PolygonCollider2D>().enabled = true;
                }
                break;
            case 2:
                for (int i = 0; i < flipItemNum; i++)
                {
                    FlipItem[i].obj.transform.localPosition += new Vector3(0, -128.9f, 0);
                    FlipItem[i].obj.GetComponent<SpriteRenderer>().enabled = true;
                    FlipItem[i].obj.GetComponent<PolygonCollider2D>().enabled = true;
                }
                break;
            case 3:
                for (int i = 0; i < flipItemNum; i++)
                {
                    FlipItem[i].obj.transform.localPosition += new Vector3(0, -22.4f, 0);
                    FlipItem[i].obj.GetComponent<SpriteRenderer>().enabled = true;
                    FlipItem[i].obj.GetComponent<PolygonCollider2D>().enabled = true;
                }
                break;
            case 4:
                for (int i = 0; i < flipItemNum; i++)
                    Destroy(FlipItem[i].obj);
                break;

        }
    }

}

