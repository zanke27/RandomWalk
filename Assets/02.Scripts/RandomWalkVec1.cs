using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkVec1 : MonoBehaviour
{
    private int MaxStep = 1000;
    public int NowStep = 0;
    public float oneStepMoveSpeed = 0.5f;

    private LineRenderer lineRenderer;

    private List<Vector2Int> dirList = new List<Vector2Int>()
    {
        new Vector2Int(0, 1), // ��
        new Vector2Int(0, -1),// ��
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
        // ������ ���� ���ϱ�
        Vector2 randomVec = dirList[Random.Range(0, dirList.Count)];
        // ������ ���� ���ϱ�
        Vector2 moveVec = new Vector2(transform.position.x + 0.5f, transform.position.y + randomVec.y);

        // Max���� ã�� ���� ī��Ʈ
        NowStep++;

        // ���� �� ���� �÷��ְ�
        lineRenderer.positionCount++;

        // ������ �׸��� ���� �̵��� ��ġ�� �� ����ֱ�
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, moveVec);

        transform.position = moveVec;

        if (MaxStep > NowStep)
            OneStep();

        // �������� ���� �������� �����̰� / MaxStep�� �������� ���ߴٸ� ���
        //transform.DOMove(moveVec, oneStepMoveSpeed).OnComplete(() => { if (MaxStep > NowStep) OneStep(); });
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