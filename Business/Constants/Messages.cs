using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka başarılı bir şekilde eklendi.";

        public static string BrandListed = "Markalar başarılı bir şekilde listelendi.";

        public static string BrandNameInvalid = "Marka adı geçersiz!!!";

        public static string CarAdded = "Araba başarılı bir şekilde eklendi.";

        public static string CarListed = "Arabalar başarılı bir şekilde listelendi.";

        public static string CarDescriptionInvalid = "Araba açıklaması geçersiz!!!";

        public static string ColorAdded = "Renk başarılı bir şekilde eklendi.";

        public static string ColorListed = "Renkler başarılı bir şekilde listelendi.";

        public static string ColorNameInvalid = "Renk adı geçersiz!!!";

        public static string MaintenanceTime = "Sistem bakımda";

        public static string UserNameInvalid = "Kullanıcı adı geçersiz!!!";
        
        public static string UserAdded = "Kullanıcı başarılı bir şekilde eklendi.";
        
        public static string UserListed = "Kullanıcı başarılı bir şekilde listelendi.";
        
        public static string CustomerAdded = "Müşteri başarılı bir şekilde eklendi.";
        
        public static string CompanyNameInvalid = "Şirket adı geçersiz!!!";
        
        public static string CustomerListed = "Müşteri başarılı bir şekilde listelendi.";
        
        public static string RentalListed = "Rezervasyon listesi listelendi";
        
        public static string RentalAdded = "Rezervasyon eklendi";

        public static string NotNullReturnDate = "Araba zaten kiralanmış!!!";

        public static string CarCountOfBrandError = "Bir markada en fazla 10 araç olabilir.";

        public static string CarNameAlreadyExists = "Bu isimde zaten başka bir araç var!!!";

        public static string BrandLimitExceded = "Marka limiti aşıldığı için yeni araç eklenemiyor!!!";

        public static string CarImageAdded = "Araç resmi başarılı bir şekilde eklenmiştir.";

        public static string CarImageListed = "Ürün görselleri başarılı bir şekilde listelendi";

        public static string CarImageUpdated = "Ürün görseli başarılı bir şekilde güncellendi";

        public static string CarImageCountOfCarError = "Bir aracın maksimum 5 adet görseli olabilir!!";

        public static string CarImageDeleted = "Ürün görseli başarılı bir şekilde silinmiştir.";

        public static string NotUploaded = "Resim ekleme işlemi başarısız!!";

        public static string AuthorizationDenied = "Yetkiniz YOK!!!";

        public static string UserRegistered = "Kayıt başarılı bir şekilde gerçekleşti.";

        public static string SuccessfulLogin = "Giriş başarılı";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre Hatası";

        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string AccessTokenCreated = "Access Token oluşturuldu";
    }
}
