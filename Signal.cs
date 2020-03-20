using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public abstract class Signal
{

}

public interface SignalReceiver<T>
where T : Signal
{
  void Receive(T signalSource);
}





