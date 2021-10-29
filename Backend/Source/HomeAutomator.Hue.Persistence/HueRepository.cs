using System.Linq;
using HomeAutomator.FileStorage;
using HomeAutomator.Hue.Domain;
using HomeAutomator.Hue.Persistence.Entities;

namespace HomeAutomator.Hue.Persistence
{
    internal class HueRepository : IHueRepository
    {
        private const string HueAppRegistrationsName = nameof(HueAppRegistrations);
        private const string UsedHueBridgeName = nameof(UsedHueBridge);
        private readonly IFileStorage fileStorage;

        public HueRepository(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public string? RetrieveCurrentBridgeId()
        {
            return this.fileStorage
                .Read<UsedHueBridge>(UsedHueBridgeName)?
                .BridgeId;
        }

        public void SaveOrUpdateCurrentBridgeId(string? bridgeId)
        {
            this.fileStorage
                .Write(new UsedHueBridge(bridgeId), UsedHueBridgeName);
        }

        public HueAppRegistration? RetrieveHueAppKeyByBridgeId(string bridgeId)
        {
            var hueAppKeys = this.fileStorage.Read<HueAppRegistrations>(HueAppRegistrationsName);
            return hueAppKeys?.Items.SingleOrDefault(x => x.BridgeId == bridgeId);
        }

        public void AddOrUpdateHueAppRegistration(HueAppRegistration hueAppRegistration)
        {
            var hueAppKeys = this.fileStorage.Read<HueAppRegistrations>(HueAppRegistrationsName);

            if (hueAppKeys == null)
            {
                hueAppKeys = new HueAppRegistrations();
            }
            else
            {
                hueAppKeys.Items.RemoveAll(x => x.BridgeId == hueAppRegistration.BridgeId);
            }

            hueAppKeys.Items.Add(hueAppRegistration);
            this.fileStorage.Write(hueAppKeys, HueAppRegistrationsName);
        }
    }
}