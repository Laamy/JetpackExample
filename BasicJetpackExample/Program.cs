#region

using BasicJetpackExample.ClientBase.KeyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace BasicJetpackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MCM.openGame(); // Open game up inside of MCM class
            MCM.openWindowHost();

            new Keymap(); // only define new keymap ONCE. this just starts up the keymap threads so it can catch minecraft key inputs

            Keymap.keyEvent += McKeyPress; // Assign Mc Keymap to function so that functions called when a keys been pressed/held/let go of

            while (true) // infinite loop
            {
            }
        }

        private static void McKeyPress(object sender, KeyEvent e)
        {
            if (e.vkey == VKeyCodes.KeyHeld) // Key is currently being held
            {
                if (e.key == Keys.F) // If FKey is currently being held this code here will trigger rapidly until its been let go
                {
                    var vel = new Vector3(0, 0, 0);
                    var dirVec = Game.lVector;

                    float speed = 0.8f;

                    vel.x = speed * dirVec.x;
                    vel.y = speed * -dirVec.y;
                    vel.z = speed * dirVec.z;

                    Game.velocity = vel;
                }
            }
        }
    }
}
