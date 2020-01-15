TubeRehber Proje Ad�mlar�

--Core--
1-)Core(T�m ortak Entity ve property tan�mlanaca�� s�n�f) C# Library a��l�r.
2-)Entity Framework(Veritaban�na bizim nesnelerimizi ba�layan ve bizim i�in veri al��veri�ini yapan Microsoft taraf�ndan 
geli�tirilmi� bir framework�t�r.) y�klenir.
3-)Entity Klas�r� a��l�r ve i�ine status i�in enum olu�turulup,CoreEntity i�ine ortak propertyler tan�mlan�r.
4-)Map a��l�r.Temel entity propertylerinin maplemeleri yap�l�r(maximum karakter alan� vb...).
5-)Service a��l�r.��erisine ICoreService interface a��l�r.Her entity �zerinde �al��acak olan metotlar tan�mlan�r.Ayr�ca RemoteIP
C# Library a��l�p ip yakalama k�sm� halledilir.

--Model--
1-)Model C# Library a��l�r=>Core referanslara eklenir.
2-)Entities klas�r� a��l�r.
3-)Category,Channel,Comment,Member entityleri olu�turulur.Hepsi CoreEntity s�n�f�ndan miras almal�d�r.Bu sayede ortak propertylere 
eri�im sa�lanacakt�r.Ezilecek(virtual) property burada belirtilmelidir ki daha sonra id yerine temsil etti�i propertye eri�im 
rahat�a sa�lans�n.

--Map--
1-)Map C# Library a��l�r.Entity Framework y�klenir,Referanslara Core ve Model eklenir.
2-)EntityMaps klas�r� a��l�r.
3-)Her entity i�in mapleme i�lemleri ger�ekle�tirilir.(Ekstra ili�ki durumlar� belirtilir.)

--Dal--
1-)Dal katman� olu�turulur. Context klas�r� a��l�r i�erisine TubeRehberContext s�n�f� olu�turulur.
2-)Constructor ile db connection yaz�l�r.(SetInitializer stratejisi kulland�k.Bu strateji sayesinde modeldeki bir de�i�imde 
veritaban� Drop edilir ve ba�tan olu�turulur.)
3-)Map s�n�flar�m�z� da context'e dahil edebilmek i�in modellerin (entitylerin) tabloya d�n��t�r�lmesi an�nda �al��acak olan 
onModelCreating metodunu yani modelleri tabloya d�n��t�ren metodu override ederek �a��r�yoruz. DB Kurallar�m�z� da dahil etmesini
sa�l�yoruz.
4-)Daha sonra DbSetlerimizi olu�turuyoruz ki tablolar olu�ssun.
5-)Otomatik loglama ama�l� kullan�lan baz� �zelliklerin doldurulmas� i�in, savechannges metodunu override ediyoruz.Bunu
ChangeTracker nesnesi(savechanges metodu �a��r�ld���nda bizim yapt���m�z t�m kay�tlardaki de�i�imleri takip eden nesnedir) sayesinde
yap�yoruz.
6-)Veri taban� olu�turuldu�unda ger�ekle�ecek olaylar�(Admin ve Category ekleme gibi.) yazmam�z i�in Migrations klas�r� i�ine Configurations
C# library a��l�r.
7-)console �zerinden DAL projesi se�ilerek enable-migrations -enableAutomaticMigrations yaz�l�r. Arkas�ndan problem ya�anmad�ysa 
update-database yaz�larak veri taban� olu�turulur.

--Service--
1-)Service katman� yaz�l�r. BaseService i�erisinde genel olarak kullan�lacak olan metotlar generic(genel) �ekilde yaz�l�r.
ICoreService interfaceten miras al�narak devam edilir.
2-)Concrete klas�r� a��l�r.��erisine t�m entitylerimizin service s�n�flar� a��l�r ve serviceBase'den miras al�n�r.��erisine t�m 
entitylerimizin service s�n�flar� a��l�r ve serviceBase'den miras al�n�r.Entity'e �zel bir metot var ise bu metotlar s�n�flar�n
i�erisine eklenir.
3-)TransferObjects klas�r� a��l�r.��erisine login i�lemleri i�in LoginVM C# library olu�turulup daha sonra kullan�lmak �zere 
gerekli property tan�mlan�r.

--UI--
1-)UI katman� i�erisine Admin Area a��l�r. UI katman�na EntitiyFramework y�klenmelidir.
2-)Core Model ve Service referanslara eklenmelidir.
3-)View i�ine Shared klas�r� olu�turup Layoutlar�(admin,member ve ziyaret�i �eklinde) olu�tur ve bunlar� _ViewStart ad� alt�nda arac� bi Layout ile y�nlerdir ki 
ielrideki de�i�imlerde kolayl�k olsun.
4-)Ana controllers herhangibi login olay� olmadan g�z�kecek controlleri ve viewlerini olu�tur(kay�t ekran�,giri� ekran�,
ziyaret�iyken ula��labilecek ekranlar gibi).
5-)Content kals�r� olu�tur ve i�ine template at.
6-)Area i�erisindeki admin ve member klas�rlerini olu�turup AreaRegistration C# library gerekli ayarlar�n� yap�p login kontrolunu
sa�la.
7-)Admin ve Member controllers ve viewlerini olu�turup tamamla.
8-)En son Authentication i�lemleri i�lemlerini yap.Attribute klas�r� a�arak rol bazl� auth i�lemleri ger�ekle�tirebiliriz.
9-)Daha sonra istersek son olarak Web.confing k�sm�nda auth i�lemlerini ve hata y�nlerdirmeleri yapabiliriz. 
Not:
*B�t�n kategorileri tek bir kontrolden ula��labilir yap�labilirdim.
*Admin kullan�c� ad�=SametSeletli �ifre=1990