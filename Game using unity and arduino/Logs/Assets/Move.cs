using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Move : MonoBehaviour
{
    // change your serial port
    public SerialPort sp = new SerialPort("COM7", 9600);
    public UI_score UI;
    public Base_move Base;
   
    
    public bool triggered = false;
    
    // Start is called before the first frame update
    void Start()
    {   
        sp.Open();
        sp.ReadTimeout = 100; 
    }  
                
    // Update is called once per frame
    void Update()
    {
               
            
                if (sp.IsOpen)
                {
                    try
                    {
                            // When left button is pushed
                            if(sp.ReadByte() == 1 && triggered == true)
                            {
                                print(sp.ReadByte());
                                UI.add();
                            }
                    }
                    catch (System.Exception){}
                }        
    }

    private void OnTriggerEnter(Collider cube)
    {
        
            triggered = true;
            Debug.Log("Touch enter");
            
 
    }
    

}
