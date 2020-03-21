using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TextSignal : Signal
{
  public string Src => src;
  private string src;

  public static TextSignal From(string text) => new TextSignal() { src = text };
}

public class TextEar : Sensor<TextSignal>
{
  public TextEar(Brain<TextSignal> b) : base(b) { }
  public override TextSignal Sense() => TextSignal.From("SenseEar");
}
public class TextEye : Sensor<TextSignal>
{
  public TextEye(Brain<TextSignal> b) : base(b) { }
  public override TextSignal Sense() => TextSignal.From("SenseEye");
}
public class Nose : Sensor<TextSignal>
{
  public Nose(Brain<TextSignal> b) : base(b) { }
  public override TextSignal Sense() => TextSignal.From("SenseNose");
}
public class Oral : Sensor<TextSignal>
{
  public Oral(Brain<TextSignal> b) : base(b) { }
  public override TextSignal Sense() => TextSignal.From("SenseOral");
}
public class Skin : Sensor<TextSignal>
{
  public Skin(Brain<TextSignal> b) : base(b) { }
  public override TextSignal Sense() => TextSignal.From("SenseSkin");
}


public class TextHumanBrain : Brain<TextSignal>
{

  public TextEar ear;
  public TextEye eye;

  public TextMuscle muscle;
  public TextHumanBrain()
  {
    ear = new TextEar(this);
    eye = new TextEye(this);
    muscle = new TextMuscle();
  }

  public override void Receive(TextSignal signal)
  {
    Console.WriteLine(signal);
  }

  public void OnUpdate(float delta)
  {
    ear.Update(delta);
    eye.Update(delta);
    muscle.Update(delta);
  }
}




public class TextMuscle : Outputer<TextSignal>
{
  public override void Receive(TextSignal src)
  {
    Console.WriteLine(src);
  }
}

public class TextSignalHumanBrain : Brain<TextSignal>
{

  public TextSignalHumanBrain()
  {
  }
  public override void Receive(TextSignal signal)
  {
    Console.WriteLine($"RECEIVE:{signal}");
  }

}
