using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class blhuman
    {
      
        dlhuman d1 = new dlhuman();
        dlhuman o = new dlhuman();
        public bool login(string pass, string use)
        {
            return o.login(pass, use);
        }
        public void changepassword(string pass, string use, string newpass)
        {
            o.changepassword(pass, use, newpass);
        }
        public void register(personel p)
        {
            dlhuman dlh = new dlhuman();
            dlh.register(p);

        }
        public List<personel> Read()
        {
            dlhuman dlh2 = new dlhuman();
            return (new db()).personels.ToList();
        }
        public List<personel> Read(string text)
        {
            return (from i in (new db()).personels where i.name.Contains(text) || i.price.Contains(text) select i).ToList();
        }
        public personel Read(int id)
        {
            return (from i in (new db()).personels where i.id == id select i).Single();
        }
        public string Delete(int id)
        {
            return d1.Delete(id);
        }

        public string Update(int id,personel hnew)
        {
            dlhuman d1 =new dlhuman();
            return d1.Update(id,hnew);
        }
    }
}
