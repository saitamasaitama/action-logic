
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


/*

特に何にも依存しないACtor
→Unityと紐づけることを考えるべき
*/
public abstract class Actor
{

  public float elapsed = 0;
  public void Update(float delta)
  {
    this.elapsed += delta;
    OnUpdate(delta);
  }
  protected virtual void OnUpdate(float delta)
  {
  }

  public virtual List<Actor> Actors => new List<Actor>() { this };
}


