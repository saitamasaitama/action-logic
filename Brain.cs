using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface SignalReceiver<T>
where T:Signal
{
  public void Receive(T signalSource);
}

public abstract class Actor{

  public float elapsed=0;
  public void Update(float delta){
    this.elapsed+=delta;
    OnUpdate(delta);
  }
  protected virtual void OnUpdate(float delta){
  }
  public virtual List<Actor> Actors=>new List<Actor>(){this};
}


public abstract class Sensor<T>
:Actor
where T:Signal
{
  public Sensor(Brain<T> b){
    this.brain=b;
  }  SignalReceiver<T> brain;
  public abstract T Sense();
}

public abstract class Signal{

}
public class TextSignal:Signal{
  public string Src=>src;
  private string src;

  public static TextSignal From(string text)=>new TextSignal(){src=text};
}

public abstract class Brain<T>:Actor
,SignalReceiver<T>
where T:Signal
{
  public abstract void Receive(T src);
}


public abstract class Outputer<T>:Actor
,SignalReceiver<T>
where T :Signal
{
  public abstract void Receive(T src);
}

public class Muscle:Outputer<TextSignal>{
  public override void Receive(TextSignal src){
    Console.WriteLine(src);
  }
}

public class Ear:Sensor<TextSignal>{
  public Ear(Brain<TextSignal> b):base(b){}
  public override TextSignal Sense()=>TextSignal.From("SenseEar");
}
public class Eye:Sensor<TextSignal>{
  public Eye(Brain<TextSignal> b):base(b){}
  public override TextSignal Sense()=>TextSignal.From("SenseEye");
}
public class Nose:Sensor<TextSignal>{
  public Nose(Brain<TextSignal> b):base(b){}
  public override TextSignal Sense()=>TextSignal.From("SenseNose");
}
public class Oral:Sensor<TextSignal>{
  public Oral(Brain<TextSignal> b):base(b){}
  public override TextSignal Sense()=>TextSignal.From("SenseOral");
}
public class Skin:Sensor<TextSignal>{
  public Skin(Brain<TextSignal> b):base(b){}
  public override TextSignal Sense()=>TextSignal.From("SenseSkin");
}


public class TextHumanBrain:Brain<TextSignal>{

  public Ear ear;
  public Eye eye;

  public Muscle muscle;
  public TextHumanBrain(){
    ear=new Ear(this);
    eye=new Eye(this);
    muscle=new Muscle();
  }

  public override void Receive(TextSignal src){
    Console.WriteLine(src);
  }

  public void OnUpdate(float delta){
    ear.Update(delta);
    eye.Update(delta);
    muscle.Update(delta);
  }
}

struct LogicFrame{
  public ulong Begin;

  public ulong End=>Begin+Length;
  public ulong Length;

}

struct W5H1{
  string What;
  string Where;
  string When;
  string Who;
  string Why;
  string Whom;
  string How;
}

public class World : List<Actor>
{
  private float timescale=0.1f;
  private long step=0;
  private long limit=1000;

  public void Start(){
    while(step < limit){
      step++;
      this.ForEach(o=>o.Update(timescale));
      Step(step);
    }
  }


  public void Step(long current){
    Console.WriteLine($"STEP {current} END");
  }
  public void End(){
    Console.WriteLine($"THE END");
  }
  public void Regist(Actor a){
    a.Actors.ForEach(act=>this.Add(act));
  }
}
