# unity-idle-game-2024
👾 2024 SJCE 스터디에서 학습한 내용을 기반으로 제작한 간단한 자동 사냥 방치형 게임입니다.

## 📸 시연 화면
![Image](https://github.com/user-attachments/assets/71de237a-24b1-46bb-93aa-c1ce85045797)

---

## 🔧 사용 기술 스택

| 분야           | 기술 |
|----------------|------|
| 게임 엔진       | Unity |
| 스크립트 언어   | C# |
| 백엔드     | Node.js, Redis, PostgreSQL |
| UI 구성 방식    | Legacy UI, Canvas 사용 |
| 프로세스 관리   | PM2 (서버 실행용) |

---

## 🧩 구현 기능

### 1 게임 기본 구조
- 3계층 아키텍처(3-Tier): Presentation, Logic, Data Layer 구성 목표
- GameManager는 Singleton 패턴으로 구현
- Scene 전환 기능 구현 (`SceneManager.LoadScene`)

### 2 캐릭터 & 몬스터 시스템
- 캐릭터 애니메이션: `character_run`, `character_attack`
- 충돌 감지: `BoxCollider` + `Rigidbody`
- 공격 동작 처리:
  - 충돌 시 `character_attack` 애니메이션 실행
  - 애니메이션 종료 시 `OnAttackAnimationEnd()` 호출 → 몬스터 HP 감소
  - 몬스터 HP가 0 이하일 때 사망 처리 및 텍스트 변경 (`"Enemy Down!"`)

### 3 몬스터 리스폰
- 사망 후 일정 시간 또는 즉시 오른쪽 화면 밖 위치에 재생성
- HP 초기화 및 이동 재시작

### 4 GameManager 역할
- 전역 인스턴스로 캐릭터, 몬스터, 배경을 컨트롤
- 배경 스크롤 중지 및 재시작 제어
- 주요 메서드:
  - `CrashCharacterToMonster()`
  - `MonsterDefeated()`
  - `ResumeAfterAttack()`

### 5 배경 스크롤
- `moveBackground.cs`에서 Sprite 이미지를 좌측으로 스크롤
- `Time.deltaTime`을 활용하여 기기 성능 차이 보정
- 충돌 시 자동 정지 및 조건 만족 시 재시작

### 6 UI 및 HP 표시
- Legacy Canvas 기반 UI 구성
- 몬스터 HP를 Text 컴포넌트로 실시간 표시
- 사망 시 `"Enemy Down!"` 텍스트 출력

---

## 📂 프로젝트 구조

```
Assets/
├── Scripts/
│   ├── Character.cs
│   ├── Monster.cs
│   ├── GameManager.cs
│   └── moveBackground.cs
├── Resources/
│   ├── character/
│   └── monster/
├── Scenes/
│   ├── SignInScene.unity
│   └── BattleScene.unity
```
