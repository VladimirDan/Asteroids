using Code.Infrastructure.AssetManaging;
using Game.Code.Game.StaticData.Player;
using Cysharp.Threading.Tasks;
using static Game.Code.Game.StaticData.Indents.AddressableLabels;

namespace Game.Code.Game.StaticData
{
    public class GameStaticDataProvider
    {
        private readonly AssetProvider _assetProvider;
        
        public PlayerConfig PlayerConfig { get; private set; }
        public ProjectileConfig ProjectileConfig { get; private set; }


        public GameStaticDataProvider(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public async UniTask PrewarmData()
        {
            var tasks = new UniTask[]
            {
                LoadPlayerConfig(),
                LoadProjectileConfig(),
            };

            await UniTask.WhenAll(tasks);
        }
        
        private async UniTask LoadProjectileConfig() =>
            ProjectileConfig = await _assetProvider.Load<ProjectileConfig>(ProjectileConfigLabel);
        
        private async UniTask LoadPlayerConfig() =>
            PlayerConfig = await _assetProvider.Load<PlayerConfig>(PlayerConfigLabel);
    }
}