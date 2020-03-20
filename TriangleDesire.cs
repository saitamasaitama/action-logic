using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public enum TypeDesire
{
  GLUTTONY,
  LUST,
  SLOTH,
  PRIDE,
  GREED,
  ENVI,
  WRATH
}



/**
 *
 * 高慢 pride
 * 物欲 greed
 * 嫉妬 envy
 * 怒り wrath
 * 色欲 lust
 * 貪食 gluttony
 * 怠惰 sloth
 *
 */
class Mind : Dictionary<TypeDesire, Desire>
{

  public Mind()
  {
    //三すくみ
    var glut = new Desire(TypeDesire.GLUTTONY);
    var lust = new Desire(TypeDesire.LUST);
    var sloth = new Desire(TypeDesire.SLOTH);

    glut.Add(lust, 0.9f);
    lust.Add(sloth, 0.9f);
    sloth.Add(glut, 0.9f);

    //四すくみ（結果が二つある）
    //強勝ち = 影響度大  弱勝=影響度小
    var pride = new Desire(TypeDesire.PRIDE);
    var greed = new Desire(TypeDesire.GREED);
    var envi = new Desire(TypeDesire.ENVI);
    var wrath = new Desire(TypeDesire.WRATH);

    pride.Add(greed, 0.6f);
    pride.Add(envi, 0.3f);

    greed.Add(envi, 0.6f);
    greed.Add(wrath, 0.3f);

    envi.Add(wrath, 0.6f);
    envi.Add(pride, 0.3f);

    wrath.Add(pride, 0.6f);
    wrath.Add(greed, 0.3f);


    this.Add(TypeDesire.ENVI, envi);
    this.Add(TypeDesire.GLUTTONY, glut);
    this.Add(TypeDesire.GREED, greed);
    this.Add(TypeDesire.LUST, lust);
    this.Add(TypeDesire.PRIDE, pride);
    this.Add(TypeDesire.SLOTH, sloth);
    this.Add(TypeDesire.WRATH, wrath);

  }

  public Desire Gluttony => this[TypeDesire.GLUTTONY];
  public Desire Lust => this[TypeDesire.LUST];
  public Desire Sloth => this[TypeDesire.SLOTH];
  public Desire Envi => this[TypeDesire.ENVI];
  public Desire Wrath => this[TypeDesire.WRATH];
  public Desire Greed => this[TypeDesire.GREED];
  public Desire Pride => this[TypeDesire.PRIDE];

  public override string ToString()
  {

    return this.Aggregate("",
        (string src, KeyValuePair<TypeDesire, Desire> kv) =>
        {
          src += $"{kv.Value} \n";
          return src;
        });
  }
}

class Desire : Dictionary<Desire, float>
{
  private TypeDesire type;
  //private string name = "";
  public string Name => type.ToString();
  private float value = 50.0f;
  private float max = 100.0f;

  public Desire(TypeDesire type)
  {
    this.type = type;

  }

  //関連する他の欲
  public void Apply(float v)
  {
    this.value += v;
    foreach (KeyValuePair<Desire, float> kv in this)
    {
      Desire d = kv.Key;
      d.value -= v * kv.Value;
    }
  }

  //欲の許容度が上がる
  public void ScaleUp()
  {
    this.max *= 1.01f;
  }

  public override string ToString() => $@"[{this.Name}] {this.value:0.00} / {this.max:0.00}  ({ value * 100.0f / max:00}%)  ";

}

