로그라이크 슈팅 게임이며 아이작 같은 랜덤 맵 구현 중심의 프로젝트 입니다
<br>
<br>

＠랜덤맵 구현<br>
![image](https://github.com/plumas90/Project-Archer/assets/129154514/eb41dcdb-4f14-4a94-9202-4bc35eb4dba9)
![image](https://github.com/plumas90/Project-Archer/assets/129154514/8844c706-5aa7-49b2-9a2f-c99c4d732c52)

- **[로직]**
1. 2차원 배열을 이용하여 미리 방의 전체적인 구조를 생성. (좌표 활용)
2. 조건에 따라 구조화 된 방을 생성하고 해당 방에 맞는 룸 리스트 중 생성
3. 상 / 하 / 좌 / 우를 고려하여 방이 있는 경우 벽을 문으로 생성

- **[구현]**

1) MapCrawler : 2차원 배열( 좌표 0,0을 기준으로 시작방)을 통해  상 , 하 , 좌, 우를 랜덤으로 이동하며 좌표를 생성 하며 리스트를 완성

2) MapCreator.cs : 방의 데이터를 구성하는 스크립트.

MapCrawler가 생성한 2차원 배열을 기준으로 방을 생성하며 방의 타입(Boss, shop, Normal)에 따라 생성하며 현재 가장 마지막에 생성된 노드를 보스방으로 생성

3) Door: 방의 클리어 여부를 체크하여 플레이어의 다른방 이동 여부를 결정함.

4) 방의 정보를 가지고 있으며 룸 타입, 룸 포지션을 가지고 있음.
<br>
<br>
<br>

＠그 외 <br>
<br>
파티클을 이용한 효과 부여<br>
![image](https://github.com/plumas90/Project-Archer/assets/129154514/3bfa42fd-ff7f-47ea-a376-ce7f8481a27e)<br>
파티클과 렌더링 시스템을 이용하여 화살 궤적 , 접촉시 효과를 제작하였습니다
<br>
<br>
객체지향적인 플레이어 조작<br>
![image](https://github.com/plumas90/Project-Archer/assets/129154514/d8724e01-f656-4dd6-bcd8-ab0791b21a49)<br>
플레이어 입력, 플레이어 움직임, 플레이어 에임 등 상태를 나눠 객체지향적인 플레이어 구조를 설계하였습니다<br><br>


＠아쉬운 점<br><br>
랜덤 맵 위치 선정<br>
![image](https://github.com/plumas90/Project-Archer/assets/129154514/88d9cfa6-b00c-4804-9d53-f75b7c0b7ba8)<br>
방 생성 좌표를 현재 위치 생성 후 상,하,좌,우 랜덤으로 이동을 실행하는 코드를 사용중이나 생각만큼 그렇게 멀리 가지 않고 중앙 시작 방에 밀집 되는 경향이 있습니다. 

아무래도 조건이 상 하 좌 우 랜덤 이동 1가지 뿐이라 이런 경향이 있는듯 한데 
그방이 이미 생성 되있는가?  외 에도 상하좌우 옆에 모두 방이 있는가? 등 조건을 추가 해주면 어느정도 방이 중앙에 몰리는 경향이 해소 될 것으로 보입니다.

<br>
방 종류의 다양성<br>
방의 종류가 4종류밖에 되지 않는데 확실히 좀 더 다양한 종류를 갖추면 좋았을 거라고 생각하지만 다른 에셋을 사용하여 테스트하였을 때 기존과 다른 이질감이 크게 느껴져 타협하였습니다