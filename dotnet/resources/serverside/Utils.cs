using GTANetworkAPI;

namespace UNL.SDK
{
    public class Utils
    {
        public static AccountData GetAccount(Player Player)
        {
            //Player.GetExternalData<AccountData>(0);
            //return new AccountData();
            return Player.GetData<AccountData>("AccData");
        }
        public static CharacterData GetCharacter(Player Player)
        {
            //Player.GetExternalData<CharacterData>(1);
            //return new CharacterData();
            return Player.GetData<CharacterData>("CharData");
        }
    }
}
