using System;
using UnityEngine;

//TODO вернуть абстрактность классу
public class ABuildingView : MonoBehaviour
{
    [SerializeField] private Renderer MainRenderer;
    [SerializeField] private Vector2Int Size = Vector2Int.one;
    public Action OnBuildingClick;

    public bool IsPlaceFree { get; private set; } = true;

    public void SetTransparent(bool available)
    {
        if (available)
        {
            foreach (var material in MainRenderer.materials)
            {
                material.color = Color.green;
            }
        }
        else
        {
            foreach (var material in MainRenderer.materials)
            {
                material.color = Color.red;
            }
        }
    }

    public void OnMouseDown()
    {
        OnBuildingClick.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
            IsPlaceFree = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
            IsPlaceFree = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
            IsPlaceFree = false;
    }

    public void SetNormal()
    {
        foreach (var material in MainRenderer.materials)
        {
            material.color = Color.white;
        }
    }

    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}