using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



//生物たちが活躍する世界
public class World : List<Actor>
{
  private float timescale = 0.1f;
  private long step = 0;
  private long limit = 1000;

  public void Start()
  {
    while (step < limit)
    {
      step++;
      this.ForEach(o => o.Update(timescale));
      Step(step);
    }
  }


  public void Step(long current)
  {
    Console.WriteLine($"STEP {current} END");
  }
  public void End()
  {
    Console.WriteLine($"THE END");
  }
  public void Regist(Actor a)
  {
    a.Actors.ForEach(act => this.Add(act));
  }
}


public class SignaledWorld<T>
: List<Actor>
where T : Signal
{
  private float timescale = 0.1f;
  private long step = 0;
  private long limit = 1000;

  public void Start()
  {
    while (step < limit)
    {
      step++;
      this.ForEach(o => o.Update(timescale));
      Step(step);
    }
  }


  public void Step(long current)
  {
    Console.WriteLine($"STEP {current} END");
  }
  public void End()
  {
    Console.WriteLine($"THE END");
  }
  public void Regist(Actor a)
  {
    a.Actors.ForEach(act => this.Add(act));
  }
}
