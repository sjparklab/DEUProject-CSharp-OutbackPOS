# Outback POS (WinForms)

아웃백 레스토랑 콘셉트의 **테이블/주문/결제** 흐름을 학습 목적으로 구현한 WinForms 기반 POS 앱입니다.  
DB는 **SQLite**를 사용하며, 실행 시 스키마/기본 데이터가 자동 생성됩니다.

## ✨ 주요 기능
- **로그인/권한**: 사용자(직원) 계정 로그인
- **테이블 관리**: 테이블 상태(공석/점유) 표시·변경
- **메뉴 관리**: 카테고리/가격/옵션(스테이크 굽기, 사이드 등) 포함 CRUD
- **주문/결제**: 주문 생성 → 미결제 조회 → 영수증/결제 기록 저장
- **영수증/요약**: 주문 상세 확인 및 인쇄용 화면(Receipt)

## 🧱 기술 스택
- **UI**: C# WinForms (.NET Framework)
- **DB**: SQLite (`System.Data.SQLite`)  
- **아키텍처**: Model, Controller, Repository 분리, 싱글톤 DataManager, 커스텀 예외 계층
- **기타**: 사용자 정의 컨트롤(테이블 패널)

## 📁 주요 구조
- /Controller # Auth, Menu, Order, Payment, Table 등
- /CustomException # DatabaseException 파생(연결/조회/쓰기 등), UnexpectedInputException
- /Data # SQLite 접근 계층 (DatabaseHelper, *Repository.cs)
- /LoadedData # 싱글톤 공유 상태(DataManager)
- /Model # 엔터티 (OutbackMenu, Order/OrderItem, Table, User 등)
- /View # WinForms 화면 (PosMain, MenuManage, OrderAndPay, Receipt 등)
- Program.cs # 진입점
- App.config # 설정

## 🗃️ 데이터 계층 요약
- `Data/DatabaseHelper.cs`  
  - `SQLiteConnection` 제공, **테이블 생성 및 시드 데이터 자동 삽입**  
  - 테이블: `Users`, `Menu`, `Tables`, `Orders`, `OrderItems`, `Payments`
- `Data/*Repository.cs`  
  - `MenuRepository`, `OrderRepository`, `PaymentRepository`, `TableRepository`, `UserRepository`

## 🧩 예외/안정성
- `CustomException/DatabaseException`(추상) + **연결/조회/쓰기** 전용 예외로 계층화
- 입력 오류용 `UnexpectedInputException`
- 공용 상태는 `LoadedData/DataManager` **싱글톤**으로 일원화

## ▶️ 실행 방법
1) Visual Studio에서 솔루션 열기  
2) NuGet에서 **System.Data.SQLite** 설치(필요 시)  
3) 실행 → 루트에 `database.db` 생성 및 초기 데이터 자동 삽입

> 별도 DB 서버가 필요하지 않습니다. (파일 기반 SQLite)

## 📸 스크린샷
<img width="522" height="290" alt="image" src="https://github.com/user-attachments/assets/4ba93e62-ca0b-460b-a944-631c4559dc1d" />
<img width="254" height="306" alt="image" src="https://github.com/user-attachments/assets/79e3469b-3cf1-4575-9711-633561dff491" />
<img width="660" height="368" alt="image" src="https://github.com/user-attachments/assets/b738bda0-660b-4655-9b9f-d99eac82ba4e" />
<img width="660" height="368" alt="image" src="https://github.com/user-attachments/assets/fa603f0b-c10d-4800-a2dc-b3c7702702e3" />
<img width="660" height="368" alt="image" src="https://github.com/user-attachments/assets/eb82fa69-78c8-43e8-96e9-316746e7adc9" />
<img width="660" height="368" alt="image" src="https://github.com/user-attachments/assets/b182cf29-2c27-4ea9-84e1-8cd232a14633" />
<img width="660" height="355" alt="image" src="https://github.com/user-attachments/assets/64ce940f-ae4e-4284-a275-6cc3dbd2d8a1" />
