
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


/*




*/
public abstract class Outputer<T> : Actor
, SignalReceiver<T>
where T : Signal
{
  public abstract void Receive(T src);
}
