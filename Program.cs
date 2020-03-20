using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;




class Program
{
  static void Main(string[] args)
  {
    var world = new World();


    world.Regist(new TextSignalHuman());
    //world.Start();
    var human = new Mind();

    human.Envi.Apply(30.5f);

    Console.WriteLine(human);
    Console.Write("Done!");
  }
}
