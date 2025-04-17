# 📝 MyBlogApi - Minimal Blog Uygulaması

Bu proje, **ASP.NET Core Minimal API** kullanarak geliştirilmiş bir blog uygulamasıdır. Kullanıcılar, JWT ile giriş yaparak blog yazılarını görüntüleyebilir, ekleyebilir, güncelleyebilir ve silebilir.

## Özellikler

-  **JWT Token** ile kimlik doğrulama
-  **CRUD** işlemleri (Blog oluştur, listele, güncelle, sil)
-  **Admin girişi**
-  **Modern**, **responsive** ve kullanıcı dostu **frontend** tasarımı
-  **Entity Framework Core** + **SQLite** veritabanı
-  **Minimal API** kullanımı
-  **Swagger** desteği (API testleri için)

##  Kullanılan Teknolojiler

| Teknoloji               | Açıklama                                   |
|-------------------------|--------------------------------------------|
| ASP.NET Core Minimal API | Backend RESTful API (Minimal API)         |
| Entity Framework Core    | ORM ve veri erişimi                        |
| SQLite                   | Hafif veritabanı                           |
| JWT                      | Token tabanlı authentication              |
| HTML/CSS/JS              | Basit frontend                             |
| Swagger                  | API test arayüzü                           |

## 📸 Ekran Görüntüleri

![minimal](https://github.com/user-attachments/assets/c5ef4b0b-5851-4a8f-a245-9ff33fb21715)


## Kurulum ve Çalıştırma

Bu projeyi bilgisayarınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz.

### 1. Repo'yu Klonla

Öncelikle projeyi kendi bilgisayarınıza klonlayın:

```bash
git clone https://github.com/yildizahmethakan0/MyBlogApi.git
cd MyBlogApi

### 2. Bağımlılıkları Yükle

dotnet restore

### 3. Veritabanını Oluştur

dotnet ef migrations add InitialCreate
dotnet ef database update

### 4. Uygulamayı Başlat

dotnet run

***
Kullanıcı Adı: admin
Şifre: Sifre123!
***
