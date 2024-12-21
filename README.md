N-Tier Kullanıcı ve Görev Yönetim Sistemi
Bir kullanıcı yönetim sistemi oluşturmanız isteniyor. Bu sistemin N-Tier mimari
prensiplerine uygun şekilde geliştirilmesi beklenmektedir. Aşağıdaki gereksinimlere göre bir
.NET Core Web API geliştirin:
Gereksinimler:
1. Mimari Yapı
2. Entity&#39;ler (Domain Layer):
- User:
- Task:
3. Endpoints (Presentation Layer):
- POST /users:
- GET /users:
- POST /tasks:
- GET /tasks:
- GET /tasks/user/{userId}:
- PUT /tasks/{taskId}/complete: (IsCompleted = true).
4. Validasyon ve İş Kuralları :
  -POST /users:
   ... Aynı email ile birden fazla kullanıcı oluşturulamaz.
  -POST /tasks:
  ... AssignedToUserId, geçerli bir kullanıcıya işaret etmelidir.
 - PUT /tasks/{taskId}/complete:
  ...Görevi tamamlandı olarak işaretlemeden önce, görev sistemde mevcut
olmalıdır.

5. Veritabanı :
- In-Memory Veritabanı kullanarak çalıştırın (örneğin, Entity Framework Core
ile).

Değerlendirme Kriterleri:
1. N-Tier mimari prensiplerine uyum: Katmanlı yapı doğru bir şekilde izlenmeli.
2. Validasyon ve iş kurallarının uygulanması: FluentValidation gibi bir yapı ile
validasyon ve iş kuralları mantığının düzgün uygulanması.
3. Clean Code prensipleri: Kodunuz temiz ve okunabilir olmalı.
4. Test Edilebilirlik: Repository veya servislerin birim testleri için yapılandırılabilir
olması.
