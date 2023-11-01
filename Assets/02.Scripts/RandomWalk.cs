using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public int MaxStep = 100;
    public int NowStep = 0;
    public float oneStepMoveSpeed = 0.5f;

    private LineRenderer lineRenderer;

    private List<Vector2Int> dirList = new List<Vector2Int>()
    {
        new Vector2Int(0, 1), // 상
        new Vector2Int(0, -1),// 하
        new Vector2Int(1, 0), // 우
        new Vector2Int(-1, 0),// 좌
    };

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        OneStep();
    }

    private void OneStep()
    {
        // 무작위 백터 구하기
        Vector2 randomVec = dirList[Random.Range(0, dirList.Count)];
        // 움직일 방향 구하기
        Vector2 moveVec = new Vector2(transform.position.x + randomVec.x, transform.position.y + randomVec.y);

        // Max제한 찾기 위한 카운트
        NowStep++;

        // 라인 점 갯수 늘려주고
        lineRenderer.positionCount++;

        // 라인을 그리기 위해 이동할 위치에 점 찍어주기
        lineRenderer.SetPosition(lineRenderer.positionCount-1, moveVec);

        // 무작위로 나온 방향으로 움직이고 / MaxStep에 도달하지 못했다면 재귀
        transform.DOMove(moveVec, oneStepMoveSpeed).OnComplete(() => { if (MaxStep > NowStep) OneStep(); });
    }

    public void Reset()
    {
        NowStep = 0;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, Vector3.zero);
        transform.position = Vector3.zero;
        OneStep();
    }
}
