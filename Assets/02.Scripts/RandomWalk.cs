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
        new Vector2Int(0, 1), // ��
        new Vector2Int(0, -1),// ��
        new Vector2Int(1, 0), // ��
        new Vector2Int(-1, 0),// ��
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
        Vector2 moveVec = new Vector2(transform.position.x + randomVec.x, transform.position.y + randomVec.y);

        // Max���� ã�� ���� ī��Ʈ
        NowStep++;

        // ���� �� ���� �÷��ְ�
        lineRenderer.positionCount++;

        // ������ �׸��� ���� �̵��� ��ġ�� �� ����ֱ�
        lineRenderer.SetPosition(lineRenderer.positionCount-1, moveVec);

        // �������� ���� �������� �����̰� / MaxStep�� �������� ���ߴٸ� ���
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
