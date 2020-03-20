using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



//基本BRAIN　シグナルを受け取る。また、シグナルの受け流し先を複数持つ
public abstract class Brain<T> : Actor
, SignalReceiver<T>
where T : Signal
{
  public List<Sensor<T>> inputs;
  public List<Outputer<T>> outputs;



  public abstract void Receive(T signal);
}


