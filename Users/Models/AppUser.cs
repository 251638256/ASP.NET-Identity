using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Users.Models {
    public class AppUser : IdentityUser {
        // 
        public string Address { get; set; }
        public string Photo { get; set; }
        public Cities City { get; set; }
        public Countries Country { get; set; }

        public void SetCountryFromCity(Cities city) {
            switch (city) {
                case Cities.LONDON:
                    Country = Countries.UK;
                    break;
                case Cities.PARIS:
                    Country = Countries.FRANCE;
                    break;
                case Cities.CHICAGO:
                    Country = Countries.USA;
                    break;
                default:
                    Country = Countries.NONE;
                    break;
            }
        }

    }

    public enum Cities {
        LONDON, PARIS, CHICAGO
    }

    public enum Countries {
        NONE, UK, FRANCE, USA
    }
}