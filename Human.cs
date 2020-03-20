using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/**
HUman or Life
*/
public abstract class Human<T> : Actor
where T : Signal
{
  public List<Sensor<T>> inputs = new List<Sensor<T>>();
  public List<Outputer<T>> outputs = new List<Outputer<T>>();
  public Brain<T> brain;
}

//サンプルHuman

public class TextSignalHuman : Human<TextSignal>
{
  public TextSignalHuman()
  {
    brain = new TextSignalHumanBrain();
    inputs.AddRange(new List<Sensor<TextSignal>>()
    {
      new TextEar(brain),
      new TextEye(brain)
    });
    outputs.AddRange(new List<Outputer<TextSignal>>(){
      new TextMuscle()
    });
  }
}