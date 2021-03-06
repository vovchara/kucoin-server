# kucoin-server
https://docs.kucoin.com/#level-2-market-data

# task
Реализовать поддерживание актуальных данных стакана любой пары на спотовой бирже KuCoin – выводить лучшые цены аск и бид в лог, 
реализовать простой сервер с помощью библтотеки http для получения значений по урлу (возвращать название пары и цены). 
Алгоритм описан в АПИ https://docs.kucoin.com/#level-2-market-data. Рекомендуемые библиотеки: ws для сокет-соединения, 
для ReST запросов – любая удобная библиотека, для http сервера – только дефолтная http.
Должна быть возможность на холодную(перезапуск кода) быстро сменить пару, которую нужно отслеживать. 
Реализовать отслеживание активности соединения и реконекта, учесть механизм sequence (в АПИ есть описания принципа его работы).

Понятия
СТАКАН (orderbook) – набор отложенных ордеров на покупку и продажу – цена и сумарный обьем с этой ценой.  
АСК и БИД (ask & bid) – лучшие цены на продажу и покупку соответственно (мин аск, макс бид) Их нужно выводить в лог и отдавать по запросу

# logic
Сервак:
0. Отримуємо запит по ХТТП від клієнта з параметром пари. (наприклад BTC/USDT)
1. Підключаємось до сокета.
2. Отримуємо меседж. (Ціна, кількість, сіквенс ІД)
3. Зберігаємо цей меседж в кеш.
4. Робимо РЕСТ запот за Ордер Буком. (в ньому є сіквенс ІД)
5. Дістаємо кешований меседж і приміняємо його дані до Ордер Бука (сортуємо по сіквенс  ІД):
   - ігноруємо все з меседжа що менше ніж сіквенс ІД Ордер Бука.
   - ігноруємо все з меседжа з ціною 0.
   
   - якщо в меседжі кількість=0, видаляємо з Ордер Бука позицію з ціною в якій кількість=0.
   - якщо ціна в меседжі=ціні в ОрдерБуку, беремо кількість з меседжа і оновлюємо її в Ордер Бук.
6. Виводимо в лог мін аск і макс бід показники.
7. Віддаємо його в респонсі клієнту.
   
Клієнт:
1. Робимо ХТТП запит за параметром пари (наприклад BTC/USDT)
2. Отримуємо відповідь з мін аск і макс бід цінами.


Загальні думки:
- Так як зміна пари відбувається перезапуском сервака (на холодну). Можемо конектитись до сокета лише при першому запиті, всі інші, просто беремо актуальні дані.
- Реалізовуємо механізм реконекта до сокета.
- Якщо підключення вже встановлено, і заходить клієнт ще раз, тоді робимо на серваку кроки починаючи з 4.