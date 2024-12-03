using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.LoadedData
{
    public class DataManager
    {
        private static DataManager instance;
        private static readonly object lockObject = new object(); // 동기화 전용 객체

        // 데이터 저장소
        public TableCollection Tables { get; private set; } = new TableCollection();
        public List<User> Users { get; private set; } = new List<User>();
        public TableRepository tableRepository;
        private static bool isRunning = true; // 스레드 실행 상태

        public static DataManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DataManager();
                    }
                }
                return instance;
            }
        }

        private DataManager()
        {
            InitializeData();
            StartAutoSave();
        }

        // 초기화 메서드
        private void InitializeData()
        {
            // 리포지토리 초기화
            tableRepository = new TableRepository();

            // 테이블 데이터 로드
            var loadedTables = tableRepository.GetAllTables();
            foreach (var table in loadedTables)
            {
                Tables.Add(table); // TableCollection의 Add 메서드를 통해 추가
            }
        }

        // 자동 저장 스레드 시작
        private void StartAutoSave()
        {
            var autoSaveThread = new Thread(() =>
            {
                while (isRunning)
                {
                    Thread.Sleep(30000); // 30초마다 저장
                    SaveAllData();
                }
            });

            autoSaveThread.IsBackground = true; // 백그라운드 스레드 설정
            autoSaveThread.Start();
        }


        // Graceful Shutdown: 스레드 종료
        public void StopAutoSave()
        {
            isRunning = false;
            SaveAllData(); // 종료 시 최종 저장
        }

        // 모든 데이터를 데이터베이스에 저장
        public void SaveAllData()
        {
            lock (lockObject)
            {
                tableRepository.SaveAllTables(Tables.GetAll());
                // TODO: Users와 다른 데이터도 저장 로직 추가 가능
                Console.WriteLine("모든 데이터가 저장되었습니다.");
            }
        }
    }
}
