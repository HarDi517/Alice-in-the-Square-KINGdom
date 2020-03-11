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


    void Awake()
    {
        if (ObjectPool_4.objectPool == null)
            ObjectPool_4.objectPool = this;

        Generate();
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
        Gosm[1].obj.transform.localPosition = new Vector3(-1.000127f, -109.6949f, gosmdochiPrefab.transform.position.z);
        Gosm[2].obj.transform.localPosition = new Vector3(1.279873f, -112.9649f, gosmdochiPrefab.transform.position.z);
        Gosm[3].obj.transform.localPosition = new Vector3(1.869873f, -131.6849f, gosmdochiPrefab.transform.position.z);


        for (int i = 0; i < 3; i++)
        {
            Flam[i].obj = Instantiate(flamingoPrefab, Obstacles.transform);
            Flam[i].name = "flamingo";
            Flam[i].count = 0;
        }
        Flam[0].obj.transform.localPosition = new Vector3(-0.2f, -107.31f, flamingoPrefab.transform.position.z);
        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 101.937f);


        //하트 2개
        Card[0].obj = Instantiate(cardHeartPrefab, Obstacles.transform);
        Card[1].obj = Instantiate(cardHeartPrefab, Obstacles.transform);
        Card[1].obj.transform.localPosition = new Vector3(1.75f, -37f, 0);
        Card[1].obj.transform.rotation = Quaternion.identity;
        //스페이드 2개
        Card[2].obj = Instantiate(cardSpadePrefab, Obstacles.transform);
        Card[3].obj = Instantiate(cardSpadePrefab, Obstacles.transform);
        Card[3].obj.transform.localPosition = new Vector3(-1.54f, -34.27f, 0);
        Card[3].obj.transform.rotation = Quaternion.identity;
        //클로버 2개
        Card[4].obj = Instantiate(cardCloverPrefab, Obstacles.transform);
        Card[5].obj = Instantiate(cardCloverPrefab, Obstacles.transform);
        Card[5].obj.transform.localPosition = new Vector3(-1.45f, -39.61f, 0);
        Card[5].obj.transform.rotation = Quaternion.identity;
        //다이아 2개
        Card[6].obj = Instantiate(cardDiamondPrefab, Obstacles.transform);
        Card[7].obj = Instantiate(cardDiamondPrefab, Obstacles.transform);
        Card[7].obj.transform.localPosition = new Vector3(1.73f, -33.04f, 0);
        Card[7].obj.transform.rotation = Quaternion.identity;

        for (int i = 0; i < 8; i++)
        {
            Card[i].name = "card";
            Card[i].count = 0;
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
                        PlantL.obj.transform.localPosition = new Vector3(-0.78f, -63.05f, plantLPrefab.transform.position.z);
                        break;
                    case 2:
                        PlantL.obj.transform.localPosition = new Vector3(-0.7f, -102.55f, plantRPrefab.transform.position.z);
                        break;
                    case 3:
                        PlantL.obj.transform.localPosition = new Vector3(-0.85f, -174.74f, plantLPrefab.transform.position.z);
                        break;
                    case 4:
                        PlantL.obj.transform.localPosition = new Vector3(-0.86f, -253.15f, plantLPrefab.transform.position.z);
                        break;
                    case 5:
                        PlantL.obj.transform.localPosition = new Vector3(-1.09f, -266.99f, plantLPrefab.transform.position.z);
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
                        PlantR1.obj.transform.localPosition = new Vector3(1.2f, -93.71f, plantRPrefab.transform.position.z);
                        break;
                    case 2:
                        PlantR2.obj.transform.localPosition = new Vector3(1.23f, -113.72f, plantRPrefab.transform.position.z);
                        break;
                    case 3:
                        PlantR1.obj.transform.localPosition = new Vector3(1.23f, -208.79f, plantRPrefab.transform.position.z);
                        break;
                    case 4:
                        PlantR2.obj.transform.localPosition = new Vector3(1.23f, -232f, plantRPrefab.transform.position.z);
                        break;
                    case 5:
                        PlantR1.obj.transform.localPosition = new Vector3(1.01f, -296.8f, plantRPrefab.transform.position.z);
                        break;
                    case 6:
                        PlantR2.obj.SetActive(false);
                        break;
                    case 7:
                        PlantR1.obj.SetActive(false);
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
                        QueenL.obj.SetActive(false);
                        break;
                }
                break;
            case "queenR":
                switch (QueenR.count)
                {
                    case 1:
                        QueenR.obj.transform.localPosition = new Vector3(queenRPrefab.transform.position.x, -90.1f, queenRPrefab.transform.position.z);
                        break;
                    case 2:
                        QueenR.obj.transform.localPosition = new Vector3(queenRPrefab.transform.position.x, -263.1f, queenRPrefab.transform.position.z);
                        break;
                    case 3:
                        QueenR.obj.transform.localPosition = new Vector3(queenRPrefab.transform.position.x, -280.7049f, queenRPrefab.transform.position.z);
                        QueenR.obj.transform.rotation = Quaternion.Euler(0, 0, 5.414f);
                        break;
                    case 4:
                        QueenR.obj.SetActive(false);
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
                        LionL.obj.SetActive(false);
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
                        LionR.obj.transform.localPosition = new Vector3(1.45f, -189.445f, lionRPrefab.transform.position.z);
                        break;
                    case 3:
                        LionR.obj.transform.localPosition = new Vector3(1.25f, -257.515f, lionRPrefab.transform.position.z);
                        break;
                    case 4:
                        LionR.obj.SetActive(false);
                        break;
                }
                break;
            case "gosmdochi":
                switch (Gosm[0].count)
                {
                    case 1:
                        Gosm[0].obj.transform.localPosition = new Vector3(1.159873f, -130.8949f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 2:
                        Gosm[1].obj.transform.localPosition = new Vector3(0.5998734f, -131.6449f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 3:
                        Gosm[2].obj.transform.localPosition = new Vector3(1.239873f, -132.3549f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 4:
                        Gosm[3].obj.transform.localPosition = new Vector3(1.869873f, -131.6849f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 5:
                        Gosm[0].obj.transform.localPosition = new Vector3(0.5198734f, -208.0649f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 6:
                        Gosm[1].obj.transform.localPosition = new Vector3(-0.7101265f, -227.4049f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 7:
                        Gosm[2].obj.transform.localPosition = new Vector3(1.349873f, -239.4149f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 8:
                        Gosm[3].obj.transform.localPosition = new Vector3(-1.920127f, -272.1549f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 9:
                        Gosm[0].obj.transform.localPosition = new Vector3(-0.7701265f, -272.2249f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 10:
                        Gosm[1].obj.transform.localPosition = new Vector3(-1.400127f, -272.9749f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 11:
                        Gosm[2].obj.transform.localPosition = new Vector3(-0.08f, -298.44f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 12:
                        Gosm[3].obj.transform.localPosition = new Vector3(1.249873f, -300.8749f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 13:
                        Gosm[0].obj.transform.localPosition = new Vector3(1.249873f, -303.8249f, gosmdochiPrefab.transform.position.z);
                        break;
                    case 14:
                        for(int i = 0; i < 4; i++)
                            Gosm[i].obj.SetActive(false);
                        break;
                }
                break;
            case "flamingo":
                switch (Flam[0].count)
                {
                    case 1:
                        Flam[0].obj.transform.localPosition = new Vector3(-1.330127f, -132.7449f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 104.022f);
                        break;
                    case 2:
                        Flam[1].obj.transform.localPosition = new Vector3(-1.420127f, -133.9349f, flamingoPrefab.transform.position.z);
                        Flam[1].obj.transform.rotation = Quaternion.Euler(0, 0, 104.022f);
                        break;
                    case 3:
                        Flam[2].obj.transform.localPosition = new Vector3(-1.550127f, -134.9949f, flamingoPrefab.transform.position.z);
                        Flam[2].obj.transform.rotation = Quaternion.Euler(0, 0, 104.022f);
                        break;
                    case 4:
                        Flam[0].obj.transform.localPosition = new Vector3(0.7898735f, -221.4749f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 31.582f);
                        break;
                    case 5:
                        Flam[1].obj.transform.localPosition = new Vector3(-0.9901266f, -242.0649f, flamingoPrefab.transform.position.z);
                        Flam[1].obj.transform.rotation = Quaternion.Euler(0, 0, 145.917f);
                        break;
                    case 6:
                        Flam[2].obj.transform.localPosition = new Vector3(-2.510127f, -260.2949f, flamingoPrefab.transform.position.z);
                        Flam[2].obj.transform.rotation = Quaternion.Euler(0, 0, -34.064f);
                        break;
                    case 7:
                        Flam[0].obj.transform.localPosition = new Vector3(2.199873f, -260.2849f, flamingoPrefab.transform.position.z);
                        Flam[0].obj.transform.rotation = Quaternion.Euler(0, 0, 31.582f);
                        break;
                    case 8:
                        Flam[1].obj.transform.localPosition = new Vector3(0.3598735f, -281.1449f, flamingoPrefab.transform.position.z);
                        Flam[1].obj.transform.rotation = Quaternion.Euler(0, 0, 71.677f);
                        break;
                    case 9:
                        for (int i = 0; i < 3; i++)
                            Flam[i].obj.SetActive(false);
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
                        Card[4].obj.transform.localPosition = new Vector3(1.4f, -47.7f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 3:
                        Card[2].obj.transform.localPosition = new Vector3(-1.64f, -50.345f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
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
                        Card[5].obj.transform.localPosition = new Vector3(-1.5f, -90.925f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, -17.654f);
                        break;
                    case 7:
                        Card[3].obj.transform.localPosition = new Vector3(0.72f, -95.425f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
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
                        Card[4].obj.transform.localPosition = new Vector3(1.75f, -97f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 11:
                        Card[2].obj.transform.localPosition = new Vector3(-0.91f, -119.88f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, -19.224f);
                        break;
                    case 12:
                        Card[0].obj.transform.localPosition = new Vector3(-0.5f, -120.09f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, -40.86f);
                        break;
                    case 13:
                        Card[7].obj.transform.localPosition = new Vector3(-0.38f, -120.35f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, -63.911f);
                        break;
                    case 14:
                        Card[5].obj.transform.localPosition = new Vector3(0.4543f, -179.955f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 15:
                        Card[3].obj.transform.localPosition = new Vector3(1.57f, -179.955f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 16:
                        Card[1].obj.transform.localPosition = new Vector3(0.4543f, -181.5f, cardHeartPrefab.transform.position.z);
                        Card[1].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 17:
                        Card[6].obj.transform.localPosition = new Vector3(1.57f, -181.5f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 18:
                        Card[4].obj.transform.localPosition = new Vector3(-1.376f, -184f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 19:
                        Card[2].obj.transform.localPosition = new Vector3(-1.61f, -184f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 20:
                        Card[0].obj.transform.localPosition = new Vector3(-1.376f, -185.46f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 21:
                        Card[7].obj.transform.localPosition = new Vector3(-1.61f, -185.46f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 22:
                        Card[5].obj.transform.localPosition = new Vector3(-1.84f, -212.4f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, -19.224f);
                        break;
                    case 23:
                        Card[3].obj.transform.localPosition = new Vector3(-1.91f, -213.75f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, -19.985f);
                        break;
                    case 24:
                        Card[1].obj.transform.localPosition = new Vector3(1.38f, -212f, cardHeartPrefab.transform.position.z);
                        Card[1].obj.transform.rotation = Quaternion.Euler(0, 0, 15.507f);
                        break;
                    case 25:
                        Card[6].obj.transform.localPosition = new Vector3(1.53f, -213.53f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, 13.116f);
                        break;
                    case 26:
                        Card[4].obj.transform.localPosition = new Vector3(-0.91f, -216.88f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, -19.224f);
                        break;
                    case 27:
                        Card[2].obj.transform.localPosition = new Vector3(-0.5f, -217.09f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, -40.86f);
                        break;
                    case 28:
                        Card[0].obj.transform.localPosition = new Vector3(-0.38f, -217.35f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, -63.911f);
                        break;
                    case 29:
                        Card[7].obj.transform.localPosition = new Vector3(1.32f, -222.28f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, -19.985f);
                        break;
                    case 30:
                        Card[5].obj.transform.localPosition = new Vector3(1.17f, -231.34f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, 15.507f);
                        break;
                    case 31:
                        Card[3].obj.transform.localPosition = new Vector3(-1.75f, -245.34f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, -25.32f);
                        break;
                    case 32:
                        Card[1].obj.transform.localPosition = new Vector3(-1.75f, -246.98f, cardHeartPrefab.transform.position.z);
                        Card[1].obj.transform.rotation = Quaternion.Euler(0, 0, -19.985f);
                        break;
                    case 33:
                        Card[6].obj.transform.localPosition = new Vector3(-1.33f, -266.3f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, -22.06f);
                        break;
                    case 34:
                        Card[4].obj.transform.localPosition = new Vector3(0.17f, -283.73f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 35:
                        Card[2].obj.transform.localPosition = new Vector3(1.32f, -283.68f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 36:
                        Card[0].obj.transform.localPosition = new Vector3(-1.01f, -287.4f, cardHeartPrefab.transform.position.z);
                        Card[0].obj.transform.rotation = Quaternion.Euler(0, 0, -19.224f);
                        break;
                    case 37:
                        Card[7].obj.transform.localPosition = new Vector3(-0.8f, -287.6f, cardHeartPrefab.transform.position.z);
                        Card[7].obj.transform.rotation = Quaternion.Euler(0, 0, -40.86f);
                        break;
                    case 38:
                        Card[5].obj.transform.localPosition = new Vector3(-0.68f, -287.8f, cardHeartPrefab.transform.position.z);
                        Card[5].obj.transform.rotation = Quaternion.Euler(0, 0, -63.911f);
                        break;
                    case 39:
                        Card[3].obj.transform.localPosition = new Vector3(0.96f, -291.68f, cardHeartPrefab.transform.position.z);
                        Card[3].obj.transform.rotation = Quaternion.Euler(0, 0, 31.579f);
                        break;
                    case 40:
                        Card[1].obj.transform.localPosition = new Vector3(0.52f, -292.03f, cardHeartPrefab.transform.position.z);
                        Card[1].obj.transform.rotation = Quaternion.Euler(0, 0, 58.063f);
                        break;
                    case 41:
                        Card[6].obj.transform.localPosition = new Vector3(0.12f, -292.75f, cardHeartPrefab.transform.position.z);
                        Card[6].obj.transform.rotation = Quaternion.Euler(0, 0, 83.15f);
                        break;
                    case 42:
                        Card[4].obj.transform.localPosition = new Vector3(0.38f, -296.39f, cardHeartPrefab.transform.position.z);
                        Card[4].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 43:
                        Card[2].obj.transform.localPosition = new Vector3(1.34f, -296.34f, cardHeartPrefab.transform.position.z);
                        Card[2].obj.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                }
                break;
        }
        
    }

}

