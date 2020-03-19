using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


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
class Mind:Dictionary<string,Desire>{

  public Mind(){
    //三すくみ
    var glut=new Desire("Gluttony");
    var lust=new Desire("Lust");
    var sloth=new Desire("Sloth");

    glut.Add(lust,0.9f);
    lust.Add(sloth,0.9f);
    sloth.Add(glut,0.9f);

    //四すくみ（結果が二つある）
    //強勝ち = 影響度大  弱勝=影響度小
    var pride=new Desire("Pride");
    var greed=new Desire("Greed");
    var envi=new Desire("Envi");
    var wrath=new Desire("Wrath");

    pride.Add(greed,0.6f);
    pride.Add(envi,0.3f);

    greed.Add(envi,0.6f);
    greed.Add(wrath,0.3f);

    envi.Add(wrath,0.6f);
    envi.Add(pride,0.3f);

    wrath.Add(pride,0.6f);
    wrath.Add(greed,0.3f);

    foreach(Desire d in new List<Desire>(){
        glut,lust,sloth,pride,greed,envi,wrath
        } ){
      this.Add(d.Name, d);
    }
  }

  public Desire Gluttony=>this["Gluttony"];
  public Desire Lust=>this["Lust"];
  public Desire Sloth=>this["Sloth"];
  public Desire Envi=>this["Envi"];
  public Desire Wrath=>this["Wrath"];
  public Desire Greed=>this["Greed"];
  public Desire Pride=>this["Pride"];

  public override string ToString(){
    return this.Aggregate("",
        (string src,KeyValuePair<string,Desire> kv)=>{
        src+=$"{kv.Value} \n";
        return src;
        });
  }
}

class Desire:Dictionary<Desire,float>{
  private string name="";
  public string Name=>name;
  private float value=50.0f;
  private float max=100.0f;

  public Desire(string name){
    this.name=name;
  }

  //関連する他の欲
  public void Apply(float v){
    this.value+=v;
    foreach(KeyValuePair<Desire,float> kv in this){
      Desire d=kv.Key;
      d.value -= v * kv.Value;
    }
  }

  //欲の許容度が上がる
  public void ScaleUp(){
    this.max*=1.01f;
  }

  public override string ToString()=>$@"[{this.name}] {this.value:0.00} / {this.max:0.00}  ({ value * 100.0f / max :00}%)  ";

}

