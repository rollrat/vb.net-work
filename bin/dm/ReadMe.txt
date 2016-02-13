VB.NET

RollRat Data Manager[

	문법 : 

	<

		[Private_Setter <Datas>]
		r;Set=DataValue(1)
		r;Set=Mash{'Number', 'Impormation'}
		r;Ret=

		[Public_Setter <Datas>]
		f;Data=K{'추가1', '그런거', '없음'}
		f;Ret=

	>

이런식으로 데이터 베이스가 저장이 됩니다.
AES-128과 Random Bytes Change 방법을 이용하여 3번을 암호화 합니다.(AES-128의 암호화 Pass는 공개하지않음)(RollRatSubroutins.dll 에서 수행합니다.)
일반적으로 사용자에겐 노출되지않습니다.


[버튼내용]
      새로만들기 : ListView를 초기화 하고 기본값을 넣습니다. 기본값은 위에 나온 문법에서 Data영역만 없앤것과 같습니다.
                저장 : ListView와 관련된 내용과 더 명확한 Private_Setter로 하여금 데이터 베이스에 암호화된 형태로 저장됩니다.(RollRatSubroutins.dll 에서 수행합니다.)
          불러오기 : 불러온 파일을 복호화한후 코드를 분석합니다.(RollRatSubroutins.dll 에서 수행합니다.)
             탭추가 : RollRat의 특수 알고리즘을 이용하여 탭을 추가합니다. 자세한 내용은 밑에 나올 내용을 참고하십시오.(RollRatSubroutins.dll 에서 수행합니다.)
             탭제거 : RollRat의 특수 알고리즘을 이용하여 탭을 제거합니다. 자세한 내용은 밑에 나올 내용을 참고하십시오.(RollRatSubroutins.dll 에서 수행합니다.)
                추가 : ListView에 아이템을 추가합니다.
선택한항목제거 : 선택한항목, 첫번째 인수와 같은 항목을 모두 지웁니다.(RollRatSubroutins.dll 에서 수행합니다.)
             암호화 : 저장할 암호화 코드를 직접 지정할 수 있습니다. 암호를 잊어버리면 복구할 방법은 없습니다.(RollRatSubroutins.dll 에서 수행합니다.)

[알고리즘](모든 내용은 RollRatSubroutins.dll 에서 수행합니다.)
탭추가 알고리즘 순서 :
	1. ListView의 내용을 미리 저장해놓은 다음(실시간으로 저장되지는 않고 탭을 추가하거나 제거할때, 저장하거나 불러올때 자동적으로 추가됩니다.) ListView를 초기화 합니다.
	2. Column()을 만든후 미리 저장된 탭의 내용을 넣습니다. 이때 문법을 사용합니다.
	3. Column()의 배열의 내용을 가상ListView에 추가합니다.
	4. 미리 저장된 ListView의 내용을 가상ListView에 추가합니다.
	5. ListView를 가상ListView로 바꿔줍니다.(ListView = 가상ListView) 

탭제거 알고리즘 순서 :
	1. ListView의 내용을 미리 저장해놓은 다음(실시간으로 저장되지는 않고 탭을 추가하거나 제거할때, 저장하거나 불러올때 자동적으로 추가됩니다.) ListView를 초기화 합니다.
	2. Column()을 만든후 미리 저장된 탭의 내용을 넣습니다. 이때 문법을 사용합니다.
	3. 문법내용중 RollRat의 알고리즘을 사용하여 Mash의 아이템을 하나지워줍니다.(위 문법을 참고하십시오. , 알고리즘은 공개하지않습니다.)
	4. 미리 저장된 ListView의 내용을 가상ListView에 추가합니다.
	5. ListView를 가상ListView로 바꿔줍니다.
	6. C:\windows\buffer.t 에 내용을 저장한뒤 불러옵니다.
	7. ListView를 가상ListView로 바꿔줍니다.(ListView = 가상ListView) 
]