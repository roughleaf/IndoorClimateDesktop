using IndoorClimateDesktop.Domain.Models;
using IndoorClimateDesktop.Services.ApiIndoorClimateLocalData.Models;
using IndoorClimateDesktop.Services.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services.ApiIndoorClimateLocalData
{
    public class ApiIndoorClimateLocalDataService : IObservable<ClimateData>
    {
        List<IObserver<ClimateData>> observers;

        public ApiIndoorClimateLocalDataService()
        {
            observers = new List<IObserver<ClimateData>>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<ClimateData>> _observers;
            private IObserver<ClimateData> _observer;

            public Unsubscriber(List<IObserver<ClimateData>> observers, IObserver<ClimateData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<ClimateData> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public async void GetLocalClimateData()
        {
            while (true)
            {
                string JsonString = await IndoorClimateTcpServer.Listen(13000);     // Hopefully this blocking call will sit here and wait untill data is received. This happens every 10 minutes.

                ClimateData apiClimateData = JsonSerializer.Deserialize<ClimateData>(JsonString);

                foreach (var observer in observers)
                    observer.OnNext(apiClimateData);    // This is where the magic happens, the ClimateData Object gets sent and notified
            }
        }
    }
}
