# article_webapi

- Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız? 

  . Factory Method Design Pattern kullanılarak metotlardan sonuç döndüren SuccessResult ve ErrorResult sınıflarının 
    IResult interface'ine atanarak tek bir IResult tipinde geri dönrülebilmesi sağlanmıştır.SuccessResult ve ErrorResult
    sınıflarının ikisi de Result sınıfından türetilerek çok biçimlilik prensibine de uygunluk sağlanmıştır.
    
  . Repository Design Pattern ile veritabanı işlerini gerçekleştirecek bir arayüz oluşturulmuştur. Bu sayede
    veri tabanı işlemleri belirlenen Repository katmanında yine belirlenen standartlarla gerçekleştirilmektedir.
    Veritabanı sorgularında kullanılacak temel metotlar IRepository interface'inde tanımlanmıştır.

  - Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?  
  
    . Entity Framework Core ORM kütüphanesi ile DB First veya Code First olarak çalışmış olduğum projelerde geliştirmelerde bulundum.
    
    . Authentication yapısı için kullanmış olduğum JwtBearer kütüphanesini daha önceki çalışmalarımda aktif olarak kullandım.
      Authentication tipi olarak Bearer Token oluşuturulmaktadır. Bearer Token dışında OAuth 2.0 diğer projelerde kullandım.
     
  - Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz? 
  
     Mapper yapısı, 
     Özel bir Validation yapısı,
     Permission Filter yapısı ile özelleştirilmiş yetkilendirme,
     Güçlendirilmiş bir arama için Elastich Search yapısı
      projeye eklenebilirler.
