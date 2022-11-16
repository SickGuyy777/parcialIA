using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private IuFuncionsStates Currentfsm;
    private Dictionary<States, IuFuncionsStates> AllStates = new Dictionary<States, IuFuncionsStates>();//creamos un diccionario en el que los States son el la llave
    public void ArtificialUpdate()
    {
        Currentfsm.OnUpdate();
    }
    public void ChangeState(States Key)
    {
        if (Currentfsm != null)
        {
            Currentfsm.OnExit();
        }
        Currentfsm = AllStates[Key];//aca decimos que la interfaz es igual a la key (en este caso la llave) del diccionario
    }
    public void AddStatesInDiccionary(States Key, IuFuncionsStates Value)
    {
        if (!AllStates.ContainsKey(Key))//si el diccionario no contiene la llave que la agregue
        {
            AllStates.Add(Key, Value);
        }
        else
        {
            AllStates[Key] = Value;//si contiene la llave los estados del diccionario (la enumeracion de su estado (del 0 al 1)) es igual al valor en este caso los metodos de la interfaz
        }
    }
}
