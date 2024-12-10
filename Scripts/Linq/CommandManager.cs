using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();
    
    public Vector3 moveDelta = Vector3.zero;
    public Vector3 rotateDelta = Vector3.zero;

    public float speed = 10.0f;
    public float rotSpeed = 5.0f;
    
    private bool preMoved = false;
    
    public void Execute(ICommand command)
    {
        // 커맨드 객체의 excute를 실행한다.
        command.Execute();
        
        undoStack.Push(command);
        redoStack.Clear();
        
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            // 가장 최근에 실행된 커맨드를 가져와서 
            ICommand command = undoStack.Pop();
            // undo 
            command.Undo();
            // redo stack에 넣는다.
            redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            ICommand command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
        }
    }

    void Update()
    {
        Vector3 movePos = Vector3.zero;
        Vector3 deltaRot = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            movePos += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movePos -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movePos += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movePos -= transform.right;
        }
        if (Input.GetKey(KeyCode.E))
        {
          deltaRot += transform.right *(Time.deltaTime * rotSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            deltaRot -= transform.right * (Time.deltaTime * rotSpeed);
        }
        
        if ( movePos == Vector3.zero && movePos.normalized != Vector3.zero )
        {
            
            ICommand MoveCommand = new MoveCommand(transform, transform.position);
            Execute(MoveCommand);
            moveDelta = Vector3.zero;
            return;
        }

        if (deltaRot == Vector3.zero &&  rotateDelta !=Vector3.zero)
        {
            
            ICommand RotateCommand = new RotateCommand(transform, transform.rotation * Quaternion.LookRotation(transform.forward - rotateDelta, Vector3.up));
            Execute(RotateCommand);
            rotateDelta = Vector3.zero;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Undo();
            return;
        }

        Vector3 addtivePosition = movePos.normalized * (speed * Time.deltaTime);

        transform.position += addtivePosition;
        
        transform.rotation = Quaternion.LookRotation(transform.forward + deltaRot, Vector3.up);
        
        moveDelta +=addtivePosition;
        rotateDelta += deltaRot;
        
    }
}

public class MoveCommand : ICommand
{
    private Transform _transfrom;
    private Vector3 _oldPosition;
    private Vector3 _newPosition;

    public MoveCommand(Transform transform, Vector3 rollbackPosition)
    {
        _transfrom = transform;
        _oldPosition = rollbackPosition;
        _newPosition = transform.position;
    }

    public void Execute()
    {
        _transfrom.position = _newPosition;
    }
    public void Undo()
    {
        _transfrom.position = _oldPosition;
    }
}

public class RotateCommand : ICommand
{
    private Transform _transfrom;
    private Quaternion _oldRotation;
    private Quaternion _newRotation;

    public RotateCommand(Transform transform, Quaternion rollbackrotation)
    {
        _transfrom = transform;
        _oldRotation = rollbackrotation;
        _newRotation = transform.rotation;
    }
    public void Execute()
    {
        _transfrom.rotation = _newRotation;
    }
    public void Undo()
    {
        _transfrom.rotation = _oldRotation;
    }
}