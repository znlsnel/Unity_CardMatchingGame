![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&size=30&pause=1000&width=435&lines=Card+Matching+Game)

---
# Description
- **프로젝트 소개** <br>
 내일 배움 캠프에서 진행한 팀 프로젝트이며, 3인으로 개발한 카드 뒤집기 게임입니다. <br>
 팀원 소개 카드를 모으는 방식으로 게임이 진행됩니다.

- **개발 기간** : 2025.01.20 ~ 2025.01.23
- **사용 기술** <br>
-언어 : C#<br>
-엔진 : Unity Engine <br>
-개발 환경 : Windows 11, GitHub
<br>

---
## 목차
- 기획 의도
- 발생 및 해결한 주요 문제점
- 핵심 기능
<br>

---
## 기획 의도
- 유니티 & Git을 사용한 협업 경험
- 필수 과제와 도전 과제를 완수하여 게임 개발 실력 향상
<br>

---

## 발생 및 해결한 주요 문제점
### 스테이지 해금 시스템 간에 자물쇠 애니메이션 중복 실행 문제
- 이전 스테이지를 클리어하면 자물쇠가 풀리는 애니메이션이 실행되고 스테이지가 해금됩니다. <br>
  발생한 문제는 해당 애니메이션이 스테이지 선택창으로 갈 때 마다 실행된다는 것 이었습니다. <br>
  해당 문제를 해결하기 위해 bool 배열을 추가로 사용했습니다. <br>
  스테이지 클리어 여부만 파악 하는 것이 아니라 자물쇠를 푼 적이 있는지 또한 bool 배열로 저장하여 문제를 해결했습니다.
<br><br>

---
## 핵심 기능
### 시작 화면
<div style="display: flex; justify-content: space-around;">
  <img src="https://github.com/user-attachments/assets/da25ae04-b11f-47ac-9243-2ad21ae1c402" alt="Image" width="600">
</div>
- 게임 시작 화면 게임 방법을 볼 수 있는 기능
 <br> <br>

### 스테이지 해금 시스템 & 히든 스테이지
<div style="display: flex; justify-content: space-around;">
  <img src="https://github.com/user-attachments/assets/80dc40ed-1a2c-45d7-9cb9-f7b5f56da93c" alt="Image" width="600">
</div>
- 이전 스테이지를 클리어하면 자물쇠가 풀리며 스테이지 해금 <br>
- 모든 스테이지 클리어시 히든 스테이지 오픈
 <br> <br>

### 게임 난이도
<div style="display: flex; justify-content: space-around;">
  <img src="https://github.com/user-attachments/assets/39b7c699-1d26-4e10-a0fc-3ea3252301ff" alt="Image" width="600">
</div>
- 게임 난이도 구현 <br>
- 난이도별 카드 개수, 배경 이미지를 다르게 설계
 <br> <br>
 
### 카드 배치 효과
<div style="display: flex; justify-content: space-around;">
  <img src="https://github.com/user-attachments/assets/2f110ebe-6cc5-42ad-afd1-4dd7fd48c95f" alt="Image" width="600">
</div>
- 카드 배치 모션 추가<br>
- 화면 하단에 카드 생성 후, 지정된 위치로 이동되도록 설계
 <br> <br>

### 팀원 프로필 UI
<div style="display: flex; justify-content: space-around;">
  <img src="https://github.com/user-attachments/assets/85582e2a-6a66-44a9-baec-2c99e19c7a3e" alt="Image" width="600">
</div>
- 프로필 UI입니다. <br>
- 타이핑 되는 효과를 추가했습니다.
