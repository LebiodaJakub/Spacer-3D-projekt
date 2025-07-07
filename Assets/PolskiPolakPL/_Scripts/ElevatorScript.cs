using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] float Speed = 1;
    [SerializeField] Transform floors;
    BetterTransform bt;
    Transform elevator, target;
    private void Start()
    {
        bt = new BetterTransform(floors);
        elevator = transform.GetChild(0);
        target = floors.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FloorUP();
        }
        elevator.position = Vector3.MoveTowards(elevator.position, target.position, Speed * Time.deltaTime);
    }

    public void FloorUP()
    {
        target = bt.GetNextChild();
    }

    public void FloorDown()
    {
        target = bt.GetPreviousChild();
        Vector3.MoveTowards(elevator.position, target.position, Speed * Time.deltaTime);

    }

}
