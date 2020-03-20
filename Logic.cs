using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Logic
{
  public Action OK;
  public int start;
  public int time_length;
  //OKではなかった場合は他人のロジックが実行される
  //  public Action NG;
}

class LogicFighting
{

}

class LogicResult : Dictionary<Logic, bool>
{
}

struct LogicFrame
{
  public ulong Begin;

  public ulong End => Begin + Length;
  public ulong Length;

}

struct W5H1
{
  string What;
  string Where;
  string When;
  string Who;
  string Why;
  string Whom;
  string How;
}

