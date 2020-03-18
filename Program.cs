using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//基本行動
public abstract class Actor{

  public float elapsed=0;
  public void Update(float delta){
    this.elapsed+=delta;
    OnUpdate(delta);
  }
  protected virtual void OnUpdate(float delta){
    //特に何もしない
  }

  public virtual List<Actor> Actors=>new List<Actor>(){this}; 
}

//センサー　思考　出力
public interface SignalReceiver<T>
where T:Signal
{
  public void Receive(T signalSource);
}

//センサークラス
public abstract class Sensor<T>
:Actor
where T:Signal
{
  public Sensor(Brain<T> b){
    this.brain=b;
  }
  //Brainに突っ込む
  SignalReceiver<T> brain;
  //
  public abstract T Sense();
}



//センサー～出力までをつなぐデータ
public abstract class Signal{
}
public class TextSignal:Signal{
  public string Src=>src;
  private string src;

  public static TextSignal From(string text)=>new TextSignal(){src=text};
  
}


//思考クラス
public abstract class Brain<T>:Actor
  ,SignalReceiver<T>
where T:Signal
{
  public abstract void Receive(T src);
}


//
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

//感覚器官一覧
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
  //感覚器官

  public Ear ear;
  public Eye eye;

  //出力
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



struct W5H1{
  string What;
  string Where;
  string When;
  string Who;
  string Why;
  string Whom;
  string How;

}

struct LogicFrame{
  public ulong Begin;

  public ulong End=>Begin+Length;
  public ulong Length;

}

//public delegate ACT

public class Logic{
  public Action OK;
  public int start;
  public int time_length;
  //OKではなかった場合は他人のロジックが実行される
//  public Action NG;
  
}

class LogicFighting{
  
}

class LogicResult:Dictionary<Logic,bool>{
}

public class World : List<Actor>
{
  private float timescale=0.1f;
  private long step=0;
  private long limit=1000;

  public void Start(){
    while(step < limit){
      step++;
      //適宜worldを変化させる    

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

class Program
{
  static void Main(string[] args)
  {
    var world=new World();
    world.Regist(new TextHumanBrain());
    world.Start();

    Console.WriteLine("Hello World!");
  }
}
