# CsvOperationsHelper

[CsvHeleper](https://joshclose.github.io/CsvHelper/) kullanarak, Generic olarak CSV dosyası oluşturan ve oluşturulan .csv dosyasının içeriğini okuyabilen yardımcı araç 

## Kullanım
### Docker

```
> docker run -p 8080:80 nrkt/csvoperationshelper 
```

## Kullandığım Kütüphanenin Detayları 

https://joshclose.github.io/CsvHelper/examples

------------------------------
### Örnek
*Projeyi çalıştırdıktan sonra test etmek için;
```
http://localhost:8080/swagger/index.html
```

veya;

### CSV Oluşturma [POST]
```
http://localhost:8080/Example/CreateCsv
```
### CreateCsv için Json Örneği
```
[
    {
        "id": 1,
        "name": "TetsProduct1",
        "price": 3.14,
        "group": {
            "id": 1,
            "name": "Test"
        },
        "status": 1,
        "addedDate": "2020-06-20T11:37:15.536Z"
    },
    {
        "id": 2,
        "name": "TetsProduct2",
        "price": 10,
        "group": {
            "id": 1,
            "name": "Test"
        },
        "status": 2
    }
]
```
### Oluşturulan .csv dosyasının içeriğini okumak için [GET]
```
http://localhost:8080/Example/ReadCsv
```
Şu şekilde bir yanıt döner;

```
[
    {
        "id": 1,
        "name": "TetsProduct1",
        "price": 3.14,
        "group": {
            "id": 1,
            "name": "Test"
        },
        "status": 1,
        "addedDate": "2020-06-20T11:37:15.536Z"
    },
    {
        "id": 2,
        "name": "TetsProduct2",
        "price": 10,
        "group": {
            "id": 1,
            "name": "Test"
        },
        "status": 2
    }
]
```


