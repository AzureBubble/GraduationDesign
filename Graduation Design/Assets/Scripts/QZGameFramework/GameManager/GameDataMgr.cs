using QZGameFramework.PersistenceDataMgr;

public class GameDataMgr : Singleton<GameDataMgr>
{
    public MusicData musicData;

    public override void Initialize()
    {
        musicData = BinaryDataMgr.Instance.LoadData<MusicData>("MusicData");
        if (musicData == null)
        {
            musicData = new MusicData();
        }
    }

    public void SaveMusicData(MusicData data)
    {
        musicData = data;
        BinaryDataMgr.Instance.SaveData(musicData, "MusicData");
    }
}