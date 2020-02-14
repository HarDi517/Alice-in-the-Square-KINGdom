using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_4 : MonoBehaviour
{
    //이 스크립트
    public static ObjectPool_4 objectPool;

    //장애물들의 부모(맵 이동 관리)
    public GameObject Obstacles;

    //장애물 생성용 프리펩
    public GameObject plantLPrefab;
    public GameObject plantRPrefab;
    public GameObject queenLPrefab;
    public GameObject queenRPrefab;
    public GameObject lionLPrefab;
    public GameObject lionRPrefab;
    public GameObject gosmdochiPrefab;
    public GameObject flamingoPrefab;
    public GameObject cardHeartPrefab;
    public GameObject cardSpadePrefab;
    public GameObject cardCloverPrefab;
    public GameObject cardDiamondPrefab;

    /*--------------------------------------고정 장애물 프리펩-------*/

    public GameObject io_gosmdochiPrefab;
    /*--------------------------------------동적 장애물 프리펩-------*/


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
    public Obstacle PlantL = new Obstacle(null, "plantL", 0);      //L 1개 R 2개
    public Obstacle PlantR1 = new Obstacle(null, "plantR", 0);
    public Obstacle PlantR2 = new Obstacle(null, "plantR", 0);
    public Obstacle QueenL = new Obstacle(null, "queenL", 0);      //L 1개 R 1개
    public Obstacle QueenR = new Obstacle(null, "queenR", 0);
    public Obstacle LionL = new Obstacle(null, "lionL", 0);       //L 1개 R 1개
    public Obstacle LionR = new Obstacle(null, "lionR", 0);
    public Obstacle[] Gosm = new Obstacle[4];       //4개
    public Obstacle[] Flam = new Obstacle[3];       //3개
    public Obstacle[] Card = new Obstacle[8];       //각 2개씩

    public Obstacle[] ioGosm = new Obstacle[5];     //5개


    void Awake()
    {
        if (ObjectPool_4.objectPool == null)
            ObjectPool_4.objectPool = this;

        Generate();
        GenerateIO();
    }

    //구조체 장애물 오브젝트(재활용 O) 생성
    void Generate()
    {
        
        PlantL.obj = Instantiate(plantLPrefab, Obstacles.transform);
        PlantR1.obj = Instantiate(plantRPrefab, Obstacles.transform);
        PlantR2.obj = Instantiate(plantRPrefab, new Vector3(1.29f, -90.34f, 0), Quaternion.identity, Obstacles.transform);

        QueenL.obj = Instantiate(queenLPrefab, Obstacles.transform);
        QueenR.obj = Instantiate(queenRPrefab, Obstacles.transform);

        LionL.obj = Instantiate(lionLPrefab, Obstacles.transform);
        LionR.obj = Instantiate(lionRPrefab, Obstacles.transform);

        for (int i = 0; i < 4; i++)
        {
            Gosm[i].obj = Instantiate(gosmdochiPrefab, Obstacles.transform);
            Gosm[i].name = "gosmdochi";
            Gosm[i].count = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            Flam[i].obj = Instantiate(flamingoPrefab, Obstacles.transform);
            Flam[i].name = "flamingo";
            Flam[i].count = 0;
        }

        //하트 2개
        Card[0].obj = Instantiate(cardHeartPrefab, Obstacles.transform);
        Card[1].obj = Instantiate(cardHeartPrefab, new Vector3(1.28f, -37f, 0), Quaternion.identity,Obstacles.transform);
        //스페이드 2개
        Card[2].obj = Instantiate(cardSpadePrefab, Obstacles.transform);
        Card[3].obj = Instantiate(cardSpadePrefab, new Vector3(-1.54f, -34.27f, 0), Quaternion.identity,Obstacles.transform);
        //클로버 2개
        Card[4].obj = Instantiate(cardCloverPrefab, Obstacles.transform);
        Card[5].obj = Instantiate(cardCloverPrefab, new Vector3(-1.45f, -39.61f, 0), Quaternion.identity,Obstacles.transform);
        //다이아 2개
        Card[6].obj = Instantiate(cardDiamondPrefab, Obstacles.transform);
        Card[7].obj = Instantiate(cardDiamondPrefab, new Vector3(1.17f, -33.04f, 0), Quaternion.identity,Obstacles.transform);
        for(int i = 0; i < 8; i++)
        {
            Card[i].name = "card";
            Card[i].count = 0;
        }
        


    }


    //동적 장애물 생성
    void GenerateIO()
    {
        for(int i = 0; i < 5; i++)
        {
            ioGosm[i].obj = Instantiate(io_gosmdochiPrefab, Obstacles.transform);
            ioGosm[i].name = "io_gosmdochi";
            ioGosm[i].count = 0;
        }
        
    }


    //장애물 이름 찾기 함수
    public string getName(GameObject thisObj)
    {
        string thisName = null;

        if (PlantL.obj == thisObj)
            thisName = PlantL.name;
        else if (PlantR1.obj == thisObj || PlantR2.obj == thisObj)
            thisName = PlantR1.name;
        else if (QueenL.obj == thisObj)
            thisName = QueenL.name;
        else if (QueenR.obj == thisObj)
            thisName = QueenR.name;
        else if (LionL.obj == thisObj)
            thisName = LionL.name;
        else if (LionR.obj == thisObj)
            thisName = LionR.name;
        else if (Gosm[0].obj == thisObj || Gosm[1].obj == thisObj || Gosm[2].obj == thisObj || Gosm[3].obj == thisObj)
            thisName = Gosm[0].name;
        else if (Flam[0].obj == thisObj || Flam[1].obj == thisObj || Flam[2].obj == thisObj)
            thisName = Flam[0].name;
        else if (Card[0].obj == thisObj || Card[1].obj == thisObj)
            thisName = Card[0].name;
        else if (Card[2].obj == thisObj || Card[3].obj == thisObj)
            thisName = Card[0].name;
        else if (Card[4].obj == thisObj || Card[5].obj == thisObj)
            thisName = Card[0].name;
        else if (Card[6].obj == thisObj || Card[7].obj == thisObj)
            thisName = Card[0].name;
        else
            thisName = null;

        return thisName;
    }

    //재활용 장애물 이동 함수
    public void MoveObst(string name)
    {
        switch (name)
        {
            case "plantL":
                switch (PlantL.count)
                {
                    case 1:
                        PlantL.obj.transform.localPosition = new Vector3(-0.78f, -73.55f, plantLPrefab.transform.position.z);
                        break;
                    case 2:
                        PlantL.obj.transform.localPosition = new Vector3(-0.7f, -113.05f, plantRPrefab.transform.position.z);
                        break;
                    case 3:
                        PlantL.obj.transform.localPosition = new Vector3(-0.85f, -185.84f, plantLPrefab.transform.position.z);
                        break;
                    case 4:
                        PlantL.obj.transform.localPosition = new Vector3(-0.86f, -263.65f, plantLPrefab.transform.position.z);
                        break;
                    case 5:
                        PlantL.obj.transform.localPosition = new Vector3(-1.09f, -277.49f, plantLPrefab.transform.position.z);
                        break;
                    case 9:
                        Destroy(PlantL.obj);
                        break;
                }
                break;
            case "plantR":
                switch (PlantR1.count)
                {
                    case 1:
                        PlantR1.obj.transform.localPosition = new Vector3(1.29f, -90.34f, plantRPrefab.transform.position.z);
                        break;
                    case 2:
                        PlantR2.obj.transform.localPosition = new Vector3(1.2f, -103.71f, plantRPrefab.transform.position.z);
                        break;
                    case 3:
                        PlantR1.obj.transform.localPosition = new Vector3(1.23f, -113.72f, plantRPrefab.transform.position.z);
                        break;
                    case 4:
                        PlantR2.obj.transform.localPosition = new Vector3(1.58f, -124.22f, plantRPrefab.transform.position.z);
                        break;
                    case 5:
                        PlantR1.obj.transform.localPosition = new Vector3(0.61f, -208.79f, plantRPrefab.transform.position.z);
                        break;
                    case 6:
                        PlantR2.obj.transform.localPosition = new Vector3(0.8f, -219.34f, plantRPrefab.transform.position.z);
                        break;
                    case 7:
                        PlantR1.obj.transform.localPosition = new Vector3(0.8f, -232f, plantRPrefab.transform.position.z);
                        break;
                    case 8:
                        PlantR2.obj.transform.localPosition = new Vector3(0.95f, -242.5f, plantRPrefab.transform.position.z);
                        break;
                    case 9:
                        PlantR1.obj.transform.localPosition = new Vector3(1.01f, -296.8f, plantRPrefab.transform.position.z);
                        break;
                    case 10:
                        Destroy(PlantR2.obj);
                        break;
                    case 11:
                        Destroy(PlantR1.obj);
                        break;
                }
                break;
            case "queenL":
                switch (QueenL.count)
                {
                    case 1:
                        QueenL.obj.transform.localPosition = new Vector3(-1.25f, -105.82f, queenLPrefab.transform.position.z);
                        break;
                    case 2:
                        QueenL.obj.transform.localPosition = new Vector3(-1.25f, -128.3749f, queenLPrefab.transform.position.z);
                        break;
                    case 3:
                        QueenL.obj.transform.localPosition = new Vector3(-1.790127f, -193.0349f, queenLPrefab.transform.position.z);
                        QueenL.obj.transform.rotation = Quaternion.Euler(0, 0, 14.321f);
                        break;
                    case 4:
                        QueenL.obj.transform.localPosition = new Vector3(-1.690127f, -228.1049f, queenLPrefab.transform.position.z);
                        QueenL.obj.transform.rotation = Quaternion.Euler(0, 0, 10.169f);
                        break;
                    case 5:
                        QueenL.obj.transform.localPosition = new Vector3(-1.7f, -303.0849f, queenLPrefab.transform.position.z);
                        QueenL.obj.transform.rotation = Quaternion.Euler(0, 0, -2.54f);
                        break;
                    case 9:
                        Destroy(QueenL.obj);
                        break;
                }
                break;
            case "queenR":
                switch (QueenR.count)
                {
                    case 1:
                        QueenR.obj.transform.localPosition = new Vector3(1.35f, -90.1f, queenRPrefab.transform.position.z);
                        break;
                    case 2:
                        QueenR.obj.transform.localPosition = new Vector3(1.23f, -263.1f, queenRPrefab.transform.position.z);
                        break;
                    case 3:
                        QueenR.obj.transform.localPosition = new Vector3(1.23f, -280.7049f, queenRPrefab.transform.position.z);
                        QueenR.obj.transform.rotation = Quaternion.Euler(0, 0, 5.414f);
                        break;
                    case 4:
                        Destroy(QueenR.obj);
                        break;
                }
                break;
            case "lionL":
                switch (LionL.count)
                {
                    case 1:
                        LionL.obj.transform.localPosition = new Vector3(-1.14f, -75.7f, lionLPrefab.transform.position.z);
                        break;
                    case 2:
                        LionL.obj.transform.localPosition = new Vector3(-1.21f, -101.2f, lionLPrefab.transform.position.z);
                        break;
                    case 3:
                        LionL.obj.transform.localPosition = new Vector3(-1.41f, -237.5f, lionLPrefab.transform.position.z);
                        break;
                    case 4:
                        LionL.obj.transform.localPosition = new Vector3(-1.21f, -276.76f, lionLPrefab.transform.position.z);
                        break;
                    case 5:
                        Destroy(LionL.obj);
                        break;
                }
                break;
            case "lionR":
                switch (LionR.count)
                {
                    case 1:
                        LionR.obj.transform.localPosition = new Vector3(1.45f, -124.115f, lionRPrefab.transform.position.z);
                        break;
                    case 2:
                        LionR.obj.transform.localPosition = new Vector3(1.2f, -189.445f, lionRPrefab.transform.position.z);
                        break;
                    case 3:
                        LionR.obj.transform.localPosition = new Vector3(1.25f, -257.515f, lionRPrefab.transform.position.z);
                        break;
                    case 4:
                        Destroy(LionR.obj);
                        break;
                }
                break;
            case "gosmdochi":
                switch (Gosm[0].count)
                {
                    case 1:
                        Gosm[0].obj.transform.localPosition = new Vector3(1.45f, -124.115f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 2:
                        Gosm[0].obj.transform.localPosition = new Vector3(1.2f, -189.445f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 3:
                        Gosm[0].obj.transform.localPosition = new Vector3(1.25f, -257.515f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 4:
                        Destroy(Gosm[0].obj);
                        break;
                }
                break;
            case "flamingo":
                switch (Flam[0].count)
                {
                    case 1:
                        Flam[0].obj.transform.localPosition = new Vector3(-1.640127f, -45.86489f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 2:
                        Flam[0].obj.transform.localPosition = new Vector3(1.4f, -47.7f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 3:
                        Flam[0].obj.transform.localPosition = new Vector3(-1.64f, -50.345f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 4:
                        Flam[0].obj.transform.localPosition = new Vector3(-1.5f, -72.3f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, -27.165f);
                        break;
                    case 5:
                        Flam[0].obj.transform.localPosition = new Vector3(1.66f, -81.975f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 16.128f);
                        break;
                    case 6:
                        Destroy(Flam[0].obj);
                        break;
                }
                break;
            case "card":
                switch (Card[0].count)
                {
                    case 1:
                        Card[6].obj.transform.localPosition = new Vector3(-1.640127f, -45.86489f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 2:
                        Card[2].obj.transform.localPosition = new Vector3(1.4f, -47.7f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 3:
                        Card[4].obj.transform.localPosition = new Vector3(-1.64f, -50.345f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 4:
                        Card[0].obj.transform.localPosition = new Vector3(-1.5f, -72.3f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, -27.165f);
                        break;
                    case 5:
                        Card[7].obj.transform.localPosition = new Vector3(1.66f, -81.975f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, 16.128f);
                        break;
                    case 6:
                        Card[3].obj.transform.localPosition = new Vector3(-1.5f, -90.925f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, -17.654f);
                        break;
                    case 7:
                        Card[5].obj.transform.localPosition = new Vector3(0.72f, -95.425f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 8:
                        Card[1].obj.transform.localPosition = new Vector3(1.75f, -95.425f, cardHeartPrefab.transform.position.z);
                        Card[1].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 9:
                        Card[6].obj.transform.localPosition = new Vector3(0.72f, -97f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 10:
                        Card[2].obj.transform.localPosition = new Vector3(1.75f, -97f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 11:
                        Card[4].obj.transform.localPosition = new Vector3(0.2543f, -177.955f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 12:
                        Card[0].obj.transform.localPosition = new Vector3(1.37f, -177.955f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 13:
                        Card[7].obj.transform.localPosition = new Vector3(0.2543f, -179.5f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 14:
                        Card[3].obj.transform.localPosition = new Vector3(1.37f, -179.5f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 15:
                        Card[5].obj.transform.localPosition = new Vector3(-1.576f, -184f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 16:
                        Card[1].obj.transform.localPosition = new Vector3(-1.61f, -184f, cardHeartPrefab.transform.position.z);
                        Card[1].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 17:
                        Card[6].obj.transform.localPosition = new Vector3(-1.576f, -185.46f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 18:
                        Card[2].obj.transform.localPosition = new Vector3(-1.61f, -185.46f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 19:
                        Card[4].obj.transform.localPosition = new Vector3(-1.84f, -212f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, -20f);
                        break;
                    case 20:
                        Card[0].obj.transform.localPosition = new Vector3(1.5f, -212f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, 20f);
                        break;
                    case 21:
                        Card[7].obj.transform.localPosition = new Vector3(-1.846f, -184f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, -20f);
                        break;
                    case 22:
                        Card[3].obj.transform.localPosition = new Vector3(1.5f, -212f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, 20f);
                        break;
                    case 23:
                        Destroy(Card[0].obj);
                        break;
                }
                break;
        }
        
    }

}

