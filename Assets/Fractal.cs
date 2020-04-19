using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Fractal : MonoBehaviour
{
    public Fractal prefab;
    public List<Fractal> children;

    public Transform[] mounts;
    
    public int Size => 1 + children.Sum(it => it.Size);
    public bool IsLeaf => !children.Any();

    public void Start(){
        name = "x"+Random.Range(1000,9999);
    }

    // Start is called before the first frame update
    public bool Add()
    {

        if(children.Any() && Random.value > 0.5f){
            var coolKid = children.Choice();
            if(coolKid.Add()){
                return true;        
            }
        }

        var parents = mounts.Where(it => it.childCount == 0).ToArray();

        if(!parents.Any())
            return false;
        
        var parent = parents.Choice();
        
        var uwu = Instantiate(prefab, parent.position, parent.rotation, parent);
        uwu.prefab = prefab;
        children.Add(uwu);
        
        return true;
    }

    public bool KillChild()
    {
        if(!IsLeaf){
            var kid = children.Choice();
            
            if(kid.IsLeaf)
            {
                children.Remove(kid);
                Destroy(kid.gameObject);
                return true;           
            }
            else{
                return kid.KillChild();
            }
        }
        else{
            return false;
        }
    }
}
