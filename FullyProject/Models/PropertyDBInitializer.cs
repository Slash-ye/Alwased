using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FullyProject.Models
{
    public class PropertyDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            /*
            IList<Standard> defaultStandards = new List<Standard>();

            defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            context.Standards.AddRange(defaultStandards);
            */
            List<CurrencyType> ct = new List<CurrencyType>();
            ct.Add(new CurrencyType() {currencyName= "ريال يمني" });
            ct.Add(new CurrencyType() { currencyName = "ريال سعودي " });
            ct.Add(new CurrencyType() { currencyName = "دولار" });

            db.CurrencyType.AddRange(ct);

            //
            List<DistanceUnit> du = new List<DistanceUnit>();
            du.Add(new DistanceUnit() { unitName = "متر مربع" });

            db.DistanceUnit.AddRange(du);

            //
            List<PropertyState> ps = new List<PropertyState>();
            ps.Add(new PropertyState() { StateName = "للبيع" });
            ps.Add(new PropertyState() { StateName = "للايجار" });

            db.PropertyState.AddRange(ps);


            //
            List<PropertyType> pt = new List<PropertyType>();
            pt.Add(new PropertyType() { TypeName = "عماره" });
            pt.Add(new PropertyType() { TypeName = "بيت" });
            pt.Add(new PropertyType() { TypeName = "شقة" });
            pt.Add(new PropertyType() { TypeName = "أرضيه" });


            db.PropertyType.AddRange(pt);


            //
            /*
            ApplicationUser u;
            u=new ApplicationUser() { UserName="mohammedaln@hotmail.com",Email= "mohammedaln@hotmail.com" ,FullName="محمد النزيلي",JobName="مهندس",PasswordHash= "AJaLrePM+zaftNGjiJrz1vLT6C8swrNBWwF3FaDFt2Iye66EucGmuZucL2nuEDmwpA==",PhoneNumber= "772882468", };

            db.Users.Add(u);

            //
            Roles r1;
            Roles r2;

            r1=new Roles() { Name="AdminUser" };
            r2=new Roles() { Name = "User" };

            db.Roles.Add(r1);
            db.Roles.Add(r2);

    */
            base.Seed(db);
        }
    }
}