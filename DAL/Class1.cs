using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.Entity;


namespace DAL
{
    public class db : DbContext
    {



        public db() : base("Entiti") { }
        public DbSet<login> logins { get; set; }
        public DbSet<personel> personels { set; get; }
    }
    public class dlhuman
    {
        public void exist()
        {
            db d = new db();
            if (d.logins.Count() == 0)
            {
                d.logins.Add(new login { username = "123", password = "123" });
                d.SaveChanges();
            }
        }
        public bool login(string pass, string use)
        {
            db d = new db();
            exist();
            return d.logins.Any(i => i.username == use && i.password == pass);

        }


        public void changepassword(string pass, string use, string newpass)
        {
            db db1 = new db();

            login l = db1.logins.Where(i => i.username == use && i.password == pass).Single();

            if (login(pass, use) == true)
            {
                l.password = newpass;
                db1.SaveChanges();
            }

        }
        db d5 = new db();
        public void register(personel p)
        {
            {
                db d5 = new db();
                d5.personels.Add(new personel { name = p.name, price = p.price, dastebandi = p.dastebandi, tedad = p.tedad });
                d5.SaveChanges();
            }
        }
        public List<personel> Read()
        {
            return (new db()).personels.ToList();
        }
        public List<personel> Read(string text)
        {
            return (from i in (new db()).personels where i.name.Contains(text) || i.price.Contains(text) select i).ToList();
        }
        public personel Read(int id)
        {
            return d5.personels.Where(i => i.id == id).Single();
        }
        public string Delete(int id)
        {
            using (var d5 = new db())
            {
                var h = d5.personels.SingleOrDefault(i => i.id == id);
                if (h != null)
                {
                    d5.personels.Remove(h);
                    d5.SaveChanges();
                    return "حذف اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "شناسه وارد شده معتبر نمی‌باشد";
                }
            }
        }
        public string Update(int id, personel hnew)
        {
            using (var d5 = new db())
            {
                var h = d5.personels.SingleOrDefault(i => i.id == id);
                if (h != null)
                {
                    h.name = hnew.name;
                    h.price = hnew.price;
                    h.tedad = hnew.tedad;
                    h.dastebandi = hnew.dastebandi;
                    d5.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "شناسه وارد شده معتبر نمی‌باشد";
                }
            }
        }    
    }
    
}
