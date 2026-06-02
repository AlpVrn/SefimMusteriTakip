# Müşteri ve Cari Yönetim Otomasyonu

Bu proje, C# Windows Forms ve Microsoft SQL Server kullanılarak geliştirilmiş, işletmelerin müşteri ve tedarikçi süreçlerini merkezi bir yapıda toplayan ticari bir otomasyon yazılımıdır. 

Sistem, kurumsal ERP (Kurumsal Kaynak Planlama) yazılımlarının standartlarına uygun olarak tasarlanmış olup, veri bütünlüğünü ve yüksek performansı ön planda tutmaktadır. Alıcı ve satıcı hesaplarının (carilerin) yönetimi, karmaşık form yapıları yerine dinamik olarak şekillenen tek bir arayüz üzerinden sağlanmaktadır.

## Projenin Temel İşlevleri ve Mimari Yapısı

* **Dinamik Cari Kart Yönetimi:** Müşteri (Satış) ve Tedarikçi (Alış) işlemleri, veritabanında tek bir tablo üzerinden ayrıştırılır. Uygulama arayüzü, seçilen cari tipine göre çalışma anında (runtime) kendini yeniden şekillendirir ve kullanıcının karşısına sadece o işlem tipine ait gerekli veri alanlarını ve tablo sütunlarını getirir.
* **Optimize Edilmiş Veri Listeleme:** Yüksek hacimli veri setlerinde arayüzün kilitlenmesini veya render kaynaklı titremeleri (flickering) önlemek amacıyla, optimize edilmiş DataGridView olayları ve veritabanı seviyesinde filtrelenmiş SQL sorguları kullanılmıştır.
* **Modüler Arama ve Seçim Ekranları:** Depo veya fatura işlemlerinde cari seçimi yapılırken, büyük muhasebe yazılımlarındaki standartlara uygun arama pencereleri (pop-up formlar) tasarlanmıştır. Bu formlar, işlem bitiminde bellekten (RAM) otomatik olarak silinecek şekilde yapılandırılarak sistem kaynaklarının verimli kullanılması sağlanmıştır.
* **Bütünleşik Süreç Takibi:** Sistem; temel cari kayıtlarının yanı sıra sözleşme bitiş tarihlerine dayalı otomatik destek durum kontrollerini, yetkili kişi erişim bilgilerini ve operasyonel modülleri (Depo, Raporlama) tek bir panelden yönetme imkanı sunar.

## Kullanılan Teknolojiler

* **Geliştirme Ortamı & Dil:** C# / .NET Framework (Windows Forms)
* **Veritabanı Yönetimi:** Microsoft SQL Server
* **Veri Erişim Teknolojisi:** ADO.NET
