TubeRehber Proje Adýmlarý

--Core--
1-)Core(Tüm ortak Entity ve property tanýmlanacaðý sýnýf) C# Library açýlýr.
2-)Entity Framework(Veritabanýna bizim nesnelerimizi baðlayan ve bizim için veri alýþveriþini yapan Microsoft tarafýndan 
geliþtirilmiþ bir framework’tür.) yüklenir.
3-)Entity Klasörü açýlýr ve içine status için enum oluþturulup,CoreEntity içine ortak propertyler tanýmlanýr.
4-)Map açýlýr.Temel entity propertylerinin maplemeleri yapýlýr(maximum karakter alaný vb...).
5-)Service açýlýr.Ýçerisine ICoreService interface açýlýr.Her entity üzerinde çalýþacak olan metotlar tanýmlanýr.Ayrýca RemoteIP
C# Library açýlýp ip yakalama kýsmý halledilir.

--Model--
1-)Model C# Library açýlýr=>Core referanslara eklenir.
2-)Entities klasörü açýlýr.
3-)Category,Channel,Comment,Member entityleri oluþturulur.Hepsi CoreEntity sýnýfýndan miras almalýdýr.Bu sayede ortak propertylere 
eriþim saðlanacaktýr.Ezilecek(virtual) property burada belirtilmelidir ki daha sonra id yerine temsil ettiði propertye eriþim 
rahatça saðlansýn.

--Map--
1-)Map C# Library açýlýr.Entity Framework yüklenir,Referanslara Core ve Model eklenir.
2-)EntityMaps klasörü açýlýr.
3-)Her entity için mapleme iþlemleri gerçekleþtirilir.(Ekstra iliþki durumlarý belirtilir.)

--Dal--
1-)Dal katmaný oluþturulur. Context klasörü açýlýr içerisine TubeRehberContext sýnýfý oluþturulur.
2-)Constructor ile db connection yazýlýr.(SetInitializer stratejisi kullandýk.Bu strateji sayesinde modeldeki bir deðiþimde 
veritabaný Drop edilir ve baþtan oluþturulur.)
3-)Map sýnýflarýmýzý da context'e dahil edebilmek için modellerin (entitylerin) tabloya dönüþtürülmesi anýnda çalýþacak olan 
onModelCreating metodunu yani modelleri tabloya dönüþtüren metodu override ederek çaðýrýyoruz. DB Kurallarýmýzý da dahil etmesini
saðlýyoruz.
4-)Daha sonra DbSetlerimizi oluþturuyoruz ki tablolar oluþssun.
5-)Otomatik loglama amaçlý kullanýlan bazý özelliklerin doldurulmasý için, savechannges metodunu override ediyoruz.Bunu
ChangeTracker nesnesi(savechanges metodu çaðýrýldýðýnda bizim yaptýðýmýz tüm kayýtlardaki deðiþimleri takip eden nesnedir) sayesinde
yapýyoruz.
6-)Veri tabaný oluþturulduðunda gerçekleþecek olaylarý(Admin ve Category ekleme gibi.) yazmamýz için Migrations klasörü içine Configurations
C# library açýlýr.
7-)console üzerinden DAL projesi seçilerek enable-migrations -enableAutomaticMigrations yazýlýr. Arkasýndan problem yaþanmadýysa 
update-database yazýlarak veri tabaný oluþturulur.

--Service--
1-)Service katmaný yazýlýr. BaseService içerisinde genel olarak kullanýlacak olan metotlar generic(genel) þekilde yazýlýr.
ICoreService interfaceten miras alýnarak devam edilir.
2-)Concrete klasörü açýlýr.Ýçerisine tüm entitylerimizin service sýnýflarý açýlýr ve serviceBase'den miras alýnýr.Ýçerisine tüm 
entitylerimizin service sýnýflarý açýlýr ve serviceBase'den miras alýnýr.Entity'e özel bir metot var ise bu metotlar sýnýflarýn
içerisine eklenir.
3-)TransferObjects klasörü açýlýr.Ýçerisine login iþlemleri için LoginVM C# library oluþturulup daha sonra kullanýlmak üzere 
gerekli property tanýmlanýr.

--UI--
1-)UI katmaný içerisine Admin Area açýlýr. UI katmanýna EntitiyFramework yüklenmelidir.
2-)Core Model ve Service referanslara eklenmelidir.
3-)View içine Shared klasörü oluþturup Layoutlarý(admin,member ve ziyaretçi þeklinde) oluþtur ve bunlarý _ViewStart adý altýnda aracý bi Layout ile yönlerdir ki 
ielrideki deðiþimlerde kolaylýk olsun.
4-)Ana controllers herhangibi login olayý olmadan gözükecek controlleri ve viewlerini oluþtur(kayýt ekraný,giriþ ekraný,
ziyaretçiyken ulaþýlabilecek ekranlar gibi).
5-)Content kalsörü oluþtur ve içine template at.
6-)Area içerisindeki admin ve member klasörlerini oluþturup AreaRegistration C# library gerekli ayarlarýný yapýp login kontrolunu
saðla.
7-)Admin ve Member controllers ve viewlerini oluþturup tamamla.
8-)En son Authentication iþlemleri iþlemlerini yap.Attribute klasörü açarak rol bazlý auth iþlemleri gerçekleþtirebiliriz.
9-)Daha sonra istersek son olarak Web.confing kýsmýnda auth iþlemlerini ve hata yönlerdirmeleri yapabiliriz. 
Not:
*Bütün kategorileri tek bir kontrolden ulaþýlabilir yapýlabilirdim.
*Admin kullanýcý adý=SametSeletli Þifre=1990