using System.Collections.Generic;
using WhatAmI.Content.src.entities;

namespace WhatAmI.Content.src.structures
{
    internal class UDHandler
    {

        private List<UD> uds;
        private List<UD> prepCache;
        


        public UDHandler() { 
            uds = new List<UD>();
            prepCache = new List<UD>();
        }

        public List<UD> getUDs() { return uds; }

        
        internal void prepUD(UD u) 
        {
            prepCache.Add(u);
        }



        internal void moveCache()
        {
            foreach(UD u in prepCache){
                uds.Add(u);
            }
            prepCache.Clear();
        }


        internal void removeUD(string name) {
            List<UD> temp = new List<UD> ();
            foreach(UD u in uds)
            {
                if(u.name != name)
                {
                    temp.Add(u);
                }
            }
            uds = temp;
        }


        internal void addUD(UD ud)
        {
            uds.Add(ud);
        }




        internal void Update()
        {
            moveCache();
            foreach(UD u in uds)
            {
                u.Update();
            }
        }



        internal void Draw()
        {
            foreach (UD u in uds)
            {
                Game1.Instance.spriteBatch.Begin();
                u.Draw();
                Game1.Instance.spriteBatch.End();
            }

        }

    }
}
