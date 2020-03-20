using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public abstract class Sensor<T>
: Actor
where T : Signal
{
  public Sensor(Brain<T> b)
  {
    this.brain = b;
  }
  SignalReceiver<T> brain;
  public abstract T Sense();
}

