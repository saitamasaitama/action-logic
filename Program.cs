using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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


class Program
{
  static void Main(string[] args)
  {
    var world=new World();
    world.Regist(new TextHumanBrain());
    //world.Start();

    var human=new Mind();

    human.Envi.Apply(30.5f);

    Console.WriteLine(human);

    Console.Write("Done!");
  }
}
