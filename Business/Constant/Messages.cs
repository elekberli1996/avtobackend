using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {
        public static string Added = "Basariyla Eklendi";
        public static string Deleted = "Basariyla Silindi";
        public static string Updated = "Basariyla Guncellendi";
        public static string CategoryExisist = "bu kategoiden var";
        public static string ModelExsist = "bu modelden var";
        public static string AccessTokenCreated = "token basariyla olusturuludu";
        public static string NotExsist = "Boyle bir kuillanici bulunamadi";
        public static string Passwordwrong = "sifre yanlisdir";
        public static string SuccesgullyLogin = "basaili login";
        public static string UserRegistred = "kullanici basariyla kaydedildi";
        public static string UserExsist = "kullanici muovcud";
        public static string AutoruzationDenied = "izinsiz giris";
    }

}
