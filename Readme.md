# CsvOperationsHelper

[CsvHeleper](https://joshclose.github.io/CsvHelper/) kullanarak, Generic olarak CSV dosyası oluşturan ve oluşturulan .csv dosyasının içeriğini okuyabilen yardımcı araç 

[![CircleCI](https://circleci.com/gh/circleci/circleci-docs.svg?style=svg)](https://app.circleci.com/pipelines/github/Nrk58/CsvOperationsHelper/5/workflows/32906b6f-396a-4e68-9a05-6c7cdd0e34cd/jobs/5/steps)

## Install
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


