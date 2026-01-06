using System.Collections.Generic;

namespace Project.Wallet {
    public class WalletService
    {
        public List<Currency> Currencies { get; }

        public WalletService(List<Currency> currencies)
        {
            Currencies = currencies;
        }
    }
}